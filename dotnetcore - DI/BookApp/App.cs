using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp
{
    class App
    {
        private readonly Dal.IBook dal;

        public App(Dal.IBook bookDal)
        {
            this.dal = bookDal;
        }
        public void TryOut()
        {
            Console.WriteLine("De BookApp");
 
            //omdat er altijd van Book.Xml vertrokken wordt => hard coded ipv DI
            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
            bookXml.Book = book;
            bookXml.ReadAll();

            //als er zowel csv als json als xml aanwezig waren kon met DI gewerkt worden zoals hieronder
            //dal.Separator = '|';
            //dal.ReadAll();


          //Verder werken met DI
            Console.WriteLine(dal.Message);
            View.BookConsole view = new View.BookConsole(dal.Book);
            view.List();
            // serialize postcodes met een andere separator
            // naar ander bestand
            dal.ConnectionString = "Data/Book2";
            dal.Create('|');
            Console.WriteLine(dal.Message);
        }
    }
}
