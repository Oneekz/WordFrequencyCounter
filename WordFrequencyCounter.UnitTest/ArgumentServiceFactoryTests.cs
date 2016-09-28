using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WordFrequencyCounter.Factory;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Service;

namespace WordFrequencyCounter.UnitTest
{
    [TestClass]
    public class ArgumentServiceFactoryTests
    {
        [TestMethod]
        public void ArgumentServiceFactoryCreateTest()
        {
            IArgumentServiceFactory factory = new ArgumentServiceFactory();
            IArgumentService service = null;

            try
            {
                service = factory.Create(null, null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("ioc"));
            }
            var ioc = new Mock<DryIoc.IContainer>();
            try
            {
                service = factory.Create(ioc.Object, null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("args"));
            }
            service = factory.Create(ioc.Object, new string[] {});
            Assert.IsNotNull(service);
            Assert.IsInstanceOfType(service, typeof(IArgumentService));
            Assert.IsInstanceOfType(service, typeof(ArgumentService));
        }
    }
}