using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservation_System_Dll
{
      public class SearchFlight
        {
            //declare variables
            string source;
            string destination;
            string travelClass;
            string dateOfJourney;
            int numberOfAdults;
            int numberOfChildren;
            int numberOfPassengers;
            string tripType;
            //string dateOfReturnJourney;

            //Input parameters for searching flight trip to be passed in a constructor
            public SearchFlight(
                         string source,
                         string destination,
                         string travelClass,
                         string dateOfJourney,
                         int numberOfAdults,
                         int numberOfChildren
                         )
            {
                this.source = source;
                this.destination = destination;
                this.travelClass = travelClass;
                this.dateOfJourney = dateOfJourney;
                this.numberOfAdults = numberOfAdults;
                this.numberOfChildren = numberOfChildren;
                this.numberOfPassengers = this.numberOfAdults + this.numberOfChildren;
            }


            /// <summary>
            /// A method for getting search results
            /// parameters taken in constructor
            /// 6 parameters are - source,destination,class,dateofjourney,dateofreturn,nadults,ninfants
            /// </summary>
            /// <returns>Data Table</returns>
            public DataTable SearchFlights()
            {

                DataTable dtSearchFlight = new DataTable();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = GetConnection.GetConnectionString();
                SqlDataReader dr;
                SqlCommand cmd;
                try
                {
                    //Establish connection with db

                    con.Open();

                    string query1 = "prc_displayFlights";
                    cmd = new SqlCommand(query1, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@source", source);
                    cmd.Parameters.AddWithValue("@destination", destination);
                    cmd.Parameters.AddWithValue("@dateOfJourney", dateOfJourney);
                    cmd.Parameters.AddWithValue("@numberOfPassengers", numberOfPassengers);
                    cmd.Parameters.AddWithValue("@class", travelClass);
                    dr = cmd.ExecuteReader();

                    dtSearchFlight.Load(dr);
                    dtSearchFlight.Columns.Add("Fare");

                    //Calculate total fare
                    for (int i = 0; i < dtSearchFlight.Rows.Count; i++)
                    {
                        int adultprice = Convert.ToInt32(dtSearchFlight.Rows[i]["AdultPrice"]);
                        adultprice = numberOfAdults * adultprice;
                        int childprice = Convert.ToInt32(dtSearchFlight.Rows[i]["ChildPrice"]);
                        childprice = numberOfChildren * childprice;
                        int fare = childprice + adultprice;
                        dtSearchFlight.Rows[i]["Fare"] = fare;
                    }

                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                
                return dtSearchFlight;
                
                
                
            }



        }

         
         public class SearchFlightByFilter
         {
             /// <summary>
             /// Search flight by a specific airline for eg. AirIndia
             /// </summary>
             /// <param name="source"></param>
             /// <param name="destination"></param>
             /// <param name="travelClass"></param>
             /// <param name="dateOfJourney"></param>
             /// <param name="numberOfAdults"></param>
             /// <param name="numberOfChildren"></param>
             /// <param name="airline"></param>
             /// <returns></returns>
           
             public DataTable FilterByAirline
                                              (
                                                  string source,
                                                  string destination,
                                                  string travelClass,
                                                  string dateOfJourney,
                                                  int numberOfAdults,
                                                  int numberOfChildren,
                                                  string airline
                                              )
             {

                 DataTable dt = new DataTable();
                 SqlConnection con = new SqlConnection();
                 con.ConnectionString = GetConnection.GetConnectionString();
                 SqlDataReader dr;
                 SqlCommand cmd;
                 try
                 {
                     //Establish connection with db

                     con.Open();

                     string query1 = "prc_displayFlightsFilterByAirline";
                    
                     cmd = new SqlCommand(query1, con);
                     cmd.CommandType = CommandType.StoredProcedure;

                     int numberOfPassengers = numberOfAdults + numberOfChildren;
                     cmd.Parameters.AddWithValue("@source", source);
                     cmd.Parameters.AddWithValue("@destination", destination);
                     cmd.Parameters.AddWithValue("@dateOfJourney", dateOfJourney);
                     cmd.Parameters.AddWithValue("@numberOfPassengers", numberOfPassengers);
                     cmd.Parameters.AddWithValue("@class", travelClass);
                     cmd.Parameters.AddWithValue("@flightName", airline);
                     dr = cmd.ExecuteReader();

                     dt.Load(dr);
                     dt.Columns.Add("Fare");

                     for (int i = 0; i < dt.Rows.Count; i++)
                     {
                         int a = Convert.ToInt32(dt.Rows[i]["AdultPrice"]);
                         a = numberOfAdults * a;
                         int b = Convert.ToInt32(dt.Rows[i]["ChildPrice"]);
                         b = numberOfChildren * b;
                         int c = a + b;
                         dt.Rows[i]["Fare"] = c;
                     }


                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex);
                 }

                 return dt;



             }

             /// <summary>
             /// Search flight by specifying maximum price. For eg if a user enters 
             /// Rs 10000 flights with a fare below Rs 10000 is shown
             /// </summary>
             /// <param name="source"></param>
             /// <param name="destination"></param>
             /// <param name="travelClass"></param>
             /// <param name="dateOfJourney"></param>
             /// <param name="numberOfAdults"></param>
             /// <param name="numberOfChildren"></param>
             /// <param name="maxPrice"></param>
             /// <returns></returns>

             public DataTable FilterByPrice
                                              (
                                                  string source,
                                                  string destination,
                                                  string travelClass,
                                                  string dateOfJourney,
                                                  int numberOfAdults,
                                                  int numberOfChildren,
                                                  int maxPrice
                                              )
             {

                 DataTable dt = new DataTable();
                 SqlConnection con = new SqlConnection();
                 con.ConnectionString = GetConnection.GetConnectionString();
                 SqlDataReader dr;
                 SqlCommand cmd;
                 try
                 {
                     //Establish connection with db

                     con.Open();

                     string query1 = "prc_displayFlightsFilterByPrice";
                     //string query1 = "select * from Flight";
                     cmd = new SqlCommand(query1, con);
                     cmd.CommandType = CommandType.StoredProcedure;

                     int numberOfPassengers = numberOfAdults + numberOfChildren;
                     cmd.Parameters.AddWithValue("@source", source);
                     cmd.Parameters.AddWithValue("@destination", destination);
                     cmd.Parameters.AddWithValue("@dateOfJourney", dateOfJourney);
                     cmd.Parameters.AddWithValue("@numberOfPassengers", numberOfPassengers);
                     cmd.Parameters.AddWithValue("@class", travelClass);
                     cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
                     dr = cmd.ExecuteReader();

                     dt.Load(dr);
                     dt.Columns.Add("Fare");

                     for (int i = 0; i < dt.Rows.Count; i++)
                     {
                         int a = Convert.ToInt32(dt.Rows[i]["AdultPrice"]);
                         a = numberOfAdults * a;
                         int b = Convert.ToInt32(dt.Rows[i]["ChildPrice"]);
                         b = numberOfChildren * b;
                         int c = a + b;
                         dt.Rows[i]["Fare"] = c;
                     }


                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex);
                 }

                 return dt;



             }

         }
    }


