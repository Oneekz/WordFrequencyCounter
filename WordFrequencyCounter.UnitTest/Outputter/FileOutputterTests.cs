using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Outputter;

namespace WordFrequencyCounter.UnitTest.Outputter
{
    [TestClass]
    public class FileOutputterTests
    {
        [TestMethod]
        public void FileOutputterCtorTest()
        {
            IOutputter outputter = null;
            try
            {
                outputter = new FileOutputter(null,null,null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("fileService"));
            }
            try
            {
                outputter = new FileOutputter(new Mock<IFileService>().Object, null, null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("console"));
            }
            try
            {
                outputter = new FileOutputter(new Mock<IFileService>().Object, new Mock<IConsoleService>().Object, null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("filePath"));
            }
            outputter = new FileOutputter(new Mock<IFileService>().Object, new Mock<IConsoleService>().Object, string.Empty);
            Assert.IsNotNull(outputter);
            Assert.IsInstanceOfType(outputter, typeof(IOutputter));
            Assert.IsInstanceOfType(outputter, typeof(FileOutputter));
        }

        [TestMethod]
        public void FileOutputterOutputTest()
        {
            string resultA = string.Empty;
            string resultB = string.Empty;
            string filePath = string.Empty;
            string fileContent = string.Empty;
            var console = new Mock<IConsoleService>();
            console.Setup(s => s.WriteLine(It.IsAny<string>())).Callback<string>(s => resultA += s);
            console.Setup(s => s.WriteLine(It.IsAny<string>(), It.IsAny<object[]>())).Callback<string, object[]>((s, o) => resultB += string.Format(s, o));
            var fileService = new Mock<IFileService>();
            fileService.Setup(s => s.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Callback<string, string>(
                (p, c) =>
                {
                    filePath = p;
                    fileContent = c;
                });

            IOutputter outputter = new FileOutputter(fileService.Object, console.Object, "out.txt");
            var dict = new Dictionary<string, int>
            {
                {"this", 5 },
                {"is", 3 },
                {"nice", 1 }
            };
            outputter.Output(dict);
            Assert.AreEqual("Outputting has been finished", resultA);
            Assert.AreEqual("Outputting results to the file out.txt", resultB);
            Assert.AreEqual("out.txt", filePath);
            Assert.AreEqual("this - 5\nis - 3\nnice - 1", fileContent);
            console.VerifyAll();
            fileService.VerifyAll();
        }
    }
}