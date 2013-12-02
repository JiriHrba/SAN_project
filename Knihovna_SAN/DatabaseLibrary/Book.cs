using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseLibrary
{
    class Book
    {
        public int book_id { get; set; }
        public string book_name { get; set; }
        public string book_isbn { get; set; }
        public string book_annotation { get; set; }
        public int author_id { get; set; }
    }
}
