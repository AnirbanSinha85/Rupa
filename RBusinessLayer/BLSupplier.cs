using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDataLayer;
using System.Data;
using RPropertyLayer;

namespace RBusinessLayer
{
    public class BLSupplier
    {
        public int BLInsertUpdateSupplier(PRSupplier objSupplier)
        {
            return new DLSupplier().DLInsertUpdateSupplier(objSupplier);
        }

        public DataTable BLGetSupplier(PRSupplier objSupplier)
        {
            return new DLSupplier().DLGetSupplier(objSupplier);
        }
    }
}
