using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace DatabaseLibrary
{
    class CopyTable
    {
        //INSERT
        private const String insert = @"insert into copy (copy_is_product, book_id) values (@copy_is_present, @book_id)";
        public void Insert(int copy_is_product, int book_id)
        {
            using (Database db = new Database())
            {
                SqlCommand command = db.CreateCmd(insert);
        
                command.Parameters.Add(new SqlParameter("@copy_is_product", SqlDbType.Int, 1)).Value = copy_is_product;
                command.Parameters.Add(new SqlParameter("@description", SqlDbType.Int, 10)).Value = book_id;
                
                db.NonQuery(command);
                db.Dispose();
                
            }
        }

        //UPDATE


        //SELECT


        //SELECT ALL


        //DELETE
    }
}
