using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lNF272_HW05.Models;
using Microsoft.Ajax.Utilities;

namespace lNF272_HW05.Controllers
{
    public class booksController : Controller
    {
        private LibraryEntities db = new LibraryEntities();

        //public ActionResult Index(string option, string search, string st, string sa)
        //{

        //    return View(db.books.Where(x => x.name.Contains(search) || search == null).ToList());
        //return View(db.books.Where(x => x.type.Equals(st) || search == null).ToList());
        //return View(db.books.Where(x => x.author.Equals(sa) || search == null).ToList());
        //}
        // GET: books
        //public ActionResult Index(string option, string search)
        //{
        //    var books = db.books.Include(b => b.author).Include(b => b.type);
        //    var searched = db.books.Where(x => x.name.StartsWith(search) || search == null).ToList();

        //    return View(books.ToList());


        //    //return View(db.books.Where(x => x.name.StartsWith(search) || search == null).ToList());

        //}

        //public ActionResult Index(string sortOrder, string search)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "name" ? "date_desc" : "Date";
        //    var books = from s in db.books
        //                   select s;

        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            books = books.OrderBy(s => s.name);
        //            break;
        //        case "Date":
        //            books = books.OrderBy(s => s.type);
        //            break;
        //        case "date_desc":
        //            books = books.OrderByDescending(s => s.author);
        //            break;
        //        default:
        //            books = db.books.Include(b => b.author).Include(b => b.type);
        //            break;
        //    }
        //    return View(books.ToList());
        //}

        public ActionResult Index(string search, string type, string author)
        {
            //var books = db.books.Include(b => b.author).Include(b => b.type).Include(b => b.borrows);
            //return View(books.ToList());
            //return View(db.books.Where(x => x.name.Contains(search) || search == null).ToList());

            return View(new ViewModel(db.books.Where(x => x.name.Contains(search) || search == null).ToList()));
        }



        // GET: books/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //book book = db.books.Find(id);
            //if (book == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(new service(book));

            borrowList bb = new borrowList
            {
                bookz = db.books.Find(id),
                ListBorrow = db.borrows.Where(b => b.bookId == id).ToList()

            };
            return View(bb);
        }

        // GET: books/Create
        public ActionResult Create()
        {
            ViewBag.authorId = new SelectList(db.authors, "authorId", "name");
            ViewBag.typeId = new SelectList(db.types, "typeId", "name");
            return View();
        }

        // POST: books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookId,name,pagecount,point,authorId,typeId")] book book)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authorId = new SelectList(db.authors, "authorId", "name", book.authorId);
            ViewBag.typeId = new SelectList(db.types, "typeId", "name", book.typeId);
            return View(book);
        }

        // GET: books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorId = new SelectList(db.authors, "authorId", "name", book.authorId);
            ViewBag.typeId = new SelectList(db.types, "typeId", "name", book.typeId);
            return View(book);
        }

        // POST: books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookId,name,pagecount,point,authorId,typeId")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorId = new SelectList(db.authors, "authorId", "name", book.authorId);
            ViewBag.typeId = new SelectList(db.types, "typeId", "name", book.typeId);
            return View(book);
        }

        // GET: books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.books.Find(id);
            db.books.Remove(book);
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

        //public ActionResult FuzzySearch(string searchText)
        //{
        /* view 

        using.BeginForm("testing", "books", FormMethod.Post) {
            <input type = "text" name = "myTxt" value ="" ></input>

            <button type="submit">Submit</button>
        }

         */

        //}

        public ActionResult testing(FormCollection thisForm)
        {
            String myAnswer = thisForm["myTxt"].ToString();

            return View();
        }
    }
}
