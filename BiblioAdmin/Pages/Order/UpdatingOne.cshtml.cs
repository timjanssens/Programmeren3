using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.Order
{
    public class UpdatingOneModel : PageModel
    {
        [BindProperty]
        public Bll.Order Order { get; set; }
        public List<Bll.Order> OrderList { get; set; }
        public List<Bll.Customer> CustomerList { get; set; }
        public List<Bll.OrderStatus> OrderStatusList { get; set; }
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
            this.Order = dbContext.Order.SingleOrDefault(m => m.Id == id);
            OrderList = dbContext.Order.ToList();
            CustomerList = dbContext.Customer.ToList();
            OrderStatusList = dbContext.OrderStatus.ToList();
            ShippingMethodList = dbContext.ShippingMethod.ToList();
        }


        public ActionResult OnPostUpdate(Bll.Order order)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page
            }
            // dbContext.OrderStatus.Update(orderStatus);
            dbContext.Order.Update(order);
            dbContext.SaveChanges();
            // keer terug naar de index pagina van OrderStatus
            return RedirectToPage("Index");
        }
    }
}
