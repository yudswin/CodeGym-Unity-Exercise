using System;
using System.IO;

namespace FIleBinaryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter source file: ");
            string sourcePath = Console.ReadLine();
            Console.WriteLine("Enter destination file: ");
            string destinationPath = Console.ReadLine();

            FileInfo source = new FileInfo(sourcePath);
            FileInfo des = new FileInfo(destinationPath);
            try
            {
                CopyFileUsingFileInfo(source, des);
                Console.WriteLine("Copy Completed");
            }
            catch (IOException e)
            {
                Console.WriteLine("Cannot Copy");
                Console.Error.WriteLine(e.Message);
            }
        }

        private static void CopyFileUsingFileInfo(FileInfo source, FileInfo des)
        {
            source.CopyTo(des.FullName, true);
        }

        private static void CopyFileUsingStream(FileInfo source, FileInfo des)
        {
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                reader = new StreamReader(source.FullName);
                writer = new StreamWriter(des.FullName);
                char[] buffer = new char[1024];
                int length;
                while ((length = reader.Read(buffer, 0 , 0)) > 0)
                {
                    writer.Write(buffer, 0, length);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                writer.Close();
                writer.Dispose();
            }
        }
    }
}