using System.Collections.Generic;
using System.Linq;
using RestaurantManagement.DAL.Entities;

namespace RestaurantManagement.BUS
{
    public class RevenueService
    {
        private readonly RestaurantManagementDBContext context = new RestaurantManagementDBContext();
        public List<Revenue> GetAll()
        {
            return context.Revenues.ToList();
        }
    }
}
