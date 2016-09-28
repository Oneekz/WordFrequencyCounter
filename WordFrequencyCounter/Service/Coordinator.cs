using System;
using DryIoc;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.Service
{
    /// <summary>
    /// Class that has responsibility to do all steps of transformation
    /// </summary>
    public class Coordinator : ICoordinator
    {
        private readonly IContainer _ioc;
        private readonly IConsoleService _console;

        /// <summary>
        /// Constructor for service
        /// </summary>
        /// <param name="ioc">IoC Container</param>
        public Coordinator(IContainer ioc)
        {
            if (ioc == null) throw new ArgumentNullException(nameof(ioc));
            _console = ioc.Resolve<IConsoleService>();
           _ioc = ioc;
        }

        /// <summary>
        /// Launches all processing of the content
        /// </summary>
        /// <param name="args">Application arguments with settings</param>
        public void Start(string[] args)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));
            try
            {
                _console.Foreground = ConsoleColor.Yellow;
                _console.WriteLine("Application has been started");
                var argService = _ioc.Resolve<IArgumentServiceFactory>().Create(_ioc, args);
                var input = argService.ContentReader.Read();
                _console.WriteLine("Input text has {0} characters", input.Length);
                input = _ioc.Resolve<ICleaningService>().Clean(input);
                _console.WriteLine("After cleaning input text has {0} characters", input.Length);
                var words = _ioc.Resolve<IWordSpliter>().SplitWords(input);
                _console.WriteLine("After splitting we have {0} words", words.Count);
                var result = _ioc.Resolve<IWordCounter>().Count(words);
                result = argService.Sorter.Sort(result);
                argService.Outputter.Output(result);
            }
            catch (Exception ex)
            {
                _console.Foreground = ConsoleColor.DarkRed;
                _console.WriteLine("Exception occured: {0}", ex);
            }
            _console.WriteLine("Press return to exit");
            _console.ReadLine();
        }
    }
}