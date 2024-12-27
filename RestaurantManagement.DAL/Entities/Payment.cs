using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Entities
{
    public class Payment
    {
        [Key]
        [StringLength(5)]
        public string MaHD { get; set; }

        public decimal SoTien { get; set; }

        public DateTime NgayTT { get; set; }

        [StringLength(50)]
        public string PTThanhToan { get; set; }

        [ForeignKey("Order")]
        [StringLength(5)]
        public string MaDH { set; get; }
        public virtual Order Order { get; set; }

        [ForeignKey("Employee")]
        [StringLength(5)]
        public string MaNV { set; get; }
        public virtual Employee Employee { get; set; }
    }
}
