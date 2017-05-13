using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDbAccess;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
namespace RestartMVC.Models
{
    public class CompanyWithEmployee
    {
          private string _name;
          public CompanyWithEmployee(string name)
    {
        this._name = name;
    }
       
        
    //public List<tblEmployee> Departments
    //{
    //    //get
    //    //{
    //    //    //EmployeeEntities db = new EmployeeEntities();
    //    //    // return db.tblEmployees.ToList();
          
    //    //}
    //}

    public string CompanyName
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    }
}