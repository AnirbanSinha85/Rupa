using System.Data;
using RPropertyLayer;
using RDataLayer;

namespace RBusinessLayer
{
   public class BLCustomer
    {
       public int BLInsertUpdateCustomer(PRCustomer objCustomer)
        {
            return new DLCustomer().DLInsertUpdateCustomer(objCustomer);
        }

       public DataTable BLGetCustomer(PRCustomer objCustomer)
        {
            return new DLCustomer().DLGetCustomer(objCustomer);
        }
    }
}
