using RestaurantManagement.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RestaurantManagement.BUS
{
    public class EmployeeService
    {
        private readonly RestaurantManagementDBContext context = new RestaurantManagementDBContext();
        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }
        public void InsertUpdate(Employee employee)
        {
            context.Employees.AddOrUpdate(employee);
            context.SaveChanges();
        }

        public void Delete(string manv)
        {
            var emplyee = context.Employees.FirstOrDefault(s => s.MaNV == manv);
            if (emplyee != null)
            {
                context.Employees.Remove(emplyee);
                context.SaveChanges();
            }
        }

        public Employee FindByID(string manv)
        {
            return context.Employees.FirstOrDefault(e => e.MaNV.Equals(manv));
        }

        public List<Employee> FindByHoTen(string tennv)
        {
            return context.Employees.Where(e => e.TenNV.Contains(tennv)).ToList();
        }
    }
}
