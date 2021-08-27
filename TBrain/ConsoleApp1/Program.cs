using System;
using Exercise01;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number to convert to words: ");
            long input = long.Parse(Console.ReadLine());

            if (string.IsNullOrEmpty(input.ToString())) return;

            Console.WriteLine("{0}", Exercise01.NumToWords(input));
        }

    }
}
