using System;
using System.IO;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.ContentReader
{
    /// <summary>
    /// Reads input content from the external file
    /// </summary>
    public class FileContentReader : IContentReader
    {
        private readonly IFileService _fileService;
        private readonly string _filePath;

        /// <summary>
        /// Constructor for this file reader
        /// </summary>
        /// <param name="fileService">File service instance</param>
        /// <param name="filePath">Path to the file</param>
        public FileContentReader(IFileService fileService, string filePath)
        {
            if (fileService == null) throw new ArgumentNullException(nameof(fileService));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if(!fileService.FileExists(filePath))
                throw new FileNotFoundException("File does not exists. Please check the parameter provided");
            _fileService = fileService;
            _filePath = filePath;
        }

        /// <summary>
        /// Method to read file content
        /// </summary>
        /// <returns>Return file content</returns>
        public string Read()
        {
            return _fileService.ReadAllText(_filePath);
        }
    }
}