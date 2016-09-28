using System.IO;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.Service
{
    /// <summary>
    /// Wrapper for System.IO.File static class
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Checks whether file exists
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>Flag whether file exists</returns>
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Reads all content of the file
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>File Content</returns>
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        /// <summary>
        /// Writes provided content to the file
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="contents">File Content</param>
        public void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }
}