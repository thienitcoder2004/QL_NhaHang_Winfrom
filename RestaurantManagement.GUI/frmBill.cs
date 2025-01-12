using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using RestaurantManagement.BUS;
using RestaurantManagement.DAL;
using RestaurantManagement.DAL.Entities;
using RestaurantManagement.GUI.Employee;

namespace RestaurantManagement.GUI
{
    public partial class frmBill : Form
    {
        private readonly MenuService menuService = new MenuService();
        private readonly OrderItemService orderItemService = new OrderItemService();
        private readonly TableService tableService = new TableService();
        private readonly PaymentService paymentService = new PaymentService();
        public string madh;
        public string manv;
        public frmBill()
        {
            InitializeComponent();
        }
        private void frmBill_Load(object sender, EventArgs e)
        {
            // Lấy danh sách món ăn trong đơn hàng
            var orderItem = orderItemService.FindByMaDH(madh);
            List<BillReport> billReport = new List<BillReport>();
            decimal Total = 0;

            foreach (var item in orderItem)
            {
                BillReport tmp = new BillReport
                {
                    TenMA = item.Menu.TenMA,
                    SL = item.SL,
                    Gia = item.Menu.Gia,
                    ThanhTien = item.ThanhTien
                };
                billReport.Add(tmp);
                Total += item.ThanhTien; // Tính tổng tiền
            }
            var table = tableService.FindByMaDH(madh);

            var tableUpdate = tableService.FindAllMaDH(madh);
            foreach (var item in tableUpdate)
            {
                item.TrangThai = "Trống";
                item.MaDH = null;
                item.SoChoNgoi = item.SoChoNgoi;
                tableService.Update(item);
            }

            var baseMaHD = $"HD{madh.Substring(2)}"; // Cơ sở mã hóa đơn
            var currentMaHD = baseMaHD;
            int counter = 1;

            // Kiểm tra và tạo mã hóa đơn mới nếu cần
            while (paymentService.GetAll().Any(p => p.MaHD == currentMaHD))
            {
                currentMaHD = $"{baseMaHD}-{counter}"; // Tạo mã mới với hậu tố số
                counter++;
            }

            var pay = new DAL.Entities.Payment
            {
                MaDH = madh,
                SoTien = Total,
                NgayTT = DateTime.Now,
                MaHD = currentMaHD, // Sử dụng mã đã kiểm tra và đảm bảo không trùng
                MaNV = manv
            };

            paymentService.Insert(pay);

            InformationReport informationReport = new InformationReport
            {
                MaDH = madh,
                TongTien = Total * (decimal)1.1, // Tổng tiền đã tính ở trên
                NgayTT = DateTime.Now // Lấy thời gian hiện tại
            };

            // Thiết lập đường dẫn báo cáo
            reportViewer1.LocalReport.ReportPath = "rptBill.rdlc";

            // Xóa dữ liệu cũ (nếu có) và thêm dữ liệu mới
            reportViewer1.LocalReport.DataSources.Clear();

            // Thiết lập các nguồn dữ liệu cho báo cáo
            var source1 = new ReportDataSource("BillDataSet", billReport); // Dataset cho chi tiết hóa đơn
            //var source2 = new ReportDataSource("InformationReport", informationReport); // Dataset cho thông tin hóa đơn
            var source2 = new ReportDataSource("InformationDataSet", new List<InformationReport> { informationReport });

            reportViewer1.LocalReport.DataSources.Add(source1);
            reportViewer1.LocalReport.DataSources.Add(source2);

            // Làm mới báo cáo
            this.reportViewer1.RefreshReport();
        }
    }
}
