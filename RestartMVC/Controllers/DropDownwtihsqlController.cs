using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDbAccess;

namespace RestartMVC.Controllers
{
    public class DropDownwtihsqlController : Controller
    {
        //
        // GET: /DropDownwtihsql/
        public ActionResult Index()
        {
            EmployeeEntities obj = new EmployeeEntities();
            ViewBag.Empname = new SelectList(obj.tblEmployees, "Id", "Name");


            return View();
        }
	}
}