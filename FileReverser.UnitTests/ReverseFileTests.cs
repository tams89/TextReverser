using System;
using System.IO;
using System.Text;
using FileReverser.Service;
using NUnit.Framework;

namespace FileReverser.UnitTests
{
    [TestFixture]
    public class ReverseFileTests
    {
        private FileReverseService _fileReverseService;
        private const string FilePath = @"C:\TestFile.txt";
        private const string ReversedFilePath = @"C:\ReversedTestFile.txt";
        private const string Text = "This is a test file.";

        [SetUp]
        public void SetUp()
        {
            _fileReverseService = new FileReverseService();
        }

        [Test]
        public void Can_Reverse_ASCII_Text_Correctly()
        {
            // Create ASCII File.
            File.WriteAllText(FilePath, Text, Encoding.ASCII);

            // Reverse it
            _fileReverseService.ReverseFile(FilePath, ReversedFilePath);

            // Check if reversed correctly
            var reversedFileText = File.ReadAllText(ReversedFilePath, Encoding.ASCII);

            var reversedText = Text.ToCharArray();
            Array.Reverse(reversedText);

            Assert.IsTrue(reversedFileText == new string(reversedText));
        }

        [Test]
        public void Exception_On_Null_InputFile_Path()
        {
            Assert.Throws<ArgumentNullException>(() => _fileReverseService.ReverseFile(null, @"C:\"));
        }

        [Test]
        public void Exception_On_Write_OutputFile()
        {
            Assert.Throws<ArgumentNullException>(() => _fileReverseService.ReverseFile(@"C:\", null));
        }

        [Test]
        public void Exception_On_NoText_In_InputFile()
        {
            // Create ASCII File.
            File.WriteAllText(FilePath, string.Empty, Encoding.ASCII);

            // Check
            Assert.Throws<InvalidOperationException>(() => _fileReverseService.ReverseFile(FilePath, ReversedFilePath));
        }
    }
}