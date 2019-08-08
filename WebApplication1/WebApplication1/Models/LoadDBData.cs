using System;
using System.Data;

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

        public int login(object[] key)
        {
            if (isObjNull(key))
                return -1;
            try
            {
                return (int)db.getDataSet("sp_login", key).Tables[0].Rows[0][0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string signin(object[] key)
        {
            try
            {
                return db.getDataSet("sp_signin", key).Tables[0].Rows[0][0].ToString();
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


        public DataTable loadTable(string tableName)
        {
            return db.loadTable(tableName);
        }

    }
}