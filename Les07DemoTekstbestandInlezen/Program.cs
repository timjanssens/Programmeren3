using System;

namespace Les07DemoTekstbestandInlezen
{
    class Program
    {
        static void Main(string[] args)
        {
            string tekst = TryOut.ReadFromCSVFile();

            Console.WriteLine(tekst);
            Console.ReadKey();
        }
    }
    
}
