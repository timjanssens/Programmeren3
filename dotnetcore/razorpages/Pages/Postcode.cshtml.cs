using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razorpages.Pages
{
    public class PostcodeModel : PageModel
    {

        private PostcodeApp.Bll.Postcode postcode;
        public PostcodeApp.Bll.Postcode Postcode
        {
            get { return postcode; }
        }
        private PostcodeApp.Dal.IPostcode postcodeDalService;
        public PostcodeModel(PostcodeApp.Dal.IPostcode postcodeDalService)
        {
            this.postcodeDalService = postcodeDalService;
        }
        public void OnGet()
        {
            postcode = new PostcodeApp.Bll.Postcode();
            postcodeDalService.Postcode = postcode;
            postcodeDalService.ReadAll();
        }
    }
}
