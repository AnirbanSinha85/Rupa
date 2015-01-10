using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace LSDataLayer.DLCommon
{
    public class DLDBAccess
    {
        #region GetConnection
        /// <summary>
        /// This static method returns a SqlConnection
        /// </summary>
        /// <remarks>Static method having database connection string which needs to be modified according to envoronment</remarks>
        /// <returns>SqlConnection</returns>
        private static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rupa"].ConnectionString);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (System.Data.DataException ex)
            {
                throw ex;
            }
            catch (System.Security.SecurityException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return con;
        }
        #endregion

        #region Execute Scalar SQL
        /// <summary>
        /// This function will execute a Scalar(ExecuteScalar) sql.
        /// </summary>
        /// <param name="commandText" description="stored procedure name"></param>
        /// <param name="htParams" description="parameters"></param>
        /// <returns>object</returns>
        public static object ExecuteScalarSQL(string CommandText, Hashtable htParams)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(CommandText);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                foreach (DictionaryEntry dE in htParams)
                {
                    cmd.Parameters.AddWithValue((string)dE.Key, dE.Value);
                }
                object result = cmd.ExecuteScalar();
                con.Close();
                con.Dispose();
                return result;
            }
            catch (System.InvalidCastException ex)
            {
                throw ex;
            }
            catch (System.NullReferenceException ex)
            {
                throw ex;
            }
            catch (System.Data.DataException ex)
            {
                throw ex;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        #endregion

        #region Execute NonQuery
        /// <summary>
        /// This function will execute a nonQuery(ExecuteNonQuery) sql.
        /// </summary>
        /// <param name="commandText" description="stored procedure name.></param>
        /// <param name="htParams" description="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuerySQL(string commandText, Hashtable htParams)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(commandText);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DictionaryEntry dE in htParams)
                {
                    cmd.Parameters.AddWithValue((string)dE.Key, dE.Value);
                }
                cmd.Connection = con;
                int result = (int)cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                return result;
            }
            catch (System.InvalidCastException ex)
            {
                throw ex;
            }
            catch (System.NullReferenceException ex)
            {
                throw ex;
            }
            catch (System.Data.DataException ex)
            {
                throw ex;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }
        #endregion

        #region DataTable
        /// <summary>
        /// This function will execute the sql and return a DataTable type object against a stored proc returning all data accepting no input param.
        /// </summary>      
        /// <param name="commandText" description="stored procedure name."></param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable(string commandText)
        {
            DataTable dt = new DataTable();
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(commandText);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Dispose();
                con.Close();
                con.Dispose();
                return dt;
            }
            catch (System.Data.DataException ex)
            {
                throw ex;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        /// <summary>
        /// This function will execute the sql and return a DataTable type object.
        /// </summary>
        /// <param name="commandText" description="stored procedure name."></param>
        /// <param name="htParams" description="parameters"></param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable(string commandText, Hashtable htParams)
        {
            SqlConnection con = GetConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(commandText);
                cmd.CommandTimeout = 180;
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (DictionaryEntry dE in htParams)
                {
                    cmd.Parameters.AddWithValue((string)dE.Key, dE.Value);
                }
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Dispose();
                con.Close();
                con.Dispose();
                return dt;
            }
            catch (System.InvalidCastException ex)
            {
                throw ex;
            }
            catch (System.NullReferenceException ex)
            {
                throw ex;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (System.Data.DataException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        #endregion

        #region DataSet
        /// <summary>
        /// This function will execute the sql and return a DataSet type object against a stored proc returning all data accepting no input param.
        /// </summary>      
        /// <param name="commandText" description="stored procedure name."></param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string commandText)
        {
            DataSet ds = new DataSet();
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(commandText);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                con.Dispose();
                return ds;
            }
            catch (System.Data.DataException ex)
            {
                throw ex;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        /// <summary>
        /// This function will execute the sql and return a Dataset type object.
        /// </summary>
        /// <param name="commandText" description="stored procedure name."></param>
        /// <param name="htParams" description="parameters"></param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string commandText, Hashtable htParams)
        {
            DataSet ds = new DataSet();
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(commandText);
                cmd.CommandTimeout = 200;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                foreach (DictionaryEntry dE in htParams)
                {
                    cmd.Parameters.AddWithValue((string)dE.Key, dE.Value);
                }
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                con.Dispose();
                return ds;
            }
            catch (System.InvalidCastException ex)
            {
                throw ex;
            }
            catch (System.NullReferenceException ex)
            {
                throw ex;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (System.Data.DataException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        #endregion

        #region FixDBNull
        /*********methods to set all null values Begins Here*********/

        public static object FixDBNull(object objValue)
        {
            return (objValue == DBNull.Value ? null : objValue);
        }

        public static object FixDBNull(object objValue, Type oType)
        {
            if (objValue == DBNull.Value)
            {
                if (oType == typeof(Boolean))
                    return false;
                else if (oType == typeof(DateTime))
                    return new DateTime(1900, 01, 01);
                else
                    return null;
            }
            return objValue;
        }

        public static object FixFieldNull(object objValue, Type oType)
        {
            if (objValue == null)
                return DBNull.Value;

            if (oType == typeof(Boolean))
            {
                if ((bool)objValue == true)
                    return 1;
                else
                    return 0;
            }
            else if (oType == typeof(DateTime))
            {
                if ((DateTime)objValue == new DateTime(1900, 01, 01))
                    return DBNull.Value;
                else
                    return objValue;
            }
            else
                return objValue;
        }

        public static object FixFieldNull(string objValue)
        {
            if (string.IsNullOrEmpty(objValue))
                return DBNull.Value;
            else
                return objValue.Trim();
        }

        public static object FixFieldNull(bool objValue)
        {
            if (objValue == true)
                return 1;
            else
                return 0;
        }

        public static object FixFieldNull(DateTime objValue)
        {
            if ((DateTime)objValue == new DateTime(1900, 01, 01) || (DateTime)objValue == new DateTime(0001, 01, 01))
                return DBNull.Value;
            else
                return objValue;
        }

        public static object FixFieldNull(int objValue)
        {
            if (objValue == 0)
                return DBNull.Value;
            else
                return objValue;
        }

        /*********methods to set all null values Ends Here*********/
        #endregion

       
    }
}
