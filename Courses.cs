
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoneyMustard.Interface.Models
{
    public class Courses
    {

        public int CoursesID { get; set; }

        [StringLength(100)]
        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Enter Course Name")]
        public string CourseName { get; set; }

        public string Module { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double? Credit { get; set; }

        public int DayOfWeek { get; set; }

        public int ContactID { get; set; }
       public virtual Contact Contact { get; set; }

        // Still unsure if this is necessary. it really depends on my conflicting schedule resolution.
        public virtual System.DateTime activated_date { get; set; }

        [DisplayName("Time Class Begins (24Hour):")]
        public DateTime TimeClassBegins { get; set; }

                [DisplayName("Time Class Ends (24Hour):")]
        public DateTime TimeClassEnds { get; set; }


        public int Location { get; set; }

        public int Gender { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [UIHint("Shekel")]
        [Range(typeof(decimal), "100.00", "50000.00",
            ErrorMessage = "Price must be between 100 and 50000")]
        public Decimal Price { get; set; }

        public string Comment { get; set; }

        public override string ToString()
        {
            return CourseName;
        }


    }
}
