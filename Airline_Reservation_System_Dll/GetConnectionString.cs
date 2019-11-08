using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservation_System_Dll
{
    public static class GetConnection
    {

        public static string GetConnectionString()
        {
            string con="Data Source=Infva07148;Initial Catalog=Airline_DB;User ID=sa;Password=Newuser123";
            return con;
        }
    }
}
