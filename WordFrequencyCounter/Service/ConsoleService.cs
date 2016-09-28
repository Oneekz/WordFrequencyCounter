using System;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.Service
{
    /// <summary>
    /// Wrapper for Console calling
    /// </summary>
    public class ConsoleService : IConsoleService
    {
        /// <summary>
        /// Writes simle message to the console
        /// </summary>
        /// <param name="value">Input message</param>
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
        /// <summary>
        /// Writes message with formatter to the console
        /// </summary>
        /// <param name="format">Formatter</param>
        /// <param name="arg">Arguments to the formatter</param>
        public void WriteLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }
        /// <summary>
        /// Reads line from the console
        /// </summary>
        /// <returns>String that was read from console</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        /// <summary>
        /// Sets or Gets color of console output
        /// </summary>
        public ConsoleColor Foreground
        {
            get { return Console.ForegroundColor; }
            set { Console.ForegroundColor = value; }
        }
    }
}