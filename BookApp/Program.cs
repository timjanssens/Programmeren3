using System;
using System.ComponentModel.Design;

namespace BookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateXmlFromXml();
            CreateCsvFromXml();
            CreateJsonFromXml();
            Console.ReadKey();
        }

        static void CreateXmlFromXml()
        {
            Console.WriteLine("De Book App Xml to Xml");
            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
            bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);
            View.BookConsole view = new View.BookConsole(book);
            view.List();
            bookXml.ConnectionString = "Data/Book2";
            bookXml.Create();
            Console.WriteLine(bookXml.Message);
        }

        static void CreateCsvFromXml()
        {
            Console.WriteLine("De Book App Xml to Csv");
            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
            bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);
            View.BookConsole view = new View.BookConsole(book);
            view.List();
            Dal.BookCsv bookCsv = new Dal.BookCsv(book);
            bookCsv.ConnectionString = "Data/Book2";
            bookCsv.Create();
            Console.WriteLine(bookCsv.Message);

        }

        static void CreateJsonFromXml()
        {
            Console.WriteLine("De Book App Xml to Json");
            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
            bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);
            View.BookConsole view = new View.BookConsole(book);
            view.List();
            // serialize naar ander bestand
            Dal.BookJson bookJson = new Dal.BookJson(book);
            bookJson.ConnectionString = "Data/Book2";
            bookJson.Create();
            Console.WriteLine(bookJson.Message);

        }


    }
}
