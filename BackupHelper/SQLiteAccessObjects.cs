using BackupHelper.model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupHelper
{
    class ProfileAccess
    {
        private DBConnection dbc = new DBConnection();
        
        public void AddProfile(Profile profile)
        {
            string query = "insert into profile(profile_listview_index,profile_name," +
                "profile_time_created,profile_last_time_modified,profile_last_time_executed) " +
                "values(@listviewIndex,@name,@timeCreated,@lastTimeModified,@lastTimeExecuted)";
            string lastIdQuery = "select last_insert_rowid()";
            using (var cn = dbc.Connect())
            {
                cn.Open();
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
        }

        public void UpdateProfile(Profile profile)
        {
            string query = "update profile set profile_listview_index=@listviewIndex," +
                "profile_name=@name,profile_last_time_modified=@lastTimeModified," +
                "profile_last_time_executed=@lastTimeExecuted where profile_id=@id";
            using (var cn = dbc.Connect())
            {
                cn.Open();
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
        }

        public void UpdateProfileListViewIndex(Profile profile)
        {
            string query = "update profile set profile_listview_index=@listviewIndex " +
                "where profile_id=@id";
            using (var cn = dbc.Connect())
            {
                cn.Open();
                using (var cmd = new SQLiteCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@id", profile.Id);
                    cmd.Parameters.AddWithValue("@listviewIndex", profile.ListViewIndex);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Profile> ListProfiles()
        {
            List<Profile> profiles = new List<Profile>();
            string query = "select profile_id,profile_listview_index,profile_name,profile_time_created," +
                "profile_last_time_modified,profile_last_time_executed from profile;";
            using (var cn = dbc.Connect())
            {
                using (var cmd = new SQLiteCommand(query, cn))
                {
                    cn.Open();
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
                            profiles.Add(prof);
                        }
                    }
                }
            }
            return profiles;
        }

        public void DeleteProfile(Profile profile)
        {
            string deleteProfileStr = "delete from profile where profile_id=@profileId";
            string deleteOptStr = "delete from option where profile_id=@profileId";
            string optQuery = "select opt_id from option where profile_id=@profileId";
            string deleteAllowOnlyExtStr = "delete from allowonly_ext where opt_id=@optId";
            string deleteIgnoreExtStr = "delete from allowonly_ext where opt_id=@optId";

            using (var cn = dbc.Connect())
            {
                cn.Open();
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
        }
    }

    public class OptionAccess
    {
        private DBConnection dbc = new DBConnection();

        public void AddOption(Option option)
        {
            string insertQuery = "insert into option(profile_id,opt_listview_index,opt_source_path," +
                "opt_destiny_path,method_id,opt_move_subfolders,opt_keep_origin_files," +
                "opt_clean_destiny_dir,opt_delete_uncommon_files,opt_allowignore_file_ext) " +
                "values(@profileId,@listviewIndex,@sourcePath,@destinyPath,@methodId,@moveSubfolders," +
                "@keepOrigin,@cleanDestinyDir,@deleteUncommonFiles,@allowIgnoreFileExt)";
            string lastIdQuery = "select last_insert_rowid()";
            string insertAllowOnlyExtStr = "insert into allowonly_ext(opt_id,ext_name) values (@id,@extName)";
            string insertIgnoreExtStr = "insert into ignore_ext(opt_id,ext_name) values (@id,@extName)";
            using (var cn = dbc.Connect())
            {
                cn.Open();
                using (var cmdOption = new SQLiteCommand(insertQuery,cn))
                using (var cmdLastId = new SQLiteCommand(lastIdQuery, cn))
                using (var cmdAllowOnly = new SQLiteCommand(insertAllowOnlyExtStr, cn))
                using (var cmdIgnore = new SQLiteCommand(insertIgnoreExtStr, cn))
                {
                    cmdOption.Prepare();
                    cmdOption.Parameters.AddWithValue("@profileId", option.Profile.Id);
                    cmdOption.Parameters.AddWithValue("@listviewIndex", option.ListViewIndex);
                    cmdOption.Parameters.AddWithValue("@sourcePath", option.SourcePath);
                    cmdOption.Parameters.AddWithValue("@destinyPath", option.DestinyPath);
                    cmdOption.Parameters.AddWithValue("@methodId", option.TransferMethod.Id);
                    cmdOption.Parameters.AddWithValue("@moveSubfolders", option.MoveSubFolders);
                    cmdOption.Parameters.AddWithValue("@keepOrigin", option.KeepOriginFiles);
                    cmdOption.Parameters.AddWithValue("@cleanDestinyDir", option.CleanDestinyDirectory);
                    cmdOption.Parameters.AddWithValue("@deleteUncommonFiles", option.DeleteUncommonFiles);
                    cmdOption.Parameters.AddWithValue("@allowIgnoreFileExt", option.AllowIgnoreFileExt);

                    cmdOption.ExecuteNonQuery();

                    using (SQLiteDataReader reader = cmdLastId.ExecuteReader())
                    {
                        reader.Read();
                        option.Id = int.Parse(reader["last_insert_rowid()"].ToString());
                    }
                    if (option.AllowOnlyFileExtensions.Count > 0)
                    {
                        foreach (FileExtension ext in option.AllowOnlyFileExtensions)
                        {
                            cmdAllowOnly.Parameters.AddWithValue("@id", option.Id);
                            cmdAllowOnly.Parameters.AddWithValue("@extName", ext.ExtensionName);
                            cmdAllowOnly.ExecuteNonQuery();
                        }
                    }
                    if (option.IgnoredFileExtensions.Count > 0)
                    {
                        foreach (FileExtension ext in option.IgnoredFileExtensions)
                        {
                            cmdIgnore.Parameters.AddWithValue("@id", option.Id);
                            cmdIgnore.Parameters.AddWithValue("@extName", ext.ExtensionName);
                            cmdIgnore.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        //public void UpdateOptions(List<Option> options)
        //{
        //    string updateOptionStr = "update option set opt_source_path=@source,opt_destiny_path=@destiny,method_id=@methodId," +
        //        "opt_move_subfolders=@moveSubf,opt_keep_origin_files=@keepOrigin,opt_clean_destiny_dir=@cleanDestinyDir," +
        //        "opt_allowignore_file_ext=@allowIgnoreFileExt where profile_id=@profileId and opt_id=@optId";
        //    string deleteAllowOnlyExtStr = "delete from allowonly_ext";
        //    string insertAllowOnlyExtStr = "insert into allowonly_ext(ext_name) values (@extName)";
        //    string deleteIgnoreExtStr = "delete from ignore_ext";
        //    string insertIgnoreExtStr = "insert into ignore_ext(ext_name) values (@extName)";
        //    using (var cn = dbc.Connect())
        //    {
        //        cn.Open();
        //        using (var cmd1 = new SQLiteCommand(updateOptionStr, cn))
        //        using (var cmd2 = new SQLiteCommand(deleteAllowOnlyExtStr, cn))
        //        using (var cmd3 = new SQLiteCommand(insertAllowOnlyExtStr, cn))
        //        using (var cmd4 = new SQLiteCommand(deleteIgnoreExtStr, cn))
        //        using (var cmd5 = new SQLiteCommand(insertIgnoreExtStr, cn))
        //        {
        //            foreach (Option opt in options)
        //            {
        //                cmd1.Parameters.AddWithValue("@source", opt.SourcePath);
        //                cmd1.Parameters.AddWithValue("@destiny", opt.DestinyPath);
        //                cmd1.Parameters.AddWithValue("@methodId", opt.TransferMethod.Id);
        //                cmd1.Parameters.AddWithValue("@moveSubf", opt.MoveSubFolders);
        //                cmd1.Parameters.AddWithValue("@keepOrigin", opt.KeepOriginFiles);
        //                cmd1.Parameters.AddWithValue("@cleanDestinyDir", opt.CleanDestinyDirectory);
        //                cmd1.Parameters.AddWithValue("@allowIgnoreFileExt", opt.AllowIgnoreFileExt);
        //                cmd1.Parameters.AddWithValue("@profileId", opt.Profile.Id);
        //                cmd1.Parameters.AddWithValue("@optId", opt.Id);
        //                try
        //                {
        //                    cmd1.ExecuteNonQuery();
        //                    cmd2.ExecuteNonQuery();
        //                    if(opt.AllowOnlyFileExtensions.Count > 0)
        //                    {
        //                        foreach(AllowOnlyFileExtension ext in opt.AllowOnlyFileExtensions)
        //                        {
        //                            cmd3.Parameters.AddWithValue("@extName", ext.ExtensionName);
        //                            cmd3.ExecuteNonQuery();
        //                        }
        //                    }
        //                    cmd4.ExecuteNonQuery();
        //                    if(opt.IgnoredFileExtensions.Count > 0)
        //                    {
        //                        foreach (IgnoredFilenameExtension ext in opt.IgnoredFileExtensions)
        //                        {
        //                            cmd5.Parameters.AddWithValue("@extName", ext.ExtensionName);
        //                            cmd5.ExecuteNonQuery();
        //                        }
        //                    }
        //                }
        //                catch (Exception e)
        //                {
        //                    throw e;
        //                }
        //            }
        //        }
        //    }
        //}

        public void UpdateOption(Option opt)
        {            
            string updateOptionStr = "update option set opt_listview_index=@listviewIndex," +
                "opt_source_path=@source,opt_destiny_path=@destiny,method_id=@methodId," +
                "opt_move_subfolders=@moveSubf,opt_keep_origin_files=@keepOrigin," +
                "opt_clean_destiny_dir=@cleanDestinyDir,opt_delete_uncommon_files=" +
                "@deleteUncommonFiles,opt_allowignore_file_ext=@allowIgnoreFileExt where " +
                "profile_id=@profileId and opt_id=@optId";
            string deleteAllowOnlyExtStr = "delete from allowonly_ext where opt_id = @id";
            string insertAllowOnlyExtStr = "insert into allowonly_ext(opt_id,ext_name) values " +
                "(@id,@extName)";
            string deleteIgnoreExtStr = "delete from ignore_ext where opt_id = @id";
            string insertIgnoreExtStr = "insert into ignore_ext(opt_id,ext_name) values " +
                "(@id,@extName)";
            using (var cn = dbc.Connect())
            {
                cn.Open();
                using (var cmd1 = new SQLiteCommand(updateOptionStr, cn))
                using (var cmd2 = new SQLiteCommand(deleteAllowOnlyExtStr, cn))
                using (var cmd3 = new SQLiteCommand(insertAllowOnlyExtStr, cn))
                using (var cmd4 = new SQLiteCommand(deleteIgnoreExtStr, cn))
                using (var cmd5 = new SQLiteCommand(insertIgnoreExtStr, cn))
                {

                    cmd1.Parameters.AddWithValue("@listviewIndex", opt.ListViewIndex);
                    cmd1.Parameters.AddWithValue("@source", opt.SourcePath);
                    cmd1.Parameters.AddWithValue("@destiny", opt.DestinyPath);
                    cmd1.Parameters.AddWithValue("@methodId", opt.TransferMethod.Id);
                    cmd1.Parameters.AddWithValue("@moveSubf", opt.MoveSubFolders);
                    cmd1.Parameters.AddWithValue("@keepOrigin", opt.KeepOriginFiles);
                    cmd1.Parameters.AddWithValue("@cleanDestinyDir", opt.CleanDestinyDirectory);
                    cmd1.Parameters.AddWithValue("@allowIgnoreFileExt", opt.AllowIgnoreFileExt);
                    cmd1.Parameters.AddWithValue("@deleteUncommonFiles", opt.DeleteUncommonFiles);
                    cmd1.Parameters.AddWithValue("@profileId", opt.Profile.Id);
                    cmd1.Parameters.AddWithValue("@optId", opt.Id);

                    cmd2.Parameters.AddWithValue("@id", opt.Id);
                    cmd4.Parameters.AddWithValue("@id", opt.Id);

                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery(); //-- DELETE ALL FROM ALLOWONLY_EXT
                    cmd4.ExecuteNonQuery(); //-- DELETE ALL FROM IGNORE_EXT
                    
                    if (opt.AllowOnlyFileExtensions.Count > 0)
                    {
                        foreach (FileExtension ext in opt.AllowOnlyFileExtensions)
                        {
                            cmd3.Parameters.AddWithValue("@id", opt.Id);
                            cmd3.Parameters.AddWithValue("@extName", ext.ExtensionName);
                            cmd3.ExecuteNonQuery();
                        }
                    }
                    else if (opt.IgnoredFileExtensions.Count > 0)
                    {
                        foreach (FileExtension ext in opt.IgnoredFileExtensions)
                        {
                            cmd5.Parameters.AddWithValue("@id", opt.Id);
                            cmd5.Parameters.AddWithValue("@extName", ext.ExtensionName);
                            cmd5.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void UpdateOptionListViewIndex(Option opt)
        {
            string updateOptionStr = "update option set opt_listview_index=@listviewIndex " +
                "where opt_id=@optId";

            using (var cn = dbc.Connect())
            {
                cn.Open();
                using (var cmd1 = new SQLiteCommand(updateOptionStr, cn))
                {

                    cmd1.Parameters.AddWithValue("@listviewIndex", opt.ListViewIndex);
                    cmd1.Parameters.AddWithValue("@optId", opt.Id);

                    cmd1.ExecuteNonQuery();
                }
            }
        }

        public List<Option> ListProfileOptions(Profile prof)
        {
            List<Option> options = new List<Option>();
            string optionQuery = "select opt_id,opt_listview_index,opt_source_path,opt_destiny_path," +
                "method_id,opt_move_subfolders,opt_keep_origin_files,opt_clean_destiny_dir," +
                "opt_delete_uncommon_files,opt_allowignore_file_ext from option where " +
                "profile_id=@profileId";
            string AllowOnlyExtQueryStr = "select extallowonly_id,ext_name from allowonly_ext where opt_id =@optId";
            string IgnoreExtQueryStr = "select extignore_id,ext_name from ignore_ext where opt_id = @optId";
            string methodQuery = "select method_id,method_text from transfer_method where method_id =@methodId";
            using (var cn = dbc.Connect())
            {
                cn.Open();
                using (var cmd1 = new SQLiteCommand(optionQuery, cn))
                using (var cmd2 = new SQLiteCommand(AllowOnlyExtQueryStr, cn))
                using (var cmd3 = new SQLiteCommand(IgnoreExtQueryStr, cn))
                using (var cmd4 = new SQLiteCommand(methodQuery,cn))
                {
                    cmd1.Parameters.AddWithValue("@profileId", prof.Id);

                    using (SQLiteDataReader reader1 = cmd1.ExecuteReader())
                    {
                        while (reader1.Read())
                        {
                            Option opt = new Option();
                            List<FileExtension> extsAllowOnly = new List<FileExtension>();
                            List<FileExtension> extsIgnore = new List<FileExtension>();
                            TransferMethod tf = null;

                            cmd2.Parameters.AddWithValue("@optId", int.Parse(reader1["opt_id"].ToString()));
                            using (SQLiteDataReader reader2 = cmd2.ExecuteReader())
                            {
                                while (reader2.Read())
                                {
                                    FileExtension ext = new FileExtension()
                                    {
                                        Id = int.Parse(reader2["extallowonly_id"].ToString()),
                                        ExtensionName = reader2["ext_name"].ToString(),
                                        Option = opt
                                    };
                                    extsAllowOnly.Add(ext);
                                }
                            }
                            cmd3.Parameters.AddWithValue("@optId", int.Parse(reader1["opt_id"].ToString()));
                            using (SQLiteDataReader reader3 = cmd3.ExecuteReader())
                            {
                                while (reader3.Read())
                                {
                                    FileExtension ext = new FileExtension
                                    {
                                        Id = int.Parse(reader3["extignore_id"].ToString()),
                                        ExtensionName = reader3["ext_name"].ToString(),
                                        Option = opt
                                    };
                                    extsIgnore.Add(ext);
                                }
                            }
                            cmd4.Parameters.AddWithValue("@methodId", int.Parse(reader1["method_id"].ToString()));
                            using (SQLiteDataReader reader4 = cmd4.ExecuteReader()) {
                                if (reader4.Read())
                                {
                                    tf = new TransferMethod()
                                    {
                                        Id = int.Parse(reader4["method_id"].ToString()),
                                        MethodName = reader4["method_text"].ToString()
                                    };
                                }
                            }

                            opt.Profile = prof;
                            opt.Id = int.Parse(reader1["opt_id"].ToString());
                            opt.ListViewIndex = int.Parse(reader1["opt_listview_index"].ToString());
                            opt.SourcePath = reader1["opt_source_path"].ToString();
                            opt.DestinyPath = reader1["opt_destiny_path"].ToString();
                            opt.MoveSubFolders = Convert.ToBoolean(int.Parse(reader1["opt_move_subfolders"].ToString()));
                            opt.KeepOriginFiles = Convert.ToBoolean(int.Parse(reader1["opt_keep_origin_files"].ToString()));
                            opt.CleanDestinyDirectory = Convert.ToBoolean(int.Parse(reader1["opt_clean_destiny_dir"].ToString()));
                            opt.DeleteUncommonFiles = Convert.ToBoolean(int.Parse(reader1["opt_delete_uncommon_files"].ToString()));
                            opt.AllowIgnoreFileExt = Convert.ToBoolean(int.Parse(reader1["opt_allowignore_file_ext"].ToString()));
                            opt.AllowOnlyFileExtensions = extsAllowOnly;
                            opt.IgnoredFileExtensions = extsIgnore;
                            opt.TransferMethod = tf;

                            options.Add(opt);
                        }
                    }
                }
            }
            return options;
        }

        public void DeleteOption(Option option)
        {
            string queryDeleteOpt = "delete from option where opt_id=@optId";
            string deleteAllowOnlyExtStr = "delete from allowonly_ext where opt_id = @id";
            string deleteIgnoreExtStr = "delete from ignore_ext where opt_id = @id";

            using (var cn = dbc.Connect())
            {
                cn.Open();
                using (var cmdOpt = new SQLiteCommand(queryDeleteOpt, cn))
                using (var cmdDeleteAllowOnlyExt = new SQLiteCommand(deleteAllowOnlyExtStr, cn))
                using (var cmdDeleteIgnoreExt = new SQLiteCommand(deleteIgnoreExtStr, cn))
                {
                    try
                    {
                        cmdDeleteAllowOnlyExt.Parameters.AddWithValue("@id", option.Id);
                        cmdDeleteIgnoreExt.Parameters.AddWithValue("@id", option.Id);
                        cmdOpt.Parameters.AddWithValue("@optId", option.Id);
                        cmdDeleteAllowOnlyExt.ExecuteNonQuery();
                        cmdDeleteIgnoreExt.ExecuteNonQuery();
                        cmdOpt.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }
    }

    public class TransferMethodAccess
    {
        private DBConnection dbc = new DBConnection();

        public List<TransferMethod> ListMethods()
        {
            List<TransferMethod> tml = new List<TransferMethod>();
            string query = "select method_id,method_text from transfer_method";
            using(var cn = dbc.Connect())
            {
                cn.Open();
                using(var cmd = new SQLiteCommand(query, cn))
                {
                    using(var result = cmd.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            TransferMethod tm = new TransferMethod()
                            {
                                Id = int.Parse(result["method_id"].ToString()),
                                MethodName = result["method_text"].ToString()
                            };
                            tml.Add(tm);
                        }
                    }
                }
            }
            return tml;
        }

        public TransferMethod GetTransferMethod(int id)
        {
            TransferMethod tm = null;
            string query = "select method_id,method_text from transfer_method where method_id=@id";
            using (var cn = dbc.Connect())
            {
                cn.Open();
                using (var cmd = new SQLiteCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var result = cmd.ExecuteReader())
                    {
                        if (result.Read())
                        {
                            tm = new TransferMethod()
                            {
                                Id = int.Parse(result["method_id"].ToString()),
                                MethodName = result["method_text"].ToString()
                            };
                        }
                    }
                }
            }
            return tm;
        }
    }

    public class DBConnection
    {
        public SQLiteConnection Connect()
        {
            SQLiteConnection cn = null;
            try
            {
                cn = new SQLiteConnection("data source=" + Program.DBPath);
            }
            catch (Exception e)
            {
                throw e;
            }
            return cn;
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
