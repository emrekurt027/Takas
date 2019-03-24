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
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(UserLoginModel user)
        {
            ////grant_type=password&username=Alice&password=password123
            ////"grant_type=password&username="+user.UserName+"&password="+user.Password

            //var dict = new Dictionary<string, string>();
            //dict.Add("grant_type", "password");
            //dict.Add("username", user.UserName);
            //dict.Add("password", user.Password);
            //var req = new HttpRequestMessage(HttpMethod.Post, "/Token") { Content = new FormUrlEncodedContent(dict) };
            //var result = await MvcApplication.httpClient.SendAsync(req);
            //if (result.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            return PartialView("_LoginPopUp");
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(UserRegisterModel user)
        {
            var result = await MvcApplication.httpClient.PostAsJsonAsync("/api/Account/Register", user);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}