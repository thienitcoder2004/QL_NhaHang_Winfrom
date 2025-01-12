using RestaurantManagement.BUS;
using RestaurantManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantManagement.GUI.Employee
{
    public partial class UC_Home : UserControl
    {
        private readonly MenuService menuService = new MenuService();
        private readonly TableService tableService = new TableService();
        private readonly OrderItemService orderItemService = new OrderItemService();
        private bool isInitializing = true; // Biến cờ để kiểm soát sự kiện
        public UC_Home()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            // Lấy từ khóa tìm kiếm từ TextBox
            string searchKeyword = txtSearch.Text;

            // Lấy loại món ăn từ ComboBox
            string selectedCategory = cmbLoai.SelectedItem?.ToString() ?? "Tất cả";

            // Gọi phương thức tìm kiếm và lọc món ăn
            FilterMenu(searchKeyword, selectedCategory);
        }

        private void UC_Home_Load(object sender, System.EventArgs e)
        {
            // Hiển thị tất cả món ăn ban đầu
            FilterMenu("", "Tất cả");

            // Lấy danh sách bàn từ cơ sở dữ liệu
            var tables = tableService.GetAll();

            // Sắp xếp danh sách theo số thứ tự trong MaBan
            var sortedTables = tables.OrderBy(t => int.Parse(t.MaBan.Substring(1))).ToList();

            // Tạo danh sách hiển thị với tên tùy chỉnh
            var displayTables = sortedTables.Select(t => new
            {
                DisplayName = $"Table {t.MaBan.Substring(1)}", // Hiển thị Table 1, Table 2, ...
                Value = t.MaBan // Mã bàn thực tế, ví dụ: B1, B2, ...
            }).ToList();

            cmbTable.DataSource = displayTables;
            cmbTable.DisplayMember = "DisplayName"; // Hiển thị tên bàn
            cmbTable.ValueMember = "Value";         // Giá trị thực tế

            cmbTable.SelectedIndex = -1;

            isInitializing = false; // Đặt cờ về false sau khi hoàn tất khởi tạo
        }

        private void FilterMenu(string searchKeyword, string selectedCategory)
        {
            // Lọc danh sách món ăn theo loại và từ khóa
            var dishes = menuService.GetAll();

            var filteredDishes = dishes.Where(d =>
                // Nếu "Tất cả" được chọn, không lọc theo loại
                (selectedCategory == "Tất cả" || d.LoaiMA == selectedCategory) &&
                // Nếu không có từ khóa, không lọc theo tên
                (string.IsNullOrEmpty(searchKeyword) || d.TenMA.Contains(searchKeyword)));

            // Hiển thị danh sách món ăn đã lọc
            GenerateMenu(filteredDishes.ToList());
        }

        private void AddToCart(DAL.Entities.Menu dish)
        {
            //Sự kiện ở đây với dish là món ăn cần thêm
            if (cmbTable.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thêm món");
                return;
            }
            string selectedTable = cmbTable.SelectedValue.ToString();
            var table = tableService.FindByMaBan(selectedTable);

            var orderitem = orderItemService.FindByMaDHMaMA(table.MaDH, dish.MaMA) ?? new DAL.Entities.OrderItem();

            orderitem.MaDH = table.MaDH;
            orderitem.MaMA = dish.MaMA;
            //sl
            int sl = 1;
            if(orderitem.SL > 0)
            {
                sl = orderitem.SL + 1;
            }
            orderitem.SL = sl;
            //thanhtien
            orderitem.ThanhTien = sl * dish.Gia;

            orderItemService.InsertUpdate(orderitem);
            LoadOrderItems(selectedTable);
            var tables = tableService.FindAllMaDH(orderitem.MaDH);
            foreach(var item in tables)
            {
                Table tableUpdate = new Table
                {
                    MaBan = item.MaBan,
                    TrangThai = "Đang sử dụng",
                    SoChoNgoi = item.SoChoNgoi,
                    MaDH = item.MaDH,
                };
                tableService.Update(tableUpdate);
            }  
        }

        private void GenerateMenu(List<DAL.Entities.Menu> filteredDishes)
        {
            // Xóa toàn bộ control trước đó trong FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();

            if (!filteredDishes.Any())
            {
                Label emptyLabel = new Label
                {
                    Text = "Không tìm thấy món ăn nào.",
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Dock = DockStyle.Top
                };
                flowLayoutPanel1.Controls.Add(emptyLabel);
                return;
            }

            foreach (DAL.Entities.Menu dish in filteredDishes)
            {
                // Tạo panel cho mỗi món ăn
                Panel panel = new Panel
                {
                    Size = new Size(124, 150),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White
                };

                // Thêm hình ảnh (PictureBox)
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(90, 90),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BorderStyle = BorderStyle.FixedSingle, // Viền để ảnh trống nhìn rõ
                };
                // Kiểm tra nếu không có ảnh
                if (string.IsNullOrEmpty(dish.HinhAnh))
                {
                    pictureBox.BackColor = Color.LightGray; // Màu nền để hiển thị ảnh trống
                    pictureBox.Image = null; // Không có ảnh
                }
                else
                {
                    string folderPath = Path.Combine(Application.StartupPath, "Images");
                    string avatarFileFatl = Path.Combine(folderPath, dish.HinhAnh);
                    pictureBox.Image = Image.FromFile(avatarFileFatl); // Load ảnh từ đường dẫn
                }

                panel.Controls.Add(pictureBox);

                // Thêm tên món ăn
                Label nameLabel = new Label
                {
                    Text = dish.TenMA,
                    Location = new Point(0, 100),
                    AutoSize = true,
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };
                panel.Controls.Add(nameLabel);

                // Thêm giá
                Label priceLabel = new Label
                {
                    Text = dish.Gia.ToString("N0") + " đ",
                    Location = new Point(12, 125),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    ForeColor = Color.Green
                };
                panel.Controls.Add(priceLabel);

                // Thêm nút "Thêm"
                System.Windows.Forms.Button addButton = new System.Windows.Forms.Button
                {
                    Text = "+",
                    Size = new Size(30, 30),
                    Location = new Point(88, 115),
                    BackColor = Color.LightGreen
                };

                // Gắn sự kiện Click cho nút
                addButton.Click += (s, e) =>
                {
                    AddToCart(dish); // Gọi phương thức thêm món vào giỏ hàng
                };

                panel.Controls.Add(addButton);

                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void cmbLoai_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Lấy loại món ăn được chọn từ ComboBox
            string selectedCategory = cmbLoai.SelectedItem?.ToString() ?? "Tất cả";

            // Lấy từ khóa tìm kiếm từ TextBox
            string searchKeyword = txtSearch.Text;

            // Lọc danh sách món ăn theo loại và từ khóa
            FilterMenu(searchKeyword, selectedCategory);
        }

        private void cmbTable_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Chỉ thực thi sự kiện nếu quá trình khởi tạo hoàn tất
            if (isInitializing)
                return;

            if (cmbTable.SelectedValue != null)
            {
                string selectedTable = cmbTable.SelectedValue.ToString();
                LoadOrderItems(selectedTable); // Gọi phương thức chung
            }
        }
        private void LoadOrderItems(string selectedTable)
        {
            if (!string.IsNullOrEmpty(selectedTable))
            {
                // Lấy thông tin bàn từ mã bàn
                var table = tableService.FindByMaBan(selectedTable);

                if (table != null && !string.IsNullOrEmpty(table.MaDH))
                {
                    // Xóa dữ liệu cũ trong DataGridView
                    dgvMenu.Rows.Clear();

                    // Lấy danh sách món ăn trong đơn hàng
                    var orderItems = orderItemService.FindByMaDH(table.MaDH);

                    // Kiểm tra nếu có món ăn trong đơn hàng
                    if (orderItems != null && orderItems.Any())
                    {

                        // Lặp qua từng món ăn trong đơn hàng
                        foreach (var item in orderItems)
                        {
                            var menu = menuService.FindByID(item.MaMA);

                            // Thêm thông tin vào DataGridView
                            dgvMenu.Rows.Add(
                                selectedTable,       // Mã bàn
                                menu.TenMA,          // Tên món ăn
                                item.SL,             // Số lượng
                                item.ThanhTien       // Thành tiền
                            );
                        }
                        return;
                    }
                }else
                {
                    // Nếu không có đơn hàng hoặc bàn rỗng
                    dgvMenu.Rows.Clear();
                    MessageBox.Show("Chưa có đơn hàng");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMenu.SelectedRows.Count > 0)
            {
                if (string.IsNullOrEmpty(txtSL.Text))
                {
                    MessageBox.Show("Vui lòng nhập số lượng cần thay đổi!");
                    return;
                }

                // Lấy dòng được chọn
                var selectedRow = dgvMenu.SelectedRows[0];


                // Lấy thông tin từ dòng
                string maBan = selectedRow.Cells[0].Value.ToString();
                var table = tableService.FindByMaBan(maBan);
                string tenMon = selectedRow.Cells[1].Value.ToString();
                var menu = menuService.FindByName(tenMon);

                OrderItem orderItem = orderItemService.FindByMaDHMaMA(table.MaDH, menu.MaMA);

                orderItem.SL = int.Parse(txtSL.Text);
                orderItem.ThanhTien = int.Parse(txtSL.Text) * menu.Gia;

                orderItemService.InsertUpdate(orderItem);
                LoadOrderItems(maBan);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong danh sách!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMenu.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                var selectedRow = dgvMenu.SelectedRows[0];

                // Lấy thông tin từ dòng
                string maBan = selectedRow.Cells[0].Value.ToString();
                var table = tableService.FindByMaBan(maBan);
                string tenMon = selectedRow.Cells[1].Value.ToString();
                var menu = menuService.FindByName(tenMon);

                orderItemService.Delete(table.MaDH, menu.MaMA);
                LoadOrderItems(maBan);

            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong danh sách!");
            }
        }
    }
}
