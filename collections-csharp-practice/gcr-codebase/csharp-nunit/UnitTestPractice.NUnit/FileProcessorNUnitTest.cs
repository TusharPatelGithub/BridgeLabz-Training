using NUnit.Framework;
using FileUtilities;
using System;
using System.IO;

namespace FileUtilities.Tests.NUnit
{
    public class FileProcessorTests
    {
        private FileProcessor _fileProcessor;
        private string _testFilePath;

        [SetUp]
        public void Setup()
        {
            _fileProcessor = new FileProcessor();
            _testFilePath = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_testFilePath))
                File.Delete(_testFilePath);
        }

        [Test]
        public void WriteAndReadFile_ContentShouldMatch()
        {
            string content = "Hello File Testing";

            _fileProcessor.WriteToFile(_testFilePath, content);
            string result = _fileProcessor.ReadFromFile(_testFilePath);

            Assert.AreEqual(content, result);
        }

        [Test]
        public void WriteToFile_FileShouldExist()
        {
            _fileProcessor.WriteToFile(_testFilePath, "Test");

            Assert.IsTrue(File.Exists(_testFilePath));
        }

        [Test]
        public void ReadFromFile_FileDoesNotExist_ShouldThrowException()
        {
            string invalidPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            Assert.Throws<IOException>(() =>
                _fileProcessor.ReadFromFile(invalidPath)
            );
        }
    }
}
