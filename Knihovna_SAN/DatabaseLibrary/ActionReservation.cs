using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseLibrary
{
    class ActionReservation
    {
        public int act_reservation_id { get; set; }
        public DateTime act_reservation_date{ get; set; }
        public Boolean act_reservation_came { get; set; }
        public int action_id { get; set; }
        public int client_id { get; set; }
    }
}
