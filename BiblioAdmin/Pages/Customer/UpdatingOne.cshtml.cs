using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.Customer
{
    public class UpdatingOneModel : PageModel
    {
        [BindProperty]
        public Bll.Customer Customer { get; set; }
        public List<Bll.Customer> CustomerList { get; set; }

        private readonly Bll.Student7Context dbContext;
        // voeg constructor toe om geïnjecteerde DBContext 
        // te kunnen binnenkrijgen in deze klasse
        public UpdatingOneModel(Bll.Student7Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            this.Customer = dbContext.Customer.SingleOrDefault(m => m.Id == id);
            CustomerList = dbContext.Customer.ToList();
        }


        public ActionResult OnPostUpdate(Bll.Customer customer)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page
            }
            
            dbContext.Customer.Update(customer);
            dbContext.SaveChanges();
            // keer terug naar de index pagina van Customer
            return RedirectToPage("Index");
        }

    }
}
