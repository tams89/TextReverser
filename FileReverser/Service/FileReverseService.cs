using System;
using System.IO;
using System.Text;
using FileReverser.Interfaces;

namespace FileReverser.Service
{
    public class FileReverseService : IFileReverse
    {
        public void ReverseFile(string inputFile, string outputFile)
        {
            if (!File.Exists(inputFile))
                throw new ArgumentNullException(nameof(inputFile));

            if (string.IsNullOrEmpty(outputFile))
                throw new ArgumentNullException(nameof(outputFile));

            var textToReverse = File.ReadAllText(inputFile, Encoding.ASCII);

            if (string.IsNullOrEmpty(textToReverse))
                throw new InvalidOperationException($"No text to reverse in {inputFile}.");

            var textArray = textToReverse.ToCharArray();
            var sb = new StringBuilder();

            for (var i = textArray.Length - 1; i >= 0; i--)
            {
                sb.Append(textArray[i]);
            }

            File.WriteAllText(outputFile, sb.ToString(), Encoding.ASCII);
        }
    }
}