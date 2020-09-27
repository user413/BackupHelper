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
            string query = "insert into profile(profile_listview_index,profile_name," +
                "profile_time_created,profile_last_time_modified,profile_last_time_executed) " +
                "values(@listviewIndex,@name,@timeCreated,@lastTimeModified,@lastTimeExecuted)";
            string lastIdQuery = "select last_insert_rowid()";
            
            using (var cmd = new SQLiteCommand(query, cn))
            using (var cmdLastId = new SQLiteCommand(lastIdQuery, cn))
            {
                //cmd.CommandText = query;
                //cmd.Prepare();
                cmd.Parameters.AddWithValue("@listviewIndex", profile.ListViewIndex);
                cmd.Parameters.AddWithValue("@name", profile.Name);
                cmd.Parameters.AddWithValue("@timeCreated", profile.TimeCreated);
                cmd.Parameters.AddWithValue("@lastTimeModified", profile.LastTimeModified);
                cmd.Parameters.AddWithValue("@lastTimeExecuted", profile.LastTimeExecuted);

                cmd.ExecuteNonQuery();

                using (SQLiteDataReader reader = cmdLastId.ExecuteReader())
                {
                    reader.Read();
                    profile.Id = Int32.Parse(reader["last_insert_rowid()"].ToString());
                }
            }
        }

        public static void UpdateProfile(Profile profile)
        {
            string query = "update profile set profile_listview_index=@listviewIndex," +
                "profile_name=@name,profile_last_time_modified=@lastTimeModified," +
                "profile_last_time_executed=@lastTimeExecuted where profile_id=@id";
            
            using (var cmd = new SQLiteCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@id", profile.Id);
                cmd.Parameters.AddWithValue("@listviewIndex", profile.ListViewIndex);
                cmd.Parameters.AddWithValue("@name", profile.Name);
                cmd.Parameters.AddWithValue("@lastTimeModified", profile.LastTimeModified);
                cmd.Parameters.AddWithValue("@lastTimeExecuted", profile.LastTimeExecuted);

                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateProfileListViewIndex(Profile profile)
        {
            string query = "update profile set profile_listview_index=@listviewIndex " +
                "where profile_id=@id";

            using (var cmd = new SQLiteCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@id", profile.Id);
                cmd.Parameters.AddWithValue("@listviewIndex", profile.ListViewIndex);

                cmd.ExecuteNonQuery();
            }
        }

        public static List<Profile> ListProfiles()
        {
            List<Profile> profiles = new List<Profile>();
            string query = "select profile_id,profile_listview_index,profile_name,profile_time_created," +
                "profile_last_time_modified,profile_last_time_executed from profile;";

            using (var cmd = new SQLiteCommand(query, cn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Profile prof = new Profile
                        {
                            Id = int.Parse(reader["profile_id"].ToString()),
                            ListViewIndex = int.Parse(reader["profile_listview_index"].ToString()),
                            Name = reader["profile_name"].ToString(),
                            TimeCreated = DateTime.Parse(reader["profile_time_created"].ToString()),
                            //LastTimeModified = reader["profile_last_time_modified"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(reader["profile_last_time_modified"].ToString()),
                            //LastTimeExecuted = reader["profile_last_time_executed"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(reader["profile_last_time_executed"].ToString())
                            LastTimeModified = DateTime.Parse(reader["profile_last_time_modified"].ToString()),
                            LastTimeExecuted = DateTime.Parse(reader["profile_last_time_executed"].ToString())
                        };

                        //prof.Options = ListProfileOptions(prof);
                        profiles.Add(prof);
                    }
                }
            }

            return profiles;
        }

        public static void DeleteProfile(Profile profile)
        {
            string deleteProfileStr = "delete from profile where profile_id=@profileId";
            string deleteOptStr = "delete from option where profile_id=@profileId";
            string optQuery = "select opt_id from option where profile_id=@profileId";
            string deleteAllowOnlyExtStr = "delete from allowonly_ext where opt_id=@optId";
            string deleteIgnoreExtStr = "delete from allowonly_ext where opt_id=@optId";

            using (var cmdOpt = new SQLiteCommand(deleteOptStr, cn))
            using (var cmdProf = new SQLiteCommand(deleteProfileStr, cn))
            using (var cmdOptQuery = new SQLiteCommand(optQuery,cn))
            using (var cmdAllow = new SQLiteCommand(deleteAllowOnlyExtStr, cn))
            using (var cmdIgnore = new SQLiteCommand(deleteIgnoreExtStr, cn))
            {
                cmdOptQuery.Parameters.AddWithValue("@profileId", profile.Id);
                using (SQLiteDataReader reader = cmdOptQuery.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmdAllow.Parameters.AddWithValue("@optId", Int32.Parse(reader["opt_id"].ToString()));
                        cmdIgnore.Parameters.AddWithValue("@optId", Int32.Parse(reader["opt_id"].ToString()));
                        cmdAllow.ExecuteNonQuery();
                        cmdIgnore.ExecuteNonQuery();
                    }
                }
                cmdOpt.Parameters.AddWithValue("@profileId", profile.Id);
                cmdOpt.ExecuteNonQuery();

                cmdProf.Parameters.AddWithValue("@profileId", profile.Id);
                cmdProf.ExecuteNonQuery();
            }
        }

        public static void AddOption(Option option)
        {
            string insertQueryText = "insert into option(profile_id,opt_listview_index,opt_source_path,opt_destiny_path,opt_move_subfolders," +
                "opt_keep_origin_files,opt_clean_destiny_dir,opt_delete_uncommon_files,opt_allowignore_file_ext,opt_spec_filenames_and_exts_mode," +
                "opt_filename_conflict_method) values(" +
                "@profileId,@listviewIndex,@sourcePath,@destinyPath,@moveSubfolders,@keepOrigin,@cleanDestinyDir,@deleteUncommonFiles," +
                "@allowIgnoreFileExt,@specFilenamesAndExtsMode,@filenameConflictMethod)";

            string lastIdQueryText = "select last_insert_rowid()";
            string insertSpecifiedFileAndExtCmdText = "insert into specified_file_or_ext(opt_id,spec_name) values (@id,@specName)";

            using (var cmdOption = new SQLiteCommand(insertQueryText,cn))
            using (var cmdLastId = new SQLiteCommand(lastIdQueryText, cn))
            using (var cmdAllowOnly = new SQLiteCommand(insertSpecifiedFileAndExtCmdText, cn))
            {
                cmdOption.Prepare();
                cmdOption.Parameters.AddWithValue("@profileId", option.Profile.Id);
                cmdOption.Parameters.AddWithValue("@listviewIndex", option.ListViewIndex);
                cmdOption.Parameters.AddWithValue("@sourcePath", option.SourcePath);
                cmdOption.Parameters.AddWithValue("@destinyPath", option.DestinyPath);
                cmdOption.Parameters.AddWithValue("@moveSubfolders", option.MoveSubFolders);
                cmdOption.Parameters.AddWithValue("@keepOrigin", option.KeepOriginFiles);
                cmdOption.Parameters.AddWithValue("@cleanDestinyDir", option.CleanDestinyDirectory);
                cmdOption.Parameters.AddWithValue("@deleteUncommonFiles", option.DeleteUncommonFiles);
                cmdOption.Parameters.AddWithValue("@allowIgnoreFileExt", option.AllowIgnoreFileExt);
                cmdOption.Parameters.AddWithValue("@specFilenamesAndExtsMode", option.SpecifiedFileNamesOrExtensionsMode);
                cmdOption.Parameters.AddWithValue("@filenameConflictMethod", option.FileNameConflictMethod);
                cmdOption.ExecuteNonQuery();

                using (SQLiteDataReader reader = cmdLastId.ExecuteReader())
                {
                    reader.Read();
                    option.Id = int.Parse(reader["last_insert_rowid()"].ToString());
                }

                foreach (string txt in option.SpecifiedFileNamesAndExtensions)
                {
                    cmdAllowOnly.Parameters.AddWithValue("@id", option.Id);
                    cmdAllowOnly.Parameters.AddWithValue("@specName", txt);
                    cmdAllowOnly.ExecuteNonQuery();
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

            using (var cmd1 = new SQLiteCommand(updateOptionCmdText, cn))
            using (var cmd2 = new SQLiteCommand(deleteSpecifiedFilesAndExtsCmdText, cn))
            using (var cmd3 = new SQLiteCommand(insertSpecifiedFileOrExtCmdText, cn))
            {

                cmd1.Parameters.AddWithValue("@listviewIndex", opt.ListViewIndex);
                cmd1.Parameters.AddWithValue("@source", opt.SourcePath);
                cmd1.Parameters.AddWithValue("@destiny", opt.DestinyPath);
                cmd1.Parameters.AddWithValue("@moveSubf", opt.MoveSubFolders);
                cmd1.Parameters.AddWithValue("@keepOrigin", opt.KeepOriginFiles);
                cmd1.Parameters.AddWithValue("@cleanDestinyDir", opt.CleanDestinyDirectory);
                cmd1.Parameters.AddWithValue("@allowIgnoreFileExt", opt.AllowIgnoreFileExt);
                cmd1.Parameters.AddWithValue("@deleteUncommonFiles", opt.DeleteUncommonFiles);
                cmd1.Parameters.AddWithValue("@specFilenamesAndExtsMode", opt.SpecifiedFileNamesOrExtensionsMode);
                cmd1.Parameters.AddWithValue("@filenameConflictMethod", opt.FileNameConflictMethod);
                cmd1.Parameters.AddWithValue("@profileId", opt.Profile.Id);
                cmd1.Parameters.AddWithValue("@optId", opt.Id);

                cmd2.Parameters.AddWithValue("@id", opt.Id);

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery(); //-- DELETE ALL SPECIFIED FILES OR EXTENSIONS
                    
                foreach (string txt in opt.SpecifiedFileNamesAndExtensions)
                {
                    cmd3.Parameters.AddWithValue("@id", opt.Id);
                    cmd3.Parameters.AddWithValue("@specName", txt);
                    cmd3.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateOptionListViewIndex(Option opt)
        {
            string updateOptionCmdText = "update option set opt_listview_index=@listviewIndex where opt_id=@optId";

            using (var cmd1 = new SQLiteCommand(updateOptionCmdText, cn))
            {

                cmd1.Parameters.AddWithValue("@listviewIndex", opt.ListViewIndex);
                cmd1.Parameters.AddWithValue("@optId", opt.Id);

                cmd1.ExecuteNonQuery();
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

            using (var cmd1 = new SQLiteCommand(queryOptionCmdText, cn))
            using (var cmd2 = new SQLiteCommand(querySpecifiedFilesAndExtsCmdText, cn))
            {
                cmd1.Parameters.AddWithValue("@profileId", prof.Id);

                using (SQLiteDataReader reader1 = cmd1.ExecuteReader())
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
                            SpecifiedFileNamesOrExtensionsMode = (SpecifiedFileNamesAndExtensionsMode)int.Parse(reader1["opt_spec_filenames_and_exts_mode"].ToString()),
                            SpecifiedFileNamesAndExtensions = new List<string>()
                        };

                        cmd2.Parameters.AddWithValue("@optId", opt.Id);

                        using (SQLiteDataReader reader2 = cmd2.ExecuteReader())
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

            using (var cmdDeleteOption = new SQLiteCommand(deleteOptionCmdText, cn))
            using (var cmdDeleteSpecifiedFilesAndExts = new SQLiteCommand(deleteSpecifiedFilesAndExtsCmdText, cn))
            {
                cmdDeleteSpecifiedFilesAndExts.Parameters.AddWithValue("@optId", option.Id);
                cmdDeleteOption.Parameters.AddWithValue("@optId", option.Id);
                cmdDeleteSpecifiedFilesAndExts.ExecuteNonQuery();
                cmdDeleteOption.ExecuteNonQuery();
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
