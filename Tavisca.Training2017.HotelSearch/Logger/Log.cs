using System;
using System.IO;

namespace Logger
{
    public class Log
    {

        public  static void LogError(Exception ex)
        {

            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
           
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            using (StreamWriter writer = new StreamWriter("d:/Log.txt", true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
            
        }
        
    }
}
