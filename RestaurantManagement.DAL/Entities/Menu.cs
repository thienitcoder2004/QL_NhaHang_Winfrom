using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Entities
{
    public class Menu
    {
        [Key]
        [StringLength(5)]
        public string MaMA { get; set; }

        [StringLength(200)]
        public string TenMA { get; set; }

        public decimal Gia { get; set; }

        [StringLength(50)]
        public string LoaiMA { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
