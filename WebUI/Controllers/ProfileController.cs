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

        [Route("ReceviedBooks")]
        public ActionResult ReceivedBooks()
        {
            return View();
        }
        [Route("SendBooks")]
        public ActionResult SendBooks()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:2252");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            response = client.GetAsync("api/Product/GetDataById?id=1").Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                OrderShowModel jResult = response.Content.ReadAsAsync<OrderShowModel>().Result;
                return View(jResult);
            }

            return View();
        }
        [Route("NotApprovedOrders")]
        public ActionResult NotApprovedOrders()
        {
            return View();
        }        
    }
}