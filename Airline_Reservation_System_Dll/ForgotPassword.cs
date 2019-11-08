using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservation_System_Dll
{
    public class ForgotPassword
    {
        //Checking Email Id Of User And Verifying Whether It is present or not


        public int CheckingEmailIdInDataBase(string EmailId)
        {
            int cnt = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = GetConnection.GetConnectionString();
            SqlCommand cmd;

            try
            {
                //Establish connection with db

                con.Open();


                string query1 = "Prc_EmailIdMatching";
                cmd = new SqlCommand(query1, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmailId", EmailId);

                var returnParameter = cmd.Parameters.Add("@Exists", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;


                cmd.ExecuteNonQuery();
                int j = Convert.ToInt32(returnParameter.Value);


                //int j=Convert.ToInt32(cmd.ExecuteScalar());



                if (j == 1)
                {

                    cnt = j;

                }
                else
                    cnt = j;


            }
            catch (Exception)
            {



            }

            return cnt;

        }//checkEmail




        public int SettingNewPassword(string EmailId, string pwd)
        {

            int n = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = GetConnection.GetConnectionString();
            SqlCommand cmd;

            try
            {
                //Establish connection with db

                con.Open();


                string query1 = "Prc_SetNewUserPassword";
                cmd = new SqlCommand(query1, con);
                cmd.CommandType = CommandType.StoredProcedure;




                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                cmd.Parameters.AddWithValue("@NewPwd", pwd);




                n = cmd.ExecuteNonQuery();



                //int j=Convert.ToInt32(cmd.ExecuteScalar());


            }

            catch (Exception)
            {



            }

            return n;



        }

    }


}


