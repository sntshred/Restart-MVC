using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestartMVC.Models
{
    [MetadataType(typeof(NameMetaData))]
    public partial  class tblEmployee
    {


    }

    public class NameMetaData{
        [Display(Name="FullName")]
        public string Name{get;set;}
    
    }
}