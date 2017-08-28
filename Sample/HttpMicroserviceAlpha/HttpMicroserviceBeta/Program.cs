using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpMicroserviceBeta
{
    class Program
    {
        private static readonly Uri url = new Uri("http://localhost:9992");

        static void Main(string[] args)
        {
            using (var host = new NancyHost(url))
            {
                host.Start();
                Console.WriteLine($"Running Beta Microservice on {url} ");
                Task.Run(() =>
                {
                    while (true)
                    {
                        using (var http = new HttpClient())
                        {
                            Console.WriteLine($"Time on Microservice Alpha is {http.GetStringAsync("http://localhost:9991/time").Result}");
                        }
                        Thread.Sleep(2000);
                    }
                });
                Console.ReadLine();
            }
        }
    }
}
