using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace LSBusinessLayer.BLCommon
{
    public class BLUtility
    {
        public static void ErrorLog(string message)
        {
            string ErrorFilePath = ConfigurationSettings.AppSettings["ErrorPath"];
            StreamWriter sw = new StreamWriter(ErrorFilePath, true);
            try
            {
                sw.WriteLine();
                sw.WriteLine("------------------Rupa------------");
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(message);
            }
            catch (Exception ex)
            {
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            finally
            {
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
        }
    }
}
