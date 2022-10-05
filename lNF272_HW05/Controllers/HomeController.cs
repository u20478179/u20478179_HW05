using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lNF272_HW05.Models;

namespace lNF272_HW05.Controllers
{
    public class HomeController : Controller
    {
        private SqlConnection myConnection = new SqlConnection(Globals.ConnectionString);






        public ActionResult Index()
        {
            LibraryEntities db = new LibraryEntities();
            List<author> authors = db.authors.ToList();
            return View(authors);
        }

        public List<author> GetAuthor()
        {
            LibraryEntities db = new LibraryEntities();
            List<author> authors = db.authors.ToList();
            return authors;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}