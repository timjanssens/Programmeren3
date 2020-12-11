using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.Customer
{
    public class ReadingOneModel : PageModel
    {
        private readonly Bll.Student7Context DbContext;
        public Bll.Customer Customer { get; set; }
        public List<Bll.Customer> CustomerList { get; set; }

        public ReadingOneModel(Bll.Student7Context dbContext)
        {
            this.DbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            this.Customer = DbContext.Customer.SingleOrDefault(m => m.Id == id);
            this.CustomerList = DbContext.Customer.ToList();
        }

        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {

                Bll.Customer customer = new Bll.Customer();
                customer.Id = (int)id;
                DbContext.Remove(customer);
                DbContext.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
