using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.View
{
    class BookConsole
    {
        public Bll.Book Model { get; set; }

        public BookConsole(Bll.Book book)
        {
            this.Model = book;
        }
        public void List(Bll.Book book)
        {
            this.Model = book;
        }
        public void List()
        {
            foreach (Bll.Book book in Model.List)
            {
                Console.WriteLine($"{book?.Title}\t{book?.Author}\t{book?.Year}\t{book?.City}\t{book?.Publisher}");
            }
        }
    }
}
