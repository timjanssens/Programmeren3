using System;
using System.ComponentModel.Design;

namespace BookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TryOutXml();
            Console.ReadKey();
        }

        static void TryOutXml()
        {
            Console.WriteLine("De Book App Xml");
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

    }
}
