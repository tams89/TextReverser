using System;
using FileReverser.Service;

namespace FileReverser
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the input files path (then press enter):");
            var inputFilePath = Console.ReadLine();

            Console.WriteLine("Please enter the output files path (then press enter):");
            var outputFilePath = Console.ReadLine();

            var revserseService = new FileReverseService();
            revserseService.ReverseFile(inputFilePath, outputFilePath);

            Console.WriteLine("Done!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}