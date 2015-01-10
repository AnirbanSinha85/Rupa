using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RDataLayer;
using RPropertyLayer;

namespace RBusinessLayer
{
    public class BLPurchaseInvoice
    {
        public DataTable BLGetPurchaseInvoice(PRPurchaseInvoice objInvoice)
        {
            return new DLPurchaseInvoice().DLGetPurchaseInvoice(objInvoice);
        }

        public int BLInsertUpdatePurchaseInvoice(PRPurchaseInvoice objInvoice)
        {
            return new DLPurchaseInvoice().DLInsertUpdatePurchaseInvoice(objInvoice);
        }
    }
}
