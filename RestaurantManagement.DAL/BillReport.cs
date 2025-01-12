using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.DAL
{
    public class BillReport
    {
        [StringLength(200)]
        public string TenMA { get; set; }

        public int SL { get; set; }

        public decimal Gia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
