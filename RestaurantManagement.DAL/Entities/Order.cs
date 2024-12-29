using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Entities
{
    public class Order
    {
        [Key]
        [StringLength(5)]
        public string MaDH { get; set; }

        public DateTime NgayDH { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<Table> Table { get; set; }

        [ForeignKey("Reservation")]
        [StringLength(5)]
        public string MaDB { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
