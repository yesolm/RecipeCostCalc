using Microsoft.Extensions.Configuration;
using RecipeCostCalc.Core;
using RecipeCostCalc.Core.Services;
using System;
using System.Threading.Tasks;

namespace RecipeCostCalc.App
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var appConfig = builder.Get<AppSettings>();

            var dataService = new DataService(appConfig);

            if (!dataService.ConfigurationIsValid)
                Console.WriteLine("Invalid Configuration.");

            var recepies = dataService.Recipes;

            foreach (var recipe in recepies)
            {
                Console.WriteLine("Choose {0} for {1}", recipe.Key, recipe.Value.Name);
            }


            int input;

            if (int.TryParse(Console.ReadLine(), out input) && recepies.ContainsKey(input))
            {
                var recipeService = new RecipeService(dataService.Recipes[input], dataService.Ingredients);
                recipeService.GetResipeCost();
                Console.Write(recipeService.GetResipeCost());
            }
            else
            {
                Console.WriteLine("Please enter a valid input.");
            }
        }
    }
}