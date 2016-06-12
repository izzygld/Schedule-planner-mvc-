using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HoneyMustard.Interface.Models;
using HoneyMustard.Web.Models;
using HoneyMustard.Interface.DataSource;
using HoneyMustard.Factories;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;



namespace HoneyMustard.Web.Controllers
{
    public class CoursesController : Controller
    {
        [HttpPost]
        public ActionResult ContactList()
        {
            using (IHoneyMustardDataSource ds = HoneyMustard.Factories.DataSourceFactory.GetDataSource())
            {
                var contacts = ds.Contacts.Select(x => new ContactListTableRow
                {
                    ContactID = x.ContactID,
                    FirstMidName = x.FirstMidName + " " + x.LastName,

                });

                return Json(contacts.ToList());
            }
        }

        public ActionResult Practising()
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {

                CourseModels model = new CourseModels
                {
                    Coursess = ds.Courses.Include(c => c.Contact)
                                            .Select(x => new CourseModelsTableRow

                                            {
                                                CourseID = x.CoursesID,
                                                CourseName = x.CourseName,
                                                Module = x.Module,
                                                StartDate = x.StartDate,
                                                EndDate = x.EndDate,
                                                Credit = x.Credit,
                                                Price = x.Price,
                                                activated_date = x.activated_date,
                                                ParticapantsGender = (CourseModelsTableRow.Gender)x.Gender,
                                                Format = (CourseModelsTableRow.Location)x.Location,
                                                DayOfWeek = (CourseModelsTableRow.DaysOfWeek)x.DayOfWeek,
                                                Comment = x.Comment,
                                                TimeClassBegins = x.TimeClassBegins,
                                                TimeClassEnds = x.TimeClassEnds
                                            }).ToList()
                };

                return View(model);
            }
        }

        // GET: Courses/Details/5
        public ActionResult Details(int id)
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {
                var course = ds.Courses.SingleOrDefault(x => x.CoursesID == id);
                CourseModelsTableRow model = new CourseModelsTableRow
                {
                    CourseID = course.CoursesID,
                    CourseName = course.CourseName,
                    Module = course.Module,
                    StartDate = course.StartDate,
                    EndDate = course.EndDate,
                    Credit = course.Credit,
                    Price = course.Price,
                    activated_date = course.activated_date,
                    ParticapantsGender = (CourseModelsTableRow.Gender)course.Gender,
                    Format = (CourseModelsTableRow.Location)course.Location,
                    DayOfWeek = (CourseModelsTableRow.DaysOfWeek)course.DayOfWeek,
                    Comment = course.Comment,
                    TimeClassBegins = course.TimeClassBegins,
                    TimeClassEnds = course.TimeClassEnds,

                    Contact = ds.Contacts.Where(x => x.ContactID == course.ContactID)
                    .Select(x => new ContactListTableRow

                    {
                        ContactID = x.ContactID,
                        FirstMidName = x.FirstMidName,
                        LastName = x.LastName
                    }).ToList()

                };
                if (TempData.ContainsKey("course"))
                {
                    ViewBag.Message = TempData["course"];
                }
                //ViewBag.Message = TempData["mesaage"];
                return View(model);
            }
        }

        // GET: Coursestryout/Create
        public ActionResult Create()
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {
                ViewBag.ContactID = new SelectList(ds.Contacts, "ContactID", "FirstMidName");
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoursesID,CourseName,Module,StartDate,EndDate,Credit,DayOfWeek,ContactID,activated_date,TimeClassBegins,TimeClassEnds,Location,Gender,Price,Comment")] Courses courses)
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {
                if (ModelState.IsValid)
                {
                    ds.Courses.Add(courses);
                    ds.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ContactID = new SelectList(ds.Contacts, "ContactID", "FirstMidName", courses.ContactID);
                return View(courses);
            }
        }


        public ActionResult DailyDeal()
        {
            var course = GetDailyDeal();
            return PartialView("_DailyDeal", course);
        }



        private Courses GetDailyDeal()
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {
               
                var course = ds.Courses
                    .OrderBy(a => System.Guid.NewGuid())
                    .First();
                course.Price *= 0.5m;
                return course;
            }
        }




        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Courses course = ds.Courses.Find(id);
                if (course == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ContactID = new SelectList(ds.Contacts, "ContactID", "FirstMidName", course.ContactID);
                return View(course);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,CourseName,Module,StartDate,EndDate,Credit,DayOfWeek,ContactID,activated_date,TimeClassBegins,TimeClassEnds,Location,Gender,Price,Comment")] Courses course)
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {
                if (ModelState.IsValid)
                {
                    //ds.Entry(course).State = EntityState.Modified;
                    ds.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ContactID = new SelectList(ds.Contacts, "ContactID", "FirstMidName", course.ContactID);
                return View(course);
            }
        }
        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Courses course = ds.Courses.Find(id);
                if (course == null)
                {
                    return HttpNotFound();
                }
                return View(course);
            }
        }
        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {
                Courses course = ds.Courses.Find(id);
                ds.Courses.Remove(course);
                ds.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Search()
        {
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMessage = TempData["error"];
            }

            return View();
        }

        //
        // POST: /Book/Search

        [HttpPost]
        public ActionResult Search(CourseSearcherModel model)
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {
                if (ModelState.IsValid)
                {
                    Courses course = ds.Courses.FirstOrDefault(x => x.CourseName == model.CourseName);

                    TempData["course"] = course;

                    if (course != null)
                    {
                        return RedirectToAction("Details", new { id = course.CoursesID });
                    }
                    else
                    {

                        string text = "Sorry Course Not Found!  Please Try Again";
                        ModelState.AddModelError("Title", text);
                    }
                }

                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            using (IHoneyMustardDataSource ds = DataSourceFactory.GetDataSource())
            {
                if (disposing)
                {
                    ds.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
}
