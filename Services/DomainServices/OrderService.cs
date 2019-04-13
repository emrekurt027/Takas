using Common.Domains;
using Common.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data.Domains;

namespace Services.DomainServices
{
    public class OrderService : BaseService<Order>
    {
        //------------------------------------------------------------------------------------------------------------------
        //Admin İŞLEMLERİ   
        public List<OrderShowModel> GetOrderByChecked(bool check)
        {
            using (context = new MyDbContext())
            {
                List<OrderShowModel> orders = context.Orders.Where(p => p.CheckByAdmin == check).Select(order => new OrderShowModel
                {
                    State = order.State,
                    ProductName = order.Product.Name,
                    Date = order.Date,
                    ProductId=order.ProductId,                    
                    ImageUrl = order.Product.ImageUrl,
                    OrderID = order.Id,
                    UserName = context.Users.Where(user => user.Id == order.UserId).FirstOrDefault().UserName
                }).ToList();

                return orders;
            }
        }
        //Admin tarafından order iptali icin hazırlandı.
        public async Task CancelOrder(int orderId)
        {
            await Delete(orderId);
        }
        // Admin tarafından order onayı
        public async Task VerifyOrder(int orderId)
        {
            using (context = new MyDbContext())
            {
                Order order=context.Set<Order>().Where(p => p.Id == orderId).FirstOrDefault();
                order.CheckByAdmin = true;
                order.Product.Verify=true;
                ApplicationUser user = await context.Users.Where(p => p.Id == order.UserId).FirstAsync();
                if (order.State)
                {
                    user.Credits += 1;
                }
                else { user.Credits -= 1; }
                Order o2 = context.Orders.Where(p=>p.Id==order.Id).FirstOrDefault();
                context.Entry(o2).CurrentValues.SetValues(order);

                context.SaveChanges();
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
        public List<OrderShowModel> GetOrdersByStateAndChecked(bool State, bool CheckedAdmin)
        {
            using (context = new MyDbContext())
            {   
                List<OrderShowModel> orders = context.Orders.Where(p => p.State == State && p.CheckByAdmin == CheckedAdmin).Select(order => new OrderShowModel
                {
                    State = order.State,
                    ProductName = order.Product.Name,
                    Date = order.Date,
                    ImageUrl = order.Product.ImageUrl,
                    OrderID = order.Id,
                    ProductId=order.ProductId,
                    UserName = context.Users.Where(user => user.Id == order.UserId).FirstOrDefault().UserName
                }).ToList();
                return orders;
            }
        }


        //------------------------------------------------------------------------------------------------------------------
        //USER İŞLEMLERİ
        // User icin Satın aldığı siparişleri belirtir.
        public List<OrderShowModel> GetSentOrders(string _UserId)
        {
            using (context = new MyDbContext())
            {
                List<OrderShowModel> orders = context.Orders.Where(p => p.State == true && p.CheckByAdmin == true && p.UserId == _UserId).Select(order => new OrderShowModel
                {
                    State = order.State,
                    ProductName = order.Product.Name,
                    Date = order.Date,
                    ProductId=order.ProductId,
                    ImageUrl = order.Product.ImageUrl,
                    OrderID = order.Id,
                    UserName = context.Users.Where(user => user.Id == order.UserId).FirstOrDefault().UserName
                }).ToList();
                return orders;
            }
        }

        // User icin Siteye Sattığı  siparişleri belirtir.
        public List<OrderShowModel> GetRecievedOrders(string _UserId)
        {
            using (context = new MyDbContext())
            {
                List<OrderShowModel> orders = context.Orders.Where(p => p.State == false && p.CheckByAdmin == true && p.UserId == _UserId).Select(order => new OrderShowModel
                {
                    State = order.State,
                    ProductName = order.Product.Name,
                    Date = order.Date,
                    ImageUrl = order.Product.ImageUrl,
                    OrderID = order.Id,
                    ProductId=order.ProductId,
                    UserName = context.Users.Where(user => user.Id == order.UserId).FirstOrDefault().UserName
                }).ToList();
                return orders;
            }
        }

        // User icin Onaylanmayan alım satım siparişleri belirtir.
        public List<OrderShowModel> GetNotApprovedOrders(string _UserId)
        {
            using (context = new MyDbContext())
            {
                List<OrderShowModel> orders = context.Orders.Where(p => p.CheckByAdmin == true && p.UserId == _UserId).Select(order => new OrderShowModel
                {
                    State = order.State,
                    ProductName = order.Product.Name,
                    Date = order.Date,
                    ImageUrl = order.Product.ImageUrl,
                    OrderID = order.Id,
                    ProductId=order.ProductId,
                    UserName = context.Users.Where(user => user.Id == order.UserId).FirstOrDefault().UserName
                }).ToList();
                return orders;
            }
        }

        //Userin Sipariş iptalini sağlar.
        public void CancelOrder(int orderId,string UserId)
        {
            using (context = new MyDbContext())
            {
                context.Set<Order>().Where(p => p.Id == orderId && p.UserId==UserId).ToList();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
