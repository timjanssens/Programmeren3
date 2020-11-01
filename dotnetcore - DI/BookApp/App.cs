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
            // de seperator staat standaard op ;
            // in het Postcode.csv bestand is dat |
          //  dal.Separator = '|';
            dal.ReadAll();
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
