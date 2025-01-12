using RestaurantManagement.BUS;
using RestaurantManagement.DAL.Entities;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantManagement.GUI.Employee
{
    public partial class UC_Seats : UserControl
    {
        private readonly TableService tableService = new TableService();
        private readonly ReservationService reservationService = new ReservationService();
        private readonly OrderService orderService = new OrderService();
        public UC_Seats()
        {
            InitializeComponent();
        }
        private void UC_Seats_Load(object sender, EventArgs e)
        {
            GenerateTable();
            Brind();
        }

        private void Brind()
        {
            var listReservation = reservationService.GetAll();
            dgvKH.Rows.Clear();
            foreach (var item in listReservation)
            {
                if (item.SoNguoi <= 0)
                {
                    continue;
                }
                int index = dgvKH.Rows.Add();
                dgvKH.Rows[index].Cells[0].Value = item.MaKH;
                dgvKH.Rows[index].Cells[1].Value = item.Customer.TenKH;
                dgvKH.Rows[index].Cells[2].Value = item.SoNguoi;
                dgvKH.Rows[index].Cells[3].Value = item.GhiChu;
            }
        }
        private void AddToCart(DAL.Entities.Table table)
        {
            //Sự kiện ở đây với table là xem thông tin bàn
            if (table.TrangThai == "Đang sử dụng")
            {
                MessageBox.Show("Bàn đang được sử dụng");
            }
            else if (table.TrangThai == "Đã đặt")
            {
                MessageBox.Show("Bàn đã được đặt");
            }
            else
            {
                // Lấy dòng được chọn
                var selectedRow = dgvKH.SelectedRows[0];

                if (!selectedRow.IsNewRow)
                {

                    // Lấy thông tin từ dòng
                    var item = reservationService.FindByMaKH(selectedRow.Cells[0].Value.ToString())[0];

                    int a = (int)table.SoChoNgoi - (int)item.SoNguoi;
                    var reservation = new DAL.Entities.Reservation();
                    if ((int)item.SoNguoi == 0)
                    {
                        MessageBox.Show("Số lượng người đã vô bàn");
                        return;
                    }
                    else
                    {

                        if (reservationService.FindByMaDB(item.MaDB).Count > 0)
                        {
                            reservation = reservationService.FindByMaDB(item.MaDB)[0];
                        }

                        reservation.MaDB = item.MaDB;
                        int sl = (int)item.SoNguoi - (int)table.SoChoNgoi;
                        if (sl < 0) { sl = 0; }
                        reservation.SoNguoi = sl;
                        reservationService.InsertUpdate(reservation);
                    }

                    Table tableUpdate = new Table
                    {
                        MaBan = table.MaBan,
                        TrangThai = "Đã đặt",
                        SoChoNgoi = table.SoChoNgoi,
                        MaDH = $"DH{item.MaDB.Substring(2)}"
                    };
                    var madh = $"DH{item.MaDB.Substring(2)}";
                    var orderUpdate = orderService.FindByMaDH(madh) ?? new DAL.Entities.Order();
                    if (orderUpdate.MaDH != madh)
                    {
                        orderUpdate.MaDH = madh;
                        orderUpdate.MaDB = item.MaDB;
                        orderUpdate.NgayDH = DateTime.Now;
                        orderService.InsertUpdate(orderUpdate);
                    }

                    tableService.Update(tableUpdate);
                    GenerateTable();
                    Brind();
                }
                else
                {
                    var order = orderService.GetAll();
                    // Lấy số lượng bản ghi hiện có trong Orders
                    int count = order.Count();

                    // Sinh mã MaDH mới, ví dụ: DH001, DH002, ...
                    var madh = $"DH{(count + 1).ToString("D3")}";

                    Table tableUpdate = new Table
                    {
                        MaBan = table.MaBan,
                        TrangThai = "Đã đặt",
                        SoChoNgoi = table.SoChoNgoi,
                        MaDH = madh
                    };
                    Order orderUpdate = new Order
                    {
                        MaDH = madh,
                        MaDB = null,
                        NgayDH = DateTime.Now,
                    };

                    orderService.InsertUpdate(orderUpdate);
                    tableService.Update(tableUpdate);
                    GenerateTable();
                    Brind();
                }
            }
        }

        private void GenerateTable()
        {
            // Xóa toàn bộ control trước đó trong FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();
            var filteredTables = tableService.GetAll();


            var sortedTables = filteredTables.OrderBy(t => int.Parse(t.MaBan.Substring(1))).ToList();

            foreach (DAL.Entities.Table table in sortedTables)
            {
                // Tạo panel cho mỗi món ăn
                System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel
                {
                    Size = new Size(120, 83),
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                };


                // Thêm sl
                Label slLabel = new Label
                {
                    Text = table.SoChoNgoi.ToString(),
                    Location = new Point(48, 50),
                    Font = new Font("Arial", 15, FontStyle.Regular),
                };

                // Thêm nút "Thêm"
                System.Windows.Forms.Button addButton = new System.Windows.Forms.Button
                {
                    Text = $"Table {table.MaBan.Substring(1)}",
                    Font = new Font("Arial", 15, FontStyle.Bold),
                    Size = new Size(120, 83),
                    Location = new Point(0, 0)
                };

                if (table.TrangThai == "Đang sử dụng")
                {
                    addButton.BackColor = Color.Red;
                    slLabel.BackColor = Color.Red;
                }
                else if (table.TrangThai == "Đã đặt")
                {
                    addButton.BackColor = Color.FromArgb(255, 255, 128);
                    slLabel.BackColor = Color.FromArgb(255, 255, 128);
                }
                else
                {
                    addButton.BackColor = Color.LightGreen;
                    slLabel.BackColor = Color.LightGreen;
                }

                // Gắn sự kiện Click cho nút
                addButton.Click += (s, e) =>
                {
                    AddToCart(table); // Gọi phương thức thêm món vào giỏ hàng
                };

                panel.Controls.Add(slLabel);
                panel.Controls.Add(addButton);

                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
