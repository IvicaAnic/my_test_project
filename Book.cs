using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebAPI.Model
{
    public class Book
    {
        public string BookTitle  { get; set; }
        public float BookPrice   { get; set; }
        public int AuthorID      { get; set; }
        public string BookVerlag { get; set; }
        public string BookISDN   { get; set; }

    }
}
