using System;
using System.IO;

namespace Lec04LibN
{
    public interface ILogger
    {
        void start(string title);
        void log(string message = "");
        void stop();
    }

    public partial class Logger : ILogger
    {
        private static readonly Logger instance = new Logger();
        private string LogFileName = string.Format(@"{0}/LOG{1}.txt", Directory.GetCurrentDirectory(), DateTime.Now.ToString("yyyyMMdd-HH-mm-ss"));

        public void log(string message = "")
        {
            using (StreamWriter sw = File.AppendText(LogFileName))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " | " + message);
            }
        }

        public static Logger Instance
        {
            get
            {
                return instance;
            }
        }

        public static Logger Create()
        {
            return Instance;
        }

        public void start(string title)
        {
            Console.WriteLine("Logger started: " + title);
            log("STRT: " + title);
        }

        public void stop()
        {
            Console.WriteLine("Logger stopped.");
            log("STOP");
        }
    }
}
