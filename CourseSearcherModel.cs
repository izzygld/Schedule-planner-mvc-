using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HoneyMustard.Web.Models
{
    public class CourseSearcherModel
    {

        public string  CourseName { get; set; }


                [Range(2000,2022)]
            public int Year { get; set; }
    }
}

