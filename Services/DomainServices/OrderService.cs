using Common.Domains;
using Common.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class OrderService : BaseService<Order>
    {

        public List<Order> GetOrderByState(bool state)
        {
            using (context = new MyDbContext())
            {
                return context.Set<Order>().Where(p => p.State == state).ToList();
            }
        }

        /// <summary>
        /// Sipariş Takip
        /// </summary>
        /// <param name="State"></param>
        /// State parametresi depomuza giren(true) / cıkan(false) ürünleri temsil etmektedir.
        /// <param name="CheckedAdmin"></param>
        /// CheckedAdmin parametresi Admin tarafından onaylandı(true)/ onaylanmadı(false) siparişleri temsil etmektedir.
        /// <returns></returns>
        public List<OrderShowModel> GetOrdersByStateAndChecked(bool State,bool CheckedAdmin)
        {
            using (context = new MyDbContext())
            {
                var a = context.Orders.Where(p => p.Id == 1).Join(context.Products, p => p.ProductId, product => product.Id, (p, product) => new
                {
                     p.Date,
                    product.ImageUrl,
                     p.Id,
                     product.Name,
                     p.State,
                    context.Users.Where(user => user.Id ==p.UserId).FirstOrDefault().UserName
                }).FirstOrDefault();

                List<OrderShowModel> orders = context.Orders.Where(p => p.State == State && p.CheckByAdmin == CheckedAdmin).Select(order => new OrderShowModel
                {
                    State = order.State,
                    ProductName = order.Product.Name,
                    Date = order.Date,
                    ImageUrl = order.Product.ImageUrl,
                    OrderID = order.Id,
                    UserName = context.Users.Where(user => user.Id == order.UserId).FirstOrDefault().UserName
                }).ToList();
                return orders;
            }
        }      

    }
}
