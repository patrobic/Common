using Shared.Logger;
using System;
using System.Diagnostics;

namespace Book.Base
{
    public abstract class BaseLoggable : ILoggable
    {
        protected ILogger _logger;
        protected string? _qualifier = null;

        public string ModuleName { get; init; }

        public bool EnableLogs { get; init; } = true;

        public BaseLoggable(ILogger logger = null)
        {
            _logger = logger;
        }

        public BaseLoggable(string name, ILogger logger = null)
        {
            ModuleName = name;
            _logger = logger;
        }

        protected Stopwatch Log(LogSource source, Stopwatch? timer = null, Exception? e = null)
        {
            if (!EnableLogs)
            {
                return null;
            }

            var qualifier = _qualifier == null ? string.Empty : $"[{_qualifier}] ";
            var name = ModuleName ?? GetType().Name;

            if (timer == null)
            {
                timer = Stopwatch.StartNew();
                _logger?.Info(name, $"{qualifier}START", null, source);
            }
            else
            {
                var elapsed = timer.Elapsed.ToString("hh':'mm':'ss'.'fff");
                var type = e == null ? "END" : "ERROR";
                var logLevel = e == null ? LogLevel.Info : LogLevel.Fatal;

                _logger?.WriteLine(logLevel, name, $"{qualifier}{type,-5} ({elapsed})", e, source);
            }
            return timer;
        }
    }
}
