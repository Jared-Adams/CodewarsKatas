using System;

namespace FindMiddleCharacter
{
    class Program
    {
        /// <summary>
        /// You are going to be given a word. Your job is to return the middle character of the word. 
        /// If the word's length is odd, return the middle character.
        /// If the word's length is even, return the middle 2 characters.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine(GetMiddle("Middle"));
            Console.ReadLine();
        }

        public static string GetMiddle(string s) => s.Length % 2 == 0 ? $"{s[(s.Length / 2) - 1]}{s[s.Length / 2]}" : $"{s[s.Length / 2]}";
    }
}
