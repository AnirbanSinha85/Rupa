using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPropertyLayer
{
    public class PRProduct
    {
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string ProductName { get; set; }
        public string SizeName { get; set; }

        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int ProductID { get; set; }
        public int SizeID { get; set; }

        public int CreatedBy { get; set; }
        public int DeleteFlag { get; set; }

        public string Status { get; set; }


        public int QtyInBox { get; set; }
        public int AvailableQty { get; set; }
    }
}
