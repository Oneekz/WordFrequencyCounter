using System.Collections.Generic;

namespace WordFrequencyCounter.Interface
{
    public interface IWordSpliter
    {
        IList<string> SplitWords(string input);
    }
}