﻿using System;
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
        ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [Route("GetData")]
        public async Task<List<Product>> GetData()
        {            
           return await _productService.GetAllData();
        }

        [Route("GetDataById")]
        public async Task<IHttpActionResult> GetDataById(int id)
        {
            var product = await _productService.GetDataByID(id);
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /*[Route("AddData")]
        public async Task<IHttpActionResult> AddData(Product product)
        {
            return NotImplementedException;
        }*/
    }
}
