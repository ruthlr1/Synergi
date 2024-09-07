using System.Text;

namespace SongSuggester.Application.Services.Logs
{
    public class LoggerService : ILoggerService
    {
        private StringBuilder _log = new StringBuilder();

        public void LogError(Exception ex)
        {
            StringBuilder log = new StringBuilder();
            log.AppendLine("Unable to fetch data from server");
            log.AppendLine(ex.ToString());

            var logDirectory = Path.Combine(Environment.CurrentDirectory, "Logs");
            if(!Directory.Exists(logDirectory)) 
                Directory.CreateDirectory(logDirectory);

            var filePath = Path.Combine(Environment.CurrentDirectory, "Logs", $"ErrorLog_{DateTime.Now.ToString("yyyyMMddhhmmss")}.txt");
            File.WriteAllText(filePath, log.ToString());
        }

    }
}
