using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Airline_Reservation_System
{
    public partial class Airline_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"]==null)
            {
                
                Logout.Visible = false;
                account.Visible = false;
                
                Login.Visible = true;
                Home.Visible = true;
                AboutUs.Visible = true;
                SignUp.Visible = true;
            }
            else
            {
                Logout.Visible = true;
                account.Visible = true;

                Login.Visible = false;
                Home.Visible = true;
                AboutUs.Visible = true;
                SignUp.Visible = false;
            }
        }

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownList1.SelectedItem.Text.Equals("My Profile"))
        //        Response.Redirect("MyProfile.aspx");
        //    else if (DropDownList1.Text.Equals("My Bookings"))
        //        Response.Redirect("BookingHistory.aspx");
        //    else if (DropDownList1.Text.Equals("My Cancellations"))
        //        Response.Redirect("CancellationHistory.aspx");
        //}

      
    }
}