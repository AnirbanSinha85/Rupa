using System;
using System.Data;
using System.Collections;
using LSDataLayer.DLCommon;
using RPropertyLayer;

namespace RDataLayer
{
    public class DLLogin
    {
        public DataTable DLCheckLogIn(PRLogIn objLogIn)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@UserName", objLogIn.UserName);
                ht.Add("@Password", objLogIn.Password);
                dt = DLDBAccess.GetDataTable(DLStoredProcedure.CheckLogIn, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
