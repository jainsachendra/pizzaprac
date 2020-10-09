using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaorderBusiness.Model
{
   public  class OrderDetailsModel
    {
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string MobileNo { get; set; }
        public List<PizzaDetailsModel> pizzaDetails { get; set; }
        public int  Amount { get; set; }
    }
}
