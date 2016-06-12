using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace HoneyMustard.Web.Models
{
    public class CourseModels 
    {
        public List<CourseModelsTableRow> Coursess { get; set; }
    }
    public class ContactListTableRow 
    {
        public int ContactID { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }

    }

             
    //public class ClassListModel
    //{
    //    public List<ClassListTableRow> Classes { get; set; }
    //}

    public class CourseModelsTableRow
    {
        public int CourseID { get; set; }
    
        public  List<ContactListTableRow> Contact { get; set; }
        
        [StringLength(100)]
        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Enter Course Name")]
        public string CourseName { get; set; }

        [DisplayName("(Module)")]
        public string Module { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double? Credit { get; set; }

        //public int DayOfWeek { get; set; }


        public List<SelectListItem> DaysOfTheWeek{ get; set; }
        [EnumDataType(typeof(DaysOfWeek))]
        [Required(ErrorMessage = "PLease Choose from one of the types: Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday")]
        public DaysOfWeek DayOfWeek { get; set; }
        public enum DaysOfWeek
        {
            Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        }

        [EnumDataType(typeof(Gender))]
        [DisplayName("Participants Gender:")]
        public  Gender ParticapantsGender { get; set; }

        public enum Gender
        {
            Male = 0,
            Female = 1
        }

       
       

      


        

        [DisplayName("Time Class Begins (AM/PM)")]
        public DateTime TimeClassBegins { get; set; }

        [DisplayName("Time Class Ends (AM/PM)")]
        public DateTime TimeClassEnds { get; set; }

        
        [EnumDataType(typeof(Location))]
        [DisplayName("Format")]
        [Range(1, int.MaxValue, ErrorMessage = "Select a correct Format")]
        public Location ? Format { get; set; }

        public enum Location
        {
            Online = 0,
            compuskills = 1
        }

        public virtual System.DateTime activated_date { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [UIHint("Shekel")]
        [Range(typeof(decimal),"100.00", "50000.00",
            ErrorMessage = "Price must be between 100 and 50000")]
        public Decimal Price { get; set; }
        public string Comment { get; set; }

    }
}