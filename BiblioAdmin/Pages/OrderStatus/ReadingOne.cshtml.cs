using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.OrderStatus
{
    public class ReadingOneModel : PageModel
    {
        private readonly Bll.Student7Context DbContext;
        public Bll.OrderStatus OrderStatus { get; set; }
        public List<Bll.OrderStatus> OrderStatusList { get; set; }

        public ReadingOneModel(Bll.Student7Context dbContext)
        {
            this.DbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            this.OrderStatus = DbContext.OrderStatus.SingleOrDefault(m => m.Id == id);
            OrderStatusList = DbContext.OrderStatus.ToList();
        }
    }
}
