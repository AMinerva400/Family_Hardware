using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.DataModels
{
    public class Sales
    {
        public int SalesID { get; set; }
        public int QuantitySold { get; set; }
        public string PaymentType { get; set; }
        public int TotalPrice { get; set; } 
    }
}