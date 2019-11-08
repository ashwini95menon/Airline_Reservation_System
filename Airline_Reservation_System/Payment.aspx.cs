
using Airline_Reservation_System_Dll;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Airline_Reservation_System
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string paymentConfirmation = "received";
            int n = Convert.ToInt32(Session["numberOfAdults"]) + Convert.ToInt32(Session["numberOfChildren"]);
            if (paymentConfirmation.Equals("received"))
            {
                BookFlightDLL book = new BookFlightDLL();
                book.ConfirmBooking(Session["referenceId"].ToString(), "Confirm", "Success",
                                    Session["selectedFlightId"].ToString(),Session["dateOfJourney"].ToString(),
                                    Session["travelClass"].ToString(),n);

                 if (Session["tripType"].ToString().Equals("Round Trip"))
                 {
                     BookFlightDLL bookRoundTrip = new BookFlightDLL();
                     book.ConfirmBooking(Session["referenceIdRoundTrip"].ToString(), "Confirm", "Success",
                                         Session["selectedFlightIdRoundTrip"].ToString(), Session["dateOfReturn"].ToString(),
                                         Session["travelClass"].ToString(), n);
                 }
            }
            else
            {
                BookFlightDLL book = new BookFlightDLL();
                book.ConfirmBooking(Session["referenceId"].ToString(), "Failed", "Failed",
                                    Session["selectedFlightId"].ToString(),Session["dateOfJourney"].ToString(),
                                    Session["travelClass"].ToString(),n);

                if (Session["tripType"].ToString().Equals("Round Trip"))
                {
                    BookFlightDLL bookRoundTrip = new BookFlightDLL();
                    book.ConfirmBooking(Session["referenceIdRoundTrip"].ToString(), "Failed", "Failed",
                                    Session["selectedFlightIdRoundTrip"].ToString(), Session["dateOfReturn"].ToString(),
                                    Session["travelClass"].ToString(), n);
                }
            }

            Response.Redirect("ViewBookedTicket.aspx");
        }
    }
}