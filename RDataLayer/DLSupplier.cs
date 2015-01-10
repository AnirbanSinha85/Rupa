using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPropertyLayer;
using System.Collections;
using LSDataLayer.DLCommon;
using System.Data;

namespace RDataLayer
{
    public class DLSupplier
    {
        public int DLInsertUpdateSupplier(PRSupplier objSupplier)
        {
            int rt = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@SupplierID", objSupplier.SupplierID);
                ht.Add("@Name", objSupplier.Name);
                ht.Add("@Address", objSupplier.Address);
                ht.Add("@ContactNo", objSupplier.ContactNo);
                ht.Add("@CreatedBy", objSupplier.CreatedBy);
                ht.Add("@DeleteFlag", objSupplier.DeleteFlag);
                ht.Add("@Status", objSupplier.Status);
                rt = DLDBAccess.ExecuteNonQuerySQL(DLStoredProcedure.InsertUpdateSupplier, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rt;
        }

        public DataTable DLGetSupplier(PRSupplier objSupplier)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@Status", objSupplier.Status);
                dt = DLDBAccess.GetDataTable(DLStoredProcedure.InsertUpdateSupplier, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
