using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace Filters.Controllers
{
        [Authorize]
    public class FiltersController : Controller
    {
        //
        // GET: /Filters/
        public ActionResult SecureMethod()
        {
            return View();
        }
            [AllowAnonymous]
        public ActionResult NonSecureMethod()
        {
            return View();
        }
	}
}