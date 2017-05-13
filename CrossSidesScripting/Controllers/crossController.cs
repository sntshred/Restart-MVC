using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrossSidesScripting.Models;
using System.Text;

namespace CrossSidesScripting.Controllers
{
    public class crossController : Controller
    {
        private StudentEntities db = new StudentEntities();

        // GET: /cross/
        public ActionResult Index()
        {
            return View(db.tblComments.ToList());
        }

        // GET: /cross/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComment tblcomment = db.tblComments.Find(id);
            if (tblcomment == null)
            {
                return HttpNotFound();
            }
            return View(tblcomment);
        }

        // GET: /cross/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /cross/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include="Id,Name,Comments")] tblComment tblcomment)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(HttpUtility.HtmlEncode(tblcomment.Comments));

            sb.Replace("&lt;b&gt;","<b>");
            sb.Replace("&lt;/b&gt;","</b>");

             tblcomment.Comments=  sb.ToString();

      string strname=   HttpUtility.HtmlEncode(tblcomment.Name);
      tblcomment.Name = strname;

            if (ModelState.IsValid)
            {
                db.tblComments.Add(tblcomment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblcomment);
        }

        // GET: /cross/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComment tblcomment = db.tblComments.Find(id);
            if (tblcomment == null)
            {
                return HttpNotFound();
            }
            return View(tblcomment);
        }

        // POST: /cross/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Comments")] tblComment tblcomment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcomment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblcomment);
        }

        // GET: /cross/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComment tblcomment = db.tblComments.Find(id);
            if (tblcomment == null)
            {
                return HttpNotFound();
            }
            return View(tblcomment);
        }

        // POST: /cross/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblComment tblcomment = db.tblComments.Find(id);
            db.tblComments.Remove(tblcomment);
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
