using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Common.Domains;
using Data;

namespace WebApiService.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        [Route("GetData")]
        public List<Product> GetData()
        {            
           return Services.ProductService.GetData();
        }
        [Route("GetDataById")]
        public Product GetDataById(int id)
        {
            return Services.ProductService.GetDataByID(id);
        }
    }
}
