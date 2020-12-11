using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.Book
{
    public class InsertingOneModel : PageModel
    {
        private readonly Bll.Student7Context dbContext;
        // voeg constructor toe om geïnjecteerde DBContext 
        // te kunnen binnenkrijgen in deze klasse
        public InsertingOneModel(Bll.Student7Context dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public Bll.Book Book { get; set; }
        public List<Bll.Book> BookList { get; set; }
        public void OnGet()
        {
            BookList = dbContext.Book.ToList();
        }

        public ActionResult OnPostInsert(Bll.Book book)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page, nog een nieuwe ingeven
            }
            // dbContext.OrderStatus.Update(orderStatus);
            dbContext.Book.Add(book);
            dbContext.SaveChanges();
            // keer terug naar de index pagina van OrderStatus
            return RedirectToPage("Index");
        }
    }
}
