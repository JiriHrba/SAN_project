using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Configuration;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web;

namespace DatabaseLibrary
{
    public class ReservationTable
    {
        //INSERT
        private const String INSERT_RESERVATION = @"INSERT INTO reservation (client_id, copy_id, reservation_appeal, reservation_date) values (@client_id, @copy_id, @reservation_appeal, @reservation_date)";
        private const string SELECT_ALL = "SELECT * FROM Copy";
        private string connString = null;

        public ReservationTable()
        {
            // Zkousel jsem nacist connection string ze souboru, ale pada to, nevim proc. Ve web.config ten string mam pod nazvem constr, ale proste to nejde.
            //connString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connString = "server=localhost;User Id=root;database=san";            
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void InsertReservation(Reservation res)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(INSERT_RESERVATION, conn);

                /* Add parameters into the command */
                command.Parameters.AddWithValue("@copy_id", res.copy_id);
                command.Parameters.AddWithValue("@client_id", res.client_id);
                command.Parameters.AddWithValue("@reservation_appeal", res.reservation_appeal);
                command.Parameters.AddWithValue("@reservation_date", res.reservation_date);

                /* Executes the command */
                command.ExecuteNonQuery();
            }
        }

        //UPDATE


        //SELECT


        //SELECT ALL
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Copy> SelectAll()
        {
            List<Copy> copyList = new List<Copy>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(SELECT_ALL, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Copy copy = new Copy();
                    copy.copy_id = reader.GetInt32(0);
                    copy.copy_is_present = reader.GetInt32(1);
                    copy.book_id = reader.GetInt32(2);

                    copyList.Add(copy);
                }
            }
            return copyList;
        }
        //DELETE
    }
}
