using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpMicroserviceOmega
{
    class Program
    {
        private static readonly Uri url = new Uri("http://localhost:9993");
        static void Main(string[] args)
        {
            using (var host = new NancyHost(url))
            {
                host.Start();
                Console.WriteLine($"Running Omega Microservice on {url} ");
                Console.ReadLine();
            }
        }
    }
}
