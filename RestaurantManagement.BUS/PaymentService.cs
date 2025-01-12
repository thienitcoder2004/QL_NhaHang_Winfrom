using System.Collections.Generic;
using System.Linq;
using RestaurantManagement.DAL.Entities;

namespace RestaurantManagement.BUS
{
    public class PaymentService
    {
        public readonly RestaurantManagementDBContext context = new RestaurantManagementDBContext();
        public List<Payment> GetAll()
        {
            return context.Payments.ToList();
        }
        public void Insert(Payment payment)
        {
            context.Payments.Add(payment);
            context.SaveChanges();
        }
    }
}
