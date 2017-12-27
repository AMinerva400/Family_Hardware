using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.DataModels
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int QuantityOnHand { get; set; }
        public int DepartmentID { get; set; }
        public int CategoryID { get; set; }
    }
}