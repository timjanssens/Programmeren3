using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razorpages.Pages
{
    public class BookModel : PageModel
    {
        private BookApp.Bll.Book book;

        public BookApp.Bll.Book Book
        {
            get { return book; }
        }

        private BookApp.Dal.IBook bookDalService;

        public BookModel(BookApp.Dal.IBook bookDalService)
        {
            this.bookDalService = bookDalService;
        }
        public void OnGet()
        {
            book = new BookApp.Bll.Book();
            bookDalService.Book = book;
            bookDalService.ReadAll();
        }
    }
}
