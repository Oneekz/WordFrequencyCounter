using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WordFrequencyCounter.ContentReader;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.UnitTest.ContentReader
{
    [TestClass]
    public class UserInputReaderTests
    {
        [TestMethod]
        public void UserInputReaderCtorTest()
        {
            IContentReader reader = null;
            try
            {
                reader = new UserInputReader(null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("console"));
            }
            reader = new UserInputReader(new Mock<IConsoleService>().Object);
            Assert.IsNotNull(reader);
            Assert.IsInstanceOfType(reader, typeof (IContentReader));
            Assert.IsInstanceOfType(reader, typeof (UserInputReader));
        }

        [TestMethod]
        public void UserInputReaderReadTest()
        {
            var console = new Mock<IConsoleService>();
            var messages = new List<string>();
            console.Setup(s => s.WriteLine(It.IsAny<string>())).Callback<string>(s => messages.Add(s));
            console.Setup(s => s.ReadLine()).Returns("data");
            var reader = new UserInputReader(console.Object);
            var content = reader.Read();
            Assert.AreEqual("data", content);
            Assert.AreEqual("Please enter input string. Finish by hitting return key", messages.First());
            Assert.IsTrue(messages.Count == 1);
            console.VerifyAll();
        }
    }
}

