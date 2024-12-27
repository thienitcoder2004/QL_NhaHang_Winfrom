using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Entities
{
    public class Revenue
    {
        [Key]
        [Column(Order = 0)]
        public DateTime NgayTD { get; set; }

        public decimal TongDoanhThu { get; set; }

        public int SLDH { get; set; }
    }
}
