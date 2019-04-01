using Common.Domains;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
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

            var response = await MvcApplication.httpClient.GetAsync("api/Product/GetDataForSlider?count=12");
            if (response.IsSuccessStatusCode)
            {
                List<ProductShowModel> jResult = response.Content.ReadAsAsync<List<ProductShowModel>>().Result;
                return View(jResult);
            }

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPopup()
        {
            return PartialView("_LoginPopUp");
        }
    }
}