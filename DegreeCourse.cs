using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyMustard.Interface.Models
{
    public class DegreeCourse
    {
        //Joint table of Degree and Course since for each degree a class can be either required or an elective 
        public int DegreeCourseID { get; set; }

        //Includes both Name and TotalCredit         
        public int DegreeID { get; set; }
        public Degree Degree { get; set; }

        //Includes both CourseName and Credit         
        public int CoursesID { get; set; }
        public Courses Courses { get; set; }

        public bool IsRequired { get; set; }
    }
}
