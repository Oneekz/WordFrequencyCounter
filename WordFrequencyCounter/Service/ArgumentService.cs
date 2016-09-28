using System;
using System.Linq;
using DryIoc;
using WordFrequencyCounter.ContentReader;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Outputter;
using WordFrequencyCounter.Sorter;

namespace WordFrequencyCounter.Service
{
    /// <summary>
    /// Service for parsing application's arguments
    /// </summary>
    public class ArgumentService : IArgumentService
    {
        private readonly IContainer _ioc;
        private readonly string[] _args;

        /// <summary>
        /// Constructor for service
        /// </summary>
        /// <param name="ioc">IoC Container</param>
        /// <param name="args">Arguments array</param>
        public ArgumentService(IContainer ioc, string[] args)
        {
            if (ioc == null) throw new ArgumentNullException(nameof(ioc));
            if (args == null) throw new ArgumentNullException(nameof(args));
            if(args.Any(a=>a.StartsWith("-i:")) && args.Any(a => a.StartsWith("-w:")))
                throw new NotSupportedException("Please pass input data either by -i or by -w argument");
            _ioc = ioc;
            _args = args;
        }

        /// <summary>
        /// Returns Content Reader based on argument that were provided
        /// </summary>
        public IContentReader ContentReader
        {
            get
            {
                foreach (var arg in _args)
                {
                    if(arg.StartsWith("-i:"))
                        return new FileContentReader(_ioc.Resolve<IFileService>(), CutStart(arg));
                    if(arg.StartsWith("-w:"))
                        return new WordsArgumentsInputReader(CutStart(arg));
                }
                return new UserInputReader(_ioc.Resolve<IConsoleService>());
            }
        }

        /// <summary>
        /// Returns Sorter based on argument that were provided
        /// </summary>
        public ISorter Sorter
        {
            get
            {
                foreach (var arg in _args)
                {
                    if (arg == "-s:count")
                        return new CountSorter(_ioc.Resolve<IConsoleService>());
                    if (arg == "-s:name")
                        return new NameSorter(_ioc.Resolve<IConsoleService>());
                }
                return new NonSorter();
            }
        }

        /// <summary>
        /// Returns Outputter based on argument that were provided
        /// </summary>
        public IOutputter Outputter
        {
            get
            {
                foreach (var arg in _args)
                {
                    if (arg.StartsWith("-o:"))
                        return new FileOutputter(_ioc.Resolve<IFileService>(), _ioc.Resolve<IConsoleService>(), CutStart(arg));
                }
                return new ConsoleOutputter(_ioc.Resolve<IConsoleService>());
            }
        }

        private static string CutStart(string arg)
        {
            return arg.Substring(3);
        }
    }
}