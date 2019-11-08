using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservation_System_Dll
{
    public class GetFlightDetails
    {
        
        public DataTable GetSource()
        {
            string conStr = GetConnection.GetConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            
            SqlDataReader dr;
            SqlCommand cmd;
            DataTable dt=new DataTable();
            string query;
            con.Open();
            query = "prc_SelectSource";
            cmd = new SqlCommand(query, con);
            cmd.CommandType=CommandType.StoredProcedure;
            dr=cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public DataTable GetDestination(string selectedSource)
        {
            string conStr = GetConnection.GetConnectionString();
            SqlConnection con = new SqlConnection(conStr);

            SqlDataReader dr;
            SqlCommand cmd;
            DataTable dt = new DataTable();
            string query;
            con.Open();
            query = "prc_SelectDestination";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@source", selectedSource);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }
        public SqlCommand cmd;
        public DataTable GetClass()
        {
            string conStr = GetConnection.GetConnectionString();
            SqlConnection con = new SqlConnection(conStr);

            SqlDataReader dr;
            
            DataTable dt = new DataTable();
            string query;
            con.Open();
            query = "prc_SelectClass";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public DataTable GetAirline()
        {
            string conStr = GetConnection.GetConnectionString();
            SqlConnection con = new SqlConnection(conStr);

            SqlDataReader dr;

            DataTable dt = new DataTable();
            string query;
            con.Open();
            query = "prc_SelectAirline";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public string GetConnectionString { get; set; }
    }
}
