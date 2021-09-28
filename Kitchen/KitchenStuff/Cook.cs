using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Kitchen.KitchenStuff
{
    enum CookRank
    {
        LineCook,
        Saucier,
        ExecutiveChef
    }
    class Cook
    {
        public int Id { get; set; }
        public CookRank Rank { get; set; }
        public int Proficiency { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }

        private Kitchen kitchen;

        public Cook() { }
        public Cook(int id, CookRank rank, int proficiency, string name, string catchPhrase, Kitchen kitchen)
        {
            Id = id;
            Rank = rank;
            Proficiency = proficiency;
            Name = name;
            CatchPhrase = catchPhrase;
            this.kitchen = kitchen;
        }

        public void SendFinishedOrder(Order order, List<CookingDetails> details)
        {
            string json = JsonConvert.SerializeObject(new
            {
                OrderId = order.Id,
                WaiterId = this.Id,
                order.TableId,
                order.Items,
                order.Priority,
                order.MaxWait,
                DetailsList = details,
                CookingTime = DateTimeOffset.Now.ToUnixTimeSeconds() - order.PickUpTime,
                PickUpTime = order.PickUpTime

            });
            
            Console.WriteLine($"Order {order.Id} from table {order.TableId} has been sent back to the DiningHall!");
            SendOrderHall.SendOrder(json); 
        }
        public void Work(Order order)
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
               
                   
                        var detailsList = new List<CookingDetails>();
                        foreach(var item in order.Items)
                        {
                            detailsList.Add(new CookingDetails(new Random().Next(1, 10), new Random().Next(1, 10))); // just for test, will be updated later
                        }
                       
                        SendFinishedOrder(order, detailsList);
                    
               
            }));

            t.Start();
        }

    }
}
