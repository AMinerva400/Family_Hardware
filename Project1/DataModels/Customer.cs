using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.DataModels
{
    public class Customer
    {
        public int CustID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
    }
}