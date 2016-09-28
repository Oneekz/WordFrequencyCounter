using DryIoc;
using WordFrequencyCounter.Factory;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Service;

namespace WordFrequencyCounter
{
    public class Program
    {
        /// <summary>
        /// Small help here:
        /// -w:"words list" read from argument
        /// -i:"File path" read from file
        /// -o:"File path" reditect result to the file
        /// no args - ask user to enter words
        /// -s:name/count turn on sort by name or count
        /// </summary>
        /// <param name="args">Application arguments</param>
        public static void Main(string[] args)
        {
            var ioc = new Container();
            RegisterDependencies(ioc);
            var coordinator = ioc.Resolve<ICoordinator>();
            coordinator.Start(args);
        }

        private static void RegisterDependencies(IContainer ioc)
        {
            ioc.Register<ICoordinator, Coordinator>();
            ioc.Register<IConsoleService, ConsoleService>();
            ioc.Register<IArgumentServiceFactory, ArgumentServiceFactory>();
            ioc.Register<ICleaningService, CleaningService>();
            ioc.Register<IWordSpliter, WordSpliter>();
            ioc.Register<IWordCounter, WordCounter>();
            ioc.Register<IFileService, FileService>();
        }
    }
}
