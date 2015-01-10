using RPropertyLayer;
using RDataLayer;
using System.Data;

namespace RBusinessLayer
{
   public class BLSalesInvoice
    {
        public int BLInsertUpdateSalesInvoice(PRSalesInvoice objInvoice)
        {
            return new DLSalesInvoice().DLInsertUpdateSalesInvoice(objInvoice);
        }

        public DataTable BLGetSalesInvoice(PRSalesInvoice objInvoice)
        {
            return new DLSalesInvoice().DLGetSalesInvoice(objInvoice);
        }
    }
}
