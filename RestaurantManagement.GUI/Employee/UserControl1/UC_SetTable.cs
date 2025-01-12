using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagement.BUS;

namespace RestaurantManagement.GUI.Employee
{
    public partial class UC_SetTable : UserControl
    {
        private readonly CustomerService customerService = new CustomerService();
        private readonly ReservationService reservationService = new ReservationService();
        public UC_SetTable()
        {
            InitializeComponent();
        }
        private void UC_SetTable_Load(object sender, EventArgs e)
        {
            List<DAL.Entities.Reservation> listReservation = reservationService.GetAll();
            BindGrid(listReservation);
        }
        private void BindGrid(List<DAL.Entities.Reservation> listReservation)
        {
            dgvKHDB.Rows.Clear();
            foreach (var item in listReservation)
            {
                if (item.SoNguoi <= 0)
                {
                    continue;
                }
                var customer = customerService.FindByMaKH(item.MaKH);
                int index = dgvKHDB.Rows.Add();
                dgvKHDB.Rows[index].Cells[0].Value = item.MaDB;
                dgvKHDB.Rows[index].Cells[1].Value = customer.TenKH;
                dgvKHDB.Rows[index].Cells[2].Value = item.NgayDat;
                dgvKHDB.Rows[index].Cells[3].Value = item.NgayDen;
                dgvKHDB.Rows[index].Cells[4].Value = item.SoNguoi;
                dgvKHDB.Rows[index].Cells[5].Value = item.GhiChu;
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMaDB.Text) || txtMaDB.Text.Length > 4)
            {
                MessageBox.Show("Mã đặt bàn không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMaKH.Text) || txtMaKH.Text.Length > 4)
            {
                MessageBox.Show("Mã khách hàng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtTenKH.Text) || txtTenKH.Text.Length < 3 || txtTenKH.Text.Length > 100)
            {
                MessageBox.Show("Họ và tên khách hàng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            DateTime date1 = dtpNgayDat.Value;
            DateTime date2 = dtpNgayDen.Value;
            if (date2 < date1)
            {
                MessageBox.Show("Ngày đặt ngày đến không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtSL.Text) || int.Parse(txtSL.Text) < 0)
            {
                MessageBox.Show("Số người không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtGhiChu.Text.Length > 200)
            {
                MessageBox.Show("Ghi chú không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void ClearData()
        {
            txtMaDB.Clear();
            txtMaKH.Clear();
            txtGhiChu.Clear();
            txtSDT.Clear();
            txtSL.Clear();
            txtTenKH.Clear();
            dtpNgayDat = null;
            dtpNgayDen = null;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;
                var reservation = new DAL.Entities.Reservation();
                //var item = reservationService.FindByMaDB(txtMaDB.Text);
                if (reservationService.FindByMaDB(txtMaDB.Text).Count > 0)
                {
                    reservation = reservationService.FindByMaDB(txtMaDB.Text)[0];
                }

                reservation.MaDB = txtMaDB.Text;
                reservation.NgayDat = dtpNgayDat.Value;
                reservation.NgayDen = dtpNgayDen.Value;
                reservation.SoNguoi = int.Parse(txtSL.Text);
                reservation.GhiChu = txtGhiChu.Text;
                reservation.MaKH = txtMaKH.Text;

                var customer = customerService.FindByMaKH(txtMaDB.Text) ?? new DAL.Entities.Customer();

                customer.MaKH = txtMaKH.Text;
                customer.TenKH = txtTenKH.Text;
                customer.SDT = txtSDT.Text;
                customerService.InsertUpdate(customer);

                reservationService.InsertUpdate(reservation);
                

                BindGrid(reservationService.GetAll());
                ClearData();
                MessageBox.Show("Thêm/Sửa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string tenkh = txtSearch.Text;
                if (string.IsNullOrEmpty(tenkh))
                {
                    throw new Exception("Vui lòng nhập tên khách hàng cần tìm kiếm!");
                    BindGrid(reservationService.GetAll());
                }
                var customer = customerService.FindByName(tenkh);
                if (customer == null) throw new Exception("Không thể tìm thấy khách hàng");
                var reservation = reservationService.FindByMaKH(customer.MaKH);
                if (reservation != null)
                {
                    BindGrid(reservation);
                }
                else
                {
                    dgvKHDB.Rows.Clear();
                    MessageBox.Show("Không tìm thấy khách hàng nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = dgvKHDB.Rows[e.RowIndex];
                txtMaDB.Text = row.Cells[0].Value?.ToString();
                if(row.Cells[0].Value?.ToString() == null)
                {
                    return;
                }    
                var reservation = reservationService.FindByMaDB(row.Cells[0].Value?.ToString())[0];
                txtMaKH.Text = reservation.MaKH.ToString();
                var customer = customerService.FindByMaKH(reservation.MaKH.ToString());
                txtSDT.Text = customer.SDT.ToString();
                txtTenKH.Text = row.Cells[1].Value?.ToString();
                dtpNgayDat.Text = row.Cells[2].Value?.ToString();
                dtpNgayDen.Text = row.Cells[3].Value?.ToString();
                txtSL.Text = row.Cells[4].Value?.ToString();
                txtGhiChu.Text = row.Cells[5].Value?.ToString();
            }
        }
    }
}
