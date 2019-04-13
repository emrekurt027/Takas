using Common.Domains;
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
    public class ProductController : Controller
    {
        // GET: Product
        public async Task<ActionResult> Index()
        {
            var response = await MvcApplication.httpClient.GetAsync("api/Product/GetData");
            if (response.IsSuccessStatusCode)
            {
                List<ProductShowModel> jResult = response.Content.ReadAsAsync<List<ProductShowModel>>().Result;

                return View(jResult);
            }

            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            var response = await MvcApplication.httpClient.GetAsync("api/Product/GetDetails?id=" + id );
            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadAsAsync<ProductDetailModel>();
                return View(product);
            }

            return View();
        }


        [HttpGet]
        public async Task<ActionResult> SearchProduct(string term)
        {
            var response = await MvcApplication.httpClient.GetAsync("api/Product/Search?term=" + term);
            if (response.IsSuccessStatusCode)
            {
                //List<ProductShowModel> products = await response.Content.ReadAsAsync<List<ProductShowModel>>();
                var products = await response.Content.ReadAsStringAsync();
                var jj = Json(products);

                return Json(products, JsonRequestBehavior.AllowGet);
            }

            return Json("");
        }


        //[AuthFilter(Roles ="User")]
        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> AddNew(ProductAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.UserId = Session["userId"].ToString();
            var response = await MvcApplication.httpClient.PostAsJsonAsync("api/Product/AddNewData", model);
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}