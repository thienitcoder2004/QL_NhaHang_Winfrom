using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.DAL.Entities;

namespace RestaurantManagement.BUS
{
    public class OrderItemService
    {
        private readonly RestaurantManagementDBContext context = new RestaurantManagementDBContext();
        public List<OrderItem> GetAll()
        {
            return context.OrderItems.ToList();
        }

        public void InsertUpdate(OrderItem orderItem)
        {
            context.OrderItems.AddOrUpdate(orderItem);
            context.SaveChanges();
        }
        public void Delete(string madh, string mama)
        {
            var orderitem = context.OrderItems.FirstOrDefault(o => o.MaDH == madh && o.MaMA == mama);
            if (orderitem != null)
            {
                context.OrderItems.Remove(orderitem);
                context.SaveChanges();
            }
        }
        public List<OrderItem> FindByMaDH(string madh)
        {
            return context.OrderItems.Where(o=>o.MaDH== madh).ToList();
        }

        public OrderItem FindByMaDHMaMA(string madh, string mama)
        {
            return context.OrderItems.FirstOrDefault(m => m.MaDH == madh && m.MaMA == mama);
        }
    }
}
