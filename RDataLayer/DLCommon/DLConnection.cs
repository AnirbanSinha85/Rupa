using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RDataLayer.DLCommon
{
    public class DLConnection
    {
        public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
        static SqlConnection con = new SqlConnection(SqlConnection);

        public static DataTable DLGetDataTable(string sp)
        {
            DataTable dt = new DataTable();
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return dt;
        }
    }
}
