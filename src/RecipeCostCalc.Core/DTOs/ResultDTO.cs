using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeCostCalc.Core.DTOs
{
    public class ResultDTO
    {
        public double Total { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }

        public override string ToString()
        {
            return $"Tax: {Tax}\nDiscount: {Discount}\nTotal: {Total}";
        }
    }
}
