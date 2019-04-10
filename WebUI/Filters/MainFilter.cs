using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Filters
{
    public class MainFilter : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["userId"] == null)
            {
                var token = filterContext.HttpContext.Request.Cookies["accessToken"]?.Value.ToString();
                if (!String.IsNullOrEmpty(token))
                {
                    MvcApplication.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var result = MvcApplication.httpClient.GetAsync("api/Account/UserInfo").Result;
                    var contents = result.Content.ReadAsStringAsync();
                    JObject jdata = JObject.Parse(contents.Result);
                    if (jdata.ContainsKey("error"))
                    {
                        return;
                    }

                    filterContext.HttpContext.Session["userId"] = (string)jdata["UserId"];
                    filterContext.HttpContext.Session["userName"] = (string)jdata["UserName"];

                }
            }
        }
    }
}