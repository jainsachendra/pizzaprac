using Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaorderBusiness.Model
{
   public class PizzaDetailsModel
    {
        public string Name { get; set; }
        public Toppings Toppings{ get; set; }
        public double Price { get; set; }
        public int Size { get; set; }
    }
}
