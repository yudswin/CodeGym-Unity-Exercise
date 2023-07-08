using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert a string: ");
            string str = Console.ReadLine();
            CharCount(str);
            Console.ReadKey();
        }

        static void CharCount(string str)
        {
            //char [newCharacter, frequency]
            List<char> characters = new List<char>();
            List<int> frequency = new List<int>();
            characters.Add(str[0]);
            frequency.Add(1);
            for (int i = 1; i < str.Length; i++)
            {
                if (Check(characters, str[i]))
                {
                    AddChar(characters, frequency, str[i]);
                } else
                {
                    characters.Add(str[i]);
                    frequency.Add(1);
                }
            }
            
            for (int i = 0; i < characters.Count; i++)
            {
                Console.WriteLine("letter '{0}' : {1}", characters[i], frequency[i]);
            }
            
        }

        static bool Check(List<char> charList, char key)
        {
            for (int i = 0;i < charList.Count;i++)
            {
                if (charList[i] == key) return true;
            }
            return false;
        }

        static void AddChar(List<char> charList,List<int> freq, int key)
        {
            for (int i = 0; i < charList.Count; i++)
            {
                if (charList[i] == key) freq[i]++;
            }
        }
    }
}
