using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestartMVC.Models
{
    public class company
    {
        public tbldisplay displayName
        {
            get
            {
                StudentEntities obj = new StudentEntities();
             return  obj.tbldisplays.Single(x => x.Id == 1);
            }
        }
    }
}