using RestaurantManagement.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RestaurantManagement.BUS
{
    public class OrderService
    {
        private readonly RestaurantManagementDBContext context = new RestaurantManagementDBContext();
        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public void InsertUpdate(Order orders)
        {
            context.Orders.AddOrUpdate(orders);
            context.SaveChanges();
        }
        public Order FindByMaDH(string maDH)
        {
            return context.Orders.FirstOrDefault(o => o.MaDH == maDH);
        }
    }
}
