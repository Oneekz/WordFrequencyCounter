using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Service;

namespace WordFrequencyCounter.UnitTest.Service
{
    [TestClass]
    public class CleaningServiceTests
    {
        [TestMethod]
        public void CleaningServiceCleanTest()
        {
            ICleaningService cleaner = new CleaningService(); try
            {
                cleaner.Clean(null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("str"));
            }
            Assert.AreEqual(string.Empty, cleaner.Clean(string.Empty));
            Assert.AreEqual(" ", cleaner.Clean(" "));
            Assert.AreEqual(" ", cleaner.Clean(" ."));
            Assert.AreEqual(" you ", cleaner.Clean(" you "));
            Assert.AreEqual("Are you ready", cleaner.Clean("Are you ready?"));
            Assert.AreEqual("a0 She was born in 90x Really", cleaner.Clean("a=0 She was born in 90x [Really?]"));
        }
    }
}