using RestaurantManagement.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RestaurantManagement.BUS
{
    public class MenuService
    {
        private readonly RestaurantManagementDBContext context = new RestaurantManagementDBContext();
        public List<Menu> GetAll()
        {
            return context.Menus.ToList();
        }

        public void InsertUpdate(Menu menus)
        {
            context.Menus.AddOrUpdate(menus);
            context.SaveChanges();
        }

        public void Delete(string mama)
        {
            var menu = context.Menus.FirstOrDefault(s => s.MaMA == mama);
            if (menu != null)
            {
                context.Menus.Remove(menu);
                context.SaveChanges();
            }
        }
        public Menu FindByID(string mama)
        {
            return context.Menus.FirstOrDefault(m => m.MaMA.Equals(mama));
        }
        public Menu FindByName(string mama)
        {
            return context.Menus.FirstOrDefault(m=>m.TenMA.Equals(mama));
        }
    }
}
