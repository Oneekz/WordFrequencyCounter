using System;
using DryIoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WordFrequencyCounter.ContentReader;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Outputter;
using WordFrequencyCounter.Service;
using WordFrequencyCounter.Sorter;

namespace WordFrequencyCounter.UnitTest.Service
{
    [TestClass]
    public class ArgumentServiceTests
    {
        [TestMethod]
        public void ArgumentServiceCtorTest()
        {
            IArgumentService service = null;
            try
            {
                service = new ArgumentService(null, null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("ioc"));
            }
            try
            {
                service = new ArgumentService(new Mock<IContainer>().Object, null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("args"));
            }
            try
            {
                service = new ArgumentService(new Mock<IContainer>().Object, new string[] {"-i:", "-w:"});
                Assert.Fail("Should fail until this moment");
            }
            catch (NotSupportedException ex)
            {
                Assert.AreEqual("Please pass input data either by -i or by -w argument", ex.Message);
            }

            service = new ArgumentService(new Mock<IContainer>().Object, new string[] {});

            Assert.IsNotNull(service);
            Assert.IsInstanceOfType(service, typeof (IArgumentService));
            Assert.IsInstanceOfType(service, typeof (ArgumentService));
        }

        [TestMethod]
        public void ArgumentServiceContentReaderTest()
        {
            var ioc = new Container();
            var fileService = new Mock<IFileService>();
            fileService.Setup(s => s.FileExists(It.IsAny<string>())).Returns(true);
            ioc.RegisterInstance(new Mock<IConsoleService>().Object);
            ioc.RegisterInstance(fileService.Object);
            IArgumentService service = new ArgumentService(ioc, new string[] {});
            IContentReader reader = service.ContentReader;
            Assert.IsNotNull(reader);
            Assert.IsInstanceOfType(reader, typeof (UserInputReader));

            service = new ArgumentService(ioc, new[] {"-i:in.txt", "-s:count"});
            reader = service.ContentReader;
            Assert.IsNotNull(reader);
            Assert.IsInstanceOfType(reader, typeof (FileContentReader));

            service = new ArgumentService(ioc, new[] {"-s:name", "-w:\"This is it\""});
            reader = service.ContentReader;
            Assert.IsNotNull(reader);
            Assert.IsInstanceOfType(reader, typeof (WordsArgumentsInputReader));
        }

        [TestMethod]
        public void ArgumentServiceSorterTest()
        {
            var ioc = new Container();
            ioc.RegisterInstance(new Mock<IConsoleService>().Object);
            IArgumentService service = new ArgumentService(ioc, new string[] {});
            ISorter sorter = service.Sorter;
            Assert.IsNotNull(sorter);
            Assert.IsInstanceOfType(sorter, typeof (NonSorter));

            service = new ArgumentService(ioc, new[] {"-i:in.txt", "-s:count"});
            sorter = service.Sorter;
            Assert.IsNotNull(sorter);
            Assert.IsInstanceOfType(sorter, typeof (CountSorter));

            service = new ArgumentService(ioc, new[] {"-s:name", "-w:\"This is it\""});
            sorter = service.Sorter;
            Assert.IsNotNull(sorter);
            Assert.IsInstanceOfType(sorter, typeof (NameSorter));
        }


        [TestMethod]
        public void ArgumentServiceOutputterTest()
        {
            var ioc = new Container();
            ioc.RegisterInstance(new Mock<IConsoleService>().Object);
            ioc.RegisterInstance(new Mock<IFileService>().Object);
            IArgumentService service = new ArgumentService(ioc, new string[] { });
            IOutputter outputter = service.Outputter;
            Assert.IsNotNull(outputter);
            Assert.IsInstanceOfType(outputter, typeof(ConsoleOutputter));

            service = new ArgumentService(ioc, new[] { "-i:in.txt", "-s:count", "-o:out.txt" });
            outputter = service.Outputter;
            Assert.IsNotNull(outputter);
            Assert.IsInstanceOfType(outputter, typeof(FileOutputter));
            
        }
    }
}