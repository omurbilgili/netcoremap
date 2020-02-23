using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/")]
    [ApiController]
    public class GeometryController : ControllerBase
    {
        public static string logfilePath = @"GeometryLog.txt";
        public static readonly object locker = new object();

        [HttpPost]
        [Route("GenerateGeometry")]
        public ActionResult<Geometry> GenerateGeometry(Models.Type type)
        {

            //Json dosyasından şekil türlerini okuyoruz.
            //İstenirse bu json üzerinden şekil tanımlaması yapılarak yeni şekiller eklenebilir.
            var JsonString = System.IO.File.ReadAllText("ShapeTypes.json");
            JObject Shapes = JObject.Parse(JsonString);
            Random rnd = new Random();
            Geometry gr = new Geometry();
            //Belirlenen tuşlar harici bir tuşa basılırsa rasgele bir şekil gönderelim
            if (String.IsNullOrEmpty(type.type))
            {
                int randomShapeIndex = rnd.Next(0, Shapes["ShapeTypes"].Count());
                gr = new Geometry()
                {
                    fillColor = Shapes["ShapeTypes"][randomShapeIndex]["fillColor"].ToString(),
                    lineColor = Shapes["ShapeTypes"][randomShapeIndex]["lineColor"].ToString(),
                    type = Shapes["ShapeTypes"][randomShapeIndex]["type"].ToString(),
                    geojson = Shapes["ShapeTypes"][randomShapeIndex]["geojson"]
                };
            }
            else if (type.type == "Square")//Eğer kare isteniyorsa kareler arasından rasgele bir şekil gönderelim
            {
                var filteredShapes = Shapes["ShapeTypes"].Where(n => n["type"].Value<string>() == "Square").ToArray();
                int randomShapeIndex = rnd.Next(0, filteredShapes.Count());
                gr = new Geometry()
                {
                    fillColor = filteredShapes[randomShapeIndex]["fillColor"].ToString(),
                    lineColor = filteredShapes[randomShapeIndex]["lineColor"].ToString(),
                    type = filteredShapes[randomShapeIndex]["type"].ToString(),
                    geojson = filteredShapes[randomShapeIndex]["geojson"]
                };

            }
            else if (type.type == "Triangle")//Eğer üçgen isteniyorsa kareler arasından rasgele bir şekil gönderelim
            {
                var filteredShapes = Shapes["ShapeTypes"].Where(n => n["type"].Value<string>() == "Triangle").ToArray();
                int randomShapeIndex = rnd.Next(0, filteredShapes.Count());
                gr = new Geometry()
                {
                    fillColor = filteredShapes[randomShapeIndex]["fillColor"].ToString(),
                    lineColor = filteredShapes[randomShapeIndex]["lineColor"].ToString(),
                    type = filteredShapes[randomShapeIndex]["type"].ToString(),
                    geojson = filteredShapes[randomShapeIndex]["geojson"]
                };

            }
            else if (type.type == "Circle")//Eğer daire isteniyorsa kareler arasından rasgele bir şekil gönderelim
            {
                var filteredShapes = Shapes["ShapeTypes"].Where(n => n["type"].Value<string>() == "Circle").ToArray();
                int randomShapeIndex = rnd.Next(0, filteredShapes.Count());
                gr = new Geometry()
                {
                    fillColor = filteredShapes[randomShapeIndex]["fillColor"].ToString(),
                    lineColor = filteredShapes[randomShapeIndex]["lineColor"].ToString(),
                    type = filteredShapes[randomShapeIndex]["type"].ToString(),
                    geojson = filteredShapes[randomShapeIndex]["geojson"]
                };

            }
            else if (type.type == "Ellipse")//Eğer elips isteniyorsa kareler arasından rasgele bir şekil gönderelim
            {
                var filteredShapes = Shapes["ShapeTypes"].Where(n => n["type"].Value<string>() == "Ellipse").ToArray();
                int randomShapeIndex = rnd.Next(0, filteredShapes.Count());
                gr = new Geometry()
                {
                    fillColor = filteredShapes[randomShapeIndex]["fillColor"].ToString(),
                    lineColor = filteredShapes[randomShapeIndex]["lineColor"].ToString(),
                    type = filteredShapes[randomShapeIndex]["type"].ToString(),
                    geojson = filteredShapes[randomShapeIndex]["geojson"]
                };

            }
            lock (locker)
            {
                System.IO.File.WriteAllText(logfilePath, JsonConvert.SerializeObject(gr));
                Thread.Sleep(1000);
            }
            return gr;
        }
    }
}