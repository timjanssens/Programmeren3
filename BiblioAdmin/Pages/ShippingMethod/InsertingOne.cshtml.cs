using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.ShippingMethod
{
    public class InsertingOneModel : PageModel
    {
        private readonly Bll.Student7Context dbContext;
        public InsertingOneModel(Bll.Student7Context dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public Bll.ShippingMethod ShippingMethod { get; set; }
        public List<Bll.ShippingMethod> ShippingMethodList { get; set; }
        public void OnGet()
        {
            ShippingMethodList = dbContext.ShippingMethod.ToList();
        }

        public ActionResult OnPostInsert(Bll.ShippingMethod shippingMethod)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page, nog een nieuwe ingeven
            }
            // dbContext.OrderStatus.Update(orderStatus);
            dbContext.ShippingMethod.Add(shippingMethod);
            dbContext.SaveChanges();
            // keer terug naar de index pagina van OrderStatus
            return RedirectToPage("Index");
        }
    }
}