using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Common;

namespace Filters.Controllers
{
    public class CustomErrorController : Controller
    {
        //
        // GET: /CustomError/
        [TrackExcectuationTime]
        public string Index()
        {
            return "custom error method";

        }

        [TrackExcectuationTime]

        public string Welcome()
        {
            throw new Exception("Exception got occured");

        }


	}
}