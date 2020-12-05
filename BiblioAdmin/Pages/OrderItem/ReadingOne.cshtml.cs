using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.OrderItem
{
    public class ReadingOneModel : PageModel
    {
        private readonly Bll.Student7Context DbContext;
        public Bll.OrderItem OrderItem { get; set; }
        public List<Bll.OrderItem> OrderItemList { get; set; }

        public ReadingOneModel(Bll.Student7Context dbContext)
        {
            this.DbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            this.OrderItem = DbContext.OrderItem.SingleOrDefault(m => m.Id == id);
            OrderItemList = DbContext.OrderItem.ToList();
        }
    }
}
