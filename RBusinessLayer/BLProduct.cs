using RPropertyLayer;
using RDataLayer;
using System.Data;

namespace RBusinessLayer
{
    public class BLProduct
    {
        public int BLInsertUpdateCategory(PRProduct objProduct)
        {
            return new DLProduct().DLInsertUpdateCategory(objProduct);
        }

        public DataTable BLGetProductCategory(PRProduct objProduct)
        {
            return new DLProduct().DLGetProductCategory(objProduct);
        }

        public int BLInsertUpdateSubCategory(PRProduct objProduct)
        {
            return new DLProduct().DLInsertUpdateSubCategory(objProduct);
        }

        public DataTable BLGetProductSubCategory(PRProduct objProduct)
        {
            return new DLProduct().DLGetProductSubCategory(objProduct);
        }

        public int BLInsertUpdateSize(PRProduct objProduct)
        {
            return new DLProduct().DLInsertUpdateSize(objProduct);
        }

        public DataTable BLGetProductSize(PRProduct objProduct)
        {
            return new DLProduct().DLGetProductSize(objProduct);
        }

        public int BLInsertUpdateProduct(PRProduct objProduct)
        {
            return new DLProduct().DLInsertUpdateProduct(objProduct);
        }

        public DataTable BLGetProduct(PRProduct objProduct)
        {
            return new DLProduct().DLGetProductProduct(objProduct);
        }

      
    }
}
