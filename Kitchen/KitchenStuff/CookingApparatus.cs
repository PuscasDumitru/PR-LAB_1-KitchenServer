using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.KitchenStuff
{
    class CookingApparatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isFree = true;

        public CookingApparatus(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
