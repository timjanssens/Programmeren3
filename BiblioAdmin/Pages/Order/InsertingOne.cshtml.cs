using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.Order
{
    public class InsertingOneModel : PageModel
    {
        private readonly Bll.Student7Context dbContext;
        public List<Bll.Customer> CustomerList { get; set; }
        public List<Bll.OrderStatus> OrderStatusList { get; set; }
        public List<Bll.ShippingMethod> ShippingMethodList { get; set; }
        // voeg constructor toe om geïnjecteerde DBContext 
        // te kunnen binnenkrijgen in deze klasse
        public InsertingOneModel(Bll.Student7Context dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public Bll.Order Order { get; set; }
        public List<Bll.Order> OrderList { get; set; }
        public void OnGet()
        {
            OrderList = dbContext.Order.ToList();
            CustomerList = dbContext.Customer.ToList();
            OrderStatusList = dbContext.OrderStatus.ToList();
            ShippingMethodList = dbContext.ShippingMethod.ToList();
        }

        public ActionResult OnPostInsert(Bll.Order order)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page, nog een nieuwe ingeven
            }
          
            dbContext.Order.Add(order);
            dbContext.SaveChanges();
            // keer terug naar de index pagina van Order
            return RedirectToPage("Index");
        }
    }
}