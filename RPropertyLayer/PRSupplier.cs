using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPropertyLayer
{
   public class PRSupplier
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public int CreatedBy { get; set; }
        public int DeleteFlag { get; set; }
        public string Status { get; set; }
    }
}
