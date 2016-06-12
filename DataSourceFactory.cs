
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyMustard.Interface.DataSource;
using HoneyMustard.EFDataImpl.DataSource;
using System.Data.Entity;
using HoneyMustard.Interface.Models;

namespace HoneyMustard.Factories

{
    public class DataSourceFactory
    {
        public static IHoneyMustardDataSource GetDataSource()
        {
            //seeding up data
            Database.SetInitializer<HoneyMustardContext>(new HoneyMustardDebugInitializer());

            return new HoneyMustardContext();
        }

        public class HoneyMustardDebugInitializer : DropCreateDatabaseIfModelChanges<HoneyMustardContext>
        {
            protected override void Seed(HoneyMustardContext context)
            {
                

                context.Contacts.Add(new Contact()
                {

                    FirstMidName = "No ",
                    LastName = "Author",
                    EmailAddress = "qqqqq@gmail.com",
                    TeudatZehutPassport = 000000,
                    CountryID = "00000",
                    Phone = 000000,
                    CellPhone = 000000
                });
                
                context.Contacts.Add(new Contact()
                {

                    FirstMidName = "Izzy",
                    LastName = "Goldman",
                    EmailAddress = "izzy@gmail.com",
                    TeudatZehutPassport = 123456,
                    CountryID = "234567",
                    Phone = 098765,
                    CellPhone = 345678
                });
                context.Contacts.Add(new Contact()
                {

                    FirstMidName = "shmuel",
                    LastName = "stef",
                    EmailAddress = "ss@gmail.com",
                    TeudatZehutPassport = 123756,
                    CountryID = "230567",
                    Phone = 098755,
                    CellPhone = 349678
                });
                context.Contacts.Add(new Contact()
                {

                    FirstMidName = "avi",
                    LastName = "berger",
                    EmailAddress = "aviberg@gmail.com",
                    TeudatZehutPassport = 123786,
                    CountryID = "289567",
                    Phone = 095765,
                    CellPhone = 344778
                });
                context.Contacts.Add(new Contact()
                {

                    FirstMidName = "avrohom",
                    LastName = "marks",
                    EmailAddress = "amarks@gmail.com",
                    TeudatZehutPassport = 673786,
                    CountryID = "208567",
                    Phone = 090465,
                    CellPhone = 784778
                });
                context.Contacts.Add(new Contact()
                {

                    FirstMidName = "Tony",
                    LastName = "Jacob",
                    EmailAddress = "tj@gmail.com",
                    TeudatZehutPassport = 120456,
                    CountryID = "234507",
                    Phone = 098705,
                    CellPhone = 340678
                });
                // Next we have to match up the Contact and ContactType in the ContactJoin table (just make sure No Author
                //is an Administrator (1,1) and the rest is a mix of students and teachers)
                context.ContactType.Add(new ContactType()
                {
                    TypeDescription = "Administrator"
                });
                context.ContactType.Add(new ContactType()
                {
                    TypeDescription = "Student"
                });


                context.ContactType.Add(new ContactType()
                {
                    TypeDescription = "Other"
                });

                context.ContactType.Add(new ContactType()
                {
                    TypeDescription = "Teacher"
                });

                context.SaveChanges();

                context.ContactJoin.Add(new ContactJoin()
                   {
                       ContactTypeID = 1,
                       ContactID = 1
                    });

                context.SaveChanges();

                context.ContactJoin.Add(new ContactJoin()
                {
                    ContactTypeID = 4,
                    ContactID = 2
                });
                context.SaveChanges();


                context.ContactJoin.Add(new ContactJoin()
                {
                    ContactTypeID = 4,
                    ContactID = 3
                });
                context.SaveChanges();

                context.ContactJoin.Add(new ContactJoin()
                {
                    ContactTypeID = 2,
                    ContactID = 4

                });
                context.SaveChanges();

                context.ContactJoin.Add(new ContactJoin()
                {
                    ContactTypeID = 2,
                    ContactID= 5
                });
                context.SaveChanges();

                context.ContactJoin.Add(new ContactJoin()
                {
                    ContactTypeID = 2,
                    ContactID = 6
                });
                context.SaveChanges();

                context.Courses.Add(new Courses()
                {
                    CourseName = "programming",
                    Module = "computers",
                    StartDate = new DateTime(2008, 5, 1, 8, 30, 52),
                    EndDate = new DateTime(2010, 5, 1, 8, 30, 52),
                    Credit = 3,
                    DayOfWeek = 5,
                    ContactID = 1,
                    activated_date = new DateTime(2007, 5, 1, 8, 30, 52),
                    TimeClassBegins = new DateTime(2008, 5, 1, 8, 30, 52),
                    TimeClassEnds = new DateTime(2008, 5, 1, 10, 40, 52),
                    Location = 1,
                    Gender = 1,
                    Price = 100.0m,
                    Comment = "one of a kind"

                });
                context.Courses.Add(new Courses()
                {
                    CourseName = "Shtusim",
                    Module = "zevel",
                    StartDate = new DateTime(2008, 5, 1, 8, 30, 52),
                    EndDate = new DateTime(2010, 5, 1, 8, 30, 52),
                    Credit = 1.5,
                    DayOfWeek = 4,
                    ContactID = 4,
                    activated_date = new DateTime(2007, 5, 1, 8, 30, 52),
                    TimeClassBegins = new DateTime(2008, 5, 1, 8, 30, 52),
                    TimeClassEnds = new DateTime(2008, 5, 1, 10, 40, 52),
                    Location = 0,
                    Gender = 1,
                    Price = 1000.0m,
                    Comment = "hurry up and register"

                });
                context.Courses.Add(new Courses()
                {
                    CourseName = "html",
                    Module = "graphics",
                    StartDate = new DateTime(2009, 5, 1, 8, 30, 52),
                    EndDate = new DateTime(2011, 5, 1, 8, 30, 52),
                    Credit = 3,
                    DayOfWeek = 4,
                    ContactID = 2,
                    activated_date = new DateTime(2007, 5, 1, 8, 30, 52),
                    TimeClassBegins = new DateTime(2008, 5, 1, 8, 30, 52),
                    TimeClassEnds = new DateTime(2008, 5, 1, 10, 40, 52),
                    Location = 0,
                    Gender = 0,
                    Price = 1345.0m,
                    Comment = "Go Go Go"

                });

                context.Courses.Add(new Courses()
                {
                    CourseName = "random",
                    Module = "mamash",
                    StartDate = new DateTime(2009, 5, 1, 8, 30, 52),
                    EndDate = new DateTime(2011, 5, 1, 8, 30, 52),
                    Credit = 3,
                    DayOfWeek = 4,
                    ContactID = 2,
                    activated_date = new DateTime(2007, 5, 1, 8, 30, 52),
                    TimeClassBegins = new DateTime(2008, 5, 1, 8, 30, 52),
                    TimeClassEnds = new DateTime(2008, 5, 1, 10, 40, 52),
                    Location = 0,
                    Gender = 0,
                    Price = 1345.0m,
                    Comment = "oiy vey"

                });
                context.SaveChanges();
                

                context.Degree.Add(new Degree()
                {
                    Name = "none",
                    TotalCredits = 0.0
                    
                });
                context.Degree.Add(new Degree()
                {
                    Name = "Computer science",
                    TotalCredits = 1.5
                });
                context.Degree.Add(new Degree()
                {
                    Name = "IT",
                    TotalCredits = 3
                });
                context.Degree.Add(new Degree()
                {
                    Name = "Mechanicel Engineer",
                    TotalCredits = 2
                });

                context.DegreeCourse.Add(new DegreeCourse()
                    {
                        CoursesID = 1,
                        DegreeID = 1,
                        IsRequired = true
                        

                    });


                context.DegreeCourse.Add(new DegreeCourse()
                {
                    CoursesID = 2,
                    DegreeID = 2,
                    IsRequired = false

                });
                context.DegreeCourse.Add(new DegreeCourse()
                {
                    CoursesID = 3,
                    DegreeID = 3,
                    IsRequired = true

                });

                context.SaveChanges();





                context.GuidancePlan.Add(new GuidancePlan()
                {
                    StudentID= 1,
                    DateCreated = new DateTime(2008, 5, 1, 8, 30, 52),
                    DegreeID = 1,
                    PeriodStart = 1,
                    PeriodStartYear = 2,
                    PeriodEnd = 2,
                    AuthorID = 1,
                    IsSaved = true
                });


                context.SaveChanges();
                context.GuidancePlanDetail.Add(new GuidancePlanDetail()
                {
                    GuidancePlanID = 1,
                    CoursesID = 1,
                    Period = "spring",
                    Year = 1
                });

                context.SaveChanges();
                context.Participant.Add(new Participant()
                {
                    ContactID = 1,
                    AgreedPrice = 123456,
                    CoursesID = 1,
                    Grade = 0
                });
                context.SaveChanges();
                context.Participant.Add(new Participant()
                {
                    ContactID = 2,
                    AgreedPrice = 12346,
                    CoursesID = 1,
                    Grade = 0
                });

                context.SaveChanges();

                context.PaymentMethod.Add(new PaymentMethod()
                {
                    Method = "Bank Transfer"
                });
              
                 context.SaveChanges();

                 context.PaymentMethod.Add(new PaymentMethod()
                 {
                     Method = "Cash"
                 });

                 context.SaveChanges();

                 context.PaymentMethod.Add(new PaymentMethod()
                 {
                     Method = "Cheque"
                 });

                 context.SaveChanges();

                 context.PaymentMethod.Add(new PaymentMethod()
                 {
                     Method = "Credit Card"
                 });

                 context.SaveChanges();

                base.Seed(context);
            }
        }
    }
}
