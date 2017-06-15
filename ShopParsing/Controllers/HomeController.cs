using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ShopParsing.Controllers
{
    public class HomeController : Controller
    {
        private string BaseAddress = ConfigurationManager.AppSettings["BaseAddress"];   //базовый адресс сайта
        private HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        private WebClient wc = new WebClient();

        public ActionResult Index()
        {
            return Content(GetContent());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //получение содержимого страницы с сайта BGP по ссылке
        private string GetContent()
        {
            int i = 0, j = 0;
            doc.Load(wc.OpenRead(BaseAddress), Encoding.UTF8);

            foreach (var divNode in doc.DocumentNode.Descendants("div").Where(d => d.Attributes["class"] != null && d.Attributes["class"].Value == "products-block"))
            {
                foreach (var productsNode in doc.DocumentNode.Descendants("div").Where(d => d.Attributes["class"] != null && d.Attributes["class"].Value == "product-items"))
                {
                    j++;
                }
                i++;
            }

               // var b = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Count > 0 && d.Attributes.Count < 2);
            // doc.DocumentNode.Descendants("body");
            return doc.DocumentNode.OuterHtml;
        }
    }
}