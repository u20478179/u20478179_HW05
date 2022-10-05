using lNF272_HW05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace lNF272_HW05.Models
{
    public class service
    {
        //public Nullable<System.DateTime> takenDate { get; set; }
        //public Nullable<System.DateTime> broughtDate { get; set; }

        //public string getStatus()
        //{
        //    if (broughtDate == null)
        //    {
        //        return "out";
        //    }
        //    else
        //    {
        //        return "available";
        //    }
        //}

        //public Nullable<System.DateTime> BorrowBook()
        //{
        //    return takenDate = DateTime.Now;
        //}

        //    public Nullable<System.DateTime> ReturnBook()
        //{
        //    return broughtDate = DateTime.Now;
        //}

        public IEnumerable<lNF272_HW05.Models.book> ListBooks { get; set; }

        public IEnumerable<lNF272_HW05.Models.borrow> ListBorrow { get; set; }

        public book Book { get; set; }



        public borrow Borrow { get; set; }

        public List<borrow> BorrowID { get; set; }

        public List<borrow> StudentID { get; set; }

        public List<borrow> TakenDate { get; set; }

        public List<borrow> BroughtDate { get; set; }


        LibraryEntities db = new LibraryEntities();

        public service(book bookx)
        {
            Book = bookx;
            Borrow = getBorrowByBookId(bookx.bookId);
        }

        public borrow getBorrowByBookId(int bookId)
        {

            //return db.borrows.FirstOrDefault(b => b.bookId == bookId);
            return db.borrows.FirstOrDefault(b => b.bookId == bookId);

        }
    }
}