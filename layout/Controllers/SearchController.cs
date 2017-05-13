using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using layout.Models;

namespace layout.Controllers
{
    public class SearchController : Controller
    {
        private StudentEntities db = new StudentEntities();

        // GET: /Search/
      

        public ActionResult Index(string searchby, string search,int? page,string sortby)
               {

                   ViewBag.SortByNameParameter = string.IsNullOrEmpty(sortby) ? "Name Desc" : "";
                   ViewBag.SortByGenderParameter = sortby == "Gender" ? "Gender Desc" : "Gender";

                   var Employess = db.tblEmployees.AsQueryable();
            if (searchby == "Gender")
            {
                Employess = Employess.Where(emp => emp.Gender == search || search == null);
            }
            else
            {
                 Employess = Employess.Where(x => x.Name.StartsWith(search) || search == null);

            }
            switch (sortby)
            {
                case "Name Desc":
                    Employess = Employess.OrderByDescending(x => x.Name);
                    break;
                case "Gender Desc":
                    Employess = Employess.OrderByDescending(x => x.Gender);
                    break;
                case "Gender":
                    Employess = Employess.OrderBy(x => x.Gender);
                    break;
                 default:
                    Employess = Employess.OrderBy(x => x.Name);
                    break;
            }
         return View(Employess.ToPagedList(page ?? 1, 3));
          
        }

        // GET: /Search/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblemployee = db.tblEmployees.Find(id);
            if (tblemployee == null)
            {
                return HttpNotFound();
            }
            return View(tblemployee);
        }

        // GET: /Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Search/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Gender,DeptName")] tblEmployee tblemployee)
        {
            if (ModelState.IsValid)
            {
                db.tblEmployees.Add(tblemployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblemployee);
        }

        // GET: /Search/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblemployee = db.tblEmployees.Find(id);
            if (tblemployee == null)
            {
                return HttpNotFound();
            }
            return View(tblemployee);
        }

        // POST: /Search/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="Id,Name,Gender,DeptName")] tblEmployee tblemployee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tblemployee).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(tblemployee);
        //}

        // GET: /Search/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblemployee = db.tblEmployees.Find(id);
            if (tblemployee == null)
            {
                return HttpNotFound();
            }
            return View(tblemployee);
        }

        // POST: /Search/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmployee tblemployee = db.tblEmployees.Find(id);
            db.tblEmployees.Remove(tblemployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
