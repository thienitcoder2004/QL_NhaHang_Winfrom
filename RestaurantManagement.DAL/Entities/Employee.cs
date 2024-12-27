using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Entities
{
    public class Employee
    {
        [Key]
        [StringLength(5)]
        public string MaNV { get; set; }

        [StringLength(200)]
        public string TenNV { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        public decimal Luong { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
