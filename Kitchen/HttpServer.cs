using Kitchen.KitchenStuff;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kitchen
{

    class HttpServer
    {
        public HttpListener listener;
        public string url = "http://localhost:8000/";
        public int requestCount = 0;
        
        public Kitchen kitchen = new Kitchen();
        
        public void Run()
        {
        kitchen.Cooks = new List<Cook>() { new Cook(1, CookRank.ExecutiveChef, 2,
                            "Gordon Ramsay", "This pizza is so disgusting, if you take it to Italy you'll get arrested.", kitchen) };

        listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine("Listening for connections on {0}", url);

            
            Task listenTask = HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();

           
            listener.Close();
        }

        public void RequestInfo(HttpListenerRequest req)
        {
            
            Console.WriteLine("Request #: {0}", ++requestCount);

            Console.WriteLine("Endpoint:" + req.LocalEndPoint);
            Console.WriteLine("Method: " + req.HttpMethod);
            Console.WriteLine("Payload: ");
           
        }

        public async Task HandleIncomingConnections()
        {
            bool runServer = true;

            
            while (runServer)
            {
                
                HttpListenerContext ctx = await listener.GetContextAsync();

                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                RequestInfo(req);

                
                if (req.HttpMethod == "POST")
                {

                    using var body = req.InputStream;
                    var encoding = req.ContentEncoding;
                    
                    using (var reader = new StreamReader(body, encoding))
                    {
                        string s = reader.ReadToEnd();
                        Console.WriteLine(s + "\n\n");
                        
                        Order order = JsonConvert.DeserializeObject<Order>(s);
                        OrderList.orders.Add(order);

                        kitchen.StartWork(order);
                        

                    }
                  
                }
                   

                byte[] data = Encoding.UTF8.GetBytes("Order received from DiningHall!");
                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;

                
                await resp.OutputStream.WriteAsync(data, 0, data.Length);
                resp.Close();
            }
        }

    }
}