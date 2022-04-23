using System;
using System.Collections.Generic;

namespace FamilyKitchen.Persistance.Models
{
    public class Menu
    {
        public DateTime Date { get; private set; }
        public List<Tuple<Dish, int>> Dishes { get; private set; }
    }
}
