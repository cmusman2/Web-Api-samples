using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTestToDo.Models.Logging
{
    public static class Logger
    {
        private static ILogger _loger;
       

        public static void log(LogTargets _loggingTarget, string message)
        {
            switch (_loggingTarget)
            {
               case LogTargets.File: _loger = new FileLogger();break;
               case LogTargets.Database: _loger = new DatabaseLogger(); break;
            }

            _loger.logData(message);
        }

        public static void log(string message)
        {
            if ((_loger==null) && !(_loger is FileLogger))
            _loger = new FileLogger();            
            _loger.logData(message);
        }

    }
}