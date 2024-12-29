using RestaurantManagement.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManagement.BUS
{
    public class OrderService
    {
        public List<Order> GetAll()
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            return context.Orders.ToList();
        }

        public Order FindById(string id)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            return context.Orders.FirstOrDefault(p => p.MaDB == id);
        }

        public void InsertUpdate(Order orders)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            context.Orders.Add(orders);
            context.SaveChanges();
        }

        public void DeleteUpdate(Order orders)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            context.Orders.Remove(orders);
            context.SaveChanges();
        }
    }
}
