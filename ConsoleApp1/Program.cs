using System;

namespace CodeKata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Kata.CountSmileys2(new string[] { ":D", ":~)", ";~D", ":)" }));

            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}