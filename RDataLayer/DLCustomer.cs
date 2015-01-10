using System;
using RPropertyLayer;
using System.Collections;
using LSDataLayer.DLCommon;
using System.Data;

namespace RDataLayer
{
   public class DLCustomer
    {
       public int DLInsertUpdateCustomer(PRCustomer objCustomer)
        {
            int rt = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@CustomerID", objCustomer.CustomerID);
                ht.Add("@Name", objCustomer.Name);
                ht.Add("@Address", objCustomer.Address);
                ht.Add("@ContactNo", objCustomer.ContactNo);
                ht.Add("@CreatedBy", objCustomer.CreatedBy);
                ht.Add("@DeleteFlag", objCustomer.DeleteFlag);
                ht.Add("@Status", objCustomer.Status);
                rt = DLDBAccess.ExecuteNonQuerySQL(DLStoredProcedure.InsertUpdateCustomer, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rt;
        }

       public DataTable DLGetCustomer(PRCustomer objCustomer)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@Status", objCustomer.Status);
                ht.Add("@CustomerID", objCustomer.CustomerID);
                dt = DLDBAccess.GetDataTable(DLStoredProcedure.InsertUpdateCustomer, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
