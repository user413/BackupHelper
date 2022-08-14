using BackupHelper.model;
using FileControlUtility;
using System.Collections.Generic;
using System.Data.SQLite;

namespace BackupHelper
{
    public static class DBAccess
    {
        private static readonly SQLiteConnection cn = new SQLiteConnection("data source=" + Program.DBPath);

        static DBAccess()
        {
            cn.Open();
        }

        public static void AddProfile(Profile profile)
        {
            string insertProfileCmdText = "insert into profile(profile_listview_index,profile_name," +
                "profile_time_created,profile_last_time_modified,profile_last_time_executed,profile_group) " +
                "values(@listviewIndex,@name,@timeCreated,@lastTimeModified,@lastTimeExecuted,@profile_group)";
            string queryProfileLastInsertedIdCmdText = "select last_insert_rowid()";
            
            using (var insertProfileCmd = new SQLiteCommand(insertProfileCmdText, cn))
            using (var queryProfileLastInsertedIdCmd = new SQLiteCommand(queryProfileLastInsertedIdCmdText, cn))
            {
                insertProfileCmd.Parameters.AddWithValue("@listviewIndex", profile.ListViewIndex);
                insertProfileCmd.Parameters.AddWithValue("@name", profile.Name);
                insertProfileCmd.Parameters.AddWithValue("@timeCreated", profile.TimeCreated);
                insertProfileCmd.Parameters.AddWithValue("@lastTimeModified", profile.LastTimeModified);
                insertProfileCmd.Parameters.AddWithValue("@lastTimeExecuted", profile.LastTimeExecuted);
                insertProfileCmd.Parameters.AddWithValue("@profile_group", profile.GroupName);

                insertProfileCmd.ExecuteNonQuery();

                using (SQLiteDataReader reader = queryProfileLastInsertedIdCmd.ExecuteReader())
                {
                    reader.Read();
                    profile.Id = int.Parse(reader["last_insert_rowid()"].ToString());
                }
            }
        }

        public static void UpdateProfile(Profile profile)
        {
            string updateProfileCmdText = "update profile set profile_listview_index=@listviewIndex," +
                "profile_name=@name,profile_last_time_modified=@lastTimeModified," +
                "profile_last_time_executed=@lastTimeExecuted,profile_group=@profile_group where profile_id=@id";
            
            using (var updateProfileCmd = new SQLiteCommand(updateProfileCmdText, cn))
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

            using (var updateProfileCmd = new SQLiteCommand(updateProfileCmdText, cn))
            {
                updateProfileCmd.Parameters.AddWithValue("@id", profile.Id);
                updateProfileCmd.Parameters.AddWithValue("@listviewIndex", profile.ListViewIndex);
                updateProfileCmd.Parameters.AddWithValue("@profile_group", profile.GroupName);

                updateProfileCmd.ExecuteNonQuery();
            }
        }

        public static List<Profile> ListProfiles()
        {
            List<Profile> profiles = new List<Profile>();
            string queryProfileCmdText = "select profile_id,profile_listview_index,profile_name,profile_time_created," +
                "profile_last_time_modified,profile_last_time_executed,profile_group from profile;";

            using (var queryProfileCmd = new SQLiteCommand(queryProfileCmdText, cn))
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

            using (var queryOptionCmd = new SQLiteCommand(queryOptionCmdText, cn))
            using (var deleteSpecifiedFileNamesAndExtsCmd = new SQLiteCommand(deleteSpecifiedFileNamesAndExtsCmdText, cn))
            using (var deleteOptionCmd = new SQLiteCommand(deleteOptionCmdText, cn))
            using (var deleteProfileCmd = new SQLiteCommand(deleteProfileCmdText, cn))
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

        public static void AddOption(Options option)
        {
            string insertOptionCmdText = "insert into option(profile_id,opt_listview_index,opt_source_path,opt_destiny_path,opt_include_subfolders," +
                "opt_keep_origin_files,opt_clean_destiny_dir,opt_delete_uncommon_files,opt_allowignore_file_ext,opt_spec_filenames_and_exts_mode," +
                "opt_filename_conflict_method,opt_reenumerate_renamed_files,opt_max_kept_renamed_file_count) values(" +
                "@profileId,@listviewIndex,@sourcePath,@destinyPath,@moveSubfolders,@keepOrigin,@cleanDestinyDir,@deleteUncommonFiles," +
                "@allowIgnoreFileExt,@specFilenamesAndExtsMode,@filenameConflictMethod,@opt_reenumerate_renamed_files,@opt_max_kept_renamed_file_count)";

            string queryOptionLastInsertedIdCmdText = "select last_insert_rowid()";
            string insertSpecifiedFileOrExtCmdText = "insert into specified_file_or_ext(opt_id,spec_name) values (@id,@specName)";

            using (var insertOptionCmd = new SQLiteCommand(insertOptionCmdText, cn))
            using (var queryOptionLastInsertedIdCmd = new SQLiteCommand(queryOptionLastInsertedIdCmdText, cn))
            using (var insertSpecifiedFileOrExtCmd = new SQLiteCommand(insertSpecifiedFileOrExtCmdText, cn))
            {
                insertOptionCmd.Prepare();
                insertOptionCmd.Parameters.AddWithValue("@profileId", option.Profile.Id);
                insertOptionCmd.Parameters.AddWithValue("@listviewIndex", option.ListViewIndex);
                insertOptionCmd.Parameters.AddWithValue("@sourcePath", option.SourcePath);
                insertOptionCmd.Parameters.AddWithValue("@destinyPath", option.DestinyPath);
                insertOptionCmd.Parameters.AddWithValue("@moveSubfolders", option.IncludeSubFolders);
                insertOptionCmd.Parameters.AddWithValue("@keepOrigin", option.KeepOriginFiles);
                insertOptionCmd.Parameters.AddWithValue("@cleanDestinyDir", option.CleanDestinyDirectory);
                insertOptionCmd.Parameters.AddWithValue("@deleteUncommonFiles", option.DeleteUncommonFiles);
                insertOptionCmd.Parameters.AddWithValue("@allowIgnoreFileExt", option.AllowIgnoreFileExt);
                insertOptionCmd.Parameters.AddWithValue("@specFilenamesAndExtsMode", option.SpecifiedFileNamesOrExtensionsMode);
                insertOptionCmd.Parameters.AddWithValue("@filenameConflictMethod", option.FileNameConflictMethod);
                insertOptionCmd.Parameters.AddWithValue("@opt_reenumerate_renamed_files", option.ReenumerateRenamedFiles);
                insertOptionCmd.Parameters.AddWithValue("@opt_max_kept_renamed_file_count", option.MaxKeptRenamedFileCount);
                insertOptionCmd.ExecuteNonQuery();

                using (SQLiteDataReader reader = queryOptionLastInsertedIdCmd.ExecuteReader())
                {
                    reader.Read();
                    option.Id = int.Parse(reader["last_insert_rowid()"].ToString());
                }

                foreach (string txt in option.SpecifiedFileNamesAndExtensions)
                {
                    insertSpecifiedFileOrExtCmd.Parameters.AddWithValue("@id", option.Id);
                    insertSpecifiedFileOrExtCmd.Parameters.AddWithValue("@specName", txt);
                    insertSpecifiedFileOrExtCmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateOption(Options opt)
        {            
            string updateOptionCmdText = "update option set opt_listview_index=@listviewIndex,opt_source_path=@source,opt_destiny_path=@destiny," +
                "opt_include_subfolders=@moveSubf,opt_keep_origin_files=@keepOrigin,opt_clean_destiny_dir=@cleanDestinyDir,opt_allowignore_file_ext=" +
                "@allowIgnoreFileExt,opt_delete_uncommon_files=@deleteUncommonFiles,opt_spec_filenames_and_exts_mode=@specFilenamesAndExtsMode," +
                "opt_filename_conflict_method=@filenameConflictMethod,opt_reenumerate_renamed_files=@opt_reenumerate_renamed_files," +
                "opt_max_kept_renamed_file_count=@opt_max_kept_renamed_file_count " +
                "where profile_id=@profileId and opt_id=@optId";

            string deleteSpecifiedFilesAndExtsCmdText = "delete from specified_file_or_ext where opt_id = @id";
            string insertSpecifiedFileOrExtCmdText = "insert into specified_file_or_ext(opt_id,spec_name) values (@id,@specName)";

            using (var updateOptionCmd = new SQLiteCommand(updateOptionCmdText, cn))
            using (var deleteSpecifiedFilesAndExtsCmd = new SQLiteCommand(deleteSpecifiedFilesAndExtsCmdText, cn))
            using (var insertSpecifiedFileOrExtCmd = new SQLiteCommand(insertSpecifiedFileOrExtCmdText, cn))
            {

                updateOptionCmd.Parameters.AddWithValue("@listviewIndex", opt.ListViewIndex);
                updateOptionCmd.Parameters.AddWithValue("@source", opt.SourcePath);
                updateOptionCmd.Parameters.AddWithValue("@destiny", opt.DestinyPath);
                updateOptionCmd.Parameters.AddWithValue("@moveSubf", opt.IncludeSubFolders);
                updateOptionCmd.Parameters.AddWithValue("@keepOrigin", opt.KeepOriginFiles);
                updateOptionCmd.Parameters.AddWithValue("@cleanDestinyDir", opt.CleanDestinyDirectory);
                updateOptionCmd.Parameters.AddWithValue("@allowIgnoreFileExt", opt.AllowIgnoreFileExt);
                updateOptionCmd.Parameters.AddWithValue("@deleteUncommonFiles", opt.DeleteUncommonFiles);
                updateOptionCmd.Parameters.AddWithValue("@specFilenamesAndExtsMode", opt.SpecifiedFileNamesOrExtensionsMode);
                updateOptionCmd.Parameters.AddWithValue("@filenameConflictMethod", opt.FileNameConflictMethod);
                updateOptionCmd.Parameters.AddWithValue("@opt_reenumerate_renamed_files", opt.ReenumerateRenamedFiles);
                updateOptionCmd.Parameters.AddWithValue("@opt_max_kept_renamed_file_count", opt.MaxKeptRenamedFileCount);
                updateOptionCmd.Parameters.AddWithValue("@profileId", opt.Profile.Id);
                updateOptionCmd.Parameters.AddWithValue("@optId", opt.Id);

                updateOptionCmd.ExecuteNonQuery();

                deleteSpecifiedFilesAndExtsCmd.Parameters.AddWithValue("@id", opt.Id);
                deleteSpecifiedFilesAndExtsCmd.ExecuteNonQuery();
                    
                foreach (string txt in opt.SpecifiedFileNamesAndExtensions)
                {
                    insertSpecifiedFileOrExtCmd.Parameters.AddWithValue("@id", opt.Id);
                    insertSpecifiedFileOrExtCmd.Parameters.AddWithValue("@specName", txt);
                    insertSpecifiedFileOrExtCmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateOptionListViewIndex(Options opt)
        {
            string updateOptionCmdText = "update option set opt_listview_index=@listviewIndex where opt_id=@optId";

            using (var updateOptionCmd = new SQLiteCommand(updateOptionCmdText, cn))
            {
                updateOptionCmd.Parameters.AddWithValue("@listviewIndex", opt.ListViewIndex);
                updateOptionCmd.Parameters.AddWithValue("@optId", opt.Id);
                updateOptionCmd.ExecuteNonQuery();
            }
        }

        public static List<Options> ListProfileOptions(Profile prof)
        {
            List<Options> options = new List<Options>();

            string queryOptionCmdText = "select opt_id,opt_listview_index,opt_source_path,opt_destiny_path,opt_include_subfolders," +
                "opt_keep_origin_files,opt_clean_destiny_dir,opt_delete_uncommon_files,opt_allowignore_file_ext,opt_spec_filenames_and_exts_mode," +
                "opt_filename_conflict_method,opt_reenumerate_renamed_files,opt_max_kept_renamed_file_count " +
                " from option where profile_id=@profileId";

            string querySpecifiedFilesAndExtsCmdText = "select spec_name from specified_file_or_ext where opt_id=@optId";

            using (var queryOptionCmd = new SQLiteCommand(queryOptionCmdText, cn))
            using (var querySpecifiedFilesAndExtsCmd = new SQLiteCommand(querySpecifiedFilesAndExtsCmdText, cn))
            {
                queryOptionCmd.Parameters.AddWithValue("@profileId", prof.Id);

                using (SQLiteDataReader reader1 = queryOptionCmd.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        Options opt = new Options
                        {
                            Profile = prof,
                            Id = reader1.GetInt32(reader1.GetOrdinal("opt_id")),
                            ListViewIndex = reader1.GetInt32(reader1.GetOrdinal("opt_listview_index")),
                            SourcePath = reader1.GetString(reader1.GetOrdinal("opt_source_path")),
                            DestinyPath = reader1.GetString(reader1.GetOrdinal("opt_destiny_path")),
                            IncludeSubFolders = reader1.GetBoolean(reader1.GetOrdinal("opt_include_subfolders")),
                            KeepOriginFiles = reader1.GetBoolean(reader1.GetOrdinal("opt_keep_origin_files")),
                            CleanDestinyDirectory = reader1.GetBoolean(reader1.GetOrdinal("opt_clean_destiny_dir")),
                            DeleteUncommonFiles = reader1.GetBoolean(reader1.GetOrdinal("opt_delete_uncommon_files")),
                            AllowIgnoreFileExt = reader1.GetBoolean(reader1.GetOrdinal("opt_allowignore_file_ext")),
                            FileNameConflictMethod = (FileNameConflictMethod)reader1.GetInt32(reader1.GetOrdinal("opt_filename_conflict_method")),
                            SpecifiedFileNamesOrExtensionsMode = (SpecifiedEntriesMode)reader1.GetInt32(reader1.GetOrdinal("opt_spec_filenames_and_exts_mode")),
                            ReenumerateRenamedFiles = reader1.GetBoolean(reader1.GetOrdinal("opt_reenumerate_renamed_files")),
                            MaxKeptRenamedFileCount = reader1.GetInt32(reader1.GetOrdinal("opt_max_kept_renamed_file_count"))
                        };

                        querySpecifiedFilesAndExtsCmd.Parameters.AddWithValue("@optId", opt.Id);

                        using (SQLiteDataReader reader2 = querySpecifiedFilesAndExtsCmd.ExecuteReader())
                        {
                            while (reader2.Read())
                                opt.SpecifiedFileNamesAndExtensions.Add(reader2["spec_name"].ToString());
                        }

                        options.Add(opt);
                    }
                }
            }

            return options;
        }

        public static void DeleteOption(Options option)
        {
            string deleteOptionCmdText = "delete from option where opt_id=@optId";
            string deleteSpecifiedFilesAndExtsCmdText = "delete from specified_file_or_ext where opt_id = @optId";

            using (var deleteOptionCmd = new SQLiteCommand(deleteOptionCmdText, cn))
            using (var deleteSpecifiedFilesAndExtsCmd = new SQLiteCommand(deleteSpecifiedFilesAndExtsCmdText, cn))
            {
                deleteSpecifiedFilesAndExtsCmd.Parameters.AddWithValue("@optId", option.Id);
                deleteSpecifiedFilesAndExtsCmd.ExecuteNonQuery();
                deleteOptionCmd.Parameters.AddWithValue("@optId", option.Id);
                deleteOptionCmd.ExecuteNonQuery();
            }
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
