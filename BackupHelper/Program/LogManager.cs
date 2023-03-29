using System.Reflection;

namespace BackupHelper
{
    static class LogManager
    {
        private static StreamWriter w;

        public static void Write(string text)
        {
            w.Write($"[{DateTime.Now.ToLongTimeString()}]: {text}");
            Console.Write($"[{DateTime.Now.ToLongTimeString()}]: {text}");
        }
        public static void WriteLine(string text)
        {
            w.WriteLine($"[{DateTime.Now.ToLongTimeString()}]: {text}");
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}]: {text}");
        }
        public static void CloseWritter()
        {
            w.Close();
        }
        public static void BeginWritter()
        {
            w = File.AppendText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt");
        }
    }
}
