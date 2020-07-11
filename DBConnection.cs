using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebAPI.Model
{
    public class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = new SqlConnection("Data Source=LAPTOP-65APHT4U\\SQLEXPRESS;Initial Catalog=produktdb;Integrated Security=True");
                cnn.Open();
                return cnn;
            }catch(Exception ex)
            {
                if(cnn != null )
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                }
                return null;
            }

        }
    }
}
