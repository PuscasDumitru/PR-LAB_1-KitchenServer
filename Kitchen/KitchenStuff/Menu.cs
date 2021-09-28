using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.KitchenStuff
{
    class Menu
    {
        static public List<Dish> menuDishes = new List<Dish>
        {
            new Dish { Id = 1, Name = "pizza", PrepTime = 20, Complexity = 2, CookingApparatus = "oven"},
            new Dish { Id = 2, Name = "salad", PrepTime = 10, Complexity = 1, CookingApparatus = null},
            new Dish { Id = 3, Name = "zeama", PrepTime = 7, Complexity = 1, CookingApparatus = "stove"},
            new Dish { Id = 4, Name = "Scallop Sashimi with Meyer Lemon Confit", PrepTime = 32, Complexity = 3, CookingApparatus = null},
            new Dish { Id = 5, Name = "Island Duck with Mulberry Mustard", PrepTime = 35, Complexity = 3, CookingApparatus = "oven"},
            new Dish { Id = 6, Name = "Waffles", PrepTime = 10, Complexity = 1, CookingApparatus = "stove"},
            new Dish { Id = 7, Name = "Aubergine", PrepTime = 20, Complexity = 2, CookingApparatus = null},
            new Dish { Id = 8, Name = "Lasagna", PrepTime = 30, Complexity = 2, CookingApparatus = "oven"},
            new Dish { Id = 9, Name = "Burger", PrepTime = 15, Complexity = 1, CookingApparatus = "oven"},
            new Dish { Id = 10, Name = "Gyros", PrepTime = 15, Complexity = 1, CookingApparatus = null}
        };
    }
}
