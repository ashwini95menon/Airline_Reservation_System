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
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblEmailId.Visible = true;
        }

        protected void txtEmailId_TextChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack == true)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = GetConnection.GetConnectionString();
                SqlCommand cmd = new SqlCommand("select * from Customer where EmailId='" + txtEmailId.Text + "'", con);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();


                da.Fill(ds, "Customer");


                if (ds.Tables[0].Rows.Count > 0)
                {

                    lblEmailId.Visible = true;

                    lblEmailId.Text = "Email Id already exists.";
                }

            }
        }
    }
}