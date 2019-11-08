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
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable dtSearchFlightResults = new DataTable();
        DataTable selectedFlight = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                if (!Page.IsPostBack)
                {
                    GetFlightDetails getFlightDetails = new GetFlightDetails();
                    DataTable airline = new DataTable();
                    airline=getFlightDetails.GetAirline();

                    //bind airline names to drop down list
                    getAirline.DataSource = airline;
                    getAirline.DataTextField = "FlightName";
                    getAirline.DataValueField = "FlightName";
                    getAirline.DataBind();
                    getAirline.Items.Insert(0, new ListItem("Select"));


                    dtSearchFlightResults = (DataTable)Session["dtSearchFlightResults"];
                    Repeater1.DataSource = dtSearchFlightResults;
                    Repeater1.DataBind();

                    int flagSelectedTrue = 0;
                    Session["flagSelectedTrue"] = flagSelectedTrue;

                    //Response.Write(Session["tripType"].ToString());
                    if (Session["tripType"].ToString().Equals("Round Trip"))
                    {
                        DataTable dtSearchFlightResultsRoundTrip = new DataTable();
                        dtSearchFlightResultsRoundTrip = (DataTable)Session["dtSearchFlightResultsRoundTrip"];
                        Repeater2.DataSource = dtSearchFlightResultsRoundTrip;
                        Repeater2.DataBind();
                        int flagSelectedTrueRoundTrip = 0;
                        Session["flagSelectedTrueRoundTrip"] = flagSelectedTrueRoundTrip;


                    }
                }
            }
            catch (Exception)
            {

            }

        }

       

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string argument=null;
            DataTable selectedFlight = new DataTable();

           

            try
            {
                if(e.CommandName=="BookNow")
                {
                   argument  = e.CommandArgument.ToString();
                   Session["flagSelectedTrue"] = 1;
                }
                DataTable dtSearchFlightResults = (DataTable)Session["dtSearchFlightResults"];
                for (int i = 0; i < dtSearchFlightResults.Rows.Count; i++)
                {
                    if (dtSearchFlightResults.Rows[i]["FlightId"].ToString().Equals(argument))
                    {
                        Session["selectedFlightId"] = dtSearchFlightResults.Rows[i]["FlightId"];
                        Session["ArrivalTime"] = dtSearchFlightResults.Rows[i]["ArrivalTime"];
                        Session["DepartureTime"] = dtSearchFlightResults.Rows[i]["DepartureTime"];
                        Session["AvailableSeats"] = dtSearchFlightResults.Rows[i]["AvailableSeats"];
                        Session["AdultPrice"] = dtSearchFlightResults.Rows[i]["AdultPrice"];
                        Session["ChildPrice"] = dtSearchFlightResults.Rows[i]["ChildPrice"];
                        Session["Fare"] = dtSearchFlightResults.Rows[i]["Fare"];
                        
                    }


                }

                Session["selectedFlight"]=selectedFlight;
                
            }

            catch (Exception)
            {

            }
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string argument = null;
            DataTable selectedFlightRoundTrip = new DataTable();

            try
            {
                if (e.CommandName == "BookNow")
                {
                    argument = e.CommandArgument.ToString();
                    Session["flagSelectedTrueRoundTrip"] = 1;
                }
                DataTable dtSearchFlightResultsRoundTrip = (DataTable)Session["dtSearchFlightResultsRoundTrip"];
                for (int i = 0; i < dtSearchFlightResultsRoundTrip.Rows.Count; i++)
                {
                    if (dtSearchFlightResultsRoundTrip.Rows[i]["FlightId"].ToString().Equals(argument))
                    {
                        Session["selectedFlightIdRoundTrip"] = dtSearchFlightResultsRoundTrip.Rows[i]["FlightId"];
                        Session["ArrivalTimeRoundTrip"] = dtSearchFlightResultsRoundTrip.Rows[i]["ArrivalTime"];
                        Session["DepartureTimeRoundTrip"] = dtSearchFlightResultsRoundTrip.Rows[i]["DepartureTime"];
                        Session["AvailableSeatsRoundTrip"] = dtSearchFlightResultsRoundTrip.Rows[i]["AvailableSeats"];
                        Session["AdultPriceRoundTrip"] = dtSearchFlightResultsRoundTrip.Rows[i]["AdultPrice"];
                        Session["ChildPriceRoundTrip"] = dtSearchFlightResultsRoundTrip.Rows[i]["ChildPrice"];
                        Session["FareRoundTrip"] = dtSearchFlightResultsRoundTrip.Rows[i]["Fare"];

                    }


                }

                Session["selectedFlightRoundTrip"] = selectedFlightRoundTrip;
                
            }

            catch (Exception)
            {

            }
        }

        

        protected void txtPriceRange_TextChanged(object sender, EventArgs e)
        {
            if (txtPriceRange.Text == "")
            {
                Repeater1.DataSource = (DataTable)Session["dtSearchFlightResults"];
                Repeater1.DataBind();
                if (Session["tripType"].ToString().Equals("Round Trip"))
                {
                    Repeater2.DataSource = (DataTable)Session["dtSearchFlightResultsRoundTrip"];
                    Repeater2.DataBind();
                }
            }

            else
            {
                SearchFlightByFilter searchFlightByFilter = new SearchFlightByFilter();

                DataTable dtSearchFlightResults = new DataTable();
                dtSearchFlightResults = searchFlightByFilter.FilterByPrice(Session["source"].ToString(), Session["destination"].ToString(),
                                                           Session["travelClass"].ToString(), Session["dateOfJourney"].ToString(),
                                                           Convert.ToInt32(Session["numberOfAdults"]), Convert.ToInt32(Session["numberOfChildren"]), Convert.ToInt32(txtPriceRange.Text));

                Session["dtSearchFlightResults2"] = dtSearchFlightResults;
                Repeater1.DataSource = dtSearchFlightResults;
                Repeater1.DataBind();

                if (Session["tripType"].ToString().Equals("Round Trip"))
                {
                    DataTable dtSearchFlightResultsRoundTrip = new DataTable();
                    dtSearchFlightResultsRoundTrip = searchFlightByFilter.FilterByPrice(Session["destination"].ToString(), Session["source"].ToString(),
                                                           Session["travelClass"].ToString(), Session["dateOfReturn"].ToString(),
                                                           Convert.ToInt32(Session["numberOfAdults"]), Convert.ToInt32(Session["numberOfChildren"]), Convert.ToInt32(txtPriceRange.Text));


                    Session["dtSearchFlightResultsRoundTrip2"] = dtSearchFlightResultsRoundTrip;
                    Repeater2.DataSource = dtSearchFlightResultsRoundTrip;
                    Repeater2.DataBind();

                }


            }
            
            

        }

        protected void getAirline_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getAirline.Text == "Select")
            {
                Repeater1.DataSource = (DataTable)Session["dtSearchFlightResults"];
                Repeater1.DataBind();
                if (Session["tripType"].ToString().Equals("Round Trip"))
                {
                    Repeater2.DataSource = (DataTable)Session["dtSearchFlightResultsRoundTrip"];
                    Repeater2.DataBind();
                }
            }
            else
            {
                SearchFlightByFilter searchFlightByFilter = new SearchFlightByFilter();

                DataTable dtSearchFlightResults = new DataTable();
                dtSearchFlightResults = searchFlightByFilter.FilterByAirline(Session["source"].ToString(),
                                                           Session["destination"].ToString(),
                                                           Session["travelClass"].ToString(),
                                                           Session["dateOfJourney"].ToString(),
                                                           Convert.ToInt32(Session["numberOfAdults"]),
                                                           Convert.ToInt32(Session["numberOfChildren"]),
                                                           getAirline.Text);

                Session["dtSearchFlightResults1"] = dtSearchFlightResults;
                Repeater1.DataSource = dtSearchFlightResults;
                Repeater1.DataBind();

                if (Session["tripType"].ToString().Equals("Round Trip"))
                {
                    DataTable dtSearchFlightResultsRoundTrip = new DataTable();
                    dtSearchFlightResultsRoundTrip = searchFlightByFilter.FilterByAirline(Session["destination"].ToString(), Session["source"].ToString(),
                                                           Session["travelClass"].ToString(), Session["dateOfReturn"].ToString(),
                                                           Convert.ToInt32(Session["numberOfAdults"]), Convert.ToInt32(Session["numberOfChildren"]), getAirline.Text);


                    Session["dtSearchFlightResultsRoundTrip1"] = dtSearchFlightResultsRoundTrip;
                    Repeater2.DataSource = dtSearchFlightResultsRoundTrip;
                    Repeater2.DataBind();

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("BookFlight.aspx");
            if (Session["tripType"].ToString().Equals("One Way"))
            {
                if(Convert.ToInt32(Session["flagSelectedTrue"])==1)
                {
                    Response.Redirect("BookFlight.aspx");
                }
                else
                {
                    lblErrorFlightNotSelected.Text = "Please select a flight to book";
                }
            }
            if (Session["tripType"].ToString().Equals("Round Trip"))
            {
                if (Convert.ToInt32(Session["flagSelectedTrueRoundTrip"]) == 1)
                {
                    Response.Redirect("BookFlight.aspx");
                }
                else
                {
                    lblErrorFlightNotSelected.Text = "Please select a flight to book";
                }
            }
        }

        

       
       
    }
}