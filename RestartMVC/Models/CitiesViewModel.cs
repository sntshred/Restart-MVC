using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestartMVC.Models
{
    public class CitiesViewModel
    {
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<string> Name { get; set; }
    }
}