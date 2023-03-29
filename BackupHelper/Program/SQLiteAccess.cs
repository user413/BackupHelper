using BackupHelper.model;
using FileControlUtility;
using System.Data.SQLite;

namespace BackupHelper
{
    public static class DBAccess
    {
        private static readonly SQLiteConnection CN = new("data source=" + Program.DBPath);

        static DBAccess() => CN.Open();

        public static void AddProfile(Profile profile)
        {
            string insertProfileCmdText = "insert into profile(profile_listview_index,profile_name," +
                "profile_time_created,profile_last_time_modified,profile_last_time_executed,profile_group) " +
                "values(@listviewIndex,@name,@timeCreated,@lastTimeModified,@lastTimeExecuted,@profile_group)";
            string queryProfileLastInsertedIdCmdText = "select last_insert_rowid()";

            using var insertProfileCmd = new SQLiteCommand(insertProfileCmdText, CN);
            using var queryProfileLastInsertedIdCmd = new SQLiteCommand(queryProfileLastInsertedIdCmdText, CN);

            insertProfileCmd.Parameters.AddWithValue("@listviewIndex", profile.ListViewIndex);
            insertProfileCmd.Parameters.AddWithValue("@name", profile.Name);
            insertProfileCmd.Parameters.AddWithValue("@timeCreated", profile.TimeCreated);
            insertProfileCmd.Parameters.AddWithValue("@lastTimeModified", profile.LastTimeModified);
            insertProfileCmd.Parameters.AddWithValue("@lastTimeExecuted", profile.LastTimeExecuted);
            insertProfileCmd.Parameters.AddWithValue("@profile_group", profile.GroupName);

            insertProfileCmd.ExecuteNonQuery();

            using SQLiteDataReader reader = queryProfileLastInsertedIdCmd.ExecuteReader();

            reader.Read();
            profile.Id = int.Parse(reader["last_insert_rowid()"].ToString());
        }

        public static void UpdateProfile(Profile profile)
        {
            string updateProfileCmdText = "update profile set profile_listview_index=@listviewIndex," +
                "profile_name=@name,profile_last_time_modified=@lastTimeModified," +
                "profile_last_time_executed=@lastTimeExecuted,profile_group=@profile_group where profile_id=@id";

            using (var updateProfileCmd = new SQLiteCommand(updateProfileCmdText, CN))
            {
                updateProfileCmd.Parameters.AddWithValue("@id", profile.Id);
                updateProfileCmd.Parameters.AddWithValue("@listviewIndex", profile.ListViewIndex);
                updateProfileCmd.Parameters.AddWithValue("@name", profile.Name);
                updateProfileCmd.Parameters.AddWithValue("@lastTimeModified", profile.LastTimeModified);
                updateProfileCmd.Parameters.AddWithValue("@lastTimeExecuted", profile.LastTimeExecuted);
                updateProfileCmd.Parameters.AddWithValue("@profile_group", profile.GroupName);

                updateProfileCmd.ExecuteNonQuery();
            }
        }

        public static void UpdateProfileListViewIndex(Profile profile)
        {
            string updateProfileCmdText = "update profile set profile_listview_index=@listviewIndex,profile_group=@profile_group " +
                "where profile_id=@id";

            using (var updateProfileCmd = new SQLiteCommand(updateProfileCmdText, CN))
            {
                updateProfileCmd.Parameters.AddWithValue("@id", profile.Id);
                updateProfileCmd.Parameters.AddWithValue("@listviewIndex", profile.ListViewIndex);
                updateProfileCmd.Parameters.AddWithValue("@profile_group", profile.GroupName);

                updateProfileCmd.ExecuteNonQuery();
            }
        }

        public static List<Profile> ListProfiles()
        {
            List<Profile> profiles = new();
            string queryProfileCmdText = "select profile_id,profile_listview_index,profile_name,profile_time_created," +
                "profile_last_time_modified,profile_last_time_executed,profile_group from profile;";

            using (var queryProfileCmd = new SQLiteCommand(queryProfileCmdText, CN))
            {
                using (SQLiteDataReader reader = queryProfileCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Profile prof = new Profile
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("profile_id")),
                            ListViewIndex = reader.GetInt32(reader.GetOrdinal("profile_listview_index")),
                            Name = reader.GetString(reader.GetOrdinal("profile_name")),
                            TimeCreated = reader.GetDateTime(reader.GetOrdinal("profile_time_created")),
                            LastTimeModified = reader.GetDateTime(reader.GetOrdinal("profile_last_time_modified")),
                            LastTimeExecuted = reader.GetDateTime(reader.GetOrdinal("profile_last_time_executed")),
                            GroupName = reader.GetString(reader.GetOrdinal("profile_group"))
                        };

                        profiles.Add(prof);
                    }
                }
            }

            return profiles;
        }

        public static void DeleteProfile(Profile profile)
        {
            string deleteProfileCmdText = "delete from profile where profile_id=@profileId";
            string deleteOptionCmdText = "delete from option where profile_id=@profileId";
            string queryOptionCmdText = "select opt_id from option where profile_id=@profileId";
            string deleteSpecifiedFileNamesAndExtsCmdText = "delete from specified_file_or_ext where opt_id=@optId";

            using (var queryOptionCmd = new SQLiteCommand(queryOptionCmdText, CN))
            using (var deleteSpecifiedFileNamesAndExtsCmd = new SQLiteCommand(deleteSpecifiedFileNamesAndExtsCmdText, CN))
            using (var deleteOptionCmd = new SQLiteCommand(deleteOptionCmdText, CN))
            using (var deleteProfileCmd = new SQLiteCommand(deleteProfileCmdText, CN))
            {
                queryOptionCmd.Parameters.AddWithValue("@profileId", profile.Id);
                using (SQLiteDataReader reader = queryOptionCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        deleteSpecifiedFileNamesAndExtsCmd.Parameters.AddWithValue("@optId", int.Parse(reader["opt_id"].ToString()));
                        deleteSpecifiedFileNamesAndExtsCmd.ExecuteNonQuery();
                    }
                }

                deleteOptionCmd.Parameters.AddWithValue("@profileId", profile.Id);
                deleteOptionCmd.ExecuteNonQuery();

                deleteProfileCmd.Parameters.AddWithValue("@profileId", profile.Id);
                deleteProfileCmd.ExecuteNonQuery();
            }
        }

        public static void CreateOption(Options option)
        {
            string insertOptionCmdText = "insert into option values(" +
                "null,@profile_id,@opt_listview_index,@opt_source_path,@opt_destiny_path,@opt_include_subfolders,@opt_keep_origin_files,@opt_clean_destiny_dir," +
                "@opt_delete_uncommon_files,@opt_filter_filenames_and_exts,@opt_filter_directories,@opt_spec_filenames_and_exts_mode,@opt_spec_directories_mode," +
                "@opt_filename_conflict_method,@opt_reenumerate_renamed_files,@opt_max_kept_renamed_file_count)";

            string queryOptionLastInsertedIdCmdText = "select last_insert_rowid()";
            string insertSpecifiedFileOrExtCmdText = "insert into specified_file_or_ext(opt_id,spec_name) values (@id,@specName)";
            string insertSpecifiedDirectoriesText = "insert into specified_directory(opt_id,spec_name) values (@id,@specName)";

            using var insertOptionCmd = new SQLiteCommand(insertOptionCmdText, CN);
            using var queryOptionLastInsertedIdCmd = new SQLiteCommand(queryOptionLastInsertedIdCmdText, CN);
            using var insertSpecifiedFileOrExtCmd = new SQLiteCommand(insertSpecifiedFileOrExtCmdText, CN);
            using var insertSpecifiedDirectoriesCmd = new SQLiteCommand(insertSpecifiedDirectoriesText, CN);

            insertOptionCmd.Prepare();
            insertOptionCmd.Parameters.AddWithValue("@profile_id", option.Profile.Id);
            insertOptionCmd.Parameters.AddWithValue("@opt_listview_index", option.ListViewIndex);
            insertOptionCmd.Parameters.AddWithValue("@opt_source_path", option.SourcePath);
            insertOptionCmd.Parameters.AddWithValue("@opt_destiny_path", option.DestinyPath);
            insertOptionCmd.Parameters.AddWithValue("@opt_include_subfolders", option.IncludeSubFolders);
            insertOptionCmd.Parameters.AddWithValue("@opt_keep_origin_files", option.KeepOriginFiles);
            insertOptionCmd.Parameters.AddWithValue("@opt_clean_destiny_dir", option.CleanDestinyDirectory);
            insertOptionCmd.Parameters.AddWithValue("@opt_delete_uncommon_files", option.DeleteUncommonFiles);
            insertOptionCmd.Parameters.AddWithValue("@opt_filter_filenames_and_exts", option.FilterFilesAndExts);
            insertOptionCmd.Parameters.AddWithValue("@opt_filter_directories", option.FilterDirectories);
            insertOptionCmd.Parameters.AddWithValue("@opt_spec_filenames_and_exts_mode", option.FilteredFileNamesOrExtensionsMode);
            insertOptionCmd.Parameters.AddWithValue("@opt_spec_directories_mode", option.FilteredDirectoriesMode);
            insertOptionCmd.Parameters.AddWithValue("@opt_filename_conflict_method", option.FileNameConflictMethod);
            insertOptionCmd.Parameters.AddWithValue("@opt_reenumerate_renamed_files", option.ReenumerateRenamedFiles);
            insertOptionCmd.Parameters.AddWithValue("@opt_max_kept_renamed_file_count", option.MaxKeptRenamedFileCount);
            insertOptionCmd.ExecuteNonQuery();

            using (SQLiteDataReader reader = queryOptionLastInsertedIdCmd.ExecuteReader())
            {
                reader.Read();
                option.Id = int.Parse(reader["last_insert_rowid()"].ToString());
            }

            foreach (string txt in option.FilteredFileNamesAndExtensions)
            {
                insertSpecifiedFileOrExtCmd.Parameters.AddWithValue("@id", option.Id);
                insertSpecifiedFileOrExtCmd.Parameters.AddWithValue("@specName", txt);
                insertSpecifiedFileOrExtCmd.ExecuteNonQuery();
            }

            foreach (string txt in option.FilteredDirectories)
            {
                insertSpecifiedDirectoriesCmd.Parameters.AddWithValue("@id", option.Id);
                insertSpecifiedDirectoriesCmd.Parameters.AddWithValue("@specName", txt);
                insertSpecifiedDirectoriesCmd.ExecuteNonQuery();
            }
        }

        public static void UpdateOption(Options opt)
        {
            string updateOptionCmdText = "update option set " +
                "opt_listview_index=@opt_listview_index,opt_source_path=@opt_source_path,opt_destiny_path=@opt_destiny_path," +
                "opt_include_subfolders=@opt_include_subfolders,opt_keep_origin_files=@opt_keep_origin_files,opt_clean_destiny_dir=@opt_clean_destiny_dir," +
                "opt_delete_uncommon_files=@opt_delete_uncommon_files,opt_filter_filenames_and_exts=@opt_filter_filenames_and_exts," +
                "opt_filter_directories=@opt_filter_directories,opt_spec_filenames_and_exts_mode=@opt_spec_filenames_and_exts_mode," +
                "opt_spec_directories_mode=@opt_spec_directories_mode,opt_filename_conflict_method=@opt_filename_conflict_method," +
                "opt_reenumerate_renamed_files=@opt_reenumerate_renamed_files,opt_max_kept_renamed_file_count= @opt_max_kept_renamed_file_count " +
                "where profile_id=@profile_id and opt_id=@opt_id";
                
            string deleteSpecifiedFilesAndExtsCmdText = "delete from specified_file_or_ext where opt_id = @opt_id";
            string insertSpecifiedFilesAndExtsCmdText = "insert into specified_file_or_ext(opt_id,spec_name) values (@opt_id,@specName)";
            string deleteSpecifiedDirectoriesText = "delete from specified_directory where opt_id = @opt_id";
            string insertSpecifiedDirectoriesText = "insert into specified_directory(opt_id,spec_name) values (@opt_id,@specName)";

            using var updateOptionCmd = new SQLiteCommand(updateOptionCmdText, CN);
            using var deleteSpecifiedFilesAndExtsCmd = new SQLiteCommand(deleteSpecifiedFilesAndExtsCmdText, CN);
            using var insertSpecifiedFilesAndExtsCmd = new SQLiteCommand(insertSpecifiedFilesAndExtsCmdText, CN);
            using var deleteSpecifiedDirectoriesCmd = new SQLiteCommand(deleteSpecifiedDirectoriesText, CN);
            using var insertSpecifiedDirectoriesCmd = new SQLiteCommand(insertSpecifiedDirectoriesText, CN);

            updateOptionCmd.Parameters.AddWithValue("@opt_listview_index", opt.ListViewIndex);
            updateOptionCmd.Parameters.AddWithValue("@opt_source_path", opt.SourcePath);
            updateOptionCmd.Parameters.AddWithValue("@opt_destiny_path", opt.DestinyPath);
            updateOptionCmd.Parameters.AddWithValue("@opt_include_subfolders", opt.IncludeSubFolders);
            updateOptionCmd.Parameters.AddWithValue("@opt_keep_origin_files", opt.KeepOriginFiles);
            updateOptionCmd.Parameters.AddWithValue("@opt_clean_destiny_dir", opt.CleanDestinyDirectory);
            updateOptionCmd.Parameters.AddWithValue("@opt_delete_uncommon_files", opt.DeleteUncommonFiles);
            updateOptionCmd.Parameters.AddWithValue("@opt_filter_filenames_and_exts", opt.FilterFilesAndExts);
            updateOptionCmd.Parameters.AddWithValue("@opt_filter_directories", opt.FilterDirectories);
            updateOptionCmd.Parameters.AddWithValue("@opt_spec_filenames_and_exts_mode", opt.FilteredFileNamesOrExtensionsMode);
            updateOptionCmd.Parameters.AddWithValue("@opt_spec_directories_mode", opt.FilteredDirectoriesMode);
            updateOptionCmd.Parameters.AddWithValue("@opt_filename_conflict_method", opt.FileNameConflictMethod);
            updateOptionCmd.Parameters.AddWithValue("@opt_reenumerate_renamed_files", opt.ReenumerateRenamedFiles);
            updateOptionCmd.Parameters.AddWithValue("@opt_max_kept_renamed_file_count", opt.MaxKeptRenamedFileCount);
            updateOptionCmd.Parameters.AddWithValue("@profile_id", opt.Profile.Id);
            updateOptionCmd.Parameters.AddWithValue("@opt_id", opt.Id);

            updateOptionCmd.ExecuteNonQuery();

            deleteSpecifiedFilesAndExtsCmd.Parameters.AddWithValue("@opt_id", opt.Id);
            deleteSpecifiedFilesAndExtsCmd.ExecuteNonQuery();

            deleteSpecifiedDirectoriesCmd.Parameters.AddWithValue("@opt_id", opt.Id);
            deleteSpecifiedDirectoriesCmd.ExecuteNonQuery();

            foreach (string txt in opt.FilteredFileNamesAndExtensions)
            {
                insertSpecifiedFilesAndExtsCmd.Parameters.AddWithValue("@opt_id", opt.Id);
                insertSpecifiedFilesAndExtsCmd.Parameters.AddWithValue("@specName", txt);
                insertSpecifiedFilesAndExtsCmd.ExecuteNonQuery();
            }

            foreach (string txt in opt.FilteredDirectories)
            {
                insertSpecifiedDirectoriesCmd.Parameters.AddWithValue("@opt_id", opt.Id);
                insertSpecifiedDirectoriesCmd.Parameters.AddWithValue("@specName", txt);
                insertSpecifiedDirectoriesCmd.ExecuteNonQuery();
            }
        }

        public static void UpdateOptionListViewIndex(Options opt)
        {
            string updateOptionCmdText = "update option set opt_listview_index=@opt_listview_index where opt_id=@opt_id";

            using (var updateOptionCmd = new SQLiteCommand(updateOptionCmdText, CN))
            {
                updateOptionCmd.Parameters.AddWithValue("@opt_listview_index", opt.ListViewIndex);
                updateOptionCmd.Parameters.AddWithValue("@opt_id", opt.Id);
                updateOptionCmd.ExecuteNonQuery();
            }
        }

        public static List<Options> ListProfileOptions(Profile prof)
        {
            List<Options> options = new();

            string queryOptionCmdText = "select * from option where profile_id=@profile_id";
            string querySpecifiedFilesAndExtsCmdText = "select spec_name from specified_file_or_ext where opt_id=@opt_id";
            string querySpecifiedDirectoriesCmdText = "select spec_name from specified_directory where opt_id=@opt_id";

            using var queryOptionCmd = new SQLiteCommand(queryOptionCmdText, CN);
            using var querySpecifiedFilesAndExtsCmd = new SQLiteCommand(querySpecifiedFilesAndExtsCmdText, CN);
            using var querySpecifiedDirectoriesCmd = new SQLiteCommand(querySpecifiedDirectoriesCmdText, CN);
            
            queryOptionCmd.Parameters.AddWithValue("@profile_id", prof.Id);

            using SQLiteDataReader readerOptions = queryOptionCmd.ExecuteReader();

            while (readerOptions.Read())
            {
                Options opt = new()
                {
                    Profile = prof,
                    Id = readerOptions.GetInt32(readerOptions.GetOrdinal("opt_id")),
                    ListViewIndex = readerOptions.GetInt32(readerOptions.GetOrdinal("opt_listview_index")),
                    SourcePath = readerOptions.GetString(readerOptions.GetOrdinal("opt_source_path")),
                    DestinyPath = readerOptions.GetString(readerOptions.GetOrdinal("opt_destiny_path")),
                    IncludeSubFolders = readerOptions.GetBoolean(readerOptions.GetOrdinal("opt_include_subfolders")),
                    KeepOriginFiles = readerOptions.GetBoolean(readerOptions.GetOrdinal("opt_keep_origin_files")),
                    CleanDestinyDirectory = readerOptions.GetBoolean(readerOptions.GetOrdinal("opt_clean_destiny_dir")),
                    DeleteUncommonFiles = readerOptions.GetBoolean(readerOptions.GetOrdinal("opt_delete_uncommon_files")),
                    FilteredFileNamesOrExtensionsMode = (FilterMode)readerOptions.GetInt32(readerOptions.GetOrdinal("opt_spec_filenames_and_exts_mode")),
                    FilteredDirectoriesMode = (FilterMode)readerOptions.GetInt32(readerOptions.GetOrdinal("opt_spec_directories_mode")),
                    FilterFilesAndExts = readerOptions.GetBoolean(readerOptions.GetOrdinal("opt_filter_filenames_and_exts")),
                    FilterDirectories = readerOptions.GetBoolean(readerOptions.GetOrdinal("opt_filter_directories")),
                    FileNameConflictMethod = (FileNameConflictMethod)readerOptions.GetInt32(readerOptions.GetOrdinal("opt_filename_conflict_method")),
                    ReenumerateRenamedFiles = readerOptions.GetBoolean(readerOptions.GetOrdinal("opt_reenumerate_renamed_files")),
                    MaxKeptRenamedFileCount = readerOptions.GetInt32(readerOptions.GetOrdinal("opt_max_kept_renamed_file_count"))
                };

                querySpecifiedFilesAndExtsCmd.Parameters.AddWithValue("@opt_id", opt.Id);
                querySpecifiedDirectoriesCmd.Parameters.AddWithValue("@opt_id", opt.Id);

                using SQLiteDataReader readerSpecifiedFilesAndExts = querySpecifiedFilesAndExtsCmd.ExecuteReader();
                using SQLiteDataReader readerSpecifiedDirectories = querySpecifiedDirectoriesCmd.ExecuteReader();
                
                while (readerSpecifiedFilesAndExts.Read())
                    opt.FilteredFileNamesAndExtensions.Add(readerSpecifiedFilesAndExts["spec_name"].ToString());

                while (readerSpecifiedDirectories.Read())
                    opt.FilteredDirectories.Add(readerSpecifiedDirectories["spec_name"].ToString());

                options.Add(opt);
            }

            return options;
        }

        public static void DeleteOption(Options option)
        {
            string deleteOptionCmdText = "delete from option where opt_id=@opt_id";
            string deleteSpecifiedFilesAndExtsCmdText = "delete from specified_file_or_ext where opt_id = @opt_id";
            string deleteSpecifiedDirectoriesCmdText = "delete from specified_directory where opt_id = @opt_id";

            using var deleteOptionCmd = new SQLiteCommand(deleteOptionCmdText, CN);
            using var deleteSpecifiedFilesAndExtsCmd = new SQLiteCommand(deleteSpecifiedFilesAndExtsCmdText, CN);
            using var deleteSpecifiedDirectoriesCmd = new SQLiteCommand(deleteSpecifiedDirectoriesCmdText, CN);

            deleteSpecifiedFilesAndExtsCmd.Parameters.AddWithValue("@opt_id", option.Id);
            deleteSpecifiedFilesAndExtsCmd.ExecuteNonQuery();
            deleteSpecifiedDirectoriesCmd.Parameters.AddWithValue("@opt_id", option.Id);
            deleteSpecifiedDirectoriesCmd.ExecuteNonQuery();
            deleteOptionCmd.Parameters.AddWithValue("@opt_id", option.Id);
            deleteOptionCmd.ExecuteNonQuery();
        }

        //public bool CreateDatabase()
        //{
        //    bool result = false;
        //    string sqlCmd = BackupHelper.Properties.Resources.schema;
        //    var cn = Connect();
        //    cn.Open();
        //    using (var cmd = new SQLiteCommand(sqlCmd, cn))
        //        if(cmd.ExecuteNonQuery() > 0) result = true;
        //    cn.Close();
        //    return result;
        //}
    }
}
