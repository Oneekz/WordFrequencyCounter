using System.Collections.Generic;

namespace WordFrequencyCounter.Interface
{
    public interface ISorter
    {
        IEnumerable<KeyValuePair<string, int>> Sort(IEnumerable<KeyValuePair<string, int>> collection);
    }
}