using System;

namespace hwapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			Console.WriteLine("Hoe heet je?");
			string naam = Console.ReadLine();
			Console.WriteLine($"Hallo {naam}");
            Console.ReadKey();
        }
    }
}
