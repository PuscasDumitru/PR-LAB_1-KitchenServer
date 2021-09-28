using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.KitchenStuff;

namespace Kitchen
{
    class Kitchen
    {
        public List<Cook> Cooks { get; set; }
        public List<CookingApparatus> Apparatuses { get; set; }
        
        public void StartWork(Order order)
        {
            foreach (var cook in Cooks)
            {
                cook.Work(order); // just for test
            }
        }

    }
}
