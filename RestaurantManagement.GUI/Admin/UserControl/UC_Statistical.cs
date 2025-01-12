using RestaurantManagement.BUS;
using RestaurantManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RestaurantManagement.GUI
{
    public partial class UC_Statistical : UserControl
    {
        private readonly PaymentService paymentService = new PaymentService();
        public UC_Statistical()
        {
            InitializeComponent();
        }

        private void UC_Statistical_Load(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ Payment thông qua PaymentService
            var payments = paymentService.GetAll();

            // Tính toán doanh thu
            var revenueData = payments
                .GroupBy(p => p.NgayTT.Date)
                .Select(g => new Revenue
                {
                    NgayTD = g.Key,                 // Ngày thanh toán
                    SLDH = g.Count(),            // Số lượng hóa đơn
                    TongDoanhThu = g.Sum(p => p.SoTien) // Tổng tiền thanh toán
                })
                .OrderBy(r => r.NgayTD) // Sắp xếp theo ngày tăng dần
            .ToList();


            // Gọi hàm BindChart để hiển thị dữ liệu
            BindChart(revenueData);
        }

        private void BindChart(List<Revenue> doanhThuData)
        {
            // Xóa dữ liệu cũ nếu có
            chartDoanhThu.Series.Clear();

            // Tạo Series cho biểu đồ đường
            Series series = new Series("Tổng Doanh Thu");
            series.ChartType = SeriesChartType.Line; // Biểu đồ đường
            series.BorderWidth = 2; // Độ dày của đường

            // Gán dữ liệu vào Series
            foreach (var item in doanhThuData)
            {
                series.Points.AddXY(item.NgayTD.ToShortDateString(), item.TongDoanhThu);
            }

            // Thêm Series vào Chart
            chartDoanhThu.Series.Add(series);

            // Tùy chỉnh trục X và Y
            chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Tổng Doanh Thu";
            chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
            chartDoanhThu.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0; // Ẩn lưới trục X
            chartDoanhThu.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot; // Lưới trục Y
        }

        private void chartDoanhThu_Click(object sender, EventArgs e)
        {

        }
    }
}
