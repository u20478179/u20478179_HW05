using lNF272_HW05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace lNF272_HW05.Models
{
    public class ViewModel
    {
        public IEnumerable<lNF272_HW05.Models.book> ListBooks { get; set; }
        public IEnumerable<lNF272_HW05.Models.student> Liststudents { get; set; }


        public List<type> Types { get; set; }

        public List<author> Authors { get; set; }





        public ViewModel(IEnumerable<book> listBooks)
        {
            Types = new List<type>();
            Authors = new List<author>();
            ListBooks = listBooks;
            foreach (var book in listBooks)
            {
                if (!Types.Contains(book.type))
                {
                    Types.Add(book.type);
                }
                if (!Authors.Contains(book.author))
                {
                    Authors.Add(book.author);
                }
            }
        }



        //public List<student> Students { get; set; }
        //public StudentViewModel(IEnumerable<student> ListStudents)
        //{
        //    Students = new List<student>();

        //    ListStudents = listStudents;

        //    foreach (var student in listStudents)
        //    {
        //        if (!Types.Contains(student.@class))
        //        {
        //            Students.Add(student.@class);
        //        }
        //    }
        //}


    }



}