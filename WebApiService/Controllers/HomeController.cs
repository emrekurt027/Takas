using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiService.Controllers
{
    public class HomeController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            Services.GoodReadsService.GetBooks getBooks = new Services.GoodReadsService.GetBooks();
            await getBooks.IndexAsync("scare");

            return View();
        }
    }
}
