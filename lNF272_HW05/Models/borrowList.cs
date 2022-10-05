using lNF272_HW05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lNF272_HW05.Models
{
    public class borrowList
    {
        public book bookz { get; set; }
        public IEnumerable<lNF272_HW05.Models.borrow> ListBorrow { get; set; }

    }
}