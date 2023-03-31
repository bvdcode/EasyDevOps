using EasyDevOps.Core;

namespace EasyDevOps.Console
{
    internal class Logger : ILogger
    {
        private readonly string? outputFilePath;

        public Logger() { }

        public Logger(string outputFilePath) : this()
        {
            this.outputFilePath = outputFilePath;
        }

        public void Log(string message)
        {
            Serilog.Log.Information(message);
            if (!string.IsNullOrWhiteSpace(outputFilePath))
            {
                string text = string.Format("[INFO] {0} - {1}{2}", DateTime.Now, message, Environment.NewLine);
                File.AppendAllText(outputFilePath, text);
            }
        }

        public void Log(string message, Exception exception)
        {
            Serilog.Log.Error(exception, message);
            if (!string.IsNullOrWhiteSpace(outputFilePath))
            {
                string text = string.Format("[ERROR] {0} - {1} - {2}{3}", DateTime.Now, exception.Message, message, Environment.NewLine);
                File.AppendAllText(outputFilePath, text);
            }
        }
    }
}