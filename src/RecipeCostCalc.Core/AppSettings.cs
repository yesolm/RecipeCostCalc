using RecipeCostCalc.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeCostCalc.Core
{
    public class AppSettings
    {
        public IList<Ingredient> Ingredients { get; set; }
        public IList<Recipe> Recipes { get; set; }

        public bool IsValid => Ingredients != null && Recipes != null && Ingredients.Any() && Recipes.Any();
    }
}
