using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApiTestToDo.Models.Logging
{
    public static class Logger
    {
        private static ILogger _loger;
       

        public static void log(LogTargets _loggingTarget, string message)
        {
            // AppSettingsSection appSettingSection = (AppSettingsSection)ConfigurationManager.GetSection("Logging");
            // string s =appSettingSection.Settings.AllKeys[0];

            string s= ConfigurationManager.AppSettings["Logging"];
            if ((s==null) || (s.ToLower() != "on")) return;
            

            switch (_loggingTarget)
            {
               case LogTargets.File: _loger = new FileLogger();break;
               case LogTargets.Database: _loger = new DatabaseLogger(); break;
            }

            _loger.logData(message);
        }

        public static void log(string message)
        {
            string s = ConfigurationManager.AppSettings["Logging"];
            if ((s == null) || (s.ToLower() != "on")) return;

            if ((_loger==null) && !(_loger is FileLogger))
            _loger = new FileLogger();            
            _loger.logData(message);
        }

    }
}