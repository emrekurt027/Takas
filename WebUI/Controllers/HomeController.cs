using Common.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri("http://localhost:2252");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response;
            //response = client.GetAsync("api/Product/GetData").Result;

            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //   List<Product> jResult = response.Content.ReadAsAsync<List<Product>>().Result;
            //    return View(jResult);
            //}

            return View();
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
        [HttpPost]
        public ActionResult LoginPopup()
        {
            return PartialView("_LoginPopUp");
        }
    }
}