using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WillApprove()
        {

            return View();
        }

        public ActionResult Approved()
        {
            //check=true
            return View();
        }


        //public async Task<ActionResult> VerifyOrder(int orderId)
        //{

        //    var response = await MvcApplication.httpClient.GetAsync("api/Order/...");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var order = await response.Content.ReadAsAsync<OrderShowModel>();
        //        return View(order);
        //    }

        //    return View();

        //}


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


        //public async Task<ActionResult> Approved(bool check=true)
        //{

        //    var response = await MvcApplication.httpClient.GetAsync("api/Order/...");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var order = await response.Content.ReadAsAsync<OrderShowModel>();
        //        return View(order);
        //    }

        //    return View();

        //}


        //public async Task<ActionResult> WillApprove(bool check=false)
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