using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;
using System.Web;
using System.Web.Mvc;
using RestartMVC.Models;

namespace RestartMVC.Models
{
    public class DisplaywayController : Controller
    {
        //
        // GET: /Displayway/
        public ActionResult Index(int id)
        {
            StudentEntities obj = new StudentEntities();
         tbldisplay dis=   obj.tbldisplays.Single(x => x.Id == id);
            return View(dis);
        }

        //for partial view 
        public ActionResult part()
        {
            StudentEntities obj = new StudentEntities();

            IEnumerable<tbldisplay> x = obj.tbldisplays.ToList();
            return View(x);
        }
        public ActionResult display1(int id)
        {
            StudentEntities obj = new StudentEntities();
            tbldisplay dis = obj.tbldisplays.Single(x => x.Id == id);
            return View(dis);
        }

        public ActionResult Details(int id)
        {
            StudentEntities obj = new StudentEntities();
            tbldisplay dis = obj.tbldisplays.Single(x => x.Id == id);
            return View(dis);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentEntities obj = new StudentEntities();
            tbldisplay dis = obj.tbldisplays.Single(x => x.Id == id);
            return View(dis);
        }

        [HttpPost]
        public ActionResult Edit(tbldisplay disp)
        {
            if (ModelState.IsValid) { 
            StudentEntities obj = new StudentEntities();
            tbldisplay dis = obj.tbldisplays.Single(x => x.Id == disp.Id);
         
            dis.PersonalWebSite = disp.PersonalWebSite;
            dis.Salary = disp.Salary;
            dis.HireDate = disp.HireDate;
            dis.FullName = disp.FullName;
            dis.Gender = disp.Gender;
            dis.Age = disp.Age;

            obj.SaveChanges();

            return RedirectToAction("display1", new { id = dis.Id });
            }
            return View();
        }

	}
}