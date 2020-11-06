using BookApp;
using DotnetCore.Learning;
using System;
using System.Collections.Generic;

namespace DontNetCore.Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gegevensserialisatie");
            List<Book> books = BookSerializing.DeserializeFromXml();
            BookSerializing.ShowBooks(books);
            BookSerializing.SerializeListToCsv(books, @"Data/Book2.csv", "|");
            books = BookSerializing.DeserializeCsvToList("|");

            Console.WriteLine("".PadLeft(60, '*'));
            Console.WriteLine("\n\n\nIngelezen van CSV bestand!\n\n\n");
            Console.WriteLine("".PadLeft(60, '*'));
            BookSerializing.ShowBooks(books);
            BookSerializing.SerializeListToJson(books, @"Data/Book2.json");

            books = BookSerializing.DeserializeJsonToList(@"Data/Book2.json");
            Console.WriteLine("".PadLeft(60, '*'));
            Console.WriteLine("\n\n\nIngelezen van JSON bestand!\n\n\n");
            Console.WriteLine("".PadLeft(60, '*'));
            BookSerializing.ShowBooks(books);

            Console.ReadKey();
        }
    }
}
