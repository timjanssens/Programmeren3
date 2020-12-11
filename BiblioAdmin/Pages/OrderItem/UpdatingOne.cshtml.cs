using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.OrderItem
{
    public class UpdatingOneModel : PageModel
    {
        [BindProperty]
        public Bll.OrderItem OrderItem { get; set; }
        public List<Bll.OrderItem> OrderItemList { get; set; }

        private readonly Bll.Student7Context dbContext;
        // voeg constructor toe om geïnjecteerde DBContext 
        // te kunnen binnenkrijgen in deze klasse
        public UpdatingOneModel(Bll.Student7Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            this.OrderItem = dbContext.OrderItem.SingleOrDefault(m => m.Id == id);
            OrderItemList = dbContext.OrderItem.ToList();
        }


        public ActionResult OnPostUpdate(Bll.OrderItem orderItem)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page
            }
            // dbContext.OrderStatus.Update(orderStatus);
            dbContext.OrderItem.Update(orderItem);
            dbContext.SaveChanges();
            // keer terug naar de index pagina van OrderStatus
            return RedirectToPage("Index");
        }
    }
}
