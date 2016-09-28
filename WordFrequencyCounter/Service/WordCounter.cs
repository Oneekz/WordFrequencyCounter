using System;
using System.Collections.Generic;
using System.Linq;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.Service
{
    /// <summary>
    /// Counts frequency of words occuring
    /// </summary>
    public class WordCounter : IWordCounter
    {
        /// <summary>
        /// Do couting of words
        /// </summary>
        /// <param name="words">Collection with the words</param>
        /// <returns>Key-value collection with words and their count</returns>
        public IEnumerable<KeyValuePair<string, int>> Count(IList<string> words)
        {
            if (words == null) throw new ArgumentNullException(nameof(words));
            var dict = new Dictionary<string, int>(words.Count);
            foreach (var word in words.Where(word => word != null))
            {
                if (dict.ContainsKey(word))
                    dict[word]++;
                else dict.Add(word, 1);
            }
            return dict;
        }
    }
}