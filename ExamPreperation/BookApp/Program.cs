using BookApp.Dal;
using System;

namespace BookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateXmlFromXml();
            PrintXml();
            CreateCsvFromXml();
            PrintCsv();
            CreateJsonFromXml();
            PrintJson();
            Console.ReadKey();
        }


        static void CreateXmlFromXml()
        {
            Console.WriteLine("".PadLeft(100, '*'));
            Console.WriteLine($"\n\nDe Book App Xml to Xml\n\n");
            Console.WriteLine("".PadLeft(100, '*'));
            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
           // bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);
            bookXml.ConnectionString = "Data/Book2";
            bookXml.Create();
            Console.WriteLine(bookXml.Message);

        }

        static void PrintXml()
        {
            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
            bookXml.ConnectionString = @"Data/Book2";
       //     bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);

            View.BookConsole view = new View.BookConsole(book);
            view.List();

        }

        static void CreateCsvFromXml()
        {
            Console.WriteLine("".PadLeft(100, '*'));
            Console.WriteLine($"\n\nDe Book App Xml to Csv\n");
            Console.WriteLine("".PadLeft(100, '*'));
            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
         //   bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);
            Dal.BookCsv bookCsv = new Dal.BookCsv(book);
            bookCsv.ConnectionString = "Data/Book2";
            bookCsv.Create();
            Console.WriteLine(bookCsv.Message);

        }

        static void PrintCsv()
        {
            Bll.Book book = new Bll.Book();
            Dal.BookCsv bookCsv = new Dal.BookCsv(book);
            bookCsv.ConnectionString = @"Data/Book2";
         //   bookCsv.Book = book;
            bookCsv.ReadAll();
            View.BookConsole view = new View.BookConsole(book);
            view.List();
        }

        static void CreateJsonFromXml()
        {
            Console.WriteLine("".PadLeft(100, '*'));
            Console.WriteLine($"\n\nDe Bookk App Xml to Json\n\n");
            Console.WriteLine("".PadLeft(100, '*'));
            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
         //   bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);
            // Deserialize naar ander bestand
            Dal.BookJson bookJson = new Dal.BookJson(book);
            bookJson.ConnectionString = "Data/Book2";
            bookJson.Create();
            Console.WriteLine(bookJson.Message);
        }

        static void PrintJson()
        {
            Bll.Book book = new Bll.Book();
            Dal.BookJson bookJson = new Dal.BookJson(book);
            bookJson.ConnectionString = @"Data/Book2";
         // bookJson.Book = book;
            bookJson.ReadAll();
            View.BookConsole view = new View.BookConsole(book);
            view.List();

        }

    }
}
