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
    public class ActionReservationTable
    {
        private const string INSERT_ActionReservation = "INSERT INTO actionreservation (act_reservation_date, act_reservation_client_came, action_id, client_id) VALUES (@act_reservation_date, @act_reservation_client_came, @action_id, @client_id)";
        private const string UPDATE_ActionReservation = "UPDATE actionreservation SET act_reservation_date = @act_reservation_date, act_reservation_client_came = @act_reservation_client_came, action_id = @action_id, client_id = @client_id WHERE act_reservation_id = @act_reservation_id";
        private const string SELECT_ONE = "SELECT * FROM actionreservation WHERE act_reservation_id = @act_reservation_id";
        private const string SELECT_ALL = "SELECT * FROM actionreservation";
        private const string DELETE = "DELETE FROM actionreservation WHERE act_reservation_id = @act_reservation_id";

        private string connString = null;

        public ActionReservationTable()
        {
            // Zkousel jsem nacist connection string ze souboru, ale pada to, nevim proc. Ve web.config ten string mam pod nazvem constr, ale proste to nejde.
            //connString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connString = "server=localhost;User Id=root;database=san";            
        }

        /// <summary>
        /// Vlozi do systemu novou rezervaci na akci.
        /// </summary>
        /// <param name="actRes"></param>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void InsertActionReservation(ActionReservation actRes)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(INSERT_ActionReservation, conn);

                /* Add parameters into the command */
                command.Parameters.AddWithValue("@act_reservation_date", actRes.act_reservation_date);
                command.Parameters.AddWithValue("@act_reservation_client", actRes.act_reservation_client_came);
                command.Parameters.AddWithValue("@action_id", actRes.action_id);
                command.Parameters.AddWithValue("@client_id", actRes.client_id);

                /* Executes the command */
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Provede update jedne rezervaci na akci.
        /// </summary>
        /// <param name="actRes"></param>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(ActionReservation actRes)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(UPDATE_ActionReservation, conn);

                command.Parameters.AddWithValue("@act_reservation_date", actRes.act_reservation_date);
                command.Parameters.AddWithValue("@act_reservation_client", actRes.act_reservation_client_came);
                command.Parameters.AddWithValue("@action_id", actRes.action_id);
                command.Parameters.AddWithValue("@client_id", actRes.client_id);

                /* Executes the command */
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Vraci jednu rezervaci na akci ze systemu podle ID.
        /// </summary>
        /// <param name="ActionReservationId"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]   
        public ActionReservation SelectOne(int ActionReservationId)
        {
            ActionReservation actRes = new ActionReservation();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(SELECT_ONE, conn);
                command.Parameters.AddWithValue("@ActionReservation_id", ActionReservationId);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    actRes.act_reservation_id = reader.GetInt32(0);
                    actRes.act_reservation_date = reader.GetDateTime(1);
                    actRes.act_reservation_client_came = reader.GetBoolean(2);
                    actRes.action_id = reader.GetInt32(3);
                    actRes.client_id = reader.GetInt32(4);
                }
                reader.Close();
            }
            return actRes;
        }

        /// <summary>
        /// Vraci vsechny rezervace na akci ze systemu.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ActionReservation> SelectAll()
        {
            List<ActionReservation> actResList = new List<ActionReservation>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(SELECT_ALL, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ActionReservation actRes = new ActionReservation();
                    actRes.act_reservation_id = reader.GetInt32(0);
                    actRes.act_reservation_date = reader.GetDateTime(1);
                    actRes.act_reservation_client_came = reader.GetBoolean(2);
                    actRes.action_id = reader.GetInt32(3);
                    actRes.client_id = reader.GetInt32(4);

                    actResList.Add(actRes);
                }
            }
            return actResList;
        }

        /// <summary>
        /// Smaze rezervaci na akci ze systemu. Vraci pocet radku, ktere byly smazany.
        /// </summary>
        /// <param name="ActionReservationId"></param>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int Delete(int ActionReservationId)
        {
            int rowsAffected = 0;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(DELETE, conn);
                command.Parameters.AddWithValue("@ActionReservation_id", ActionReservationId);
                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}