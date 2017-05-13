using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    public class ChildActionController : Controller
    {
        //
        // GET: /ChildAction/
        public ActionResult Index()
        {
            return View();

        }
        [ChildActionOnly]
        public ActionResult countries(List<string> countries)
        {
            return View(countries);
        }

       
       

	}

}