using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.Book
{
    public class ReadingOneModel : PageModel
    {
        private readonly Bll.Student7Context DbContext;
        public Bll.Book Book { get; set; }
        public List<Bll.Book> BookList { get; set; }

        public ReadingOneModel(Bll.Student7Context dbContext)
        {
            this.DbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            this.Book = DbContext.Book.SingleOrDefault(m => m.Id == id);
            this.BookList = DbContext.Book.ToList();
        }
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {

                Bll.Book book = new Bll.Book();
                book.Id = (int)id;
                DbContext.Remove(book);
                DbContext.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
