using RestaurantManagement.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManagement.BUS
{
    public class TableService
    {
        public List<Table> GetAll()
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            return context.Tables.ToList();
        }

        public Table FindById(string id)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            return context.Tables.FirstOrDefault(p => p.MaBan == id);
        }

        public void InsertUpdate(Table tables)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            context.Tables.Add(tables);
            context.SaveChanges();
        }

        public void DeleteUpdate(Table tables)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            context.Tables.Remove(tables);
            context.SaveChanges();
        }
    }
}
