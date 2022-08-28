using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicManagementLibrary
{
    public class Login : ILogin
    {
        static SqlConnection conn;
        static SqlCommand comm;

        private static SqlConnection getConnection()
        {
            conn = new SqlConnection("Data Source =.; Initial Catalog" +
                " = clinicmanagement; Integrated Security = True");
            conn.Open();
            return conn;
        } 
        public bool loginUser(string username, string password)
        {
            conn = getConnection();
            comm = new SqlCommand("sp_loginUser");
            comm.CommandType=System.Data.CommandType.StoredProcedure;
            comm.Connection = conn;
            comm.Parameters.AddWithValue("username", username);
            comm.Parameters.AddWithValue("password", password);
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                throw new LoginException("Login Failed Pls Enter Valid Login Details");
            }
        }
    }
}
