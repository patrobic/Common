using System;
using System.Runtime.CompilerServices;

namespace Shared.Logger
{
    public interface ILogger
    {
        public void WriteLine(LogLevel level, Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);

        public void WriteLine(LogLevel level, string type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);

        public void Fatal(Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);
        public void Error(Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);
        public void Warn(Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);
        public void Info(Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);
        public void Debug(Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);

        public void Fatal(string name, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);
        public void Error(string name, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);
        public void Warn(string name, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);
        public void Info(string name, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);
        public void Debug(string name, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0);
    }
}
