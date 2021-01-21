using BookApp.Bll;
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


            foreach (Bll.Book book in Book.List)
            {
                Console.WriteLine($"{book?.Title} - {book?.Author} - {book?.Year} - {book?.City}" +
                    $" - {book?.Publisher} - {book?.Edition} - {book?.Translator} - {book?.Comment}");
            }
        }
    }
}
