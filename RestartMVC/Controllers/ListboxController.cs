using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestartMVC.Models;
using System.Text;

namespace RestartMVC.Controllers
{
    public class ListboxController : Controller
    {
        //
        // GET: /Listbox/
        [HttpGet]
        public ActionResult Index()
        {
            StudentEntities obj = new StudentEntities();
            List<SelectListItem> listitem = new List<SelectListItem>();
            foreach (tblCity city in obj.tblCities)
            {
                SelectListItem selectlistitem = new SelectListItem()
                {
                    Text = city.Name,
                    Value = city.ID.ToString(),
                    Selected = city.IsSelected
                };

            listitem.Add(selectlistitem);
            }

            CitiesViewModel CitiesViewModel = new CitiesViewModel();
            CitiesViewModel.Cities = listitem;



            return View(CitiesViewModel);
            
           
        }

        [HttpPost]
        public string Index(IEnumerable<string> selectcities)
        {
            if (selectcities == null)
            {
                return "didn't selected";
            }
            else
            {
                StringBuilder ob = new StringBuilder();
                ob.Append(string.Join(",", selectcities));
                return ob.ToString();

            }
        
        
        }

	}
}