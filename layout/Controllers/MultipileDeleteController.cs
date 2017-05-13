using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using layout.Models;

namespace layout.Controllers
{
    public class MultipileDeleteController : Controller
    {
        //
        // GET: /MultipileDelete/
        
         StudentEntities db = new StudentEntities();
        public ActionResult Index()
        {

            return View(db.tblEmployees.ToList());
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<int> EmployeesstoDelete)
        {
            //db.tblEmployees.Where(x => EmployeesstoDelete.Contains(x.Id)).ToList().ForEach(db.tblEmployees.RemoveRange(EmployeesstoDelete));
            tblEmployee obj = new tblEmployee();
            foreach(int id in EmployeesstoDelete){
                obj = db.tblEmployees.Find(id);
                db.tblEmployees.Remove(obj);
                db.SaveChanges();
             }
                return RedirectToAction("Index");

            
        }
	}
}