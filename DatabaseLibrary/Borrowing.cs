using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseLibrary
{
    public class Borrowing
    {
        public int borrowing_id { get; set; }
        public DateTime borrowing_from { get; set; }
        public DateTime borrowing_to { get; set; }
        public Boolean borrowing_is_returned { get; set; }
        public int client_id { get; set; }
        public int copy_id { get; set; }
    }
}
