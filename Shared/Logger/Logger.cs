using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Shared.Logger
{
    public class Logger : ILogger, IDisposable
    {
        private LoggerParameters _parameters = new();

        private string _path;
        private StreamWriter _fileWriter;
        private static object _lock = new();

        public Logger()
        {
            _path = Path.Combine(_parameters.LogPath, $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt");
        }

        public void Dispose()
        {
            if (_fileWriter != null)
            {
                _fileWriter.Dispose();
            }
        }

        public void WriteLine(LogLevel level, Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            var text = Format(level, type.Name, message, e, source, method, line);
            Write(level, text, e, source);
        }

        public void WriteLine(LogLevel level, string type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            var text = Format(level, type, message, e, source, method, line);
            Write(level, text, e, source);
        }

        public void Fatal(Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            WriteLine(LogLevel.Fatal, type, message, e, source, method, line);
        }

        public void Error(Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            WriteLine(LogLevel.Error, type, message, e, source, method, line);
        }

        public void Warn(Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            WriteLine(LogLevel.Warn, type, message, e, source, method, line);
        }

        public void Info(Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            WriteLine(LogLevel.Info, type, message, e, source, method, line);
        }

        public void Debug(Type type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            WriteLine(LogLevel.Debug, type, message, e, source, method, line);
        }

        public void Fatal(string type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            WriteLine(LogLevel.Fatal, type, message, e, source, method, line);
        }

        public void Error(string type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            WriteLine(LogLevel.Error, type, message, e, source, method, line);
        }

        public void Warn(string type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            WriteLine(LogLevel.Warn, type, message, e, source, method, line);
        }

        public void Info(string type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            WriteLine(LogLevel.Info, type, message, e, source, method, line);
        }

        public void Debug(string type, string message, Exception e = null, LogSource source = LogSource.Class,
            [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            WriteLine(LogLevel.Debug, type, message, e, source, method, line);
        }

        private string Format(LogLevel level, string type, string message, Exception e, LogSource source, string method, int line)
        {
            var time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            var lvl = level.ToString().ToUpper();
            var src = source.ToString().ToUpper();
            var error = e == null ? string.Empty : $"\n\t{e.GetType()}: {e.Message}";
            var loc = source == LogSource.Class ? $"{type}.{method}.{line}" : $"{type,-24}";
            var formatted = $"[{time}] [{lvl,-5}] [{src,-6}] [{loc}]: {message}{error}";

            return formatted;
        }

        private void Write(LogLevel level, string text, Exception e, LogSource source)
        {
            lock (_lock)
            {
                if (level <= _parameters.LogConsoleLimits[source])
                {
                    WriteToConsole(text, e);
                }
                if (level <= _parameters.LogFileLimits[source])
                {
                    WriteToFile(text, e);
                }
            }
        }

        private void WriteToConsole(string text, Exception e)
        {
            Console.WriteLine(text);
            if (e != null && _parameters.LogFullStackTrace)
            {
                Console.WriteLine($"\t{e.StackTrace.Replace("\n", "\n\t")}\r\n");
            }
        }

        private void WriteToFile(string text, Exception e)
        {
            CreateFile();
            if (_fileWriter != null)
            {
                _fileWriter.WriteLine(text);
                if (e != null)
                {
                    _fileWriter.WriteLine($"\t{e.StackTrace.Replace("\n", "\n\t")}\r\n");
                }
                _fileWriter.Flush();
            }
        }

        private void CreateFile()
        {
            if (_path != null && _fileWriter == null)
            {
                try
                {
                    new FileInfo(_path).Directory.Create();
                    _fileWriter = new StreamWriter(_path, true);
                }
                catch { }
            }
        }
    }
}
