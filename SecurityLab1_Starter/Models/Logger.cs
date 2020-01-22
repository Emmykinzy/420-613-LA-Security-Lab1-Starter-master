using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;

namespace SecurityLab1_Starter.Models
{
    public class Logger
    {


        public static void Log(string logMessage)
        {
            TextWriter w = File.AppendText("C:\\Users\\ekjoh\\Desktop\\School\\Year4\\Semester 6\\Security\\420-613-LA-Security-Lab1-Starter-master\\SecurityLab1_Starter\\Util\\log.txt");
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  ");
            w.WriteLine($"  {logMessage}");
            w.WriteLine("-------------------------------");
            w.Close();
        }

        public static void LogToEventViewer(EventLogEntryType type, String text)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(text, type, 101, 1);
            }

        }

    }
}