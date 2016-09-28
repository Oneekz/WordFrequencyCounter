using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Outputter;

namespace WordFrequencyCounter.UnitTest.Outputter
{
    [TestClass]
    public class ConsoleOutputterTests
    {
        [TestMethod]
        public void ConsoleOutputterCtorTest()
        {
            IOutputter outputter = null;
            try
            {
                outputter = new ConsoleOutputter(null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("console"));
            }
            outputter = new ConsoleOutputter(new Mock<IConsoleService>().Object);
            Assert.IsNotNull(outputter);
            Assert.IsInstanceOfType(outputter, typeof(IOutputter));
            Assert.IsInstanceOfType(outputter, typeof(ConsoleOutputter));
        }

        [TestMethod]
        public void ConsoleOutputterOutputTest()
        {
            string resultA = string.Empty;
            string resultB = string.Empty;
            var console = new Mock<IConsoleService>();
            console.Setup(s => s.WriteLine(It.IsAny<string>())).Callback<string>(s => resultA += s);
            console.Setup(s => s.WriteLine(It.IsAny<string>(), It.IsAny<object[]>())).Callback<string, object[]>((s, o) => resultB += string.Format(s, o));
            IOutputter outputter = new ConsoleOutputter(console.Object);
            var dict = new Dictionary<string, int>
            {
                {"this", 5 },
                {"is", 3 },
                {"nice", 1 }
            };
            outputter.Output(dict);
            Assert.AreEqual("Outputting result to the console______________________________________________________", resultA);
            Assert.AreEqual("this - 5is - 3nice - 1", resultB);
            console.VerifyAll();
        }
    }
}
