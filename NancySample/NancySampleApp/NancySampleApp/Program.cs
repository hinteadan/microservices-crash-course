using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancySampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var httpServer = new NancyHost(new Uri("http://localhost:9999/")))
            {
                httpServer.Start();
                Console.WriteLine("Running server @ http://localhost:9999/");
                Console.ReadLine();
            }
        }
    }
}
