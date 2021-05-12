using RecipeCostCalc.Core.DTOs;
using RecipeCostCalc.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeCostCalc.Core.Services
{
    public class RecipeService
    {
       
        private const double SALES_TAX_MULTIPLIER = 0.086;
        private const double WELLNESS_DISCOUNT = 0.05;
        private const double ROUNDUP_CENT_VAL = 7.0;

        private readonly Recipe _recipe;
        private readonly IDictionary<int, Ingredient> _ingredients;

        public RecipeService(Recipe recipe, IDictionary<int, Ingredient> ingredients)
        {
            _recipe = recipe;
            _ingredients = ingredients;
        }


        public ResultDTO GetResipeCost()
        {
            double subTotal = 0;
            double tax = 0;
            double discount = 0;
           
            foreach (var ing in _recipe.Ingredients)
            {
                double itemCost = ing.Qty * _ingredients[ing.Id].Price;

                tax += _ingredients[ing.Id].IngredientCategory == IngredientCategory.Produce ? 0 : itemCost * SALES_TAX_MULTIPLIER;
                discount += _ingredients[ing.Id].IsOrganic ? itemCost * WELLNESS_DISCOUNT : 0;

                subTotal += itemCost;

            }

            return  new ResultDTO
            {
                Tax = GetRoundedUpTax(tax),
                Discount = Math.Round(discount, 2, MidpointRounding.ToPositiveInfinity),
                Total = GetTotal(subTotal, GetRoundedUpTax(tax), Math.Round(discount, 2, MidpointRounding.ToPositiveInfinity))
            };
        }


        private double GetRoundedUpTax(double tax) => (ROUNDUP_CENT_VAL * (int)Math.Ceiling(tax * 100 / ROUNDUP_CENT_VAL)) / 100.0;

        private double GetTotal(double subTotal, double tax, double discount) => Math.Round(subTotal + tax - discount, 2, MidpointRounding.ToPositiveInfinity);
    }
}
