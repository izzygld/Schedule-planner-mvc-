using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoneyMustard.Web.Models
{
    public class CourseScheduleSearcherModels
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Module { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean Gender { get; set; }
    
    }

    public class ClassInfoSearcherModels
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Module { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean Gender { get; set; }
    }
}