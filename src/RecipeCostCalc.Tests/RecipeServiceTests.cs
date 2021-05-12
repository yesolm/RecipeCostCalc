using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeCostCalc.Core;
using RecipeCostCalc.Core.Models;
using RecipeCostCalc.Core.Services;
using System.Collections.Generic;

namespace RecipeCostCalc.Tests
{
    [TestClass]
    public class RecipeServiceTests
    {
        DataService _dataService;

        [TestInitialize]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            var appConfig = builder.Get<AppSettings>();
            _dataService = new DataService(appConfig);
        }

        [TestMethod]
        public void RecipeService_DataService_ConfigurationIsValid()
        {
            Assert.IsNotNull(_dataService);
            Assert.IsTrue(_dataService.ConfigurationIsValid);
        }


        [TestMethod]
        public void RecipeService_CostCalculationSuccessul()
        {
            var recipe = new Recipe
            {
                Id = 1,
                Name = " Recipe 1",
                Ingredients = new List<IngredientQty>
                {
                    new IngredientQty { Id = 1, Qty = 1}, // 1 garlic clove
                    new IngredientQty { Id = 2, Qty = 1}, // 1 lemon
                    new IngredientQty { Id = 7, Qty = 0.75}, // 3/4 cup olive oil
                    new IngredientQty { Id = 9, Qty = 0.75}, // 3/4 teaspons of salt
                    new IngredientQty { Id = 10, Qty = 0.5} // 1/2 teaspoons of papper

                }

            };

            var result = new RecipeService(recipe, _dataService.Ingredients).GetResipeCost();
            Assert.AreEqual(result.Tax, 0.21);
            Assert.AreEqual(result.Discount, 0.11);
            Assert.AreEqual(result.Total, 4.45);
        }
    }
}
