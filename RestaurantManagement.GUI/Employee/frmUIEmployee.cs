using System;
using System.Windows.Forms;

namespace RestaurantManagement.GUI.Employee
{
    public partial class frmUIEmployee : Form
    {
        private string loggedInUsername;

        public frmUIEmployee(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            UC_Home uc_Home = new UC_Home();
            addController(uc_Home);
            lblPageChange.Text = "Trang Chủ";
        }

        private void frmUIEmployee_Load(object sender, EventArgs e)
        {
            lblLoginUser.Text = $"Xin Chào, {loggedInUsername}!";
        }


        private void addController(System.Windows.Forms.UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlChangePage.Controls.Clear();
            pnlChangePage.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UC_Home uc_Home = new UC_Home();
            addController(uc_Home);
            lblPageChange.Text = "Trang Chủ";
        }

        private void btnTableStatus_Click(object sender, EventArgs e)
        {
            UC_TableStatus uc_TableStatus = new UC_TableStatus(loggedInUsername);
            addController(uc_TableStatus);
            lblPageChange.Text = "Tình Trạng Bàn";
        }
        private void btnSetTable_Click(object sender, EventArgs e)
        {
            UC_SetTable uc_SetTable = new UC_SetTable();
            addController(uc_SetTable);
            lblPageChange.Text = "Đặt Bàn";
        }

        private void logo_Click(object sender, EventArgs e)
        {
            UC_Home uc_Home = new UC_Home();
            addController(uc_Home);
            lblPageChange.Text = "Trang Chủ";
        }

        private void logo_Paint(object sender, PaintEventArgs e)
        {
            UC_Home uc_Home = new UC_Home();
            addController(uc_Home);
            lblPageChange.Text = "Trang Chủ";
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            Hide();
        }

        private void btnSeats_Click(object sender, EventArgs e)
        {
            UC_Seats uc_Seats = new UC_Seats();
            addController(uc_Seats);
            lblPageChange.Text = "Xếp Chỗ";
        }

    }
}
