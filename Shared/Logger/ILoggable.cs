namespace Shared.Logger
{
    public interface ILoggable
    {
        public string ModuleName { get; init; }

        public bool EnableLogs { get; init; }
    }
}
