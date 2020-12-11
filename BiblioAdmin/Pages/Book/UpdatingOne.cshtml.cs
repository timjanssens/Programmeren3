using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.Book
{
    public class UpdatingOneModel : PageModel
    {
        [BindProperty]
        public Bll.Book Book { get; set; }
        public List<Bll.Book> BookList { get; set; }

        private readonly Bll.Student7Context dbContext;
        // voeg constructor toe om ge�njecteerde DBContext 
        // te kunnen binnenkrijgen in deze klasse
        public UpdatingOneModel(Bll.Student7Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            this.Book = dbContext.Book.SingleOrDefault(m => m.Id == id);
            BookList = dbContext.Book.ToList();
        }


        public ActionResult OnPostUpdate(Bll.Book book)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page
               
            }
     
            dbContext.Book.Update(book);
            dbContext.SaveChanges();
            // keer terug naar de index pagina van Book
            return RedirectToPage("Index");
        }

    }
}
