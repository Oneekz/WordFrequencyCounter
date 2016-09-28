using System;
using System.Collections.Generic;
using System.Linq;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.Sorter
{
    /// <summary>
    /// Collection sorter by words frequency
    /// </summary>
    public class CountSorter : ISorter
    {
        private readonly IConsoleService _console;

        /// <summary>
        /// Constructor of the sorter
        /// </summary>
        /// <param name="consoleService">Console Service</param>
        public CountSorter(IConsoleService consoleService)
        {
            if (consoleService == null) throw new ArgumentNullException(nameof(consoleService));
            _console = consoleService;
        }

        /// <summary>
        /// Does sorting by words frequency 
        /// </summary>
        /// <param name="collection">Original collection</param>
        /// <returns>Sorted collection</returns>
        public IEnumerable<KeyValuePair<string, int>> Sort(IEnumerable<KeyValuePair<string, int>> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            _console.WriteLine("Sorting by words frequency was applied");
            return collection.OrderByDescending(c => c.Value);
        }
    }
}