using Airline_Reservation_System_Dll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Airline_Reservation_System
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BookingHistoryClass bookingHistoryInstance = new BookingHistoryClass();

            DataTable dtBookingHistory = new DataTable();
            dtBookingHistory = bookingHistoryInstance.ViewBookingHistory("101");

            Repeater1.DataSource = dtBookingHistory;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string argument = null;
            if (e.CommandName == "SelectBookingId")
            {
                argument = e.CommandArgument.ToString();
            }
            Session["selectedBookingId"] = argument;
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewTicket.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CancelTicket.aspx");
        }
    }
}