using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseLibrary
{
    class Action
    {
        public int action_id { get; set; }
        public DateTime action_date { get; set; }
        public int action_capacity { get; set; }
        public string action_name { get; set; }
        public int action_cost { get; set; }
    }
}
