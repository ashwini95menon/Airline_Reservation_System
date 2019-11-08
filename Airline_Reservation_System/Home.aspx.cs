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
    public partial class WebForm2 : System.Web.UI.Page
        
    {
        public void setSearchParameters()
        {
            Session["source"] = listSource.Text;
            Session["destination"] = listDestination.Text;
            Session["dateOfJourney"] = txtDateOfJourney.Text;
            Session["travelClass"] = listClass.Text;
            Session["numberOfAdults"] = txtAdult.SelectedItem.Value;
            Session["numberOfChildren"] = txtChild.SelectedItem.Value;
            Session["numberOfInfants"] = txtInfant.Text;
            
            
        }

        public void getSearchResults()
        {
            //Create class instance which has six parameters
            SearchFlight SearchClassInstance = new SearchFlight(Session["source"].ToString(), Session["destination"].ToString(),
                                                       Session["travelClass"].ToString(), Session["dateOfJourney"].ToString(),
                                                       Convert.ToInt32(Session["numberOfAdults"]), Convert.ToInt32(Session["numberOfChildren"]));
            
            
                

                //Search flight results of one way stored in a data table
                DataTable dtSearchFlightsResults = new DataTable();
                dtSearchFlightsResults = SearchClassInstance.SearchFlights();


                //Store dtSearchFlights as a session variable
                Session["dtSearchFlightResults"] = dtSearchFlightsResults;

                //Search flight results of round trip stored in a data table
                if (Session["tripType"].ToString().Equals("Round Trip"))
                {
                    Session["dateOfJourney"] = txtDateOfJourney.Text;
                    Session["dateOfReturn"] = txtDateOfReturn.Text;
                    var SearchClassInstanceRoundTrip = new SearchFlight(Session["destination"].ToString(),Session["source"].ToString(),
                                                       Session["travelClass"].ToString(), Session["dateOfReturn"].ToString(),
                                                       Convert.ToInt32(Session["numberOfAdults"]), Convert.ToInt32(Session["numberOfChildren"])
                                                      );

                    DataTable dtSearchFlightsResultsRoundTrip = new DataTable();
                    dtSearchFlightsResultsRoundTrip = SearchClassInstanceRoundTrip.SearchFlights();

                    //Store dtSearchFlights as a session variable
                    Session["dtSearchFlightResultsRoundTrip"] = dtSearchFlightsResultsRoundTrip;


                }

            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!Page.IsPostBack)
            {
                //default trip type if user do not select anything
                Session["tripType"] = "One Way";

                GetFlightDetails getFlightDetails = new GetFlightDetails();

                //bind distinct sources to drop down source
                listSource.DataSource = getFlightDetails.GetSource();
                listSource.DataBind();

                //bind distinct travel class to drop down
                listClass.DataSource = getFlightDetails.GetClass();
                listClass.DataBind();

            }

            
            //disabling dates before current day
            txtDateOfJourney.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
            txtDateOfReturn.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");

            DropDownList1_SelectedIndexChanged(sender, e);

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //bind distinct destination to drop down destination for which flight originate from selected source
            string source = listSource.Text;
            GetFlightDetails getFlightDetails = new GetFlightDetails();
            listDestination.DataSource = getFlightDetails.GetDestination(source);
            listDestination.DataBind();
        }

        protected void txtDateOfReturn_TextChanged(object sender, EventArgs e)
        {

        }

        

       
       

       

        
        protected void txtAdult_TextChanged(object sender, EventArgs e)
        {
            
        
        }

        protected void txtChild_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnTripType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(btnTripType.SelectedItem.Text.Equals("One Way"))
            {
            //disable date of return if one way is selected
            lblDateOfReturn.Visible = false;
            txtDateOfReturn.Visible = false;
            txtDateOfReturn.Enabled = false;
            Session["tripType"] = btnTripType.Text;
            //txtDateOfJourney.Enabled = true;
           
            }
            else if(btnTripType.SelectedItem.Text.Equals("Round Trip"))
            {
                //enable date of return if round trip is selected
            lblDateOfReturn.Visible = true;
            txtDateOfReturn.Visible = true; 
            txtDateOfReturn.Enabled = true;
            Session["tripType"] = btnTripType.Text;
            
            }
        }

        protected void txtAdult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtDateOfJourney_TextChanged(object sender, EventArgs e)
        {
          
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {

            //Define session variables
            setSearchParameters();
            //Run functions for search flights
            getSearchResults();


            
            int totalPassengers = Convert.ToInt32(Session["numberOfAdults"]) + Convert.ToInt32(Session["numberOfChildren"]) + Convert.ToInt32(Session["numberOfInfants"]);
            if(totalPassengers>9)
            {
               
                lblCheckPassengers.Text = "Number of passengers cannot exceed 9";
                
            }
            else
            {
                lblCheckPassengers.Text = "";
                Response.Redirect("DisplaySearchResults.aspx");
            }
        }

   
       

        
    }
}