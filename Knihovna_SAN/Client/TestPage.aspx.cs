using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseLibrary;

namespace Knihovna_SAN.Client
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Vlozeni nove kategorie
            // bez validatoru
            DatabaseLibrary.Category cat = new DatabaseLibrary.Category();

            cat.category_name = TextBox_categoryName.Text;
            cat.category_type = Convert.ToInt32(TextBox_categoryType.Text);

            new DatabaseLibrary.CategoryTable().InsertCategory(cat);

            Response.Redirect(Request.RawUrl);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DatabaseLibrary.Action act = new DatabaseLibrary.Action();

            string actionDate = TextBox_actionDate.Text;
            string[] items = actionDate.Split('/');
            DateTime dateAction = new DateTime(Int32.Parse(items[2]), Int32.Parse(items[1]), Int32.Parse(items[0]));

            act.action_date = dateAction;
            act.action_capacity = Convert.ToInt32(TextBox_actionCapacity.Text);
            act.action_name = TextBox_actionName.Text;
            act.action_cost = Convert.ToInt32(TextBox_actionCost.Text);

            new DatabaseLibrary.ActionTable().Insert(act);

            Response.Redirect(Request.RawUrl);
        }
    }
}