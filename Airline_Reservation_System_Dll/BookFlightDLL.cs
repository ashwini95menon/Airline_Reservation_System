using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservation_System_Dll
{
    public class BookFlightDLL
    {
         
        
        public int updatePassengersBeforePayment(int PassengerId,
												   string ReferenceId,
												   string PassengerName,
												   int PassengerAge,
												   char PassengerGender,
                                                   string BookingStatus)
        {
            
                SqlConnection con = new SqlConnection();
                con.ConnectionString = GetConnection.GetConnectionString();
                SqlCommand cmd;
                int cnt=0;
                try
                {
                    //Establish connection with db

                    con.Open();


                    string query1 = "prc_InsertPassengersBeforePayment";
                    cmd = new SqlCommand(query1, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PassengerId", PassengerId);
                    cmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                    cmd.Parameters.AddWithValue("@PassengerName", PassengerName);
                    cmd.Parameters.AddWithValue("@PassengerAge", PassengerAge);
                    cmd.Parameters.AddWithValue("@PassengerGender", PassengerGender);
                    cmd.Parameters.AddWithValue("@BookingStatus", BookingStatus);
                    

                   cnt=cmd.ExecuteNonQuery();

                    

                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                
                return cnt;
                
                
                
            }

        public int updateBookedTicketBeforePayment
            (
            string FlightId,
            string travelClass,
            string DateOfJourney,
            string DateOfBooking,
            int NumberOfAdults,
            int NumberOfChildren,
            string TicketFare,
            string CustomerId,
            string ReferenceId,
            string BookingStatus,
            string PaymentStatus,
            int AdultPrice,
            int ChildPrice
            )
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = GetConnection.GetConnectionString();
            SqlCommand cmd;
            int cnt = 0;
            try
            {
                //Establish connection with db

                con.Open();


                string query1 = "prc_BookingStatusBeforePayment";
                cmd = new SqlCommand(query1, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FlightId", FlightId);
                cmd.Parameters.AddWithValue("@Class", travelClass);
                cmd.Parameters.AddWithValue("@DateOfJourney", DateOfJourney);
                cmd.Parameters.AddWithValue("@DateOfBooking", DateOfBooking);
                cmd.Parameters.AddWithValue("@NumberOfAdults", NumberOfAdults);
                cmd.Parameters.AddWithValue("@NumberOfChildren", NumberOfChildren);
                cmd.Parameters.AddWithValue("@TicketFare", TicketFare);
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                cmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                cmd.Parameters.AddWithValue("@BookingStatus", BookingStatus);
                cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                cmd.Parameters.AddWithValue("@AdultPrice", AdultPrice);
                cmd.Parameters.AddWithValue("@ChildPrice", ChildPrice);

                cnt = cmd.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return cnt;



        }

        public void ConfirmBooking(string ReferenceId,
                                  string BookingStatus,
                                  string PaymentStatus,
                                  string FlightId,
                                  string DateOfFlight,
                                  string travelClass,
                                  int numberOfPassengers)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = GetConnection.GetConnectionString();
            SqlCommand cmd;
            int cnt = 0;

            con.Open();

            //SqlTransaction transaction;
            //transaction=con.BeginTransaction();

            string query1 = "prc_ConfirmBooking";
            cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);
            cmd.Parameters.AddWithValue("@BookingStatus", BookingStatus);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);

            cnt = cmd.ExecuteNonQuery();

            string query2 = "prc_ConfirmPassengers";
            cmd = new SqlCommand(query2, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);
            cmd.Parameters.AddWithValue("@BookingStatus", BookingStatus);
            

            cnt = cmd.ExecuteNonQuery();

            string query3 = "prc_DecrementAvailableSeats";
            cmd = new SqlCommand(query3, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlightId", FlightId);
            cmd.Parameters.AddWithValue("@Class", travelClass);
            cmd.Parameters.AddWithValue("@DateOfFlight", DateOfFlight);
            cmd.Parameters.AddWithValue("@numberOfPassengers", numberOfPassengers);


            cnt = cmd.ExecuteNonQuery();

            //transaction.Commit();
            
        }
        }
    }

