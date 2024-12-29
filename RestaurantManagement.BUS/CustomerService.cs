using RestaurantManagement.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManagement.BUS
{
    public class CustomerService
    {
        public List<Customer> GetAll()
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            return context.Customers.ToList();
        }

        public Customer FindById(string id)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            return context.Customers.FirstOrDefault(p => p.MaKH == id);
        }

        public void InsertUpdate(Customer customer)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void DeleteUpdate(Customer customer)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
    }
}
