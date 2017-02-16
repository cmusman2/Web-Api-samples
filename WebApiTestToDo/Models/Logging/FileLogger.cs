using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;

namespace WebApiTestToDo.Models.Logging
{
    public class FileLogger : ILogger
    {
        private string filePath = "logs.txt";
        public async  void logData(string v)
        {
            Boolean append = true;
            
            using (StreamWriter sr = new StreamWriter(filePath, append))
            {
                //CultureInfo ci = CultureInfo.CreateSpecificCulture("en-GB");                 
                await sr.WriteLineAsync(DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss:fff") + " : " + v);
            }
            
        }
    }
}