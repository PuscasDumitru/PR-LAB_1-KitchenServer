using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kitchen.KitchenStuff
{
    class Order
    {
        public Guid Id { get; set; }
        public int WaiterId { get; set; }
        public int[] Items { get; set; }
        public int Priority { get; set; }
        public double MaxWait { get; set; }
        public long PickUpTime { get; set; }
        public int TableId { get; set; }

    }
}
