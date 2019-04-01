﻿using Common.Models;
using Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiService.Controllers
{
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        protected OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
        
        [Route("GetOrders")]
        public List<OrderShowModel> GetOrders(bool State,bool Check)
        {
            return  _orderService.GetOrdersByStateAndChecked(State,Check);
        }        

        [Route("GetOrderByChecked")]
        public async Task<IHttpActionResult> GetOrderByChecked(bool check)
        {
            try
            {
                var orderList = await _orderService.GetOrderByChecked(check);
                return Ok(orderList);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("CancelOrder")]
        public async Task<IHttpActionResult> CancelOrder(int orderId)
        {
            try
            {
                await _orderService.CancelOrder(orderId);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
