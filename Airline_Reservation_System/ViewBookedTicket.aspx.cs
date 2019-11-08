using Airline_Reservation_System_Dll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Airline_Reservation_System
{
    public partial class WebForm26 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = GetConnection.GetConnectionString();
            con.Open();
            SqlDataReader dr;
            SqlCommand cmd;

            string referenceId = Session["referenceId"].ToString();
           

            string query1 = "prc_ViewBookedTicket";
            cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReferenceId", referenceId);

            dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();


            GridView1.DataSource = dt;
            GridView1.DataBind();

            if(Session["tripType"].ToString().Equals("Round Trip"))
            {
                DataTable dt2 = new DataTable();
                

                con.ConnectionString = GetConnection.GetConnectionString();
                con.Open();
                SqlDataReader dr2;
                SqlCommand cmd2;

                
                string referenceIdRoundTrip = Session["referenceIdRoundTrip"].ToString();

                string query2 = "prc_ViewBookedTicket";
                cmd2= new SqlCommand(query2, con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@ReferenceId", referenceIdRoundTrip);

                dr2 = cmd2.ExecuteReader();
                dt2.Load(dr2);
                con.Close();


                GridView2.DataSource = dt2;
                GridView2.DataBind();
            }
            
        }
    }
}