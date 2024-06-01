using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlybanhang.Class;

namespace Quanlybanhang
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Functions.Connect(); //Mở kết nối
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Functions.Disconnect(); //Đóng kết nối
            Application.Exit(); //Thoát
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            frmDMNCC frmNCC = new frmDMNCC(); //Khởi tạo đối tượng
            frmNCC.ShowDialog(); //Hiển thị
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmDMNhanVien frmNhanVien = new frmDMNhanVien(); //Khởi tạo đối tượng
            frmNhanVien.ShowDialog(); //Hiển thị
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmDMKhachHang frmKhachHang = new frmDMKhachHang(); //Khởi tạo đối tượng
            frmKhachHang.ShowDialog(); //Hiển thị
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            frmDMHang frmHang = new frmDMHang(); //Khởi tạo đối tượng
            frmHang.ShowDialog(); //Hiển thị
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frmHoaDonBan = new frmHoaDonBan(); //Khởi tạo đối tượng
            frmHoaDonBan.ShowDialog(); //Hiển thị
        }

        private void mnuFindHoaDon_Click(object sender, EventArgs e)
        {
            frmTimHDBan frmTimHDBan = new frmTimHDBan();
            frmTimHDBan.ShowDialog();
        }

        private void chiTiếtKháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmChiTietKhachHang frmChiTietKH = new frmChiTietKhachHang();
            frmChiTietKH.ShowDialog();
        }

        private void chiTiếtNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTietNhanVien frmChiTietNhanVien = new frmChiTietNhanVien();
            frmChiTietNhanVien.ShowDialog();
        }
    }
}
