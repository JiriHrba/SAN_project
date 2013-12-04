using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseLibrary;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Knihovna_SAN
{
    public partial class _Default : System.Web.UI.Page
    {
        private const String insert = @"insert into copy (copy_is_present, book_id) values (@copy_is_present, @book_id)";
        protected void Page_Load(object sender, EventArgs e)
        {
            //using (Database db = new Database())
            //{
            //    SqlCommand command = db.CreateCmd(insert);

            //    command.Parameters.Add(new SqlParameter("@copy_is_present", SqlDbType.Bit, 1)).Value = 1;
            //    command.Parameters.Add(new SqlParameter("@book_id", SqlDbType.Int, 10)).Value = 1;

            //    db.NonQuery(command);
            //    db.Dispose();

            //}
        }

        

        
    }
}
