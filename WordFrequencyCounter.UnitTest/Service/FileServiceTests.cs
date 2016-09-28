using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Service;

namespace WordFrequencyCounter.UnitTest.Service
{
    [TestClass]
    public class FileServiceTests
    {
        [TestMethod]
        public void FileExistsTest()
        {
            IFileService fileService = new FileService();
            var tempFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Assert.IsTrue(!fileService.FileExists(tempFile));
            File.Create(tempFile).Close();
            Assert.IsTrue(fileService.FileExists(tempFile));
            File.Delete(tempFile);
            Assert.IsTrue(!fileService.FileExists(tempFile));
        }
        
        [TestMethod]
        public void FileReadWriteTest()
        {
            IFileService fileService = new FileService();
            var tempFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var content = DateTime.Now.ToLongTimeString();
            fileService.WriteAllText(tempFile, content);
            Assert.AreEqual(content, fileService.ReadAllText(tempFile));
            if (fileService.FileExists(tempFile))
            {
                File.Delete(tempFile);
            }
        }
    }
}