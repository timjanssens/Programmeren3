using System;
using BookApp.Dal;

namespace BookApp
{
    class Program
    {
        static void Main(string[] args)
        {

            CreateCSV();
            TestCSV();
            
            CreateXML();
            TestXML();

            CreateJSON();
            TestJSON();

            Console.ReadKey();
        }

        public static void CreateCSV()
        {
            Console.WriteLine("".PadLeft(60, '*'));
            Console.WriteLine("\n\n\nDe BookApp CSV\n\n\n");
            Console.WriteLine("".PadLeft(60, '*'));

            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
            bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);

            Dal.BookCsv bookCsv = new Dal.BookCsv(book);
            bookCsv.ConnectionString = @"Data/Book2";
            bookCsv.Create('|');
            Console.WriteLine(bookCsv.Message);
        }

        public static void TestCSV()
        {
            Bll.Book book = new Bll.Book();
            BookCsv bookCsv = new BookCsv(book);
            bookCsv.ConnectionString = @"Data/Book2";
            bookCsv.Book = book;
            bookCsv.ReadAll();
            Console.WriteLine(bookCsv.Message);
            Pl.BookConsole view = new Pl.BookConsole(book);
            view.List();
        }

        public static void CreateXML()
        {
            Console.WriteLine("".PadLeft(60, '*'));
            Console.WriteLine("\n\n\nDe BookApp XML\n\n\n");
            Console.WriteLine("".PadLeft(60, '*'));

            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
            bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);

            BookXml bookXml1 = new BookXml(book);
            bookXml1.ConnectionString = @"Data/Book2";
            bookXml1.Create();
            Console.WriteLine(bookXml1.Message);

        }

        public static void TestXML()
        {
            Bll.Book book = new Bll.Book();
            BookXml bookXml = new BookXml(book);
            bookXml.ConnectionString = @"Data/Book2";
            bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);
            Pl.BookConsole view = new Pl.BookConsole(book);
            view.List();
        }

        public static void CreateJSON()
        {
            Console.WriteLine("".PadLeft(60, '*'));
            Console.WriteLine("\n\n\nDe BookApp JSON\n\n\n");
            Console.WriteLine("".PadLeft(60, '*'));

            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
            bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);


            BookJson bookJson = new BookJson(book);
            bookJson.ConnectionString = @"Data/Book2";
            bookJson.Create();
            Console.WriteLine(bookJson.Message);

        }

        public static void TestJSON()
        {
            Bll.Book book = new Bll.Book();
            BookJson bookJson = new BookJson(book);
            bookJson.ConnectionString = @"Data/Book2";
            bookJson.Book = book;
            bookJson.ReadAll();
            Console.WriteLine(bookJson.Message);
            Pl.BookConsole view = new Pl.BookConsole(book);
            view.List();
        }

    }
}
