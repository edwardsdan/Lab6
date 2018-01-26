using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        public static string ValidateInput ()
        {
            bool loop = true;
            Console.WriteLine("Enter a word or phrase you want to translate!");
            string x = Console.ReadLine();
            while (loop == true)
            {
                if (x.Length < 1)
                {
                    Console.WriteLine("Sorry! Try again!");
                    x = Console.ReadLine();
                }
                else
                {
                    loop = false;
                }
            }
            return x;
        }

        public static void Print(string[] x)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            for (int i = 0; i < x.Length; i++)
            {
                if (Regex.IsMatch(x[i], @"^[a-zA-Z\']+$") == true)
                {
                    if (x[i].IndexOfAny(vowels) == 0)
                    {
                        Console.Write(x[i] + "way ");
                        continue;
                    }
                    else
                    {
                        int vowelIndex = x[i].IndexOfAny(vowels);
                        string toAppend = x[i].Substring(0, vowelIndex);
                        Console.Write(x[i].Remove(0, vowelIndex) + toAppend + "ay ");
                        continue;
                    }
                }
                if (Regex.IsMatch(x[i], @"^[a-zA-Z\u0021-\u0040]+$") == true)
                {
                    Console.Write(x[i] + " ");
                }
            }
        }

        static void Main(string[] args)
        {
            bool loop = true;
            while (loop == true)
            {
                string[] Test = ValidateInput().Split(' ');
                Print(Test);

                Console.WriteLine();

                Console.WriteLine("Translate another word or phrase? (y/n)");
                string response = Console.ReadLine();
                if (string.Compare(response, "y", true) == 0)
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    loop = false;
                }
            }
        }
    }
}
