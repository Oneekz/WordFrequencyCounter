using System;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.ContentReader
{
    /// <summary>
    /// Give user possibility to enter input data
    /// </summary>
    public class UserInputReader : IContentReader
    {
        private readonly IConsoleService _console;
        /// <summary>
        /// Constructor for this user input reader
        /// </summary>
        /// <param name="console">Console service</param>
        public UserInputReader(IConsoleService console)
        {
            if (console == null) throw new ArgumentNullException(nameof(console));
            _console = console;
        }
        /// <summary>
        /// Reads data from the user input
        /// </summary>
        /// <returns></returns>
        public string Read()
        {
            _console.WriteLine("Please enter input string. Finish by hitting return key");
            return _console.ReadLine();
        }
    }
}