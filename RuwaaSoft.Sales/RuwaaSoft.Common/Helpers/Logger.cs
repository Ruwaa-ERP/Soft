using System;
using System.IO;

namespace RuwaaSoft.Common.Helpers
{
    public static class Logger
    {
        private static readonly string LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static readonly object LockObject = new object();

        static Logger()
        {
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        public static void Log(string message, string level = "INFO")
        {
            try
            {
                lock (LockObject)
                {
                    var logFile = Path.Combine(LogDirectory, $"Log_{DateTime.Now:yyyy-MM-dd}.txt");
                    var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
                    File.AppendAllText(logFile, logEntry + Environment.NewLine);
                }
            }
            catch
            {
            }
        }

        public static void LogError(string message, Exception ex = null)
        {
            var errorMessage = ex != null ? $"{message} - Exception: {ex.Message}\nStackTrace: {ex.StackTrace}" : message;
            Log(errorMessage, "ERROR");
        }

        public static void LogInfo(string message)
        {
            Log(message, "INFO");
        }

        public static void LogWarning(string message)
        {
            Log(message, "WARNING");
        }
    }
}
