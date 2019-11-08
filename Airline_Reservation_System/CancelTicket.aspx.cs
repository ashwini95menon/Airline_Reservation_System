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
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            { 
            DataTable dtPassengers = new DataTable();

            CancelTicketClass cancelClass = new CancelTicketClass();

            dtPassengers = cancelClass.GetPassengers(Session["selectedBookingId"].ToString());

            GridView1.DataSource = dtPassengers;
            GridView1.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string argument = null;
            if (e.CommandName == "CancelPassenger")
            {
                argument = e.CommandArgument.ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                 if (chk.Checked==true)
                 {
                     int autoId = int.Parse(GridView1.DataKeys[row.RowIndex].Value.ToString());
                     CancelTicketClass cancelInstance = new CancelTicketClass();
                     cancelInstance.CancelTicket(autoId, Session["selectedBookingId"].ToString(),
                         "101");
                 }
            }

            Response.Redirect("BookingHistory.aspx");
        }
    }
}