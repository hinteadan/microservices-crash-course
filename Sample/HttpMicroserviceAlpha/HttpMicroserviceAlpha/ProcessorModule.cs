using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpMicroserviceAlpha
{
    public class ProcessorModule : NancyModule
    {
        public ProcessorModule()
            : base("")
        {
            Post["/start", true] = async (_, c) =>
            {

                using (var http = new HttpClient())
                {
                    await http.PostAsync("http://localhost:9991/process", new StringContent("1", Encoding.UTF8, "text/plain"));
                }

                return HttpStatusCode.OK;
            };

            Get["/time"] = _ => Response.AsText(DateTime.Now.ToString());

            Post["/process", true] = async (_, c) =>
            {
                Console.WriteLine($"Processing @ {DateTime.Now}");

                var count = int.Parse(Request.Body.AsString());

                Console.WriteLine($"Received value: {count}");

                Thread.Sleep(1000);

                using (var http = new HttpClient())
                {
                    await http.PostAsync("http://localhost:9992/process", new StringContent((count + 1).ToString(), Encoding.UTF8, "text/plain"));
                }

                Console.WriteLine($"Processed @ {DateTime.Now}");

                return HttpStatusCode.OK;
            };
        }
    }
}
