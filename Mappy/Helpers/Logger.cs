using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Mappy.Helpers
{
    static class Logger
    {
        private static List<string> logs = new List<string>();
        private static List<string> lines = new List<string>();

        //
        // Add to log
        //
        public static void Add(string text)
        {
            // create log entry
            text = String.Format("[{0}] {1}", AppHelper.getCurrentTime(), text);

            // add to lists
            logs.Add(text);
            lines.Add(text);

            // save every 50 lines
            if (lines.Count > 25)
            {
                try {
                    // generate log lines
                    string loglines = String.Join(Environment.NewLine, lines.ToArray());

                    // clear logs
                    lines.Clear();

                    // write to log
                    File.AppendAllText(GetLogFilename(), loglines + Environment.NewLine);
                }
                catch (Exception err)
                {
                    Add("-- Could not write to log file: " + err.Message);
                }
            }
        }

        public static void Exception(Exception ex, string message)
        {
            var LineNumber = new StackTrace(ex, true).GetFrame(0).GetFileLineNumber();

            Add("---[ EXCEPTION ]------------------------------------------------");
            Add($"{LineNumber} :: {message}");
            Add(ex.ToString());
            Add("----------------------------------------------------------------");
        }

        public static void Write(string filename, string text)
        {
            text = String.Format("[{0}] {1}", AppHelper.getCurrentTime(), text);
            File.AppendAllText(AppHelper.getApplicationPath() + "/logs/" + filename, text + Environment.NewLine);
        }

        //
        // Get log entries
        //
        public static List<String> Get(int skipCount)
        {
            List<string> copy = logs;
            copy = copy.Skip(skipCount).ToList();
            return copy;
        }

        //
        // Reset log entries
        //
        public static void Geset()
        {
            File.WriteAllText(GetLogFilename(), String.Empty);
        }
       
        //
        // Get log filename
        //
        private static string GetLogFilename()
        {
            if (!Directory.Exists(AppHelper.getApplicationPath() + "/logs/"))
            {
                Directory.CreateDirectory(AppHelper.getApplicationPath() + "/logs/");
            }

            // get log file
            return AppHelper.getApplicationPath() + "/logs/log.txt";
        }
    }
}
