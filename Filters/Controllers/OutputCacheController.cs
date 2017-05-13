using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Filters.Models;
using Filters.Common;

namespace Filters.Controllers
{
    public class OutputCacheController : Controller
    {
        private StudentEntities db = new StudentEntities();

        // GET: /OutputCache/
        //[OutputCache(Duration=10)]
       
        //getting the cache duration from the web.config, so that we could not hardcore it
        //[OutputCache(CacheProfile = "1MinuteCache")]

        //Custome case profile
        [partialCacheAtrribute("1MinuteCache")]
        public ActionResult Index()
        {
            
            //System.Threading.Thread.Sleep(5000);
            return View(db.tblEmployees.ToList());
        }

        [ChildActionOnly]
        [OutputCache(Duration=20)]
        public string GetEmployeeCount()
        {


            return "Employess Count" + db.tblEmployees.Count().ToString() + " @" + DateTime.Now.ToString();

        }
        

        
        
        
        // GET: /OutputCache/Details/5
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

        // GET: /OutputCache/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /OutputCache/Create
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

        // GET: /OutputCache/Edit/5
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

        // POST: /OutputCache/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Gender,DeptName")] tblEmployee tblemployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblemployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblemployee);
        }

        // GET: /OutputCache/Delete/5
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

        // POST: /OutputCache/Delete/5
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
