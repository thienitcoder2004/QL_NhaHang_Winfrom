using RestaurantManagement.BUS;
using RestaurantManagement.GUI.Admin;
using RestaurantManagement.GUI.Employee;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RestaurantManagement.GUI
{
    public partial class frmLogin : Form
    {
        private readonly EmployeeService employeeService = new EmployeeService();
        private List<User> users = new List<User>();
        // Biến tạm lưu vai trò người dùng (admin hoặc employee)
        private string role = "";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Tạo danh sách tài khoản với vai trò
            users.Add(new User { Username = "1", Password = "1", Role = "admin" });
            users.Add(new User { Username = "2", Password = "2", Role = "employee" });

            try
            {
                var employees = employeeService.GetAll();
                // Tạo tài khoản đăng nhập từ danh sách nhân viên
                foreach (var employee in employees)
                {
                    string role = employee.ChucVu == "Quản Lý" ? "admin" : "employee";

                    // Thêm tài khoản vào danh sách
                    users.Add(new User
                    {
                        Username = employee.MaNV,
                        Password = employee.SDT, // Mật khẩu là số điện thoại
                        Role = role
                    });  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateLogin(string username, string password, out string userRole)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    // Gán vai trò khi tìm thấy tài khoản
                    userRole = user.Role;
                    return true;
                }
            }
            userRole = "";
            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim(); // Lấy username từ textbox
            string password = txtPassword.Text.Trim(); // Lấy password từ textbox

            if (ValidateLogin(username, password, out role)) // Xác thực login
            {
                if (role == "admin")
                {
                    frmUIAdmin frmUIAdmin = new frmUIAdmin(username); // Truyền username sang frmUIAdmin
                    frmUIAdmin.Show();
                    Hide();
                }
                else if (role == "employee")
                {
                    frmUIEmployee frmUIEmployee = new frmUIEmployee(username); // Truyền username sang frmUIEmployee
                    frmUIEmployee.Show();
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Hello World Github

    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Vai trò: admin hoặc employee
    }
}
