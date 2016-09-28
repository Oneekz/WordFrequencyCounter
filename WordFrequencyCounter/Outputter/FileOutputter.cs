using System;
using System.Collections.Generic;
using System.Linq;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.Outputter
{
    /// <summary>
    /// Class for saving resulting collection to the file
    /// </summary>
    public class FileOutputter : IOutputter
    {
        private readonly IFileService _fileService;
        private readonly IConsoleService _console;
        private readonly string _filePath;

        /// <summary>
        /// Constructor of the file outputter
        /// </summary>
        /// <param name="fileService">File Service</param>
        /// <param name="console">Console Service</param>
        /// <param name="filePath">Path to the file. Could be either relative or absolute</param>
        public FileOutputter(IFileService fileService, IConsoleService console, string filePath)
        {
            if (fileService == null) throw new ArgumentNullException(nameof(fileService));
            if (console == null) throw new ArgumentNullException(nameof(console));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            _fileService = fileService;
            _console = console;
            _filePath = filePath;
        }
        /// <summary>
        /// Save collection content to the file
        /// </summary>
        /// <param name="collection"></param>
        public void Output(IEnumerable<KeyValuePair<string, int>> collection)
        {
            _console.WriteLine("Outputting results to the file {0}", _filePath);
            _fileService.WriteAllText(_filePath, string.Join("\n", collection.Select(s=> $"{s.Key} - {s.Value}")));
            _console.WriteLine("Outputting has been finished");
        }
    }
}