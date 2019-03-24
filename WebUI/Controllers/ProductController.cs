using Common.Domains;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            var response = await MvcApplication.httpClient.GetAsync("api/Product/GetProductDetails?id=" + id);
            if(response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadAsAsync<ProductShowModel>();
                return View(product);
            }

            return View();
        }
    }
}