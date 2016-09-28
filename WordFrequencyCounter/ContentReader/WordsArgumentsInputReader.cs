using System;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.ContentReader
{
    /// <summary>
    /// Content reader from the arguments
    /// </summary>
    public class WordsArgumentsInputReader : IContentReader
    {
        private readonly string _arg;
        /// <summary>
        /// Constructor for this arguments reader
        /// </summary>
        /// <param name="arg"></param>
        public WordsArgumentsInputReader(string arg)
        {
            if (arg == null) throw new ArgumentNullException(nameof(arg));
            _arg = arg;
        }
        /// <summary>
        /// Fetches content from the argument
        /// </summary>
        /// <returns>Content inself</returns>
        public string Read()
        {
            return _arg.Substring(3);
        }
    }
}