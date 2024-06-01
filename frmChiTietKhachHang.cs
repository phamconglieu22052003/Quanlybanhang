using Quanlybanhang.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlybanhang
{
    public partial class frmChiTietKhachHang : Form
    {
        DataTable tblCTKH; //Bảng ctkh
        public frmChiTietKhachHang()
        {
            InitializeComponent();
        }

        private void frmChiTietKhachHang_Load(object sender, EventArgs e)
        {
           /* string sql;
            sql = "SELECT * from tblChiTietKhachHang";*/
            txtMaKhachHang.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql = "SELECT * from tblChiTietKhachHang";
            tblCTKH = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dgvChiTietKhachHang.DataSource = tblCTKH; //Hiển thị vào dataGridView
            dgvChiTietKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            dgvChiTietKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgvChiTietKhachHang.Columns[2].HeaderText = "Tên công ty";
            dgvChiTietKhachHang.Columns[3].HeaderText = "Thông tin liên lạc";
            dgvChiTietKhachHang.Columns[4].HeaderText = "Địa Chỉ";
            dgvChiTietKhachHang.Columns[5].HeaderText = "Thành phố";
            dgvChiTietKhachHang.Columns[6].HeaderText = "Vùng";
            dgvChiTietKhachHang.Columns[7].HeaderText = "Mã Bưu chính";
            dgvChiTietKhachHang.Columns[8].HeaderText = "Quốc gia";
            dgvChiTietKhachHang.Columns[9].HeaderText = "Điện thoại";
            dgvChiTietKhachHang.Columns[10].HeaderText = "Ngày sinh";
            for (int i = 0; i < dgvChiTietKhachHang.Columns.Count; i++)
            {
                dgvChiTietKhachHang.Columns[i].Width = 70;
            }
            dgvChiTietKhachHang.AllowUserToAddRows = false;
            dgvChiTietKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaKhachHang.Enabled = true;
            txtMaKhachHang.Focus();
        }
        private void ResetValues()
        {
            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtTenCongTy.Text = "";
            txtThongTinLienLac.Text = "";
            txtDiaChi.Text = "";
            txtThanhPho.Text = "";
            txtVung.Text = "";
            txtMaBuuChinh.Text = "";
            txtQuocGia.Text = "";
            mtbDienThoai.Text = "";
            mskNgaySinh.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhachHang.Focus();
                return;
            }
            if (txtTenKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKhachHang.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (mtbDienThoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtbDienThoai.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã khách chưa
           /* sql = "SELECT MaKhach FROM tblKhach WHERE MaKhach=N'" + txtMaKhach.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhach.Focus();
                return;
            }*/
            //Chèn thêm
            sql = "INSERT INTO tblChiTietKhachHang VALUES (N'" + txtMaKhachHang.Text.Trim() +
                "',N'" + txtTenKhachHang.Text.Trim() + "',N'" + txtTenCongTy.Text.Trim() + "',N'" + txtThongTinLienLac.Text.Trim() +
                "',N'" + txtDiaChi.Text.Trim() + "',N'" + txtThanhPho.Text.Trim() + "',N'" + txtVung.Text.Trim() + "',N'" + txtMaBuuChinh.Text.Trim() +
                "',N'" + txtQuocGia.Text.Trim() + "',N'" + mtbDienThoai.Text.Trim() + "','" + mskNgaySinh.Text + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKhachHang.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCTKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhachHang.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblChiTietKhachHang WHERE MaKhachHang=N'" + txtMaKhachHang.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void dgvChiTietKhachHang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhachHang.Focus();
                return;
            }
            if (tblCTKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKhachHang.Text = dgvChiTietKhachHang.CurrentRow.Cells["MaKhachHang"].Value.ToString();
            txtTenKhachHang.Text = dgvChiTietKhachHang.CurrentRow.Cells["TenKhachHang"].Value.ToString();
            txtTenCongTy.Text = dgvChiTietKhachHang.CurrentRow.Cells["TenCongTy"].Value.ToString();
            txtThongTinLienLac.Text = dgvChiTietKhachHang.CurrentRow.Cells["ThongTinLienLac"].Value.ToString();
            txtDiaChi.Text = dgvChiTietKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtThanhPho.Text = dgvChiTietKhachHang.CurrentRow.Cells["ThanhPho"].Value.ToString();
            txtVung.Text = dgvChiTietKhachHang.CurrentRow.Cells["Vung"].Value.ToString();
            txtMaBuuChinh.Text = dgvChiTietKhachHang.CurrentRow.Cells["MaBuuChinh"].Value.ToString();
            txtQuocGia.Text = dgvChiTietKhachHang.CurrentRow.Cells["QuocGia"].Value.ToString();
            mtbDienThoai.Text = dgvChiTietKhachHang.CurrentRow.Cells["DienThoai"].Value.ToString();
            mskNgaySinh.Text = dgvChiTietKhachHang.CurrentRow.Cells["NgaySinh"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCTKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhachHang.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKhachHang.Focus();
                return;
            }
            if (txtTenCongTy.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên công ty", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenCongTy.Focus();
                return;
            }
            if (txtThongTinLienLac.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thông tin liên lạc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtThongTinLienLac.Focus();
                return;
            }

            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (txtThanhPho.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thành phố", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtThanhPho.Focus();
                return;
            }
            if (txtVung.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Vùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVung.Focus();
                return;
            }
            if (txtMaBuuChinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã bưu chính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaBuuChinh.Focus();
                return;
            }
            if (txtQuocGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập quốc gia", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuocGia.Focus();
                return;
            }
            if (mtbDienThoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtbDienThoai.Focus();
                return;
            }
            if (mskNgaySinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskNgaySinh.Focus();
                return;
            }
            sql = "UPDATE tblChiTietKhachHang SET TenKhachHang=N'" + txtTenKhachHang.Text.Trim().ToString() + "',TenCongTy=N'" +
                txtTenCongTy.Text.Trim().ToString() + "',ThongTinLienLac=N'" +
                txtThongTinLienLac.Text.Trim().ToString()+ "',DiaChi=N'" +
                txtDiaChi.Text.Trim().ToString() + "',ThanhPho=N'" +
                txtThanhPho.Text.Trim().ToString() + "',Vung=N'" +
                txtVung.Text.Trim().ToString() + "',MaBuuChinh=N'" +
                txtMaBuuChinh.Text.Trim().ToString() + "',QuocGia=N'" +
                txtQuocGia.Text.Trim().ToString()+ "',DienThoai='" + mtbDienThoai.Text.ToString() + "',NgaySinh=N'" +
                mskNgaySinh.Text.Trim().ToString()+
                "' WHERE MaKhachHang=N'" + txtMaKhachHang.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            SqlCommand cmd;
            // Kiểm tra nếu cả hai ô tìm kiếm đều trống
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text) && string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo câu lệnh SQL với điều kiện tìm kiếm
            sql = "SELECT * FROM tblChiTietKhachHang WHERE 1=1"; // 1=1 để dễ dàng thêm điều kiện động

            cmd = new SqlCommand(sql, Functions.Con);

            if (!string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                sql += " AND MaKhachHang LIKE @MaKhachHang";
                cmd.Parameters.AddWithValue("@MaKhachHang", "%" + txtMaKhachHang.Text.Trim() + "%");
            }

            if (!string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                sql += " AND TenKhachHang LIKE @TenKhachHang";
                cmd.Parameters.AddWithValue("@TenKhachHang", "%" + txtTenKhachHang.Text.Trim() + "%");
            }

            cmd.CommandText = sql;

            // Thực hiện truy vấn và lấy kết quả vào DataTable
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            tblCTKH = new DataTable();
            adapter.Fill(tblCTKH);

            // Hiển thị thông báo kết quả tìm kiếm
            if (tblCTKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có " + tblCTKH.Rows.Count + " bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Hiển thị kết quả trong DataGridView
            dgvChiTietKhachHang.DataSource = tblCTKH;

            // Đặt lại các ô tìm kiếm
            ResetValues();
        }
    }
}
