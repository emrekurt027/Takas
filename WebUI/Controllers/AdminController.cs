using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Filters;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        //[AuthFilter(Roles ="Admin")]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Approved()
        {

            var response = await MvcApplication.httpClient.GetAsync("api/Order/GetOrderByChecked?check=true");
            if (response.IsSuccessStatusCode)
            {
                List<OrderShowModel> order = await response.Content.ReadAsAsync<List<OrderShowModel>>();
                return View(order);
            }

            return View();

        }

        [HttpGet]
        public async Task<ActionResult> WillApprove()
        {
            var response = await MvcApplication.httpClient.GetAsync("api/Order/GetOrderByChecked?check=false");
            if (response.IsSuccessStatusCode)
            {
                List<OrderShowModel> order = await response.Content.ReadAsAsync<List<OrderShowModel>>();
                return View(order);
            }
            return View();
        }

        public async Task<ActionResult> VerifyOrder(int id)
        {

            var response = await MvcApplication.httpClient.GetAsync("api/Order/...");
            if (response.IsSuccessStatusCode)
            {
                var order = await response.Content.ReadAsAsync<OrderShowModel>();
                return View(order);
            }

            return View();

        }


        //public async Task<ActionResult> CancelOrder(int orderId)
        //{

        //    var response = await MvcApplication.httpClient.GetAsync("api/Order/...");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var order = await response.Content.ReadAsAsync<OrderShowModel>();
        //        return View(order);
        //    }

        //    return View();

        //}

    }
}