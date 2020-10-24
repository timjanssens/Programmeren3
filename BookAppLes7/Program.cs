using DotNetCore.Learning;
using System;
using System.Collections.Generic;

namespace DotNetCore.Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gegevensserialisatie");
            List<Book> booksFromXml = BookSerializing.DeserializeFromXml();
            BookSerializing.ShowBooks(booksFromXml);
            
            Console.WriteLine("".PadLeft(60, '*'));
            Console.WriteLine("\n\n\nIngelezen CSV bestand!\n\n\n");
            Console.WriteLine("".PadLeft(60, '*'));
            BookSerializing.SerializeListToCsv(booksFromXml, @"Data/Book.csv", "|");
            List<Book> booksFromCsv = BookSerializing.DeserializeCsvToList("|");
            BookSerializing.ShowBooks(booksFromCsv);
            
            Console.WriteLine("".PadLeft(60, '*'));
            Console.WriteLine("\n\n\nIngelezen JSON bestand!\n\n\n");
            Console.WriteLine("".PadLeft(60, '*'));
            BookSerializing.SerializeListToJson(booksFromCsv, @"Data/Book.json");
            List<Book> booksFromJson = BookSerializing.DeserializeJsonToList (@"Data/Book.json");
            BookSerializing.ShowBooks(booksFromJson);

            Console.ReadKey();
        }
    }
}
