using System;
using System.Data;

namespace WebApplication1.Models
{
    public class LoadDBData
    {
        DbConnectHelpers db = new DbConnectHelpers();
        public DataTable search(object[] key)
        {
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
            try
            {
                return int.Parse(db.getDataSet("sp_login", key).Tables[0].Rows[0][0].ToString());
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

        public string[] getInfoKH(object[] key)
        {
            try
            {
                DataRow dr = db.getDataSet("sp_getInfoKH", key).Tables[0].Rows[0];
                return new string[2] { dr[0].ToString(), dr[1].ToString() };
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

        public string  bookTicket(object[] key)
        {
            try
            {
                return db.getDataSet("sp_bookTicket", key).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string addNhanVien(object[] key)
        {
            try
            {
                return db.getDataSet("sp_addNhanVien", key).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string addTuyenXe(object[] key)
        {
            try
            {
                return db.getDataSet("sp_addTuyenXe", key).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string deleteChuyenXe(object[] key)
        {
            try
            {
                return db.getDataSet("sp_deleteChuyenXe", key).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string editChuyenXe(object[] key)
        {
            try
            {
                return db.getDataSet("sp_editChuyenXe", key).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string editNhanVien(object[] key)
        {
            try
            {
                return db.getDataSet("sp_editNhanVien", key).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string editTuyenXe(object[] key)
        {
            try
            {
                return db.getDataSet("sp_editTuyenXe", key).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public DataTable loadTable(string tableName)
        {
            return db.loadTable(tableName);
        }

    }
}