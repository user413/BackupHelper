using BackupHelper.model;
using FileControlUtility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace BackupHelper
{
    static class Program
    {

        public static string DBPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\backup_helper.db";
        public static FormProfileMenu ProfileMenu;

        [STAThread]
        static void Main(string[] args)
        {
            if (ApplicationIsRunning())
            {
                MessageBox.Show("Application is already running.");
                return;
            }

            //args = new string[] { "new:w", "s"};
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //MessageBox.Show($"Error: \"{e.Message}\" while retrieving database data.");

            if (args.Length > 0)
            {
                bool showDialogs = true;
                string profileNamesStr;
                string dialogMessage;

                LogManager.BeginWritter();

                try
                {
                    LogManager.WriteLine("Starting transfer from parameters...");

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

                    List<Profile> profiles = DBAccess.ListProfiles();

                    if (profiles.Count == 0)
                    
                    {
                        dialogMessage = "No profiles saved in the database. Canceled.";
                        LogManager.WriteLine(dialogMessage);
                        if (showDialogs) MessageBox.Show(dialogMessage);
                        return;
                    }

                    string[] profileNames = profileNamesStr.Split(':');
                    FileControlConsoleImpl fileControl = new FileControlConsoleImpl(showDialogs);

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

                            foreach (Option o in profile.Options)
                            {
                                if (!o.AllowIgnoreFileExt) o.SpecifiedFileNamesAndExtensions.Clear(); //-- Names must be ignored
                                o.SourcePath = Environment.ExpandEnvironmentVariables(o.SourcePath);
                                o.DestinyPath = Environment.ExpandEnvironmentVariables(o.DestinyPath);
                            }

                            UpdateLastTimeExecuted(profile);
                            fileControl.ManageFiles(DBAccess.ListProfileOptions(profile).ToList<TransferSettings>());
                        }
                        catch (Exception e)
                        {
                            LogManager.WriteLine($"Error: {e.Message} while executing \"{profile.Name}\".");
                            dialogMessage = $"Error: {e.Message} while executing \"{profile.Name}\". Proceed to the next profile?";
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
            {
                if ((process.Id != currentProcess.Id) && (process.MainModule.FileName == currentProcess.MainModule.FileName))
                    return true;
            }

            return false;
        }

        public static void UpdateLastTimeModified(Profile profile)
        {
            profile.LastTimeModified = DateTime.Now;
            DBAccess.UpdateProfile(profile);
            if (ProfileMenu != null) ProfileMenu.GetListViewItemById(profile.Id).SubItems[(int)ListViewProfileSubItemIndex.INDEX_TIME_MODIFIED].Text =
                 profile.LastTimeModified.ToString();
        }

        public static void UpdateLastTimeExecuted(Profile profile)
        {
            profile.LastTimeExecuted = DateTime.Now;
            DBAccess.UpdateProfile(profile);
            if (ProfileMenu != null) ProfileMenu.GetListViewItemById(profile.Id).SubItems[(int)ListViewProfileSubItemIndex.INDEX_TIME_EXECUTED].Text =
                 profile.LastTimeExecuted.ToString();
        }
    }
}
