using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebAPI.Model
{
    public class Author
    {
        public string AuthorName { get; set; }
        public string AuthorVorname { get; set; }
        public string Strasse { get; set; }
        public string PLZ { get; set; }
        public string Stadt { get; set; }
    }
}
