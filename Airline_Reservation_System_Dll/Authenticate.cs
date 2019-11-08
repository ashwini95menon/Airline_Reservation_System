using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservation_System_Dll
{
    public class Authenticate
    {
        public  bool AuthenticateUser(string username,string password)
        {
            bool allowAccess=false;

            string conString = GetConnection.GetConnectionString();
            SqlConnection con = new SqlConnection(conString);

            string query="prc_authenticateUser";

            con.Open();

            SqlDataReader dr;

            SqlCommand cmd = new SqlCommand(query,con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            dr=cmd.ExecuteReader();
            
            DataTable dt = new DataTable();
            dt.Load(dr);

            for(int i=0;i<dt.Rows.Count;i++)
            {
                if(dt.Rows[i]["CustomerId"].ToString().Equals(username))
                    allowAccess=true;
            }

            return allowAccess;
        }
    }
}
