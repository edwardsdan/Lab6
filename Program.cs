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
            Console.WriteLine("Enter a word or phrase you want to translate!");
            string x = Console.ReadLine();
            if (x.Length < 1)
            {
                Console.WriteLine("Sorry! Try again!");
                ValidateInput();
            }
                return x;
        }
        static void Main(string[] args)
        {

            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            string[] Test = ValidateInput().Split(' ');

            for(int i = 0; i<Test.Length; i++)
            {
                if (Regex.IsMatch(Test[i], @"^[a-zA-Z\']+$") == true)
                {
                    if (Test[i].IndexOfAny(vowels) == 0)
                    {
                        Console.Write(Test[i] + "way ");
                        continue;
                    }
                    else
                    {
                        int vowelIndex = Test[i].IndexOfAny(vowels);
                        string toAppend = Test[i].Substring(0, vowelIndex);
                        Console.Write(Test[i].Remove(0, vowelIndex) + toAppend + "ay ");
                        continue;
                    }
                }
                if (Regex.IsMatch(Test[i], @"^[a-zA-Z\u0021-\u0040]+$") == true)
                {
                    Console.Write(Test[i] + " ");
                }
            }
            Console.WriteLine();




            Console.WriteLine("Translate another word or phrase? (y/n)");
            string response = Console.ReadLine();
            if (string.Compare(response, "y", true) == 0)
            {
                Console.Clear();
                Main(args);
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}
