using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestartMVC.Models;
using System.Text;
namespace RestartMVC.Controllers
{
    public class CheckBoxController : Controller
    {
        //
        // GET: /CheckBox/
        [HttpGet]
        public ActionResult Index()
        {
            StudentEntities obj = new StudentEntities();
            return View(obj.tblCities);
            
        }
        [HttpPost]
        public string Index(IEnumerable<tblCity> cities)
        {
            if (cities.Count(x => x.IsSelected) == 0)
            {
                return "you dint selected city";
            }
            else{
                StringBuilder sb = new StringBuilder();
                sb.Append("you selected");
                foreach(tblCity cit in cities){
                    if(cit.IsSelected){
                        sb.Append(cit.Name+" ,");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                return sb.ToString();
            }
        }
	}
}