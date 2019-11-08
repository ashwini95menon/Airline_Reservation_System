using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservation_System_Dll
{
    public class BookingHistoryClass
    {
        public DataTable ViewBookingHistory(string CustomerId)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = GetConnection.GetConnectionString();
            con.Open();
            SqlDataReader dr;
            SqlCommand cmd;

            string query1 = "prc_BookingHistory";
            cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

            dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }
    }
}
