using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Entities
{
    public class Customer
    {
        [Key]
        [StringLength(5)]
        public string MaKH { get; set; }

        [StringLength(200)]
        public string TenKH { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
