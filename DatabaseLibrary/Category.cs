using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseLibrary
{
    public class Category
    {
        public Category() { }

        public Category(int id, string name, int type)
        {
            category_id = id;
            category_name = name;
            category_type = type;
        }

        public Category(string name, int type)
        {
            category_name = name;
            category_type = type;
        }

        public int category_id { get; set; }
        public string category_name { get; set; }
        public int category_type { get; set; }
    }
}
