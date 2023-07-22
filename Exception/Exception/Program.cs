using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<char> characters = new List<char>();
                characters.InsertRange(0, new Char[] { 'a', 'b', 'c', 'd', 'e', 'f' });
                int value = characters[6]; //out of range

            }
            catch (IndexOutOfRangeException ex)
            {
                System.Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
    }
}
