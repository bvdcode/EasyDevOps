namespace EasyDevOps.Core
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string message, System.Exception exception);
    }
}