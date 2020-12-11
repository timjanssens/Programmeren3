using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.ShippingMethod
{
    public class UpdatingOneModel : PageModel
    {
        [BindProperty]
        public Bll.ShippingMethod ShippingMethod { get; set; }
        public List<Bll.ShippingMethod> ShippingMethodList { get; set; }

        private readonly Bll.Student7Context dbContext;
        // voeg constructor toe om geïnjecteerde DBContext 
        // te kunnen binnenkrijgen in deze klasse
        public UpdatingOneModel(Bll.Student7Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            this.ShippingMethod = dbContext.ShippingMethod.SingleOrDefault(m => m.Id == id);
            ShippingMethodList = dbContext.ShippingMethod.ToList();
        }


        public ActionResult OnPostUpdate(Bll.ShippingMethod shippingMethod)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page
            }
            // dbContext.OrderStatus.Update(orderStatus);
            dbContext.ShippingMethod.Update(ShippingMethod);
            dbContext.SaveChanges();
            // keer terug naar de index pagina van OrderStatus
            return RedirectToPage("Index");
        }

    }
}