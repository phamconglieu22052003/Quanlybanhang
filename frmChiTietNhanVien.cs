using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Quanlybanhang.Class;


namespace Quanlybanhang
{
    public partial class frmChiTietNhanVien : Form
    {
        DataTable tblCTNV; //Bảng ctNV
        public frmChiTietNhanVien()
        {
            InitializeComponent();
        }

        private void frmChiTietNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql = "SELECT * from tblChiTietNhanVien";
            tblCTNV = Functions.GetDataToTable(sql);
            dgvChiTietNhanVien.DataSource = tblCTNV;
            dgvChiTietNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvChiTietNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvChiTietNhanVien.Columns[2].HeaderText = "Thông tin liên lạc";
            dgvChiTietNhanVien.Columns[3].HeaderText = "Địa chỉ";
            dgvChiTietNhanVien.Columns[4].HeaderText = "Thành phố";
            dgvChiTietNhanVien.Columns[5].HeaderText = "Điện thoại";
            dgvChiTietNhanVien.Columns[6].HeaderText = "Ngày sinh";
            dgvChiTietNhanVien.Columns[7].HeaderText = "Chức vụ";
            dgvChiTietNhanVien.Columns[8].HeaderText = "Ảnh";
            dgvChiTietNhanVien.Columns[0].Width = 80;
            dgvChiTietNhanVien.Columns[1].Width = 140;
            dgvChiTietNhanVien.Columns[2].Width = 80;
            dgvChiTietNhanVien.Columns[3].Width = 80;
            dgvChiTietNhanVien.Columns[4].Width = 100;
            dgvChiTietNhanVien.Columns[5].Width = 100;
            dgvChiTietNhanVien.Columns[6].Width = 50;
            dgvChiTietNhanVien.Columns[7].Width = 100;
            dgvChiTietNhanVien.AllowUserToAddRows = false;
            dgvChiTietNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaNhanVien.Enabled = true;
            txtMaNhanVien.Focus();
        }
        private void ResetValues()
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtThongTinLienLac.Text = "";
            txtDiaChi.Text = "";
            txtThanhPho.Text = "";
            mtbDienThoai.Text = "";
            mskNgaySinh.Text = "";
            txtChucVu.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return;
            }
           
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }
            sql = "SELECT MaNhanVien FROM tblChiTietNhanVien WHERE MaNhanVien=N'" + txtMaNhanVien.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return;
            }
            sql = "INSERT INTO tblChiTietNhanVien VALUES (N'" + txtMaNhanVien.Text.Trim() +
                    "',N'" + txtTenNhanVien.Text.Trim() + "',N'" + txtThongTinLienLac.Text.Trim() + "',N'" + txtDiaChi.Text.Trim() + "',N'" + txtThanhPho.Text.Trim() + "',N'" + mtbDienThoai.Text.Trim() + "','" + mskNgaySinh.Text + "',N'" + txtChucVu.Text.Trim() + "',N'" + txtAnh.Text + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNhanVien.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCTNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblChiTietNhanVien WHERE MaNhanVien=N'" + txtMaNhanVien.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCTNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return;
            }
            if (txtThongTinLienLac.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtThongTinLienLac.Focus();
                return;
            }
            if (mtbDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtbDienThoai.Focus();
                return;
            }
            if (mskNgaySinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskNgaySinh.Focus();
                return;
            }
            
            sql = "UPDATE tblChiTietNhanVien SET TenNhanVien=N'" + txtTenNhanVien.Text.Trim().ToString() + "',ThongTinLienLac=N'" +
              txtThongTinLienLac.Text.Trim().ToString() + "',DiaChi=N'" +
              txtDiaChi.Text.Trim().ToString() + "',ThanhPho=N'" +
              txtThanhPho.Text.Trim().ToString() +
              "',DienThoai='" + mtbDienThoai.Text.ToString() + "',NgaySinh=N'" +
              mskNgaySinh.Text.Trim().ToString() + "',ChucVu=N'" +
              txtChucVu.Text.Trim().ToString() +
              "' WHERE MaNhanVien=N'" + txtMaNhanVien.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void dgvChiTietNhanVien_Click(object sender, EventArgs e)
        {
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return;
            }
            if (tblCTNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNhanVien.Text = dgvChiTietNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txtTenNhanVien.Text = dgvChiTietNhanVien.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            txtThongTinLienLac.Text= dgvChiTietNhanVien.CurrentRow.Cells["ThongTinLienLac"].Value.ToString();
            txtDiaChi.Text = dgvChiTietNhanVien.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtThanhPho.Text = dgvChiTietNhanVien.CurrentRow.Cells["ThanhPho"].Value.ToString() ;
            mtbDienThoai.Text = dgvChiTietNhanVien.CurrentRow.Cells["DienThoai"].Value.ToString();
            mskNgaySinh.Text = dgvChiTietNhanVien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtChucVu.Text = dgvChiTietNhanVien.CurrentRow.Cells["ChucVu"].Value.ToString();
            sql = "SELECT Anh FROM tblChiTietNhanVien WHERE MaNhanVien=N'" + txtMaNhanVien.Text + "'";
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

    }
}
