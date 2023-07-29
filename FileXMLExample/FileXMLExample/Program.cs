using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileXMLExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWriten = ReadWriteFileXML.WriteToFile();
            if (isWriten)
            {
                ReadWriteFileXML.ReadFromFile();
            }
            else
            {
                System.Console.WriteLine("Write data to file occur an error. Please try again !");
            }

        }
    }
}
