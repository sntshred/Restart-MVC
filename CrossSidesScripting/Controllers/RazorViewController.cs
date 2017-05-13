using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrossSidesScripting.Controllers
{
    public class RazorViewController : Controller
    {
        //
        // GET: /RazorView/
        public ActionResult Index()
        {
            return View();
        }
	}
}