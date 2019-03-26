using Common.Models;
using Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public  List<OrderShowModel> GetOrders(bool State,bool Check)
        {
            return  _orderService.GetOrdersByStateAndChecked(State,Check);
        }        
    }
}
