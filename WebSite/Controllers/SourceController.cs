using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WebSite.Controllers
{
    public class Tech
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }


        public static IEnumerable<Tech> GetData()
        {
            yield return new Tech() { Title = "A title", ImagePath = "cus01111.png" };
            yield return new Tech() { Title = "B title", ImagePath = "02.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "03.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "04.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "05.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "06.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "07.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "08.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "09.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "09.jpg" };
            yield return new Tech() { Title = "A title", ImagePath = "cus01111.png" };
            yield return new Tech() { Title = "B title", ImagePath = "02.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "03.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "04.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "05.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "06.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "07.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "08.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "09.jpg" };
            yield return new Tech() { Title = "B title", ImagePath = "09.jpg" };
            yield break;
        }
    }



    public class SourceController : Controller
    {
        // Get: /Source/GetImage?name=i
        // Get image file via the URI from app 
        public ActionResult GetImage(String name)
        {
            System.Threading.Thread.Sleep(1000);
            var dir = Server.MapPath("/Images");
            var path = Path.Combine(dir, name);
            return base.File(path, "image/png");
        }

        // Get:/Source/GetTech
        // Get the JSON data contains images URI.
        public ActionResult GetTech()
        {
            var query = Tech.GetData();
            return Json(query.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
