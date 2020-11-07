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
            Console.WriteLine("".PadLeft(60, '*'));
            Console.WriteLine("\n\n\nDe BookApp\n\n\n");
            Console.WriteLine("".PadLeft(60, '*'));

            dal.Separator = '|';
            dal.ReadAll();
            Console.WriteLine(dal.Message);
            Pl.BookConsole view = new Pl.BookConsole(dal.Book);
            view.List();

            dal.ConnectionString = "Data/Book2";
            dal.Create('|');
            Console.WriteLine(dal.Message);
        }

    }
}
