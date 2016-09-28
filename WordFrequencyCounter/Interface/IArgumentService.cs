namespace WordFrequencyCounter.Interface
{
    public interface IArgumentService
    {
        IContentReader ContentReader { get; }
        ISorter Sorter { get; }
        IOutputter Outputter { get; }
    }
}