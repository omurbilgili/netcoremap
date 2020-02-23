using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Geometry
    {
        public Newtonsoft.Json.Linq.JToken geojson { get; set; }
        public string type { get; set; }
        public string fillColor { get; set; }
        public string lineColor { get; set; }
    }
}
