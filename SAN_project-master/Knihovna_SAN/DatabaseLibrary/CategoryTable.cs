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
    public class CategoryTable
    {
        private const string INSERT_CATEGORY = "INSERT INTO category (category_name, category_type) VALUES (@category_name, @category_type)";
        private const string UPDATE_CATEGORY = "UPDATE Category SET category_name = @category_name, category_type = @category_type WHERE category_id = @category_id";
        private const string SELECT_ONE = "SELECT * FROM Category WHERE category_id = @category_id";
        private const string SELECT_ALL = "SELECT * FROM Category";
        private const string DELETE = "DELETE FROM Category WHERE category_id = @category_id";

        private string connString = null;

        public CategoryTable()
        {
            // Zkousel jsem nacist connection string ze souboru, ale pada to, nevim proc. Ve web.config ten string mam pod nazvem constr, ale proste to nejde.
            //connString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connString = "server=localhost;User Id=root;database=san";            
        }

        /// <summary>
        /// Vlozi do systemu novou kategorii.
        /// </summary>
        /// <param name="cat"></param>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void InsertCategory(Category cat)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(INSERT_CATEGORY, conn);

                /* Add parameters into the command */
                command.Parameters.AddWithValue("@category_name", cat.category_name);
                command.Parameters.AddWithValue("@category_type", cat.category_type);

                /* Executes the command */
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Provede update jedne kategorie.
        /// </summary>
        /// <param name="cat"></param>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(Category cat)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(UPDATE_CATEGORY, conn);

                command.Parameters.AddWithValue("@category_id", cat.category_id);
                command.Parameters.AddWithValue("@category_name", cat.category_name);
                command.Parameters.AddWithValue("@category_type", cat.category_type);

                /* Executes the command */
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Vraci jednu kategorii ze systemu podle ID.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]   
        public Category SelectOne(int categoryId)
        {
            Category cat = new Category();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(SELECT_ONE, conn);
                command.Parameters.AddWithValue("@category_id", categoryId);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cat.category_id = reader.GetInt32(0);
                    cat.category_name = reader.GetString(1);
                    cat.category_type = reader.GetInt32(2);
                }
                reader.Close();
            }
            return cat;
        }

        /// <summary>
        /// Vraci vsechny kategorie ze systemu.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Category> SelectAll()
        {
            List<Category> catList = new List<Category>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(SELECT_ALL, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Category cat = new Category();
                    cat.category_id = reader.GetInt32(0);
                    cat.category_name = reader.GetString(1);
                    cat.category_type = reader.GetInt32(2);

                    catList.Add(cat);
                }
            }
            return catList;
        }

        /// <summary>
        /// Smaze kategorii ze systemu. Vraci pocet radku, ktere byly smazany.
        /// </summary>
        /// <param name="categoryId"></param>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int Delete(int categoryId)
        {
            int rowsAffected = 0;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(DELETE, conn);
                command.Parameters.AddWithValue("@category_id", categoryId);
                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
