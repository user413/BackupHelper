using BackupHelper.model;
using FileControlUtility;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BackupHelper
{
    static class Program
    {
        [DllImport("Kernel32.dll")]
        static extern bool AttachConsole(int processId);

        public static string DBPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\backup_helper.db";
        public static FormProfileMenu ProfileMenu;

        //public static FileControl FC = new();
        //static bool ShowDialogs = true; //--Whether to show dialogs when running paremeter mode

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                bool showDialogs = true;
                string profileNamesStr;
                string dialogMessage;

                LogManager.BeginWritter();

                try
                {
                    if (args.Length == 1)
                        profileNamesStr = args[0];
                    else if (args.Length == 2)
                    {
                        if (!args[0].Equals("-nd", StringComparison.OrdinalIgnoreCase))
                        {
                            dialogMessage = $"Invalid parameter \"{args[0]}\". Canceled.";
                            if (showDialogs) MessageBox.Show(dialogMessage);
                            LogManager.WriteLine(dialogMessage);
                            return;
                        }

                        showDialogs = false;
                        profileNamesStr = args[1];
                    }
                    else
                    {
                        dialogMessage = "Invalid number of parameters. Canceled.";
                        LogManager.WriteLine(dialogMessage);
                        if (showDialogs) MessageBox.Show(dialogMessage);
                        return;
                    }

                    //-- Set parent process as the console
                    AttachConsole(-1);
                    LogManager.WriteLine("Starting transfer from parameters...");

                    List<Profile> profiles = DBAccess.ListProfiles();

                    if (profiles.Count == 0)

                    {
                        dialogMessage = "No profiles saved in the database. Canceled.";
                        LogManager.WriteLine(dialogMessage);
                        if (showDialogs) MessageBox.Show(dialogMessage);
                        return;
                    }

                    string[] profileNames = profileNamesStr.Split(';');
                    
                    FileControl fileControl = new();
                    ConfigureConsoleFileEvents(fileControl, showDialogs);

                    foreach (string profileName in profileNames)
                    {
                        Profile profile = profiles.Find(p => p.Name == profileName);

                        if (profile == null)
                        {
                            LogManager.WriteLine($"No profile named \"{profileName}\" available in the database.");
                            dialogMessage = $"No profile named \"{profileName}\" available in the database.{Environment.NewLine}" +
                                $"Proceed to the next profile?";

                            if (showDialogs && MessageBox.Show(dialogMessage, "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            {
                                LogManager.WriteLine("Transfer canceled by user.");
                                break;
                            }
                            else
                            {
                                LogManager.WriteLine("Continuing to the next profile.");
                                continue;
                            }
                        }

                        try
                        {
                            LogManager.WriteLine($"Working on profile \"{profileName}\"");
                            profile.Options = DBAccess.ListProfileOptions(profile).OrderBy(o => o.ListViewIndex).ToList();

                            foreach (Options o in profile.Options)
                            {
                                if (!o.FilterFilesAndExts) o.FilteredFileNamesAndExtensions.Clear(); //-- Names must be ignored
                                if (!o.FilterDirectories) o.FilteredDirectories.Clear();
                                o.SourcePath = Environment.ExpandEnvironmentVariables(o.SourcePath);
                                o.DestinyPath = Environment.ExpandEnvironmentVariables(o.DestinyPath);
                            }

                            UpdateLastTimeExecuted(profile);
                            fileControl.Transfer(profile.Options.ToList<TransferSettings>());
                        }
                        catch (Exception e)
                        {
                            LogManager.WriteLine($"Error: {e.Message} while executing \"{profile.Name}\".");
                            dialogMessage = $"Error: \"{e.Message}\" while executing \"{profile.Name}\". Proceed to the next profile?";
                            if (showDialogs && MessageBox.Show(dialogMessage, "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            {
                                LogManager.WriteLine("Transfer canceled by user.");
                                break;
                            }

                            LogManager.WriteLine("Continuing to the next profile.");
                        }
                        finally
                        {
                            if (profile != null) UpdateLastTimeExecuted(profile);
                        }
                    }

                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
                finally
                {
                    LogManager.WriteLine("DONE");
                    LogManager.WriteLine("");
                    LogManager.CloseWritter();
                }
            }

            if (ApplicationIsRunning())
            {
                MessageBox.Show("Application is already running.");
                return;
            }

            //if (!File.Exists(DBPath))
            //{
            //File.Create(DBPath);
            //DBConnection dbc = new DBConnection();
            //dbc.CreateDatabase();
            //    File.Create()
            //}

            Console.WriteLine("Backup Helper - Log...");
            ProfileMenu = new FormProfileMenu();
            Application.Run(ProfileMenu);
        }

        public static bool ApplicationIsRunning()
        {
            Process currentProcess = Process.GetCurrentProcess();

            foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
                if ((process.Id != currentProcess.Id) && (process.MainModule.FileName == currentProcess.MainModule.FileName))
                    return true;

            return false;
        }

        public static void UpdateLastTimeModified(Profile profile)
        {
            profile.LastTimeModified = DateTime.Now;
            DBAccess.UpdateProfile(profile);
            if (ProfileMenu != null)
                //ProfileMenu.GetListViewItemById(profile.Id).SubItems[(int)ListViewProfileSubItemIndex.INDEX_TIME_MODIFIED].Text = profile.LastTimeModified.ToString();
                ProfileMenu.EditListViewItem(profile);
        }

        public static void UpdateLastTimeExecuted(Profile profile)
        {
            profile.LastTimeExecuted = DateTime.Now;
            DBAccess.UpdateProfile(profile);
            if (ProfileMenu != null)
                //ProfileMenu.GetListViewItemById(profile.Id).SubItems[(int)ListViewProfileSubItemIndex.INDEX_TIME_EXECUTED].Text = profile.LastTimeExecuted.ToString();
                ProfileMenu.EditListViewItem(profile);
        }

        static public void ConfigureFileEvents(FileControl fileControl, FormOptionsMenu menu)
        {
            fileControl.ErrorOccured += new ErrorOccuredHandler((sender, args) =>
            {
                FormErrorDialog form = new($"{args.ErrorMessage}{Environment.NewLine}{args.Exception.Message}");
                form.ShowDialog();
                args.TransferErrorAction = form.Result;
            });

            fileControl.FileExecuting += new FileExecutingHandler((sender, args) =>
            {
                menu.ShowCurrentFileExecution(args.TrimmedPathWithFileName.Length > 100 ?
                    $"...{args.TrimmedPathWithFileName.Substring(args.TrimmedPathWithFileName.Length - 100)}" : args.TrimmedPathWithFileName
                );
            });

            fileControl.LogMessageGenerated += new LogMessageGeneratedHandler((sender, message) =>
            {
                LogManager.WriteLine(message);
            });
        }

        static void ConfigureConsoleFileEvents(FileControl fileControl, bool showDialogs)
        {
            //fileControl.FileExecuting += new FileExecutingHandler((sender, args) =>
            //{

            //});

            fileControl.LogMessageGenerated += new LogMessageGeneratedHandler((sender, message) =>
            {
                LogManager.WriteLine(message);
            });

            if (!showDialogs) return;

            fileControl.ErrorOccured += new ErrorOccuredHandler((sender, args) =>
            {
                FormErrorDialog form = new FormErrorDialog(args.ErrorMessage);
                form.ShowDialog();
                args.TransferErrorAction = form.Result;
            });
        }
    }
}
