using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Knihovna_SAN
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                List<string> roles = new List<string>();
                // Jeslize je jmeno admin, pak dame roli admin, jinak obycejny klient.
                if (Context.User.Identity.Name.CompareTo("admin") == 0)
                {
                    roles.Add("Admin");
                }
                else
                {
                    roles.Add("User");
                }
                Context.User = new System.Security.Principal.GenericPrincipal(Context.User.Identity, roles.ToArray());
            }
        
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

       
    }
}