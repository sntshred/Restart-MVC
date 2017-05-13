using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    public class RequirehttpController : Controller
    {
        //
        // GET: /Requirehttp/
        [RequireHttps]
        public string Index()
        {
            return "Hello please go by https protocol";
        }
	}
}