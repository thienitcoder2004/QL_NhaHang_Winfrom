using RestaurantManagement.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantManagement.GUI.Employee
{
    public partial class UC_TableStatus : UserControl
    {
        private readonly TableService tableService = new TableService();
        private readonly OrderItemService orderItemService = new OrderItemService();
        private readonly EmployeeService employeeService = new EmployeeService();
        private string loggedInUsername;
        public UC_TableStatus(string user)
        {
            InitializeComponent();
            loggedInUsername = user;
        }
        private void UC_TableStatus_Load(object sender, System.EventArgs e)
        {
            // Hiển thị tất cả món ăn ban đầu
            GenerateTable();
        }

        private void AddToCart(DAL.Entities.Table table)
        {
            var orderitem = orderItemService.FindByMaDH(table.MaDH);
            //Sự kiện ở đây với table là xem thông tin bàn
            if (orderitem != null)
            {
                // Xóa dữ liệu cũ trong DataGridView (nếu cần)
                dgvBill.Rows.Clear();
                decimal Total = 0;
                // Thêm từng item vào DataGridView
                foreach (var item in orderitem)
                {
                    dgvBill.Rows.Add(
                        item.MaDH,
                        item.Menu.TenMA,   // Tên sản phẩm
                        item.SL, // Số lượng
                        item.ThanhTien // Thành tiền
                    );
                    Total += item.ThanhTien;
                }
                lblToltal.Text = Total.ToString() + " VNĐ";
            }
            else
            {
                MessageBox.Show("Không có thông tin đơn hàng cho bàn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void GenerateTable()
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
                    Size = new Size(161, 130),
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                    ForeColor = Color.Black,
                };

                // Thêm nút "Thêm"
                System.Windows.Forms.Button addButton = new System.Windows.Forms.Button
                {
                    Text = $"Table {table.MaBan.Substring(1)}",
                    Font = new Font("Arial", 20, FontStyle.Bold),
                    Size = new Size(161, 130),
                    Location = new Point(0, 0),
                    ForeColor = Color.Black,

                };

                if (table.TrangThai == "Đang sử dụng")
                {
                    addButton.BackColor = Color.Red;
                }
                else if (table.TrangThai == "Đã đặt")
                {
                    addButton.BackColor = Color.FromArgb(255, 255, 128);
                }
                else
                {
                    addButton.BackColor = Color.LightGreen;
                }

                // Gắn sự kiện Click cho nút
                addButton.Click += (s, e) =>
                {
                    AddToCart(table); // Gọi phương thức thêm món vào giỏ hàng
                };

                panel.Controls.Add(addButton);

                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = dgvBill.SelectedRows[0];
                frmBill frmbill = new frmBill();
                frmbill.madh = selectedRow.Cells[0].Value.ToString();
                frmbill.manv = loggedInUsername;

                // Kiểm tra loggedInUsername có nằm trong danh sách manv của employee không
                bool isLoggedInUserValid = employeeService.GetAll()
                .Any(emp => emp.MaNV == loggedInUsername);

                if (isLoggedInUserValid)
                {
                    frmbill.Show();
                }
                else
                {
                    MessageBox.Show("User không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thanh toán khi chưa có món", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}