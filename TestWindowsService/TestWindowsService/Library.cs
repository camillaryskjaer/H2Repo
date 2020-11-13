using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TestWindowsService
{
    public static class Library
    {
        static StreamWriter stream = null;
        public static void WriteErrorLog(Exception ex)
        {
            try
            {
                stream = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                stream.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                stream.Flush();
                stream.Close();
            }
            catch
            {
            }
        }

        public static void WriteErrorLog(string Message)
        {
            try
            {
                stream = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                stream.WriteLine(DateTime.Now.ToString() + ": " + Message);
                stream.Flush();
                stream.Close();
            }
            catch
            {
            }
        }
    }
}
