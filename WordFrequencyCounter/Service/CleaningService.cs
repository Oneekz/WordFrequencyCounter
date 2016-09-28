using System;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.Service
{
    /// <summary>
    /// Service for removing unneeded characters from the string. Leaves letters, numbers, '-' sign and whitespaces
    /// </summary>
    public class CleaningService : ICleaningService
    {
        /// <summary>
        /// Cleans string from unneeded characters.
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>Processed string</returns>
        public string Clean(string str)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            var arr = str.ToCharArray();
            arr = Array.FindAll(arr, (c => (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-')));
            return new string(arr);
        }
    }
}