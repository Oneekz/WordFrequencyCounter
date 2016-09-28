using System.Collections.Generic;

namespace WordFrequencyCounter.Interface
{
    public interface IOutputter
    {
        void Output(IEnumerable<KeyValuePair<string, int>> collection);
    }
}