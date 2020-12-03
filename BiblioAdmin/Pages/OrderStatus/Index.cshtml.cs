using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.OrderStatus
{
    public class IndexModel : PageModel
    {
        private readonly Bll.Student7Context dbContext;
        public List<Bll.OrderStatus> OrderStatusList { get; set; }
        public IndexModel(Bll.Student7Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            this.OrderStatusList = dbContext.OrderStatus.ToList();
        }
    }
}
