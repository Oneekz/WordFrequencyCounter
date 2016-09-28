using System;

namespace WordFrequencyCounter.Interface
{
    public interface IConsoleService
    {
        string ReadLine();
        void WriteLine(string value);
        void WriteLine(string format, params object[] arg);
        ConsoleColor Foreground { get; set; }
    }
}