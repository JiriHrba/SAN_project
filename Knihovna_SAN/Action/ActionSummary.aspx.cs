using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Knihovna_SAN.Action
{
    public partial class ActionSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        /// <summary>
        /// Uzivatel chce provest rezervaci na akci. Do session se uloze id akce a dojde k prechodu na stranku pro provadeni rezervaci.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {                       
            int actionId = (int)((GridView)sender).SelectedDataKey.Value;
            Session["actionId"] = actionId;
            Response.Redirect("ActionReservation.aspx");

        }
}
}