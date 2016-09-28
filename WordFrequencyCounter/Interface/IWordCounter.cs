using System.Collections.Generic;

namespace WordFrequencyCounter.Interface
{
    public interface IWordCounter
    {
        IEnumerable<KeyValuePair<string, int>> Count(IList<string> words);
    }
}