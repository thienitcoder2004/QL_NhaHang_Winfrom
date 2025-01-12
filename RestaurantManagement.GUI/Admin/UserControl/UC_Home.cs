using RestaurantManagement.BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantManagement.GUI
{
    public partial class UC_Home : UserControl
    {
        private readonly MenuService menuService = new MenuService();

        public UC_Home()
        {
            InitializeComponent();
        }
        private void ClearData()
        {
            txtFoodID.Clear();
            txtFullnameFood.Clear();
            txtMoney.Clear();
            cmbLoai.SelectedIndex = 0;
            cmbTypeFood.SelectedIndex = 0;
            picHinhMA.Image = null;
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
            cmbTypeFood.SelectedIndex = 0;
            cmbLoai.SelectedIndex = 0;
            // Hiển thị tất cả món ăn ban đầu
            FilterMenu("", "Tất cả");
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
            txtFoodID.Text = dish.MaMA.ToString();
            txtFullnameFood.Text = dish.TenMA.ToString();
            txtMoney.Text = dish.Gia.ToString();
            cmbTypeFood.SelectedItem = dish.LoaiMA.ToString();
            LoadAvatar(dish.MaMA);
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
                    Size = new Size(125, 150),
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
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };
                panel.Controls.Add(nameLabel);

                // Thêm giá
                Label priceLabel = new Label
                {
                    Text = dish.Gia.ToString("N0") + " đ",
                    Location = new Point(15, 115),
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
                    Location = new Point(88, 120),
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

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtFoodID.Text) || txtFoodID.Text.Length > 4)
            {
                MessageBox.Show("Mã món ăn không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtFullnameFood.Text))
            {
                MessageBox.Show("Tên món ăn không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtMoney.Text) || Decimal.Parse(txtMoney.Text) < 0)
            {
                MessageBox.Show("Giá món ăn không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbTypeFood.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại món ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private string avatarFilePath = string.Empty;
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;
                var menu = menuService.FindByID(txtFoodID.Text) ?? new DAL.Entities.Menu();

                menu.MaMA = txtFoodID.Text;
                menu.TenMA = txtFullnameFood.Text;
                menu.Gia = Decimal.Parse(txtMoney.Text);

                menu.LoaiMA = cmbTypeFood.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(avatarFilePath))
                {
                    string avatarFileName = SaveAvatar(avatarFilePath, txtFoodID.Text);
                    if (!string.IsNullOrEmpty(avatarFileName))
                    {
                        menu.HinhAnh = avatarFileName;
                    }
                }
                menuService.InsertUpdate(menu);
                FilterMenu("", "Tất cả");
                ClearData();
                MessageBox.Show("Thêm/Sửa món ăn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm/sửa món ăn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAvatar(string mama)
        {
            string folderPath = Path.Combine(Application.StartupPath, "Images");
            var menu = menuService.FindByID(mama);
            if (menu != null && !string.IsNullOrEmpty(menu.HinhAnh))
            {
                string avatarFileFatl = Path.Combine(folderPath, menu.HinhAnh);
                if (File.Exists(avatarFileFatl))
                {
                    picHinhMA.Image = Image.FromFile(avatarFileFatl);
                }
                else
                {
                    picHinhMA.Image = null;
                }
            }
        }
        private string SaveAvatar(string sourceFilePath, string studentID)
        {
            try
            {
                string folderPath = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileExtension = Path.GetExtension(sourceFilePath);
                string targetFilePath = Path.Combine(folderPath, $"{studentID}{fileExtension}");

                if (!File.Exists(sourceFilePath))
                {
                    throw new FileNotFoundException($"Không tìm thấy file nguồn: {sourceFilePath}");
                }

                File.Copy(sourceFilePath, targetFilePath, true);
                return $"{studentID}{fileExtension}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving avatar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void btnRemoteFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFoodID.Text))
                {
                    MessageBox.Show("Vui lòng chọn một món ăn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    menuService.Delete(txtFoodID.Text);
                    FilterMenu("", "Tất cả");
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa món ăn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        avatarFilePath = openFileDialog.FileName;
                        picHinhMA.Image = Image.FromFile(avatarFilePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể tải hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
