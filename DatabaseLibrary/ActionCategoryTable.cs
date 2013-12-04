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
    public class ActionCategoryTable
    {
        private const string INSERT = "INSERT INTO actioncategory (action_id, category_id) VALUES (@action_id, @category_id)";
        //private const string UPDATE = "UPDATE actioncategory SET actioncategory_name = @actioncategory_name, actioncategory_type = @actioncategory_type WHERE actioncategory_id = @actioncategory_id";
        private const string SELECT_ONE = "SELECT * FROM actioncategory WHERE action_id = @action_id";
        private const string SELECT_ALL = "SELECT * FROM actioncategory";
        private const string DELETE = "DELETE FROM actioncategory WHERE action_id = @action_id";

        private string connString = null;

        public ActionCategoryTable()
        {
            // Zkousel jsem nacist connection string ze souboru, ale pada to, nevim proc. Ve web.config ten string mam pod nazvem constr, ale proste to nejde.
            //connString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connString = "server=localhost;User Id=root;database=san";            
        }

        /// <summary>
        /// Vlozi do systemu novou kategorii.
        /// </summary>
        /// <param name="actcat"></param>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void InsertActionCategory(ActionCategory actcat)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(INSERT, conn);

                /* Add parameters into the command */
                command.Parameters.AddWithValue("@action_id", actcat.action_id);
                command.Parameters.AddWithValue("@category_id", actcat.category_id);

                /* Executes the command */
                command.ExecuteNonQuery();
            }
        }

        
        ///// <summary>
        ///// Provede update ActionCatgory se neresi.
        ///// </summary>
        ///// <param name="actcat"></param>
        //[DataObjectMethod(DataObjectMethodType.Update, true)]
        //public void Update(ActionCategory actcat)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(connString))
        //    {
        //        conn.Open();
        //        MySqlCommand command = new MySqlCommand(UPDATE, conn);

        //        command.Parameters.AddWithValue("@actioncategory_id", actcat.actioncategory_id);
        //        command.Parameters.AddWithValue("@actioncategory_name", actcat.actioncategory_name);
        //        command.Parameters.AddWithValue("@actioncategory_type", actcat.actioncategory_type);

        //        /* Executes the command */
        //        command.ExecuteNonQuery();
        //    }
        //}

        /// <summary>
        /// Vraci jednu kategorii ze systemu podle ID.
        /// </summary>
        /// <param name="ActionCategoryId"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]   
        public ActionCategory SelectOne(int ActionCategoryId)
        {
            ActionCategory actcat = new ActionCategory();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(SELECT_ONE, conn);
                command.Parameters.AddWithValue("@actioncategory_id", ActionCategoryId);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    actcat.action_id = reader.GetInt32(0);
                    actcat.category_id = reader.GetInt32(1);
                }
                reader.Close();
            }
            return actcat;
        }

        /// <summary>
        /// Vraci vsechny kategorie ze systemu.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ActionCategory> SelectAll()
        {
            List<ActionCategory> catList = new List<ActionCategory>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(SELECT_ALL, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ActionCategory actcat = new ActionCategory();
                    actcat.action_id = reader.GetInt32(0);
                    actcat.category_id = reader.GetInt32(1);

                    catList.Add(actcat);
                }
            }
            return catList;
        }

        /// <summary>
        /// Smaze kategorii ze systemu. Vraci pocet radku, ktere byly smazany.
        /// </summary>
        /// <param name="ActionCategoryId"></param>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int Delete(int ActionCategoryId)
        {
            int rowsAffected = 0;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(DELETE, conn);
                command.Parameters.AddWithValue("@actioncategory_id", ActionCategoryId);
                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}