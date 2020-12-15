using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.Order
{
    public class ReadingOneModel : PageModel
    {
        private readonly Bll.Student7Context DbContext;
        public Bll.Order Order { get; set; }
        public List<Bll.Order> OrderList { get; set; }

        public ReadingOneModel(Bll.Student7Context dbContext)
        {
            this.DbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            this.Order = DbContext.Order.SingleOrDefault(m => m.Id == id);
            Order.ShippingMethod = DbContext.ShippingMethod.SingleOrDefault(m => m.Id == this.Order.ShippingMethodId);
            Order.Status = DbContext.OrderStatus.SingleOrDefault(m => m.Id == this.Order.StatusId);
            Order.Customer = DbContext.Customer.SingleOrDefault(m => m.Id == this.Order.CustomerId);
            OrderList = DbContext.Order.ToList();

        }
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {

                Bll.Order order = new Bll.Order();
                order.Id = (int)id;
                DbContext.Remove(order);
                DbContext.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}