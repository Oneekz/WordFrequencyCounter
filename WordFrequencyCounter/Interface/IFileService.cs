namespace WordFrequencyCounter.Interface
{
    public interface IFileService
    {
        bool FileExists(string path);
        string ReadAllText(string path);
        void WriteAllText(string path, string contents);
    }
}