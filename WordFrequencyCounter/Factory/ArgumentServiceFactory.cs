using System;
using DryIoc;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Service;

namespace WordFrequencyCounter.Factory
{
    /// <summary>
    /// Factory for creating Argument service
    /// </summary>
    public class ArgumentServiceFactory : IArgumentServiceFactory
    {
        /// <summary>
        /// Creates instance of argument service
        /// </summary>
        /// <param name="ioc">IoC container</param>
        /// <param name="args">Arguments</param>
        /// <returns></returns>
        public IArgumentService Create(IContainer ioc, string[] args)
        {
            if (ioc == null) throw new ArgumentNullException(nameof(ioc));
            if (args == null) throw new ArgumentNullException(nameof(args));
            return new ArgumentService(ioc, args);
        }
    }
}