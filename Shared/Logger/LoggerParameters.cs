using System;
using System.Collections.Generic;
using System.IO;

namespace Shared.Logger
{
    public class LoggerParameters
    {
        public string LogPath { get; set; } = Path.Combine(Path.GetDirectoryName(AppContext.BaseDirectory), "Logs");

        public Dictionary<LogSource, LogLevel> LogConsoleLimits { get; set; } = new Dictionary<LogSource, LogLevel>()
        {
            { LogSource.Runner, LogLevel.Info },
            { LogSource.Module, LogLevel.Info },
            { LogSource.Tool, LogLevel.Warn },
            { LogSource.Class, LogLevel.Warn },
        };

        public Dictionary<LogSource, LogLevel> LogFileLimits { get; set; } = new Dictionary<LogSource, LogLevel>()
        {
            { LogSource.Runner, LogLevel.Info },
            { LogSource.Module, LogLevel.Info },
            { LogSource.Tool, LogLevel.Error },
            { LogSource.Class, LogLevel.Error },
        };

        public bool LogFullStackTrace { get; set; } = false;
    }
}
