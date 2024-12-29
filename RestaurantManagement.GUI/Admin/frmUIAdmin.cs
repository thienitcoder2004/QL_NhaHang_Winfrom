using System;
using System.Windows.Forms;

namespace RestaurantManagement.GUI.Admin
{
    public partial class frmUIAdmin : Form
    {
        private string loggedInUsername;

        public frmUIAdmin(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            UC_Home uc_Home = new UC_Home();
            addController(uc_Home);
            lblPageChange.Text = "Trang Chủ";
        }

        private void addController(System.Windows.Forms.UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlChangePage.Controls.Clear();
            pnlChangePage.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void frmUIAdmin_Load(object sender, EventArgs e)
        {
            lblLoginUser.Text = $"Xin Chào, {loggedInUsername}!";
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UC_Home uc_Home = new UC_Home();
            addController(uc_Home);
            lblPageChange.Text = "Trang Chủ";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_Employee uc_Employee = new UC_Employee();
            addController(uc_Employee);
            lblPageChange.Text = "Quản Lý Nhân Viên";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_Statistical uc_Statistical = new UC_Statistical();
            addController(uc_Statistical);
            lblPageChange.Text = "Bảng Thống Kê";
        }

        private void logo_Click(object sender, EventArgs e)
        {
            UC_Home uc_Home = new UC_Home();
            addController(uc_Home);
            lblPageChange.Text = "Trang Chủ";
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            Hide();
        }
    }
}
