using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.OrderStatus
{
    public class UpdatingOneModel : PageModel
    {
        [BindProperty]
        public Bll.OrderStatus OrderStatus { get; set; }
        public List<Bll.OrderStatus> OrderStatusList { get; set; }

        private readonly Bll.Student7Context dbContext;
        // voeg constructor toe om ge�njecteerde DBContext 
        // te kunnen binnenkrijgen in deze klasse
        public UpdatingOneModel(Bll.Student7Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            this.OrderStatus = dbContext.OrderStatus.SingleOrDefault(m => m.Id == id);
            OrderStatusList = dbContext.OrderStatus.ToList();
        }


        public ActionResult OnPostUpdate(Bll.OrderStatus orderStatus)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page
            }
            // dbContext.OrderStatus.Update(orderStatus);
            dbContext.OrderStatus.Update(orderStatus);
            dbContext.SaveChanges();
            // keer terug naar de index pagina van OrderStatus
            return RedirectToPage("Index");
        }

    }
}
