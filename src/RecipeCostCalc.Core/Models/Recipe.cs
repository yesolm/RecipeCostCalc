using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeCostCalc.Core.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<IngredientQty> Ingredients { get; set; }
    }
}
