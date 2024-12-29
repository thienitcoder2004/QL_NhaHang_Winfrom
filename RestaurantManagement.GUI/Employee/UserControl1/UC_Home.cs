using RestaurantManagement.BUS;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantManagement.GUI.Employee
{
    public partial class UC_Home : UserControl
    {
        private readonly MenuService menuService = new MenuService();

        public UC_Home()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

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
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
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
            MessageBox.Show($"Đã thêm {dish.TenMA} với giá {dish.Gia:N0} đ vào giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Sự kiện ở đây với dish là món ăn cần thêm
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
                    BorderStyle = BorderStyle.FixedSingle
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
                if (string.IsNullOrEmpty(dish.HinhAnh) || !File.Exists(dish.HinhAnh))
                {
                    pictureBox.BackColor = Color.LightGray; // Màu nền để hiển thị ảnh trống
                    pictureBox.Image = null; // Không có ảnh
                }
                else
                {
                    pictureBox.Image = Image.FromFile(dish.HinhAnh); // Load ảnh từ đường dẫn
                }

                panel.Controls.Add(pictureBox);

                // Thêm tên món ăn
                Label nameLabel = new Label
                {
                    Text = dish.TenMA,
                    Location = new Point(5, 140),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };
                panel.Controls.Add(nameLabel);

                // Thêm giá
                Label priceLabel = new Label
                {
                    Text = dish.Gia.ToString("N0") + " đ",
                    Location = new Point(10, 170),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    ForeColor = Color.Green
                };
                panel.Controls.Add(priceLabel);

                // Thêm nút "Thêm"
                System.Windows.Forms.Button addButton = new System.Windows.Forms.Button
                {
                    Text = "+",
                    Size = new Size(40, 40),
                    Location = new Point(140, 190),
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Lấy loại món ăn được chọn từ ComboBox
            string selectedCategory = cmbLoai.SelectedItem?.ToString() ?? "Tất cả";

            // Lấy từ khóa tìm kiếm từ TextBox
            string searchKeyword = txtSearch.Text;

            // Lọc danh sách món ăn theo loại và từ khóa
            FilterMenu(searchKeyword, selectedCategory);
        }
    }
}
