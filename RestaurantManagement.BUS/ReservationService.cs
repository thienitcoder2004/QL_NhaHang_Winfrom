using RestaurantManagement.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RestaurantManagement.BUS
{
    public class ReservationService
    {
        private readonly RestaurantManagementDBContext context = new RestaurantManagementDBContext();
        public List<Reservation> GetAll()
        {
            return context.Reservations.ToList();
        }

        public void InsertUpdate(Reservation reservation)
        {
            context.Reservations.AddOrUpdate(reservation);
            context.SaveChanges();
        }

        public void Delete(string madb)
        {
            var reservation = context.Reservations.FirstOrDefault(r => r.MaDB == madb);
            if (reservation != null)
            {
                context.Reservations.Remove(reservation);
                context.SaveChanges();
            }
        }
        public List<Reservation> FindByMaDB(string madb)
        {
            return context.Reservations.Where(r => r.MaDB == madb).ToList();
        }
        public List<Reservation> FindByMaKH(string makh)
        {
            return context.Reservations.Where(r=>r.MaKH == makh).ToList();
        }
    }
}
