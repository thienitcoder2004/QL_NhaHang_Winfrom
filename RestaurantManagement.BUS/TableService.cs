using RestaurantManagement.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RestaurantManagement.BUS
{
    public class TableService
    {
        private readonly RestaurantManagementDBContext context = new RestaurantManagementDBContext();
        public List<Table> GetAll()
        {
            return context.Tables.ToList();
        }

        public void Update(Table tables)
        {
            context.Tables.AddOrUpdate(tables);
            context.SaveChanges();
        }
        public Table FindByMaBan(string maban)
        {
            return context.Tables.FirstOrDefault(t=>t.MaBan == maban);
        }
        public Table FindByMaDH(string madh)
        {
            return context.Tables.FirstOrDefault(t => t.MaDH == madh);
        }
        public List<Table> FindAllMaDH(string madh)
        {
            return context.Tables.Where(context=>context.MaDH == madh).ToList();
        }
    }
}
