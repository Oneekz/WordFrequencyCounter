using System;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.UnitTest
{
    public class FakeConsoleService : IConsoleService
    {
        private readonly Action<string> _logger;
        private string _message = string.Empty;

        public FakeConsoleService(Action<string> logger)
        {
            _logger = logger;
        }

        public string ReadLine()
        {
            return _message;
        }

        public void ReadyToRead(string answer)
        {
            _message = answer;
        }

        public void WriteLine(string value)
        {
            _logger(value);
        }

        public void WriteLine(string format, params object[] arg)
        {
            _logger(string.Format(format, arg));
        }

        public ConsoleColor Foreground { get; set; }
    }
}