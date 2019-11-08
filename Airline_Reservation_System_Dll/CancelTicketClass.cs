using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservation_System_Dll
{
    public class CancelTicketClass
    {
        public DataTable GetPassengers(string ReferenceId)
        {
            DataTable dtPassengers = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = GetConnection.GetConnectionString();
            SqlDataReader dr;
            SqlCommand cmd;
            con.Open();
            string query1 = "prc_GetPassengerData";
            cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);

            dr = cmd.ExecuteReader();
            dtPassengers.Load(dr);
            con.Close();
            return dtPassengers;

        }

        public void CancelTicket(int PassengerId, string ReferenceId,string user)
        {
           

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = GetConnection.GetConnectionString();
                con.Open();
                SqlCommand cmd;

                string query1 = "prc_UpdateCancelledStatus";
                cmd = new SqlCommand(query1, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PassengerId", PassengerId);
                cmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                cmd.Parameters.AddWithValue("@user", user);

                int cnt = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception) { }
        }
    }
}
