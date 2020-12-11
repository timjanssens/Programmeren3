using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.OrderItem
{
    public class InsertingOneModel : PageModel
    {
        private readonly Bll.Student7Context dbContext;
        public InsertingOneModel(Bll.Student7Context dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public Bll.OrderItem OrderItem { get; set; }
        public List<Bll.OrderItem> OrderItemList { get; set; }
        public void OnGet()
        {
            OrderItemList = dbContext.OrderItem.ToList();
        }

        public ActionResult OnPostInsert(Bll.OrderItem orderItem)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page, nog een nieuwe ingeven
            }
            // dbContext.OrderStatus.Update(orderStatus);
            dbContext.OrderItem.Add(orderItem);
            dbContext.SaveChanges();
            // keer terug naar de index pagina van OrderStatus
            return RedirectToPage("Index");
        }
    }
}