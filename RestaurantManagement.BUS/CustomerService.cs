using RestaurantManagement.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RestaurantManagement.BUS
{
    public class CustomerService
    {
        private readonly RestaurantManagementDBContext context = new RestaurantManagementDBContext();
        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public void InsertUpdate(Customer customer)
        {
            context.Customers.AddOrUpdate(customer);
            context.SaveChanges();
        }

        public void Delete(string makh)
        {
            var customer = context.Customers.FirstOrDefault(s => s.MaKH == makh);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }
        public Customer FindByMaKH(string makh)
        {
            return context.Customers.FirstOrDefault(c=>c.MaKH == makh);
        }
        public Customer FindByName(string name)
        {
            return context.Customers.FirstOrDefault(c=>c.TenKH.Contains(name));
        }
    }
}
