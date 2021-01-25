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
        public List<Bll.OrderItem> OrderItemList { get; set; }
        public Bll.OrderItem OrderItem { get; set; }
        public List<Bll.Book> BookList { get; set; }

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
            OrderItemList = DbContext.OrderItem.Where(m => m.OrderId == id).ToList();
            BookList = DbContext.Book.ToList();
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


        public ActionResult OnPostInsertOrderItem(Bll.OrderItem orderItem)
        {
            if (!ModelState.IsValid)
            {
                // als er een foutief gegeven is ingetypt ga terug
                // de pagina en toon de fout
                return Page(); // return page, nog een nieuwe ingeven
            }
            // dbContext.OrderItem.Update(orderItem);
            DbContext.OrderItem.Add(orderItem);
            DbContext.SaveChanges();
            // keer terug naar de ReadingOne pagina van Order
            return RedirectToPage("ReadingOne");
        }

        public ActionResult OnPostDeleteOrderItem(Bll.OrderItem orderItem)
        {
            DbContext.OrderItem.Remove(orderItem);
            DbContext.SaveChanges();
            return RedirectToPage("ReadingOne");

        }
    }
}