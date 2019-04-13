using Common.Domains;
using Common.Models;
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
    [Route("Profile")]
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult ReceivedBooks()
        {
            return PartialView("_PartialBooks");
        }
        [HttpPost]
        public PartialViewResult SendBooks()
        {
            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri("http://localhost:2252");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response;
            //response = client.GetAsync("api/Product/GetDataById?id=1").Result;

            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    OrderShowModel jResult = response.Content.ReadAsAsync<OrderShowModel>().Result;
            //    return View(jResult);
            //}

            return PartialView("_PartialBooks");
        }
        [HttpPost]
        public PartialViewResult NotApprovedOrders()
        {
            return PartialView("_PartialBooks");
        }

        public ActionResult Settings()
        {
            return View();
        }
    }
}