using System;
using System.Collections.Generic;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.Sorter
{
    /// <summary>
    /// Default sorter that does not perform any sorting.
    /// </summary>
    public class NonSorter : ISorter
    {
        /// <summary>
        /// Return the same collection without sorting
        /// </summary>
        /// <param name="collection">Original collection</param>
        /// <returns>Original collection</returns>
        public IEnumerable<KeyValuePair<string, int>> Sort(IEnumerable<KeyValuePair<string, int>> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            return collection;
        }
    }
}