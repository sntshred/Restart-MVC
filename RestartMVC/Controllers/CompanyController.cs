using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDbAccess;

namespace RestartMVC.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/

      
        public ActionResult Index()
        {
            COMPANY company = new COMPANY("Google");
            ViewBag.Departments = new SelectList(company.Departments, "Id", "Name");
            ViewBag.CompanyName = company.CompanyName;

            return View();
        }

        public ActionResult Index1()
        {
            COMPANY company = new COMPANY("Pragim");
            return View(company);
        }

        [HttpGet]
        public ActionResult selectCity()
        {
            COMPANY company = new COMPANY("Pragim");
            return View(company);   
        }
        
       

        [HttpPost]
        public string selectcity(COMPANY com)
        {
            
            if (string.IsNullOrEmpty(com.selectEmployeeCity))
            {
                return "you did not selected"; 
            }else{

                return "your selected city id" + com.selectEmployeeCity;
            }

          
        }


	}
}