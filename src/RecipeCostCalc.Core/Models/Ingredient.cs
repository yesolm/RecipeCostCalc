using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeCostCalc.Core.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public IngredientCategory IngredientCategory { get; set; }
        public bool IsOrganic { get; set; }

        public override string ToString() => Name;
    }
}
