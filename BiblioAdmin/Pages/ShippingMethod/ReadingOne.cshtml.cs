using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BiblioAdmin.Pages.ShippingMethod
{
    public class ReadingOneModel : PageModel
    {
        private readonly Bll.Student7Context DbContext;
        public Bll.ShippingMethod ShippingMethod { get; set; }
        public List<Bll.ShippingMethod> ShippingMethodList { get; set; }

        public ReadingOneModel(Bll.Student7Context dbContext)
        {
            this.DbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            this.ShippingMethod = DbContext.ShippingMethod.SingleOrDefault(m => m.Id == id);
            ShippingMethodList = DbContext.ShippingMethod.ToList();
        }
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {

                Bll.ShippingMethod shippingMethod = new Bll.ShippingMethod();
                shippingMethod.Id = (int)id;
                DbContext.Remove(shippingMethod);
                DbContext.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
