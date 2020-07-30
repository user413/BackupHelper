using BackupHelper.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackupHelper
{
    public class FileControl
    {
        public List<TransferedFilesReport> TransFilesReports { get; set; }
        public List<NotTransferedFilesReport> NotTransFilesReports { get; set; }
        public List<RenamedFilesReport> RenamedFilesReports { get; set; }
        public List<CreatedDirectoriesReport> CreatedDirReports { get; set; }
        public List<ReplacedFilesReport> ReplacedFilesReports { get; set; }
        public List<RemovedFilesAndDirectoriesReport> RemovedFilesAndDirReports { get; set; }

        public bool CancelExecution { get; set; }
        public bool JumpFileExecution { get; set; }
        public bool RepeatFileExecution { get; set; }

        private readonly FormOptionsMenu OptionsMenu;

        public FileControl(FormOptionsMenu menu)
        {
            TransFilesReports = new List<TransferedFilesReport>();
            NotTransFilesReports = new List<NotTransferedFilesReport>();
            RenamedFilesReports = new List<RenamedFilesReport>();
            CreatedDirReports = new List<CreatedDirectoriesReport>();
            ReplacedFilesReports = new List<ReplacedFilesReport>();
            RemovedFilesAndDirReports = new List<RemovedFilesAndDirectoriesReport>();

            CancelExecution = false;

            this.OptionsMenu = menu;
        }

        //private string originPath;
        //private string destinyPath;
        //private bool moveSubFolders;
        //private bool keepOriginFiles;

        //public FileControl(string originPath, string destinyPath, bool moveSubFolders, bool keepOriginFiles)
        //{
        //    this.originPath = originPath;
        //    this.destinyPath = destinyPath;
        //    this.moveSubFolders = moveSubFolders;
        //    this.keepOriginFiles = keepOriginFiles;
        //}

        public void ManageFiles(Option option)
        {
            bool AllowOnlyExt = false;
            bool IgnoreExt = false;

            if (!this.CancelExecution)
            {
                LogManager.WriteLine("## Transfering from: " + option.SourcePath);
                LogManager.WriteLine("## To: " + option.DestinyPath);
                LogManager.WriteLine("## "+option.TransferMethod.MethodName);
                switch (option.TransferMethod.Id)
                {
                    case (int)TransferMethodType.TYPE_DO_NOT_MOVE:
                        LogManager.WriteLine("## For repeated filenames: do not move");
                        break;
                    case (int)TransferMethodType.TYPE_REPLACE_ALL:
                        LogManager.WriteLine("## For repeated filenames: replace all");
                        break;
                    case (int)TransferMethodType.TYPE_REPLACE_DIFFERENT:
                        LogManager.WriteLine("## For repeated filenames: replace unique files (binary comparison)");
                        break;
                    case (int)TransferMethodType.TYPE_RENAME_DIFFERENT:
                        LogManager.WriteLine("## For repeated filenames: rename unique files (binary comparison)");
                        break;
                }
                LogManager.WriteLine("## Include subfolders: " + option.MoveSubFolders);
                LogManager.WriteLine("## Keep Files: " + option.KeepOriginFiles);
                LogManager.WriteLine("## Clean destiny: " + option.CleanDestinyDirectory);
                LogManager.WriteLine("## Delete uncommon: " + option.DeleteUncommonFiles);
                LogManager.WriteLine("## Manage extensions: " + option.AllowIgnoreFileExt);

                if (option.AllowOnlyFileExtensions.Count > 0)
                    AllowOnlyExt = true;
                else
                    IgnoreExt = true;
            }

            string[] originFiles = null;
            string[] originDirectories = null;
            List<string> trimmedFiles = new List<string>();
            List<string> trimmedDirectories = new List<string>();
            string[] destinyFiles = null;
            string[] destinyDirectories = null;

            try
            {
                LogManager.WriteLine("Generating files and directories lists...");

                if(option.MoveSubFolders || !option.KeepOriginFiles)
                    originDirectories = Directory.GetDirectories(option.SourcePath, "*", SearchOption.AllDirectories);

                if (option.MoveSubFolders)
                {
                    originFiles = Directory.GetFiles(option.SourcePath, "*", SearchOption.AllDirectories);

                    if (option.DeleteUncommonFiles)
                    {
                        destinyDirectories = Directory.GetDirectories(option.DestinyPath, "*", SearchOption.AllDirectories);
                        destinyFiles = Directory.GetFiles(option.DestinyPath, "*", SearchOption.AllDirectories);
                    }
                }
                else
                {
                    originFiles = Directory.GetFiles(option.SourcePath, "*", SearchOption.TopDirectoryOnly);

                    if (option.DeleteUncommonFiles)
                        destinyFiles = Directory.GetFiles(option.DestinyPath, "*", SearchOption.TopDirectoryOnly);
                }

                //-- GENERATING COMMON TRIMMED FILE PATHS
                foreach (string file in originFiles)
                    trimmedFiles.Add(file.Replace(option.SourcePath, ""));
                if(option.MoveSubFolders) foreach (string originDirectory in originDirectories)
                    trimmedDirectories.Add(originDirectory.Replace(option.SourcePath, ""));
            }
            catch (Exception e)
            {
                LogManager.WriteLine($"Error: {e} when retrieving files/directories lists");
                throw;
            }

            if (!this.CancelExecution)
            {
                if (option.CleanDestinyDirectory)
                {
                    LogManager.WriteLine("Cleaning destiny directory...");
                    try
                    {
                        if (Directory.Exists(option.DestinyPath))
                        {
                            DirectoryInfo dir = new DirectoryInfo(option.DestinyPath);
                            foreach (FileInfo file in dir.GetFiles())
                            {
                                file.Delete();
                                LogManager.WriteLine($"File deleted: {file.Name}");
                            }
                            foreach (DirectoryInfo subdirs in dir.GetDirectories())
                            {
                                subdirs.Delete(true);
                                LogManager.WriteLine($"Folder deleted: {subdirs.Name}");
                            }
                            //for each (string dire in Directory.GetDirectories(option.DestinyPath, "*", SearchOption.AllDirectories)) Directory.Delete(dire);
                        }
                    }
                    catch (Exception e)
                    {
                        LogManager.WriteLine($"Error: {e.ToString()} when cleaning destiny directory");
                        throw;
                    }
                }
                try
                {
                    LogManager.WriteLine("Creating directories...");
                    if (!Directory.Exists(option.DestinyPath))
                    {
                        try
                        {
                            Directory.CreateDirectory(option.DestinyPath);
                            CreatedDirReports.Add(new CreatedDirectoriesReport
                            {
                                Directory = option.DestinyPath,
                                Origin = "None (created)"
                            });
                            LogManager.WriteLine($"Directory created: " + option.DestinyPath);
                        }
                        catch (Exception e)
                        {
                            LogManager.WriteLine($"Error: {e.ToString()} when creating the directory {option.DestinyPath}");
                            throw new Exception($"An error has occurred when creating the directory {option.DestinyPath}. {e.Message} Aborting.");
                        }
                    }
                    if (option.MoveSubFolders)
                    {
                        foreach (string trimmedDirectory in trimmedDirectories)
                        {
                            if (!Directory.Exists(option.DestinyPath + trimmedDirectory))
                            {
                                try
                                {
                                    Directory.CreateDirectory(option.DestinyPath + trimmedDirectory);
                                    CreatedDirReports.Add(new CreatedDirectoriesReport
                                    {
                                        Directory = option.DestinyPath + trimmedDirectory,
                                        Origin = option.SourcePath + trimmedDirectory
                                    });
                                    LogManager.WriteLine($"Directory created: " + option.DestinyPath + trimmedDirectory);
                                }
                                catch (Exception e)
                                {
                                    LogManager.WriteLine($"Error: {e.ToString()} when creating the directory {option.DestinyPath + trimmedDirectory}");
                                    throw new Exception($"An error has occurred when creating the directory {option.DestinyPath + trimmedDirectory}. {e.Message} Aborting");
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    foreach (string trimmedFile in trimmedFiles)
                    {
                        NotTransFilesReports.Add(new NotTransferedFilesReport
                        {
                            File = option.SourcePath + trimmedFile,
                            Destiny = option.DestinyPath + trimmedFile.Substring(0, trimmedFile.LastIndexOf("\\")),
                            Reason = "Canceled"
                        });
                    }
                    throw;
                }

                LogManager.WriteLine("Transfering files..."); 
            }

            foreach (string trimmedPathWithFileName in trimmedFiles)
            {
                string originPathWithFileName = option.SourcePath + trimmedPathWithFileName;
                string destinyPathWithFileName = option.DestinyPath + trimmedPathWithFileName;
                string destinyPathWOFileName = option.DestinyPath + trimmedPathWithFileName.Substring(0, trimmedPathWithFileName.LastIndexOf("\\"));
                string currentFileName = trimmedPathWithFileName.Substring(trimmedPathWithFileName.LastIndexOf("\\") + 1);

                if (this.CancelExecution)
                {
                    NotTransFilesReports.Add(new NotTransferedFilesReport
                    {
                        File = originPathWithFileName,
                        Destiny = destinyPathWOFileName,
                        Reason = "Canceled"
                    });
                    continue;
                }

                OptionsMenu.ShowCurrentFileExecution(currentFileName);
                //System.Threading.Thread.Sleep(5000);

                //-- MANAGING EXTENSIONS
                if (option.AllowIgnoreFileExt)
                {
                    if (AllowOnlyExt)
                    {
                        string ext = Path.GetExtension(trimmedPathWithFileName);
                        if (option.AllowOnlyFileExtensions.Find(x => x.ExtensionName.Equals(ext,StringComparison.OrdinalIgnoreCase)) == null)
                        {
                            NotTransFilesReports.Add(new NotTransferedFilesReport
                            {
                                File = originPathWithFileName,
                                Destiny = destinyPathWOFileName,
                                Reason = $"File extension ignored ({ext})"
                            });
                            LogManager.WriteLine($"Filename extension ignored. File not transfered:\"'{originPathWithFileName}\" as \"{destinyPathWithFileName}\"");
                            continue;
                        }
                    }
                    else if (IgnoreExt)
                    {
                        string ext = Path.GetExtension(trimmedPathWithFileName);
                        if (option.IgnoredFileExtensions.Find(x => x.ExtensionName.Equals(ext,StringComparison.OrdinalIgnoreCase)) != null)
                        {
                            NotTransFilesReports.Add(new NotTransferedFilesReport
                            {
                                File = originPathWithFileName,
                                Destiny = destinyPathWOFileName,
                                Reason = $"File extension ignored ({ext})"
                            });
                            LogManager.WriteLine($"Filename extension ignored. File not ransfered: \"{originPathWithFileName}\" as \"{destinyPathWithFileName}\"");
                            continue;
                        }
                    }
                }

                do
                    TransferFile(option, originPathWithFileName, destinyPathWithFileName, destinyPathWOFileName);
                while (this.RepeatFileExecution);
            }

            //-- DELETING ORIGIN DIRECTORIES
            if (!option.KeepOriginFiles && !this.CancelExecution)
            {
                LogManager.WriteLine("Cleaning origin directories...");
                try
                {
                    foreach (string entry in originDirectories.Reverse().ToList())
                    {
                        if (Directory.Exists(entry))
                        {
                            Directory.Delete(entry,true);

                            RemovedFilesAndDirReports.Add(new RemovedFilesAndDirectoriesReport
                            {
                                Entry = entry,
                                Description = "Removed origin directory"
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    LogManager.WriteLine($"Error: {e} when deleting origin directories.");
                    //LogManager.WriteLine($"Error: {e.ToString()} when deleting directory \"{entry}\"");
                    //this.OptionsMenu.ShowErrorDialog($"Couldn't delete directory \"{entry}\": {e.Message}");
                    throw;
                }
            }

            //-- DELETING UNCOMMON DESTINY FILES AND DIRECTORIES
            if (option.DeleteUncommonFiles && !option.CleanDestinyDirectory && !this.CancelExecution)
            {
                try
                {
                    foreach (string destinyFile in destinyFiles)
                    {
                        string trimmedDestinyFile = destinyFile.Replace(option.DestinyPath, "");
                        if (trimmedFiles.Find(x => x.Equals(trimmedDestinyFile,StringComparison.OrdinalIgnoreCase)) == null)
                        {
                            if (File.Exists(destinyFile))
                            {
                                File.Delete(destinyFile);
                                RemovedFilesAndDirReports.Add(new RemovedFilesAndDirectoriesReport
                                {
                                    Entry = destinyFile,
                                    Description = "Removed uncommon destiny file"
                                });
                            }
                        }
                    }
                    if (option.MoveSubFolders)
                    {
                        foreach (string destinyDirectory in destinyDirectories.Reverse().ToList())
                        {
                            string trimmedDestinyDirectory = destinyDirectory.Replace(option.DestinyPath, "");
                            if (trimmedDirectories.Find(x => x.Equals(trimmedDestinyDirectory,StringComparison.OrdinalIgnoreCase)) == null)
                            {
                                if (Directory.Exists(destinyDirectory))
                                {
                                    Directory.Delete(destinyDirectory);
                                    RemovedFilesAndDirReports.Add(new RemovedFilesAndDirectoriesReport
                                    {
                                        Entry = destinyDirectory,
                                        Description = "Removed uncommon destiny directory"
                                    });
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    LogManager.WriteLine($"Error: {e.ToString()} when deleting uncommon destiny files and directories.");
                    throw;
                }
            }
        }

        void TransferFile(Option option,string originPathWithFileName,string destinyPathWithFileName,
            string destinyPathWOFileName)
        {
            if (this.JumpFileExecution) this.JumpFileExecution = false;
            if (this.RepeatFileExecution) this.RepeatFileExecution = false;

            if (!File.Exists(destinyPathWithFileName))
            {
                try
                {
                    if (option.KeepOriginFiles)
                    {
                        File.Copy(originPathWithFileName, destinyPathWithFileName);
                    }
                    else
                    {
                        File.Move(originPathWithFileName, destinyPathWithFileName);
                        RemovedFilesAndDirReports.Add(new RemovedFilesAndDirectoriesReport
                        {
                            Entry = originPathWithFileName,
                            Description = "Removed origin file"
                        });
                    }

                    TransFilesReports.Add(new TransferedFilesReport
                    {
                        File = originPathWithFileName,
                        Destiny = destinyPathWOFileName
                    });
                    LogManager.WriteLine($"Transfered file: \"{originPathWithFileName}\" to \"{destinyPathWOFileName}\"");
                }
                catch (Exception e)
                {
                    LogManager.WriteLine($"Error: {e.ToString()} when transfering \"{originPathWithFileName}\" to \"{destinyPathWOFileName}\"");
                    if (File.Exists(destinyPathWithFileName))
                    {
                        try
                        {
                            File.Delete(destinyPathWithFileName);
                            LogManager.WriteLine($"File deleted for safety: \"{destinyPathWithFileName}\"");
                        }
                        catch (Exception e1)
                        {
                            LogManager.WriteLine($"Error: {e1.ToString()} when deleting \"{destinyPathWithFileName}\"");
                        }
                    }

                    //throw new Exception($"An error has occurred when transfering the file: '{option.DestinyPath + destiny}'. {e.Message}");
                    this.OptionsMenu.ShowErrorDialog($"An error has occurred when transfering the file \"{originPathWithFileName}\" to \"{destinyPathWOFileName}\": {e.Message}", true);
                    if (this.RepeatFileExecution) return;

                    NotTransFilesReports.Add(new NotTransferedFilesReport
                    {
                        File = originPathWithFileName,
                        Destiny = destinyPathWOFileName,
                        Reason = "Error: " + e.Message
                    });
                }
            }
            else
            {
                switch (option.TransferMethod.Id)
                {
                    case (int)TransferMethodType.TYPE_DO_NOT_MOVE:
                        HandleFilenameConflictDoNotReplaceFiles(originPathWithFileName, destinyPathWithFileName, destinyPathWOFileName);
                        break;
                    case (int)TransferMethodType.TYPE_REPLACE_ALL:
                        HandleFilenameConflictReplaceAllFiles(originPathWithFileName, destinyPathWithFileName, destinyPathWOFileName);
                        break;
                    case (int)TransferMethodType.TYPE_REPLACE_DIFFERENT:
                        HandleFilenameConflictReplaceUniqueFiles(originPathWithFileName, destinyPathWithFileName, destinyPathWOFileName);
                        break;
                    case (int)TransferMethodType.TYPE_RENAME_DIFFERENT:
                        HandleFilenameConflictRenameUniqueFiles(originPathWithFileName, destinyPathWithFileName, destinyPathWOFileName);
                        break;
                }

                //-- DELETING ORIGIN FILE
                if (!option.KeepOriginFiles && !this.CancelExecution && !this.JumpFileExecution && !this.RepeatFileExecution)
                {
                    try
                    {
                        if (File.Exists(originPathWithFileName))
                        {
                            File.Delete(originPathWithFileName);

                            RemovedFilesAndDirReports.Add(new RemovedFilesAndDirectoriesReport
                            {
                                Entry = originPathWithFileName,
                                Description = "Removed origin file"
                            });
                        }
                    }
                    catch (Exception e)
                    {
                        LogManager.WriteLine($"Error: {e.ToString()} when deleting the source file \"{originPathWithFileName}\"");
                        //throw new Exception($"An error has occurred when deleting the source file '{entry}'. {e.Message}");
                        this.OptionsMenu.ShowErrorDialog($"An error has occurred when deleting the source file \"{originPathWithFileName}\". {e.Message}", false);
                    }
                }

                //if (this.CancelExecution) LogManager.WriteLine("Canceling operation...");
            }
        }

        private void HandleFilenameConflictDoNotReplaceFiles(string originPathWithFileName, string destinyPathWithFileName, string destinyPathWOFileName)
        {
            NotTransFilesReports.Add(new NotTransferedFilesReport
            {
                File = originPathWithFileName,
                Destiny = destinyPathWOFileName,
                Reason = "Repeated name"
            });
            LogManager.WriteLine($"Conflicted filename. File not moved: \"{originPathWithFileName}\" as \"{destinyPathWithFileName}\"");
        }

        private void HandleFilenameConflictReplaceAllFiles(string originPathWithFileName, string destinyPathWithFileName, string destinyPathWOFileName)
        {
            //try
            //{
            //    FileInfo bkp = new FileInfo(destinyPath + destiny);
            //    bkp.CopyTo(destinyPath + destiny + ".bac", true);
            //}
            //catch (Exception e)
            //{
            //    NotTransFilesReports.Add(new NotTransferedFilesReport
            //    {
            //        File = entry,
            //        Destiny = destinyPath + destiny.Substring(0, destiny.LastIndexOf("\\")),
            //        Reason = "Error: " + e.Message
            //    });
            //    LogManager.WriteLine($"Error: {e.ToString()} when creating a backup file (.bac) for '{destinyPath + destiny}'");
            //    try
            //    {
            //        //if(File.Exists(destinyPath + destiny + ".bac"))
            //        File.Delete(destinyPath + destiny + ".bac");
            //    }
            //    catch (Exception) { }
            //    throw new Exception($"An error has occurred when creating a backup file (.bac) for '{destinyPath + destiny}'. {e.Message} Aborting.");
            //}
            FileInfo sourceFile = new FileInfo(originPathWithFileName);
            try
            {
                sourceFile.CopyTo(destinyPathWithFileName, true);
                //File.Replace(entry, destinyPath + destiny, destinyPath + destiny + ".bac", false);
                //File.Delete(destinyPath + destiny);
                //File.Copy(entry, destinyPath + destiny);
                ReplacedFilesReports.Add(new ReplacedFilesReport
                {
                    File = originPathWithFileName,
                    Destiny = destinyPathWOFileName
                });
                LogManager.WriteLine($"File replaced: \"{destinyPathWithFileName}\"");
            }
            catch (Exception e)
            {
                LogManager.WriteLine($"Error: {e.ToString()} when replacing \"{destinyPathWithFileName}\"");
                //if (File.Exists(destinyPath + destiny + ".bac"))
                //{
                    if (File.Exists(destinyPathWithFileName))
                    {
                        try
                        {
                            File.Delete(destinyPathWithFileName);
                            LogManager.WriteLine($"File deleted for safety: \"{destinyPathWithFileName}\"");
                        }
                        catch (Exception e1)
                        {
                            LogManager.WriteLine($"Error: {e1.ToString()} when deleting \"{destinyPathWithFileName}\" as safety procedure");
                        }
                    }

                //try
                //{
                //    File.Move(destinyPath + destiny + ".bac", destinyPath + destiny);
                //    LogManager.WriteLine($"Original file restored: '{destinyPath + destiny}' from backup file");
                //}
                //catch (Exception e1)
                //{
                //    LogManager.WriteLine($"Error: {e1.ToString()} when restoring file '{destinyPath + destiny}' from backup");
                //}
                //}
                //else
                //{
                //    LogManager.WriteLine($"Backup file could not be found '{destinyPath + destiny}.bac'. Couldn't restore original file");
                //}
                //throw new Exception($"An error has occurred when when replacing \"{destinyPath + destiny}\": {e.Message}");
                
                this.OptionsMenu.ShowErrorDialog($"An error has occurred when when replacing \"{destinyPathWithFileName}\": {e.Message}",true);
                if (this.RepeatFileExecution) return;
                
                NotTransFilesReports.Add(new NotTransferedFilesReport
                {
                    File = originPathWithFileName,
                    Destiny = destinyPathWOFileName,
                    Reason = "Error: " + e.Message
                });
            }
            //try
            //{
            //    File.Delete(destinyPath + destiny + ".bac");
            //}
            //catch (Exception e)
            //{
            //    LogManager.WriteLine($"Error: {e.ToString()} when deleting the backup file '{destinyPath + destiny}.bac'");
            //    throw new Exception($"An error has occurred when deleting the backup file (.bac) for '{destinyPath + destiny}'. {e.Message} Aborting.");
            //}
        }

        private void HandleFilenameConflictReplaceUniqueFiles(string originPathWithFileName, string destinyPathWithFileName, string destinyPathWOFileName)
        {
            bool filesAreTheSame = false;
            try
            {
                filesAreTheSame = FileEquals(originPathWithFileName, destinyPathWithFileName);
            }
            catch (Exception)
            {
                //this.OptionsMenu.ShowErrorDialog($"An error occurred when comparing files: \"{originPathWithFileName}\" and \"{destinyPathWithFileName}\". {e.Message}",true);
                return;
            }

            if (!filesAreTheSame)
            {
                //try
                //{
                //    FileInfo bkp = new FileInfo(destinyPath + destiny);
                //    bkp.CopyTo(destinyPath + destiny + ".bac", true);
                //}
                //catch (Exception e)
                //{
                //    NotTransFilesReports.Add(new NotTransferedFilesReport
                //    {
                //        File = entry,
                //        Destiny = destinyPath + destiny.Substring(0, destiny.LastIndexOf("\\")),
                //        Reason = "Error: " + e.Message
                //    });
                //    LogManager.WriteLine($"Error: {e.ToString()} when creating backup file (.bac) for '{destinyPath + destiny}'");
                //    try
                //    {
                //        //if(File.Exists(destinyPath + destiny + ".bac"))
                //        File.Delete(destinyPath + destiny + ".bac");
                //    }
                //    catch (Exception) { }
                //    throw new Exception($"An error has occurred when creating a backup file (.bac) for '{destinyPath + destiny}'. {e.Message} Aborting.");
                //}
                FileInfo sourceFile = new FileInfo(originPathWithFileName);
                try
                {
                    sourceFile.CopyTo(destinyPathWithFileName, true);
                    //File.Delete(destinyPath + destiny);
                    //File.Copy(entry, destinyPath + destiny);
                    //File.Replace(entry, destinyPath + destiny, destinyPath + destiny + ".bac", false);
                    ReplacedFilesReports.Add(new ReplacedFilesReport
                    {
                        File = originPathWithFileName,
                        Destiny = destinyPathWOFileName
                    });
                    LogManager.WriteLine($"Replaced file: \"{destinyPathWithFileName}\"");
                }
                catch (Exception e)
                {
                    LogManager.WriteLine($"Error: {e.ToString()} when replacing \"{destinyPathWithFileName}\"");
                    //if (File.Exists(destinyPath + destiny + ".bac"))
                    //{
                    if (File.Exists(destinyPathWithFileName))
                    {
                        try
                        {
                            File.Delete(destinyPathWithFileName);
                            LogManager.WriteLine($"File deleted for safety: \"{destinyPathWithFileName}\"");
                        }
                        catch (Exception e1)
                        {
                            LogManager.WriteLine($"Error: {e1.ToString()} when deleting \"{destinyPathWithFileName}\" as safety procedure");
                        }
                    }
                    //try
                    //{
                    //    File.Move(destinyPath + destiny + ".bac", destinyPath + destiny);
                    //    LogManager.WriteLine($"Original file restored: '{destinyPath + destiny}' from backup file");
                    //}
                    //catch (Exception e1)
                    //{
                    //    LogManager.WriteLine($"Error: {e1.ToString()} when restoring file '{destinyPath + destiny}' from backup");
                    //}
                    //}
                    //else
                    //{
                    //    LogManager.WriteLine($"Backup file could not be found '{destinyPath + destiny}.bac'. Couldn't restore original file");
                    //}

                    //throw new Exception($"An error has occurred when replacing the file: \"{destinyPath + destiny}\": {e.Message}");
                    this.OptionsMenu.ShowErrorDialog($"An error has occurred when replacing the file: \"{destinyPathWithFileName}\": {e.Message}",true);
                    if (this.RepeatFileExecution) return;

                    NotTransFilesReports.Add(new NotTransferedFilesReport
                    {
                        File = originPathWithFileName,
                        Destiny = destinyPathWOFileName,
                        Reason = "Error: " + e.Message
                    });
                }
                //try
                //{
                //    File.Delete(destinyPath + destiny + ".bac");
                //}
                //catch (Exception e)
                //{
                //    LogManager.WriteLine($"Error: {e.ToString()} when deleting the backup file '{destinyPath + destiny}.bac'");
                //    throw new Exception($"An error has occurred when deleting the backup file (.bac) for '{destinyPath + destiny}'. {e.Message} Aborting.");
                //}
            }
            else
            {
                NotTransFilesReports.Add(new NotTransferedFilesReport
                {
                    File = originPathWithFileName,
                    Destiny = destinyPathWOFileName,
                    Reason = "File already exists"
                });
                LogManager.WriteLine($"File not replaced: \"{originPathWithFileName}\" and \"{destinyPathWithFileName}\" are the same");
            }
            //}
            //catch (Exception e)
            //{
            //    this.OptionsMenu.ShowErrorDialog(e.Message);
            //}
        }

        private void HandleFilenameConflictRenameUniqueFiles(string originPathWithFileName, string destinyPathWithFileName, string destinyPathWOFileName)
        {
            bool filesAreTheSame = false;
            try
            {
                filesAreTheSame = FileEquals(originPathWithFileName, destinyPathWithFileName);
            }
            catch (Exception)
            {
                //this.OptionsMenu.ShowErrorDialog($"An error occurred when comparing files: \"{originPathWithFileName}\" and \"{destinyPathWithFileName}\". {e.Message}",true);
                return;
            }

            if (!filesAreTheSame)
            {
                string filenameExtension = destinyPathWithFileName.Substring(destinyPathWithFileName.LastIndexOf("."));

                bool i = true;
                int repetitions = 1;
                while (i)
                {
                    //try
                    string destinyPathWithNewFileName = destinyPathWithFileName.Substring(0, destinyPathWithFileName.LastIndexOf(".")) + " (" + repetitions + ")" + filenameExtension;
                    if (!File.Exists(destinyPathWithNewFileName))
                    {
                        try
                        {
                            File.Copy(originPathWithFileName, destinyPathWithNewFileName);
                            RenamedFilesReports.Add(new RenamedFilesReport
                            {
                                File = originPathWithFileName,
                                Destiny = destinyPathWithNewFileName
                            });
                            LogManager.WriteLine($"File moved and renamed: \"{originPathWithFileName}\" to \"{destinyPathWithNewFileName}\"");
                            i = false;
                        }
                        catch (Exception e)
                        {
                            LogManager.WriteLine($"Error: {e.ToString()} when moving and renaming \"{originPathWithFileName}\" to \"{destinyPathWithNewFileName}\"");
                            if (File.Exists(destinyPathWithNewFileName))
                            {
                                try
                                {
                                    File.Delete(destinyPathWithNewFileName);
                                    LogManager.WriteLine($"File deleted for safety: \"{destinyPathWithNewFileName}\"");
                                }
                                catch (Exception e1)
                                {
                                    LogManager.WriteLine($"Error: {e1.ToString()} when deleting \"{destinyPathWithNewFileName}\"as safety procedure");
                                }
                            }

                            //throw new Exception($"An error has occurred when moving and renaming the file: '{entry}' to '{newFileName}'. {e.Message}");
                            this.OptionsMenu.ShowErrorDialog($"An error has occurred when moving and renaming the file: \"{originPathWithFileName}\" to \"{destinyPathWithNewFileName}\". {e.Message}",true);
                            if (this.RepeatFileExecution) return;

                            NotTransFilesReports.Add(new NotTransferedFilesReport
                            {
                                File = originPathWithFileName,
                                Destiny = destinyPathWOFileName,
                                Reason = "Error: " + e.Message
                            });
                        }
                    }
                    //catch (IOException)
                    else
                    {
                        try
                        {
                            filesAreTheSame = FileEquals(originPathWithFileName, destinyPathWithNewFileName);
                        }
                        catch (Exception)
                        {
                            //this.OptionsMenu.ShowErrorDialog($"An error occurred when comparing files: \"{originPathWithFileName}\" and \"{destinyPathWithNewFileName}\". {e.Message}",true);
                            return;
                        }
                        if (!filesAreTheSame)
                        {
                            repetitions++;
                        }
                        else
                        {
                            NotTransFilesReports.Add(new NotTransferedFilesReport
                            {
                                File = originPathWithFileName,
                                Destiny = destinyPathWOFileName,
                                Reason = "File already exists as \"" + destinyPathWithNewFileName.Substring(destinyPathWithNewFileName.LastIndexOf("\\") + 1) + "\""
                            });
                            LogManager.WriteLine($"File not moved: {originPathWithFileName} and \"{destinyPathWithNewFileName}\" are the same");
                            i = false;
                        }
                    }
                }
            }
            else
            {
                NotTransFilesReports.Add(new NotTransferedFilesReport
                {
                    File = originPathWithFileName,
                    Destiny = destinyPathWOFileName,
                    Reason = "File already exists as \"" + destinyPathWithFileName.Substring(destinyPathWithFileName.LastIndexOf("\\") + 1) + "\""
                });
                LogManager.WriteLine($"File not moved: \"{originPathWithFileName}\" and \"{destinyPathWithFileName}\" are the same");
            }
        }

        private bool FileEquals(string file1, string file2)
        {
            try
            {
                using (FileStream s1 = new FileStream(file1, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (FileStream s2 = new FileStream(file2, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (BinaryReader b1 = new BinaryReader(s1))
                using (BinaryReader b2 = new BinaryReader(s2))
                {
                    while (true)
                    {
                        byte[] data1 = b1.ReadBytes(64 * 1024);
                        byte[] data2 = b2.ReadBytes(64 * 1024);
                        if (data1.Length != data2.Length)
                            return false;
                        if (data1.Length == 0)
                            return true;
                        if (!data1.SequenceEqual(data2))
                            return false;
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.WriteLine($"Error: {e.ToString()} when comparing files: \"{file1}\" and \"{file2}\"");
                this.OptionsMenu.ShowErrorDialog($"An error has occurred when comparing files: \"{file1}\" and \"{file2}\". {e.Message}",true);
                if (this.RepeatFileExecution) throw;

                NotTransFilesReports.Add(new NotTransferedFilesReport
                {
                    File = file1,
                    Destiny = file2.Substring(0, file2.LastIndexOf("\\")),
                    Reason = "Error: "+ e.Message
                });
                throw;// new Exception($"An error occurred when comparing files: \"{file1}\" and \"{file2}\". {e.Message}");
                //this.OptionsMenu.ShowErrorDialog(e.Message);
            }
        }

        public int FilesTotal(List<Option> options)
        {
            int fileCount = 1;
            string[] files;

            foreach (Option o in options)
            {
                if (o.MoveSubFolders == true)
                    files = Directory.GetFiles(o.SourcePath, "*", SearchOption.AllDirectories);
                else
                    files = Directory.GetFiles(o.SourcePath, "*", SearchOption.TopDirectoryOnly);

                fileCount += files.Length;
            }
            return fileCount;
        }
    }
}
