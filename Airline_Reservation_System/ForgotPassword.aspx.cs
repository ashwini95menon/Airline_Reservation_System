using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Airline_Reservation_System_Dll;

namespace Airline_Reservation_System
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            string Email;
            Email = txtEmail.Text;
            ForgotPassword fp = new ForgotPassword();
            int result = fp.CheckingEmailIdInDataBase(Email);

            if (result == 1)

                lblShowResult.Text = "Ok...EmailId Exists";

            else

                lblShowResult.Text = "Please Try Again";


        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResetPassword.aspx");
        }
    }
}