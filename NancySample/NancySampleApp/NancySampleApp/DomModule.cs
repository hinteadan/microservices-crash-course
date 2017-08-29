using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancySampleApp
{
    public class DomModule : NancyModule
    {
        public DomModule() : base("/dom")
        {
            var sampleDom = new EtiDomModel
            {
                FullText = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecena porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Sections = new Section[]
                {
                    new Section{
                        Text = "Lorem ipsum dolor sit amet",
                        Reference = new Box{ X=13, Y=12, Width=100, Height=20 },
                    },
                    new Section{
                        Text = "Lorem ipsum dolor sit amet",
                        Reference = new Box{ X=13, Y=12, Width=100, Height=20 },
                    },
                }
            };

            Get["/"] = _ => Response.AsJson(sampleDom);
        }
    }
}
