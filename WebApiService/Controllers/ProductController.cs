using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Common.Domains;
using Data;
using Services;

namespace WebApiService.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        BaseService<Product> _productService;
        public ProductController(BaseService<Product> productService)
        {
            _productService = productService;
        }

        [Route("GetData")]
        public async Task<List<Product>> GetData()
        {            
           return await _productService.GetAll();
        }

        [Route("GetDataById")]
        public async Task<IHttpActionResult> GetDataById(int id)
        {
            var product = await _productService.GetById(id);
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [Route("PostNewData")]
        public async Task<IHttpActionResult> PostNewData(Product product)
        {
            try
            {
                await _productService.Add(product);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("DeleteData")]
        public async Task<IHttpActionResult> DeleteData(Product product)
        {
            try
            {
                await _productService.Delete(product);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("UpdateData")]
        public async Task<IHttpActionResult> UpdateData(Product product)
        {
            try
            {
                await _productService.Update(product);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}
