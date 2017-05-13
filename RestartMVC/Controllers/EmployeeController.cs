using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDbAccess;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
namespace RestartMVC.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult GetEmployee()
        {
            EmployeeEntities obj = new EmployeeEntities();
           List<tblEmployee> ob1= obj.tblEmployees.ToList();
           return View(ob1);
        }

        //Ask this has a question
        //public ActionResult EmployeesByName()
        //{
        //    EmployeeEntities obj = new EmployeeEntities();
        //   var emp = obj.tblEmployees.Include("tblEmployee").GroupBy(x=>x.Name).Select(y=>new {

        //       Name=y.Key,
        //       Total=y.Count()

        //   }).ToList().OrderByDescending(y=>y.Total);
        //   return View(emp);
        //}
        [HttpGet]
        public ActionResult Create()
        {
            return View();
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeEntities obj = new EmployeeEntities();
           var employee = obj.tblEmployees.Single(emp => emp.Id == id);
            return View(employee);

        }

     
        public ActionResult Delete(int id)
        {
            EmployeeEntities obj = new EmployeeEntities();
            var employee = obj.tblEmployees.Single(x => x.Id == id);
            obj.tblEmployees.Remove(employee);
            obj.SaveChanges();
            return RedirectToAction("GetEmployee");

        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_post(int id)
        {
            EmployeeEntities obj = new EmployeeEntities();
           var employee= obj.tblEmployees.Single(x => x.Id == id);
     ///   Whitel List - Include List
           UpdateModel(employee, new string[] { "Id", "Gender", "City" });
       // Black List - Exclude List
           UpdateModel(employee,null,null, new string[] { "name"});
            
            if (ModelState.IsValid)
            {

            obj.tblEmployees.AddOrUpdate(employee);
            obj.SaveChanges();
            return RedirectToAction("GetEmployee");
            }
            return View(employee);
        }


        //Another way using Bind Attribute to bind 
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_post([Bind(Include="Id,Gender,City")]tblEmployee employee )
        //{
        //    EmployeeEntities obj = new EmployeeEntities();
        //    tblEmployee emp = obj.tblEmployees.Single(x => x.Id == employee.Id);
        //    emp.Id = employee.Id;
        //    emp.Gender = employee.Gender;
        //    emp.City= employee.City;

        //    if (ModelState.IsValid)
        //    {
        //        var manager = ((IObjectContextAdapter)dbContext).ObjectContext.ObjectStateManager;
        //        manager.ChangeObjectState(emp, EntityState.Modified);
        //        //obj.tblEmployees.Add(emp);
        //        obj.SaveChanges();
        //        return RedirectToAction("GetEmployee");
        //    }
        //    return View(employee);
        //}

        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_post(int Id)
        //{
        //    EmployeeEntities obj = new EmployeeEntities();
        //    tblEmployee employee = obj.tblEmployees.Single(x => x.Id == Id);
        //    UpdateModel<IEmployee>(employee);


        //    if (ModelState.IsValid)
        //    {

        //        obj.tblEmployees.AddOrUpdate(employee);
        //        obj.SaveChanges();
        //        return RedirectToAction("GetEmployee");
        //    }
        //    return View(employee);
        //}





        //[HttpPost]
        //public ActionResult Create(string Name, string Gender, string City, DateTime DateOfBirth)
        //{
            
        //    tblEmployee obj = new tblEmployee();
        //    obj.Name = Name;
        //    obj.Gender = Gender;
        //    obj.City = City;
        //    obj.DateOfBirth = DateOfBirth;
        //    EmployeeEntities entity1 = new EmployeeEntities();
        //    entity1.tblEmployees.Add(obj);
        //    entity1.SaveChanges();

        //    return RedirectToAction("GetEmployee");
         
        //}

        //[HttpPost]
        //public ActionResult Create(tblEmployee employee)
        //{

        //    EmployeeEntities entity1 = new EmployeeEntities();
        //    entity1.tblEmployees.Add(employee);
        //    entity1.SaveChanges();

        //    return RedirectToAction("GetEmployee");
        //}

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if (ModelState.IsValid) { 
            tblEmployee tblemp = new tblEmployee();
            UpdateModel(tblemp);
            EmployeeEntities entity1 = new EmployeeEntities();
            entity1.tblEmployees.Add(tblemp);
            entity1.SaveChanges();
            return RedirectToAction("GetEmployee");
            }
            return View();
        }

        public IObjectContextAdapter dbContext { get; set; }
    }
}