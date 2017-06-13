using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShopParsing.Controllers
{
    public class HomeController : Controller
    {
        private string BaseAddress = ConfigurationManager.AppSettings["BaseAddress"];   //базовый адресс сайта BGP
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
            doc.Load(wc.OpenRead(BaseAddress));

            doc.DocumentNode.Descendants("body");

            return doc.DocumentNode.OuterHtml;
        }
    }
}