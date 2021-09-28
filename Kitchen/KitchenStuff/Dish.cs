using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.KitchenStuff
{

    class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PrepTime { get; set; }
        public int Complexity { get; set; }
        public string CookingApparatus { get; set; }


    }
}
