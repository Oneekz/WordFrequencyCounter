using DryIoc;

namespace WordFrequencyCounter.Interface
{
    public interface IArgumentServiceFactory
    {
        IArgumentService Create(IContainer ioc, string[] args);
    }
}