using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApplication1.Helper
{
    public class Logger
    {
        private static Logger logger = new Logger();
        string filepath;
        FileStream fs = null;
        StreamWriter writer = null;
       
        private Logger()
        {
            filepath = ConfigurationManager.AppSettings["logfile"].ToString();

        }
        public static Logger currentLogger { get { return logger; } }

        public void Log(string msg)
        {
            if (File.Exists(filepath))
            {
                fs = new FileStream(filepath, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);
            }
            writer = new StreamWriter(fs);
            string msgToBeLog = "Logged : {0} at {1}";
            writer.WriteLine(msgToBeLog, msg, DateTime.Now.ToString());
            writer.Close();
            fs = null;
        }

    }
}