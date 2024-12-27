using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Entities
{
    public class Table
    {
        [Key]
        [StringLength(5)]
        public string MaBan { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public int SoChoNgoi { get; set; }

        [ForeignKey("Order")]
        [StringLength(5)]
        public string MaDH { get; set; }
        public virtual Order Order { get; set; }
    }
}
