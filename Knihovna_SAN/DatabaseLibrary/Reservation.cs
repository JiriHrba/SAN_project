using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseLibrary
{
    class Reservation
    {
        public int reservation_id { get; set; }
        public DateTime reservation_date { get; set; }
        public DateTime reservation_appeal { get; set; }
        public int client_id { get; set; }
        public int book_id { get; set; }
    }
}
