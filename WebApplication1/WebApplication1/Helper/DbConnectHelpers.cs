using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public class DbConnectHelpers
    {
        private string connStr { get; set; }
        SqlConnection conn;

        public DbConnectHelpers()
        {
            getConnectionString();
            conn = new SqlConnection(connStr);
        }

        private void getConnectionString()
        {
            connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        #region Connect & Disconnect

        public bool open()
        {
            if (conn.State.ToString() == "open")
                return true;
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool close()
        {
            if (conn.State.ToString() == "close")
                return true;
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public DataSet getDataSet(string procName, params object[] parameters)
        {
            SqlDataAdapter da = new SqlDataAdapter(procName, conn);
            DataSet ds = new DataSet();
            open();
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(da.SelectCommand);
                if (da.SelectCommand.Parameters.Count - 1 != parameters.Length)
                    return null;
                int i = 0;
                foreach (SqlParameter p in da.SelectCommand.Parameters)
                {
                    if (p.Direction == ParameterDirection.Input || p.Direction == ParameterDirection.InputOutput)
                        p.Value = parameters[i++];
                }
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                close();
            }
        }
    }
}