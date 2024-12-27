using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Entities
{
    public class Reservation
    {
        [Key]
        [StringLength(5)]
        public string MaDB { get; set; }

        public DateTime NgayDat { get; set; }

        public DateTime NgayDen { get; set; }

        public int SoNguoi { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [ForeignKey("Customer")]
        [StringLength(5)]
        public string MaKH { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
