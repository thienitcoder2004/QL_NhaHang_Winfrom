using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Entities
{
    public class OrderItem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MaDH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MaMA { get; set; }

        public int SL { get; set; }

        public decimal ThanhTien { get; set; }

        [ForeignKey("MaDH")]
        public virtual Order Order { get; set; }

        [ForeignKey("MaMA")]
        public virtual Menu Menu { get; set; }
    }
}
