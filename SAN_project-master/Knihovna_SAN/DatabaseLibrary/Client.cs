using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseLibrary
{
    public class Client
    {
        

        public int client_id { get; set; }
        public string client_name { get; set; }
        public string client_surname { get; set; }
        public string client_email { get; set; }
        public string client_phone { get; set; }
        public DateTime client_birth_date { get; set; }
        public DateTime client_member_from { get; set; }
        public DateTime client_member_to { get; set; }
        public string client_street { get; set; }
        public string client_city { get; set; }
        public string client_zip { get; set; }
        public string client_country { get; set; }
        public Boolean client_isEmp { get; set; }
        public Boolean client_is_active { get; set; }
        public string client_login { get; set; }
        public string client_pass_hash { get; set; }
        public DateTime client_last_act { get; set; }
    }
}
