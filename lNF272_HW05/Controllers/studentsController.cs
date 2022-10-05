using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lNF272_HW05.Models;

namespace lNF272_HW05.Controllers
{
    public class studentsController : Controller
    {
        private LibraryEntities db = new LibraryEntities();

        // GET: students
        //public ActionResult Index()
        //{
        //    return View(db.students.ToList());
        //}

        //public ActionResult Index(string sortOrder)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
        //    var students = from s in db.students
        //                   select s;
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            students = students.OrderBy(s => s.name);
        //            break;
        //        case "Date":
        //            students = students.OrderBy(s => s.birthdate);
        //            break;
        //        case "date_desc":
        //            students = students.OrderByDescending(s => s.birthdate);
        //            break;
        //        default:
        //            students = students.OrderBy(s => s.surname);
        //            break;
        //    }
        //    return View(students.ToList());
        //}

        public ActionResult Index(string option, string search)
        {

            return View(db.students.Where(x => x.name.StartsWith(search) || search == null).ToList());

        }

        //public ActionResult Index(string option, string search, string sortOrder)
        //{
        //    if (option == search)
        //    {
        //        return View(db.students.Where(x => x.name.StartsWith(search) || search == null).ToList());
        //    }
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
        //    var students = from s in db.students
        //                   select s;
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            students = students.OrderBy(s => s.name);
        //            break;
        //        case "Date":
        //            students = students.OrderBy(s => s.birthdate);
        //            break;
        //        case "date_desc":
        //            students = students.OrderByDescending(s => s.birthdate);
        //            break;
        //        default:
        //            students = students.OrderBy(s => s.surname);
        //            break;
        //    }
        //    return View(students.ToList());


        //}

        // GET: students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "studentId,name,surname,birthdate,gender,class,point")] student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentId,name,surname,birthdate,gender,class,point")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
