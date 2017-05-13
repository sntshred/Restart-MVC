using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDbAccess
{
    public class COMPANY
    {
        //This is for checkbox
        public bool selectCity { get; set; }
        

        //This is for RadioButton
        public string selectEmployeeCity { get; set; }

          private string _name;

          public COMPANY(string name)
    {
        this._name = name;
    }
        
    public List<tblEmployee> Departments
    {
        get
        {
            EmployeeEntities db = new EmployeeEntities();
            return db.tblEmployees.ToList();
        }
    }

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
