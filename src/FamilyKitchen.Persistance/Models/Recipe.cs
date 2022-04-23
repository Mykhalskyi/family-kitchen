using System;
using System.Collections.Generic;

namespace FamilyKitchen.Persistance.Models
{
    public class Recipe
    {
        public int PorionsAmount { get; private set; }
        public List<Tuple<Ingredient, decimal>> Ingredients { get; private set; }
        public List<string> Steps { get; private set; }
        public string Notes { get; private set; }
    }
}