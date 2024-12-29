using RestaurantManagement.BUS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RestaurantManagement.GUI
{
    public partial class UC_Employee : UserControl
    {
        private readonly EmployeeService employeeService = new EmployeeService();

        public UC_Employee()
        {
            InitializeComponent();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            try
            {
                List<DAL.Entities.Employee> listEmployeee = employeeService.GetAll();
                BindGrid(listEmployeee);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<DAL.Entities.Employee> listEmployee)
        {
            dgvEmployee.Rows.Clear();
            foreach (var item in listEmployee)
            {
                int index = dgvEmployee.Rows.Add();
                dgvEmployee.Rows[index].Cells[0].Value = item.MaNV;
                dgvEmployee.Rows[index].Cells[1].Value = item.TenNV;
                dgvEmployee.Rows[index].Cells[2].Value = item.ChucVu;
                dgvEmployee.Rows[index].Cells[3].Value = item.SDT;
                dgvEmployee.Rows[index].Cells[4].Value = item.Luong;
            }
        }
        private void ClearData()
        {
            txtEmployeeID.Clear();
            txtFullName.Clear();
            txtPosition.Clear();
            txtPhoneNumber.Clear();
            txtMoney.Clear();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string tennv = txtSearch.Text;
                if (string.IsNullOrEmpty(tennv))
                {
                    throw new Exception("Vui lòng nhập mã nhân viên cần tìm kiếm!");
                }
                var employee = employeeService.FindByHoTen(txtSearch.Text);
                if (employee != null)
                {
                    BindGrid(employee);
                }
                else
                {
                    dgvEmployee.Rows.Clear();
                    MessageBox.Show("Không tìm thấy nhân viên nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text) || txtEmployeeID.Text.Length > 4)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtFullName.Text) || txtFullName.Text.Length < 3 || txtFullName.Text.Length > 100)
            {
                MessageBox.Show("Họ và tên nhân viên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtPosition.Text))
            {
                MessageBox.Show("Vui lòng nhập chức vụ nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtPhoneNumber.Text) || txtPhoneNumber.Text.Length != 11)
            {
                MessageBox.Show("Số điện thoại nhân viên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMoney.Text) || Decimal.Parse(txtMoney.Text) < 0)
            {
                MessageBox.Show("Lương nhân viên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;
                var employee = employeeService.FindByID(txtEmployeeID.Text) ?? new DAL.Entities.Employee();

                employee.MaNV = txtEmployeeID.Text;
                employee.TenNV = txtFullName.Text;
                employee.ChucVu = txtPosition.Text;
                employee.SDT = txtPhoneNumber.Text;
                employee.Luong = Decimal.Parse(txtMoney.Text);

                employeeService.InsertUpdate(employee);
                BindGrid(employeeService.GetAll());
                ClearData();
                MessageBox.Show("Thêm/Sửa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemote_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmployeeID.Text))
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    employeeService.Delete(txtEmployeeID.Text);
                    BindGrid(employeeService.GetAll());
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thông tin", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}