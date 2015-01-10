using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using LSDataLayer.DLCommon;
using RPropertyLayer;
using System.Data;
using System.Data.SqlClient;

namespace RDataLayer
{
    public class DLProduct
    {
        public int DLInsertUpdateCategory(PRProduct objProduct)
        {
            int rt = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@CategoryID", objProduct.CategoryID);
                ht.Add("@CategoryName", objProduct.CategoryName);
                ht.Add("@CreatedBy", objProduct.CreatedBy);
                ht.Add("@DeleteFlag", objProduct.DeleteFlag);
                ht.Add("@Status", objProduct.Status);
                rt = DLDBAccess.ExecuteNonQuerySQL(DLStoredProcedure.InsertUpdateProductCategory, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rt;
        }

        public DataTable DLGetProductCategory(PRProduct objProduct)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@Status", objProduct.Status);
                dt = DLDBAccess.GetDataTable(DLStoredProcedure.InsertUpdateProductCategory, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public int DLInsertUpdateSubCategory(PRProduct objProduct)
        {
            int rt = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@SubCategoryID", objProduct.SubCategoryID);
                ht.Add("@SubCategoryName", objProduct.SubCategoryName);
                ht.Add("@CreatedBy", objProduct.CreatedBy);
                ht.Add("@DeleteFlag", objProduct.DeleteFlag);
                ht.Add("@Status", objProduct.Status);
                rt = DLDBAccess.ExecuteNonQuerySQL(DLStoredProcedure.InsertUpdateProductSubCategory, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rt;
        }

        public DataTable DLGetProductSubCategory(PRProduct objProduct)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@Status", objProduct.Status);
                dt = DLDBAccess.GetDataTable(DLStoredProcedure.InsertUpdateProductSubCategory, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public int DLInsertUpdateSize(PRProduct objProduct)
        {
            int rt = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@SizeID", objProduct.SizeID);
                ht.Add("@SizeName", objProduct.SizeName);
                ht.Add("@CreatedBy", objProduct.CreatedBy);
                ht.Add("@DeleteFlag", objProduct.DeleteFlag);
                ht.Add("@Status", objProduct.Status);
                rt = DLDBAccess.ExecuteNonQuerySQL(DLStoredProcedure.InsertUpdateProductSize, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rt;
        }

        public DataTable DLGetProductSize(PRProduct objProduct)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@Status", objProduct.Status);
                dt = DLDBAccess.GetDataTable(DLStoredProcedure.InsertUpdateProductSize, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public int DLInsertUpdateProduct(PRProduct objProduct)
        {
            int rt = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@ProductID", objProduct.ProductID);
                ht.Add("@CategoryID", objProduct.CategoryID);
                ht.Add("@SubCategoryID", objProduct.SubCategoryID);
                ht.Add("@ProductName", objProduct.ProductName);
                ht.Add("@CreatedBy", objProduct.CreatedBy);
                ht.Add("@DeleteFlag", objProduct.DeleteFlag);
                ht.Add("@Status", objProduct.Status);
                ht.Add("@AvailableQty", objProduct.AvailableQty);
                ht.Add("@QtyInBox", objProduct.QtyInBox);
                rt = DLDBAccess.ExecuteNonQuerySQL(DLStoredProcedure.InsertUpdateProduct, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rt;
        }

        public DataTable DLGetProductProduct(PRProduct objProduct)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@Status", objProduct.Status);
                dt = DLDBAccess.GetDataTable(DLStoredProcedure.InsertUpdateProduct, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }
}
