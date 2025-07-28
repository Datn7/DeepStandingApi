namespace DeepStandingApi.Services
{
    public class ConsoleLogService : ILogService
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now:HH:mm:ss} - {message}");
        }
    }
}
