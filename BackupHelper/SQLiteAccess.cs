using BackupHelper.model;
using FileControlUtility;
using System;
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
                            Id = int.Parse(reader["profile_id"].ToString()),
                            ListViewIndex = int.Parse(reader["profile_listview_index"].ToString()),
                            Name = reader["profile_name"].ToString(),
                            TimeCreated = DateTime.Parse(reader["profile_time_created"].ToString()),
                            LastTimeModified = DateTime.Parse(reader["profile_last_time_modified"].ToString()),
                            LastTimeExecuted = DateTime.Parse(reader["profile_last_time_executed"].ToString()),
                            GroupName = reader["profile_group"].ToString()
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

        public static void AddOption(Option option)
        {
            string insertOptionCmdText = "insert into option(profile_id,opt_listview_index,opt_source_path,opt_destiny_path,opt_move_subfolders," +
                "opt_keep_origin_files,opt_clean_destiny_dir,opt_delete_uncommon_files,opt_allowignore_file_ext,opt_spec_filenames_and_exts_mode," +
                "opt_filename_conflict_method) values(" +
                "@profileId,@listviewIndex,@sourcePath,@destinyPath,@moveSubfolders,@keepOrigin,@cleanDestinyDir,@deleteUncommonFiles," +
                "@allowIgnoreFileExt,@specFilenamesAndExtsMode,@filenameConflictMethod)";

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
                insertOptionCmd.Parameters.AddWithValue("@moveSubfolders", option.MoveSubFolders);
                insertOptionCmd.Parameters.AddWithValue("@keepOrigin", option.KeepOriginFiles);
                insertOptionCmd.Parameters.AddWithValue("@cleanDestinyDir", option.CleanDestinyDirectory);
                insertOptionCmd.Parameters.AddWithValue("@deleteUncommonFiles", option.DeleteUncommonFiles);
                insertOptionCmd.Parameters.AddWithValue("@allowIgnoreFileExt", option.AllowIgnoreFileExt);
                insertOptionCmd.Parameters.AddWithValue("@specFilenamesAndExtsMode", option.SpecifiedFileNamesOrExtensionsMode);
                insertOptionCmd.Parameters.AddWithValue("@filenameConflictMethod", option.FileNameConflictMethod);
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

        public static void UpdateOption(Option opt)
        {            
            string updateOptionCmdText = "update option set opt_listview_index=@listviewIndex,opt_source_path=@source,opt_destiny_path=@destiny," +
                "opt_move_subfolders=@moveSubf,opt_keep_origin_files=@keepOrigin,opt_clean_destiny_dir=@cleanDestinyDir,opt_allowignore_file_ext=" +
                "@allowIgnoreFileExt,opt_delete_uncommon_files=@deleteUncommonFiles,opt_spec_filenames_and_exts_mode=@specFilenamesAndExtsMode," +
                "opt_filename_conflict_method=@filenameConflictMethod " +
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
                updateOptionCmd.Parameters.AddWithValue("@moveSubf", opt.MoveSubFolders);
                updateOptionCmd.Parameters.AddWithValue("@keepOrigin", opt.KeepOriginFiles);
                updateOptionCmd.Parameters.AddWithValue("@cleanDestinyDir", opt.CleanDestinyDirectory);
                updateOptionCmd.Parameters.AddWithValue("@allowIgnoreFileExt", opt.AllowIgnoreFileExt);
                updateOptionCmd.Parameters.AddWithValue("@deleteUncommonFiles", opt.DeleteUncommonFiles);
                updateOptionCmd.Parameters.AddWithValue("@specFilenamesAndExtsMode", opt.SpecifiedFileNamesOrExtensionsMode);
                updateOptionCmd.Parameters.AddWithValue("@filenameConflictMethod", opt.FileNameConflictMethod);
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

        public static void UpdateOptionListViewIndex(Option opt)
        {
            string updateOptionCmdText = "update option set opt_listview_index=@listviewIndex where opt_id=@optId";

            using (var updateOptionCmd = new SQLiteCommand(updateOptionCmdText, cn))
            {
                updateOptionCmd.Parameters.AddWithValue("@listviewIndex", opt.ListViewIndex);
                updateOptionCmd.Parameters.AddWithValue("@optId", opt.Id);
                updateOptionCmd.ExecuteNonQuery();
            }
        }

        public static List<Option> ListProfileOptions(Profile prof)
        {
            List<Option> options = new List<Option>();

            string queryOptionCmdText = "select opt_id,opt_listview_index,opt_source_path,opt_destiny_path,opt_move_subfolders," +
                "opt_keep_origin_files,opt_clean_destiny_dir,opt_delete_uncommon_files,opt_allowignore_file_ext,opt_spec_filenames_and_exts_mode," +
                "opt_filename_conflict_method" +
                " from option where profile_id=@profileId";

            string querySpecifiedFilesAndExtsCmdText = "select spec_name from specified_file_or_ext where opt_id =@optId";

            using (var queryOptionCmd = new SQLiteCommand(queryOptionCmdText, cn))
            using (var querySpecifiedFilesAndExtsCmd = new SQLiteCommand(querySpecifiedFilesAndExtsCmdText, cn))
            {
                queryOptionCmd.Parameters.AddWithValue("@profileId", prof.Id);

                using (SQLiteDataReader reader1 = queryOptionCmd.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        Option opt = new Option
                        {
                            Profile = prof,
                            Id = int.Parse(reader1["opt_id"].ToString()),
                            ListViewIndex = int.Parse(reader1["opt_listview_index"].ToString()),
                            SourcePath = reader1["opt_source_path"].ToString(),
                            DestinyPath = reader1["opt_destiny_path"].ToString(),
                            MoveSubFolders = Convert.ToBoolean(int.Parse(reader1["opt_move_subfolders"].ToString())),
                            KeepOriginFiles = Convert.ToBoolean(int.Parse(reader1["opt_keep_origin_files"].ToString())),
                            CleanDestinyDirectory = Convert.ToBoolean(int.Parse(reader1["opt_clean_destiny_dir"].ToString())),
                            DeleteUncommonFiles = Convert.ToBoolean(int.Parse(reader1["opt_delete_uncommon_files"].ToString())),
                            AllowIgnoreFileExt = Convert.ToBoolean(int.Parse(reader1["opt_allowignore_file_ext"].ToString())),
                            FileNameConflictMethod = (FileNameConflictMethod)int.Parse(reader1["opt_filename_conflict_method"].ToString()),
                            SpecifiedFileNamesOrExtensionsMode = (SpecifiedFileNamesAndExtensionsMode)int.Parse(reader1["opt_spec_filenames_and_exts_mode"].ToString())
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

        public static void DeleteOption(Option option)
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
