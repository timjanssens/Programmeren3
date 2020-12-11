using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.OrderStatus
{
    public class InsertingOneModel : PageModel
    {
        private readonly Bll.Student7Context dbContext;
        public InsertingOneModel(Bll.Student7Context dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public Bll.OrderStatus OrderStatus { get; set; }
        public List<Bll.OrderStatus> OrderStatusList { get; set; }
        public void OnGet()
        {
            OrderStatusList = dbContext.OrderStatus.ToList();
        }

        public ActionResult OnPostInsert(Bll.OrderStatus orderStatus)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page, nog een nieuwe ingeven
            }
            // dbContext.OrderStatus.Update(orderStatus);
            dbContext.OrderStatus.Add(orderStatus);
            dbContext.SaveChanges();
            // keer terug naar de index pagina van OrderStatus
            return RedirectToPage("Index");
        }
    }
}
