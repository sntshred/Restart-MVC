using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace RestartMVC.Models
{
    [MetadataType(typeof(displaymetadData))]
    [DisplayColumn("FullName")]
    public partial class tbldisplay
    {


    }

    public class displaymetadData
    {
        //[Display(Name = "Full Name")]
        //public string Fullname { get; set; }

        [HiddenInput(DisplayValue=false)]

        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode=true)]
        public DateTime? HireDate { get; set; }

       // [ScaffoldColumn(false)]
        [DataType(DataType.Currency)]

        public int? Salary { get; set; }
        [DataType(DataType.EmailAddress)]
        [ReadOnly(true)]
        public string EmailAddress { get; set; }
        [DataType(DataType.Url)]
        [UIHint("openInNewWindow")]
        public string PersonalWebSite { get; set; }

    }
}