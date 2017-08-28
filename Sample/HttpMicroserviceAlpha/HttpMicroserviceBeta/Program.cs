using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                Console.ReadLine();
            }
        }
    }
}
