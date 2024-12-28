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
        }

        private void frmUIAdmin_Load(object sender, EventArgs e)
        {
            lblUsername.Text = $"Welcome, {loggedInUsername}!";
        }


        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }
    }
}
