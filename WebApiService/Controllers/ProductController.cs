using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Common.Domains;
using Common.Models;
using Data;
using Services;
using Services.DomainServices;

namespace WebApiService.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }


        //Tüm ürünleri getirir
        [Route("GetData")]
        public IHttpActionResult GetDataAsync()
        {
            try
            {
                var productList = _productService.GetAllForProductsIndex();
                return Ok(productList);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //verilen sayıda ürünü getirir
        [Route("GetDataForSlider")]
        public IHttpActionResult GetDataForSlider(int count)
        {
            try
            {
                var productSlider = _productService.GetProductsForSlider(count);
                return Ok(productSlider);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //belirtilen idye sahip ürün bilgisini getirir.
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
        //Product nesenesini veri tabanına ekler
        [HttpPost]
        [Route("AddNewData")]
        public async Task<IHttpActionResult> AddNewData(ProductAddModel productModel)
        {
            try
            {
                await _productService.AddNewProduct(productModel);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        //obje olarak verilen ürünü siler
        [HttpPost]
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
        //Product
        [HttpPost]
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


        [Route("GetProductDetails")]
        public async Task<IHttpActionResult> GetProductDetails(int id)
        {
            try
            {
                var productDetail =await _productService.GetProductDetails(id);
                return Ok(productDetail);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}
