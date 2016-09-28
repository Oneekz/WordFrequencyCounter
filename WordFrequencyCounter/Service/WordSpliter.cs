using System;
using System.Collections.Generic;
using System.Linq;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.Service
{
    /// <summary>
    /// Splits string by whitespaces
    /// </summary>
    public class WordSpliter : IWordSpliter
    {
        /// <summary>
        /// Do split itself
        /// </summary>
        /// <param name="input">String with all words</param>
        /// <returns>Collection of words</returns>
        public IList<string> SplitWords(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            return input.ToLower().Split(null).Where(s=>s!=string.Empty).ToArray(); //Split(null) uses all WhiteSpaces as seperator
        }
    }
}