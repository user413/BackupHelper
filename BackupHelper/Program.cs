using BackupHelper.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace BackupHelper
{
    static class Program
    {

        //-- DEVELOPING LOCATION
        //public static string DBPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\..\\..\\database\\backup_helper.db";
        //-- RELEASE LOCATION
        public static string DBPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\backup_helper.db";

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (!File.Exists(DBPath))
            //{
            //File.Create(DBPath);
            //DBConnection dbc = new DBConnection();
            //dbc.CreateDatabase();
            //    File.Create()
            //}

            Console.WriteLine("Backup Helper 1.0 - Log...");
            Application.Run(new FormProfileMenu());
            
            
            //Application.Run(new FormReport());
            //Application.Run(new FormCancelExecution());
            //Application.Run(new FormConfirmAction());
            //Application.Run(new FormErrorDialog());
            //Application.Run(new FormEditOption(new FormOptionsMenu() { },new OptionAccess() { }));
        }
    }
}
