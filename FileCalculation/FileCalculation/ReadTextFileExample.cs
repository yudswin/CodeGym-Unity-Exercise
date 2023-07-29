using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCalculation
{
    public class ReadTextFileExample
    {
        public void ReadTextFile(string filePath)
        {
            {
                try
                {
                    FileInfo file = new FileInfo(filePath);
                    if (!file.Exists)
                    {
                        throw new FileNotFoundException();
                    }

                    StreamReader reader = new StreamReader(filePath);
                    string line = "";
                    int sum = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        sum += Int32.Parse(line);
                    }
                    reader.Close();
                    Console.WriteLine("Total: " + sum);
                }
                catch (System.Exception)
                {
                    Console.Error.WriteLine("File not found or invalid content");
                }
            }
        }
    }
}
