using Airline_Reservation_System_Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Airline_Reservation_System
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool allowAccess;

            Authenticate authenticateInstance = new Authenticate();
            allowAccess=authenticateInstance.AuthenticateUser(username, password);

            if(allowAccess)
            {
                Session["user"] = username;
                //Response.Redirect("Home.aspx");
                FormsAuthentication.RedirectFromLoginPage(username, false);
            }
            else
            {
                lblErrorLogin.Text = "Invalid username or password";
            }
        }
    }
}