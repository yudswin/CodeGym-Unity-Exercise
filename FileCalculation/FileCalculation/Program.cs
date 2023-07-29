using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCalculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input file path");
            string path = Console.ReadLine();
            Console.WriteLine("File path: " + path);
            ReadTextFileExample example = new ReadTextFileExample();
            example.ReadTextFile(path);

            Console.ReadKey();
        }
    }
}
