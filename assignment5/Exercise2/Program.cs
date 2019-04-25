using System;

namespace Exercise2
{
    class Program
    {
        /// <summary>
        /// Converts a long name to its acronym.
        /// </summary>
        public static void Acronym()
        {
            string str = Console.ReadLine();
            String[] words = str.Split(' ', '-');
            for (int i = 0; i < words.Length; ++i)
            {
                if(Char.IsLetter(words[i], 0))
                {
                    String curr = words[i];
                    Console.Write(char.ToUpper(curr[0]));
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Acronym();
        }
    }
}
