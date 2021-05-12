using RecipeCostCalc.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeCostCalc.Core.Services
{
    public class DataService
    {
        private readonly AppSettings _settings;
        public DataService(AppSettings settings) => _settings = settings;

        public Dictionary<int, Ingredient> Ingredients { get { return _settings.Ingredients.ToDictionary(x => x.Id, x => x); } }
        public Dictionary<int, Recipe> Recipes { get { return _settings.Recipes.ToDictionary(x => x.Id, x => x); } }

        public bool ConfigurationIsValid => _settings.IsValid;

    }
}
