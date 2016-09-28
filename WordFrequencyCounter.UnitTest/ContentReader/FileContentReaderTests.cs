using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WordFrequencyCounter.ContentReader;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.UnitTest.ContentReader
{
    [TestClass]
    public class FileContentReaderTests
    {
        [TestMethod]
        public void FileContentReaderCtorTest()
        {
            IContentReader reader = null;
            try
            {
                reader = new FileContentReader(null, null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("fileService"));
            }
            var fileService = new Mock<IFileService>();
            try
            {
                reader = new FileContentReader(fileService.Object, null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("filePath"));
            }
            try
            {
                reader = new FileContentReader(fileService.Object, string.Empty);
                Assert.Fail("Should fail until this moment");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Assert.AreEqual("File does not exists. Please check the parameter provided", ex.Message);
            }
            string filename = null;
            fileService.Setup(s => s.FileExists(It.IsAny<string>())).Callback<string>(c => filename = c).Returns(true);

            reader = new FileContentReader(fileService.Object, "input.txt");
            Assert.IsNotNull(reader);
            Assert.IsInstanceOfType(reader, typeof (IContentReader));
            Assert.IsInstanceOfType(reader, typeof (FileContentReader));
            Assert.AreEqual("input.txt", filename);
            fileService.VerifyAll();
        }

        [TestMethod]
        public void FileContentReaderReadTest()
        {
            var fileService = new Mock<IFileService>();
            fileService.Setup(s => s.FileExists(It.IsAny<string>())).Returns(true);
            string filepath = null;
            fileService.Setup(s => s.ReadAllText(It.IsAny<string>()))
                .Callback<string>(c => filepath = c)
                .Returns("data");
            var reader = new FileContentReader(fileService.Object, string.Empty);
            var content = reader.Read();
            Assert.AreEqual("data", content);
            fileService.VerifyAll();
        }
    }
}
