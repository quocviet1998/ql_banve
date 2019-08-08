using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class LoadDBData
    {
        DbConnectHelpers db = new DbConnectHelpers();
        public DataTable search(object[] key)
        {
            if (isObjNull(key))
                return null;
            try
            {
                return db.getDataSet("sp_search", key).Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string login(object[] key)
        {
            if (isObjNull(key))
                return null;
            try
            {
                return db.getDataSet("sp_login", key).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool isObjNull(object[] obj)
        {
            //string[] temp = obj;
            foreach (var o in obj)
                if (!o.Equals(null))
                    return false;
            return true;
        }
    }
}