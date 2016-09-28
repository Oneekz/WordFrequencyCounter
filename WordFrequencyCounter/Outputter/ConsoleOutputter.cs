using System;
using System.Collections.Generic;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.Outputter
{
    /// <summary>
    /// Outputs result to the console
    /// </summary>
    public class ConsoleOutputter : IOutputter
    {
        private readonly IConsoleService _console;
        /// <summary>
        /// Constructor of the outputter
        /// </summary>
        /// <param name="console">Console service</param>
        public ConsoleOutputter(IConsoleService console)
        {
            if (console == null) throw new ArgumentNullException(nameof(console));
            _console = console;
        }
        /// <summary>
        /// Shows collection on the console
        /// </summary>
        /// <param name="collection">Collection to be shown</param>
        public void Output(IEnumerable<KeyValuePair<string, int>> collection)
        {
            _console.WriteLine("Outputting result to the console");
            var currentColor = _console.Foreground;
            _console.Foreground = ConsoleColor.White;
            _console.WriteLine("___________________________");
            foreach (var an in collection)
            {
                _console.WriteLine("{0} - {1}", an.Key, an.Value);
            }
            _console.WriteLine("___________________________");
            _console.Foreground = currentColor;
        }
    }
}