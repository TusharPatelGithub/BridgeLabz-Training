using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileUtilities;
using System;
using System.IO;

namespace FileUtilities.Tests.MSTest
{
    [TestClass]
    public class FileProcessorTests
    {
        private FileProcessor _fileProcessor;
        private string _testFilePath;

        [TestInitialize]
        public void Setup()
        {
            _fileProcessor = new FileProcessor();
            _testFilePath = Path.GetTempFileName();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(_testFilePath))
                File.Delete(_testFilePath);
        }

        [TestMethod]
        public void WriteAndReadFile_ContentShouldMatch()
        {
            string content = "Hello File Testing";

            _fileProcessor.WriteToFile(_testFilePath, content);
            string result = _fileProcessor.ReadFromFile(_testFilePath);

            Assert.AreEqual(content, result);
        }

        [TestMethod]
        public void WriteToFile_FileShouldExist()
        {
            _fileProcessor.WriteToFile(_testFilePath, "Test");

            Assert.IsTrue(File.Exists(_testFilePath));
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ReadFromFile_FileDoesNotExist_ShouldThrowException()
        {
            string invalidPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            _fileProcessor.ReadFromFile(invalidPath);
        }
    }
}
