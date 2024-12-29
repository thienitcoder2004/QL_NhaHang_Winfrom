using RestaurantManagement.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManagement.BUS
{
    public class MenuService
    {
        public List<Menu> GetAll()
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            return context.Menus.ToList();
        }

        public Menu FindById(string id)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            return context.Menus.FirstOrDefault(p => p.MaMA == id);
        }

        public void InsertUpdate(Menu menus)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            context.Menus.Add(menus);
            context.SaveChanges();
        }

        public void DeleteUpdate(Menu menus)
        {
            RestaurantManagementDBContext context = new RestaurantManagementDBContext();
            context.Menus.Remove(menus);
            context.SaveChanges();
        }
    }
}
