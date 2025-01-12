using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
    public class InformationReport
    {
        [StringLength(5)]
        public string MaDH { get; set; }

        [StringLength(10)]
        public string MaBan { get; set; }

        
        public decimal TongTien { get; set; }

     
        public DateTime NgayTT { get; set; }
    }
}
