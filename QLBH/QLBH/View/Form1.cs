using QLBanHang.Control;
using QLBanHang.Object;
using QLBH.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class Form1 : Form
    {
        NhanVienCtr nvCtr = new NhanVienCtr();
        HangHoaCtr hhCtr = new HangHoaCtr();
        KhachHangCtr khCtr = new KhachHangCtr();
        NhaCCCtr nccCtr = new NhaCCCtr();
        DataTable dtDSCT = new System.Data.DataTable();
        HoaDonCtr hdCtr = new HoaDonCtr();
        ChiTietCtr ctCtr = new ChiTietCtr();
        private int total = 0;
        private int i=1;
        int vitriclick = 0;
        private int flagLuu = 0;
        private string _message;

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string message):this()//tạo hàm chứa tham số
        {
            _message = message;
            lbShow.Text = _message;//gán biến đó bằng lbS
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (lbShow.Text == "Nhân viên")
            {
                tabControl.TabPages.Remove(tabNhanVien);
                mnHome.DropDownItems.Remove(submenuAddAccount);
                mnHome.DropDownItems.Remove(submnDelAccount);
            }
            frmChooseReport frm = new frmChooseReport();
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tabControl.TabPages[5].Controls.Add(frm);

            //Load NV
            DataTable dtDSNV = new DataTable();
            dtDSNV = nvCtr.GetData();
            dtgvDSNV.DataSource = dtDSNV;//hiển thị dl trong dtgv
            DTBDNhanVien();//lấy dự liệu từ dtgv hiển thị lên cac textbox
            DisEnlNV(false);

            //LoadHH
            DataTable dtDSHH = new DataTable();
            dtDSHH = hhCtr.GetData();
            dtgvHH.DataSource = dtDSHH;
            DTBDHH();
            DisEnlHH(false);

            //Load KH\
            DataTable dtDSKH = new System.Data.DataTable();
            dtDSKH = khCtr.GetData();
            dtgvKH.DataSource = dtDSKH;
            DTBDKH();
            DisEnlKH(false);

            //Load NCC
            DataTable dtDSNCC = new DataTable();
            dtDSNCC = nccCtr.GetData();
            dtgvNCC.DataSource = dtDSNCC;//hiển thị dl trong dtgv
            DTBDNCC();//lấy dự liệu từ dtgv hiển thị lên cac textbox
            DisEnlNCC(false);

            //Load Hoa Don
            DisEnlHD(false);
            DataTable dt = new DataTable();
            dt = hdCtr.GetData();
            dtgvDSHD.DataSource = dt;
            DTBDHD();
            txtCreateDate.Enabled = false;
            //DataTable dt1 = new DataTable();
            //dt1 = ctCtr.GetData(txtMa.Text.Trim());
            //dtgvDSHH.DataSource = dt1;
        }
        //Tab NV
        private void DTBDNhanVien()//lấy dự liệu từ dtgv hiển thị lên cac textbox
        {
            txtCodeNV.DataBindings.Clear();
            txtCodeNV.DataBindings.Add("Text", dtgvDSNV.DataSource, "MaNV");
            txtNameNV.DataBindings.Clear();
            txtNameNV.DataBindings.Add("Text", dtgvDSNV.DataSource, "TenNV");
            cbbSexNV.DataBindings.Clear();
            cbbSexNV.DataBindings.Add("Text", dtgvDSNV.DataSource, "GioiTinh");
            txtAddressNV.DataBindings.Clear();
            txtAddressNV.DataBindings.Add("Text", dtgvDSNV.DataSource, "DiaChi");
            txtPhoneNumberNV.DataBindings.Clear();
            txtPhoneNumberNV.DataBindings.Add("Text", dtgvDSNV.DataSource, "SDT");
            dpDateBirthNV.DataBindings.Clear();
            dpDateBirthNV.DataBindings.Add("Text", dtgvDSNV.DataSource, "NamSinh");
            txtSalaryNV.DataBindings.Clear();
            txtSalaryNV.DataBindings.Add("Text", dtgvDSNV.DataSource, "Luong");

        }

        private void DisEnlNV(bool enl)
        {
            btnAddNV.Enabled = !enl;
            btnDelNV.Enabled = !enl;
            btnEditNV.Enabled = !enl;
            btnSaveNV.Enabled = enl;
            btnCancleNV.Enabled = enl;
            txtCodeNV.Enabled = enl;
            txtNameNV.Enabled = enl;
            txtAddressNV.Enabled = enl;
            txtPhoneNumberNV.Enabled = enl;
            cbbSexNV.Enabled = enl;
            dpDateBirthNV.Enabled = enl;
            txtMatKhau.Enabled = enl;
            txtSalaryNV.Enabled = enl;

        }

        private void addData(NhanVienObj nv)//lấy dl trong textbox vào các biến trong đối trượng nv
        {

            nv.MaNhanVien = txtCodeNV.Text.Trim();
            if (cbbSexNV.SelectedIndex == 0)
            {
                nv.GioiTinh = "Nam";
            }
            else
                nv.GioiTinh = "Nữ";
            nv.DiaChi = txtAddressNV.Text.Trim();
            nv.DienThoai = txtPhoneNumberNV.Text.Trim();
            nv.TenNhanVien = txtNameNV.Text.Trim();
            nv.NamSinh = dpDateBirthNV.Text;
            nv.MatKhau = txtMatKhau.Text.Trim();
            nv.Luong = txtSalaryNV.Text.Trim();
        }

        private void loadcmbSexNV()//load combobox giới tính
        {
            cbbSexNV.Items.Clear();
            cbbSexNV.Items.Add("Nam");
            cbbSexNV.Items.Add("Nữ");
            cbbSexNV.SelectedItem = 0;
        }

        private void clearData()//xóa dl trong các textbox
        {
            txtCodeNV.Text = "";
            txtNameNV.Text = "";
            txtPhoneNumberNV.Text = "";
            txtAddressNV.Text = "";
            txtSalaryNV.Text = "";
            txtMatKhau.Text = "1";
            dpDateBirthNV.Value = DateTime.Now.Date;
            loadcmbSexNV();
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            clearData();//btnXoa dl
            DisEnlNV(true);//chp phẹp nhập
            //int temp = 0;
            //var MaxID2 = dtgvDSNV.Rows.Cast<DataGridViewRow>()
            //            .Max(r => int.TryParse(r.Cells["MaNV"].Value.ToString(), out temp) ?
            //                       temp : 0);
            //txtCodeNV.Text = temp.ToString();
        }

        private void btnDelNV_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (nvCtr.DelData(txtCodeNV.Text.Trim()))
                    MessageBox.Show("Xóa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Xóa không thành công", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(sender, e);
        }

        private void btnEditNV_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            DisEnlNV(true);
            loadcmbSexNV();
        }

        private void btnCancleNV_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn hủy thao tác?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Form1_Load(sender, e);
            else
                return;
        }

        private void btnSaveNV_Click(object sender, EventArgs e)
        {
            NhanVienObj nvObj = new NhanVienObj();
            addData(nvObj);
            if (flagLuu == 0)
            {
                if (nvCtr.AddData(nvObj))
                    MessageBox.Show("Thêm thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm thất bại!!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (flagLuu == 1)
            {
                if (nvCtr.UpdData(nvObj))
                    MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(sender, e);
        }

        private void txtSearchNV_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-IQ8SNUJ;Initial Catalog=QL_BanHang;Integrated Security=True");
                kn.Open();
                    string timkiem = "SELECT * FROM tb_NhanVien WHERE TenNV like '%" + txtSearchNV.Text.Trim() + "%' OR MaNV like '%" + txtSearchNV.Text.Trim() + "%' OR SDT like '%" + txtPhoneNumberNV.Text.Trim() + "%'";
                    SqlCommand commandsqltim = new SqlCommand(timkiem, kn);//thực thi các câu lệnh trong sql
                    SqlDataAdapter comm = new SqlDataAdapter(commandsqltim);//vận chuyển dữ liệu
                    DataTable tabletim = new DataTable();// tạo 1 bảng ảo trong hệ thống
                    comm.Fill(tabletim);// đổ dữ liệu vào bảng ảo
                    dtgvDSNV.DataSource = tabletim;
                    DTBDNhanVien();
                kn.Close();
            }
            catch
            {
                MessageBox.Show("Thao tác bị lỗi, xin kiểm tra lại!");
                //kn.Close();
            }
        }

        //Tab Hang Hoa
        private void DTBDHH()
        {
            txtCodeHH.DataBindings.Clear();
            txtCodeHH.DataBindings.Add("Text", dtgvHH.DataSource, "MaHH");
            txtNameHH.DataBindings.Clear();
            txtNameHH.DataBindings.Add("Text", dtgvHH.DataSource, "TenHH");
            txtPriceHH.DataBindings.Clear();
            txtPriceHH.DataBindings.Add("Text", dtgvHH.DataSource, "DonGia");
            txtNumber.DataBindings.Clear();
            txtNumber.DataBindings.Add("Text", dtgvHH.DataSource, "SoLuong");
            txtCodeNCCHH.DataBindings.Clear();
            txtCodeNCCHH.DataBindings.Add("Text", dtgvHH.DataSource, "MaNCC");
        }

        private void clearDataHH()
        {
            txtCodeHH.Text = "";
            txtNameHH.Text = "";
            txtPriceHH.Text = "";
            txtNumber.Text = "";
            txtCodeNCCHH.Text = "";
        }

        private void addDataHH(HangHoaObj hh)
        {

            hh.MaHangHoa = txtCodeHH.Text.Trim();
            hh.TenHangHoa = txtNameHH.Text.Trim();
            hh.DonGia = int.Parse(txtPriceHH.Text.Trim());
            hh.SoLuong = int.Parse(txtPriceHH.Text.Trim());
            hh.MaNCC = txtCodeNCCHH.Text.Trim();
        }

        private void DisEnlHH(bool enl)
        {
            btnAddHH.Enabled = !enl;
            btnDelHH.Enabled = !enl;
            btnEditHH.Enabled = !enl;
            btnSaveHH.Enabled = enl;
            btnCancleHH.Enabled = enl;
            btnInput.Enabled = !enl;
            txtCodeHH.Enabled = enl;
            txtNameHH.Enabled = enl;
            txtPriceHH.Enabled = enl;
            txtNumber.Enabled = enl;
            txtCodeNCCHH.Enabled = enl;
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddHH_Click(object sender, EventArgs e)
        {
            flagLuu = 2;
            clearDataHH();
            DisEnlHH(true);
        }

        private void btnEditHH_Click(object sender, EventArgs e)
        {
            flagLuu = 3;
            DisEnlHH(true);
            txtCodeHH.Enabled = false;
            //dtgvHH.Enabled = false;
        }

        private void btnDelHH_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (hhCtr.DelData(txtCodeHH.Text.Trim()))
                    MessageBox.Show("Xóa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Xóa không thành công", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(sender, e);
        }

        private void btnCancleHH_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn hủy thao tác?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Form1_Load(sender, e);
            else
                return;
        }

        private void btnSaveHH_Click(object sender, EventArgs e)
        {
            //if (txtMa.Text == "")
            //{
            //    errorProvider1.SetError(txtMa, "Bạn chưa nhập password");
            //    return;
            //}
            //if (txtTen.Text == "")
            //{
            //    errorProvider1.SetError(txtTen, "Bạn chưa nhập password");
            //    return;
            //}
            //if (txtSL.Text == "")
            //{
            //    errorProvider1.SetError(txtSL, "Bạn chưa nhập password");
            //    return;
            //}
            //if (txtDonGia.Text == "")
            //{
            //    errorProvider1.SetError(txtDonGia, "Bạn chưa nhập password");
            //    return;
            //}
            //if (txtMaNCC.Text == "")
            //{
            //    errorProvider1.SetError(txtMaNCC, "Bạn chưa nhập password");
            //    return;
            //}

            HangHoaObj hhObj = new HangHoaObj();
            addDataHH(hhObj);
            if (flagLuu == 2)
            {
                if (hhCtr.AddData(hhObj))
                    MessageBox.Show("Thêm thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm thất bại,mã đã tồn tại!!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (flagLuu == 3)
            {
                if (hhCtr.UpdData(hhObj))
                    MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Không thành công!!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (flagLuu == 4)
            {
                if (hhCtr.UpdData(hhObj))
                {
                    MessageBox.Show("Nhập thành công !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Nhập thất bại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(sender, e);
        }

        private void txtSearchHH_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-IQ8SNUJ;Initial Catalog=QL_BanHang;Integrated Security=True");
                kn.Open();
                string timkiem = "SELECT * FROM tb_HangHoa WHERE MaHH like '%" + txtSearchHH.Text.Trim() + "%' OR TenHH like '%" + txtSearchHH.Text.Trim() + "%'";
                SqlCommand commandsqltim = new SqlCommand(timkiem, kn);//thực thi các câu lệnh trong sql
                SqlDataAdapter comm = new SqlDataAdapter(commandsqltim);//vận chuyển dữ liệu
                DataTable tabletim = new DataTable();// tạo 1 bảng ảo trong hệ thống
                comm.Fill(tabletim);// đổ dữ liệu vào bảng ảo
                dtgvHH.DataSource = tabletim;
                DTBDHH();
                kn.Close();
            }
            catch
            {
                MessageBox.Show("Thao tác bị lỗi, xin kiểm tra lại!");
                //kn.Close();
            }
        }

        //Tab KhachHang

        private void DTBDKH()//load dl lên txt
        {
            txtCodeKH.DataBindings.Clear();
            txtCodeKH.DataBindings.Add("Text", dtgvKH.DataSource, "MaKH");
            txtNameKH.DataBindings.Clear();
            txtNameKH.DataBindings.Add("Text", dtgvKH.DataSource, "TenKH");
            cbbSexKH.DataBindings.Clear();
            cbbSexKH.DataBindings.Add("Text", dtgvKH.DataSource, "GioiTinh");
            txtAddressKH.DataBindings.Clear();
            txtAddressKH.DataBindings.Add("Text", dtgvKH.DataSource, "DiaChi");
            txtNumberPhoneKH.DataBindings.Clear();
            txtNumberPhoneKH.DataBindings.Add("Text", dtgvKH.DataSource, "SDT");
            dpDateBirthKH.DataBindings.Clear();
            dpDateBirthKH.DataBindings.Add("Text", dtgvKH.DataSource, "NamSinh");
            txtEmailKH.DataBindings.Clear();
            txtEmailKH.DataBindings.Add("Text", dtgvKH.DataSource, "Email");
            txtPointKH.DataBindings.Clear();
            txtPointKH.DataBindings.Add("Text", dtgvKH.DataSource, "Diem");
        }
        private void DisEnlKH(bool e)//hàm trạng thái active
        {
            btnAddKH.Enabled = !e;
            btnDelKH.Enabled = !e;
            btnEditKH.Enabled = !e;
            btnSaveKH.Enabled = e;
            btnCancleKH.Enabled = e;
            txtCodeKH.Enabled = e;
            txtNameKH.Enabled = e;
            txtAddressKH.Enabled = e;
            txtNumberPhoneKH.Enabled = e;
            cbbSexKH.Enabled = e;
            dpDateBirthKH.Enabled = e;
            txtEmailKH.Enabled = e;
        }

        private void loadCMBKH()//load ccbb gioitinh
        {
            cbbSexKH.Items.Clear();
            cbbSexKH.Items.Add("Nam");
            cbbSexKH.Items.Add("Nữ");
            cbbSexKH.SelectedItem = 0;
        }

        private void clearDataKH()
        {
            txtCodeKH.Text = "";
            txtNameKH.Text = "";
            txtAddressKH.Text = "";
            txtNumberPhoneKH.Text = "";
            dpDateBirthKH.Value = DateTime.Now.Date;
            loadCMBKH();
            txtEmailKH.Text = "";
        }

        private void addDataKH(KhachHangObj kh)//add DL vào đối tượng KhachHangObj
        {
            kh.MaKhachHang = txtCodeKH.Text.Trim();
            if (cbbSexKH.SelectedIndex == 0)//giá tri mặc đinh cbb
            {
                kh.GioiTinh = "Nam";
            }
            else
                kh.GioiTinh = "Nữ";
            kh.DiaChi = txtAddressKH.Text.Trim();
            kh.DienThoai = txtNumberPhoneKH.Text.Trim();
            kh.TenKhachHang = txtNameKH.Text.Trim();
            kh.NamSinh = dpDateBirthKH.Text;
            kh.Email = txtEmailKH.Text.Trim();
            kh.Diem = int.Parse(txtPointKH.Text.Trim());//ep kiểu
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddKH_Click(object sender, EventArgs e)
        {
            flagLuu = 4;
            clearDataKH();
            DisEnlKH(true);
        }

        private void btnEditKH_Click(object sender, EventArgs e)
        {
            flagLuu = 5;
            DisEnlKH(true);
            txtCodeKH.Enabled = false;
            loadCMBKH();
        }

        private void btnCancleKH_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Form1_Load(sender, e);
            else
                return;
        }

        private void btnSaveKH_Click(object sender, EventArgs e)
        {
            //if (txtMa.Text == "")
            //{
            //    errorProvider1.SetError(txtMa, "Bạn chưa nhập mã khách hàng");//thông báo lỗi erroprovider
            //    return;
            //}
            //if (txtTen.Text == "")
            //{
            //    errorProvider1.SetError(txtTen, "Bạn chưa nhập tên khách hàng");//thông báo lỗi erroprovider
            //    return;
            //}
            KhachHangObj khObj = new KhachHangObj();
            addDataKH(khObj);
            if (flagLuu == 4)
            {
                if (khCtr.AddData(khObj))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(flagLuu == 5)
            {
                if (khCtr.UpdData(khObj))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(sender, e);
        }

        private void txtSearchKH_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-IQ8SNUJ;Initial Catalog=QL_BanHang;Integrated Security=True");
                kn.Open();
                string timkiem = "SELECT * FROM tb_KhachHang WHERE TenKH like '%" + txtSearchKH.Text.Trim() + "%' OR MaKH like '%" + txtSearchKH.Text.Trim() + "%' OR SDT like '%" + txtNumberPhoneKH.Text.Trim() + "%' OR Email like '%" + txtNumberPhoneKH.Text.Trim() + "%'";
                SqlCommand commandsqltim = new SqlCommand(timkiem, kn);//thực thi các câu lệnh trong sql
                SqlDataAdapter comm = new SqlDataAdapter(commandsqltim);//vận chuyển dữ liệu
                DataTable tabletim = new DataTable();// tạo 1 bảng ảo trong hệ thống
                comm.Fill(tabletim);// đổ dữ liệu vào bảng ảo
                dtgvKH.DataSource = tabletim;
                DTBDKH();
                kn.Close();
            }
            catch
            {
                MessageBox.Show("Thao tác bị lỗi, xin kiểm tra lại!");
                //kn.Close();
            }
        }

        //Tab Nha Cung cap

        private void DTBDNCC()//lấy dự liệu từ dtgv hiển thị lên cac textbox
        {
            txtCodeNCC.DataBindings.Clear();
            txtCodeNCC.DataBindings.Add("Text", dtgvNCC.DataSource, "MaNCC");
            txtNameNCC.DataBindings.Clear();
            txtNameNCC.DataBindings.Add("Text", dtgvNCC.DataSource, "TenNCC");
            txtAddressNCC.DataBindings.Clear();
            txtAddressNCC.DataBindings.Add("Text", dtgvNCC.DataSource, "DiaChi");
            txtPhoneNumberNCC.DataBindings.Clear();
            txtPhoneNumberNCC.DataBindings.Add("Text", dtgvNCC.DataSource, "SDT");
        }
        private void clearDataNCC()//xóa dl trong các textbox
        {
            txtCodeNCC.Text = "";
            txtNameNCC.Text = "";
            txtPhoneNumberNCC.Text = "";
            txtAddressNCC.Text = "";
        }
        private void DisEnlNCC(bool enl)
        {
            btnAddNCC.Enabled = !enl;
            btnEditNCC.Enabled = !enl;
            btnDelNCC.Enabled = !enl;
            btnSaveNCC.Enabled = enl;
            btnCancleNCC.Enabled = enl;
            txtCodeNCC.Enabled = enl;
            txtNameNCC.Enabled = enl;
            txtAddressNCC.Enabled = enl;
            txtPhoneNumberNCC.Enabled = enl;

        }

        private void addDataNCC(NhaCCObj ncc)//lấy dl trong textbox vào các biến trong đối trượng nv
        {

            ncc.MaNCC = txtCodeNCC.Text.Trim();
            ncc.DiaChi = txtAddressNCC.Text.Trim();
            ncc.SDT = txtPhoneNumberNCC.Text.Trim();
            ncc.TenNCC = txtNameNCC.Text.Trim();

        }

        private void btnAddNCC_Click(object sender, EventArgs e)
        {
            flagLuu = 6;
            clearDataNCC();//btnXoa dl
            DisEnlNCC(true);//chp phẹp nhập
            //dtgvNCC.Rows.Clear();
        }

        private void btnEditNCC_Click(object sender, EventArgs e)
        {
            flagLuu = 7;
            DisEnlNCC(true);
        }

        private void btnDelNCC_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (nccCtr.DelData(txtCodeNCC.Text.Trim()))
                    MessageBox.Show("Xóa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Xóa không thành công", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(sender, e);
        }

        private void btnSaveNCC_Click(object sender, EventArgs e)
        {
            NhaCCObj nccObj = new NhaCCObj();
            addDataNCC(nccObj);
            if (flagLuu == 6)
            {
                if (nccCtr.AddData(nccObj))
                    MessageBox.Show("Thêm thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm thất bại!!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (flagLuu == 7)
            {
                if (nccCtr.UpdData(nccObj))
                    MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(sender, e);
        }

        private void btnCancleNCC_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Form1_Load(sender, e);
            else
                return;
        }

        private void txtSearchNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelKH_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (khCtr.DelData(txtCodeKH.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(sender, e);
        }

        private void txtSearchNCC_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-IQ8SNUJ;Initial Catalog=QL_BanHang;Integrated Security=True");
                kn.Open();
                string timkiem = "SELECT * FROM tb_NhaCC WHERE TenNCC like '%" + txtSearchNCC.Text.Trim() + "%' OR MaNCC like '%" + txtSearchNCC.Text.Trim() + "%'";
                SqlCommand commandsqltim = new SqlCommand(timkiem, kn);//thực thi các câu lệnh trong sql
                SqlDataAdapter comm = new SqlDataAdapter(commandsqltim);//vận chuyển dữ liệu
                DataTable tabletim = new DataTable();// tạo 1 bảng ảo trong hệ thống
                comm.Fill(tabletim);// đổ dữ liệu vào bảng ảo
                dtgvNCC.DataSource = tabletim;
                DTBDNCC();
                kn.Close();
            }
            catch
            {
                MessageBox.Show("Thao tác bị lỗi, xin kiểm tra lại!");
                //kn.Close();
            }
        }

        //tab Hoa Don

        private void DTBDHD()
        {
            txtCodeHD.DataBindings.Clear();
            txtCodeHD.DataBindings.Add("Text", dtgvDSHD.DataSource, "MaHD");
            txtCreateDate.DataBindings.Clear();
            txtCreateDate.DataBindings.Add("Text", dtgvDSHD.DataSource, "NgayLap");
            txtCodeNVCreate.DataBindings.Clear();
            txtCodeNVCreate.DataBindings.Add("Text", dtgvDSHD.DataSource, "TenNV");
            cbbCodeKHBuy.DataBindings.Clear();
            cbbCodeKHBuy.DataBindings.Add("Text", dtgvDSHD.DataSource, "TenKH");
        }
        private void DisEnlHD(bool e)
        {
            txtCodeHD.Enabled = e;
            txtCodeNVCreate.Enabled = e;
            cbbCodeKHBuy.Enabled = e;
            btnAddHD.Enabled = !e;
            btnDelHD.Enabled = !e;
            //btnPrint.Enabled = !e;
            btnSaveHD.Enabled = e;
            btnCancleHD.Enabled = e;
            //btncham.Enabled = e;
            btnAdd.Enabled = e;
            btnDel.Enabled = e;
            cbbHH.Enabled = e;
            txtNumberHH.Enabled = e;
        }
        private void LoadcmbKhachHang()
        {
            KhachHangCtr khctr = new KhachHangCtr();
            cbbCodeKHBuy.DataSource = khctr.GetData();
            cbbCodeKHBuy.DisplayMember = "TenKH";
            cbbCodeKHBuy.ValueMember = "MaKH";
            cbbCodeKHBuy.SelectedIndex = 0;
        }
        private void LoadcmbHH()
        {
            HangHoaCtr hhctr = new HangHoaCtr();
            cbbHH.DataSource = hhctr.GetData();
            cbbHH.DisplayMember = "TenHH";
            cbbHH.ValueMember = "MaHH";

        }
        private void clearDataHD()
        {
            txtCodeHD.Text = "";
            txtCodeNVCreate.Text = "";
            txtCreateDate.Text = DateTime.Now.Date.ToShortDateString();
            LoadcmbKhachHang();
        }
        private void addDataHD(HoaDonObj hdObj)
        {
            hdObj.MaHoaDon = txtCodeHD.Text.Trim();
            hdObj.NgayLap = txtCreateDate.Text.Trim();
            hdObj.NguoiLap = txtCodeNVCreate.Text.Trim();
            hdObj.KhachHang = cbbCodeKHBuy.SelectedValue.ToString();
        }
        private bool checktrung(string mahh)
        {
            for (int i = 0; i < dtDSCT.Rows.Count; i++)
                if (dtDSCT.Rows[i][1].ToString() == mahh)
                    return true;
            return false;
        }
        private void capnhatSL(string mahh, int SL)
        {
            for (int i = 0; i < dtDSCT.Rows.Count; i++)
                if (dtDSCT.Rows[i][1].ToString() == mahh)
                {
                    int soluong = int.Parse(dtDSCT.Rows[i][2].ToString()) + SL;
                    dtDSCT.Rows[i][3] = soluong;
                    double dongia = double.Parse(dtDSCT.Rows[i][3].ToString());
                    dtDSCT.Rows[i][4] = (dongia * soluong).ToString();
                    break;
                }
        }
        private bool kiemtraSL(string mahh, int sl)
        {
            DataTable dt = new DataTable();
            dt = hhCtr.GetData("Where MaHH = '" + cbbHH.SelectedValue.ToString() + "' and SoLuong>= " + sl);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ctCtr.GetData(txtCodeHD.Text.Trim());
                dtgvDSHH.DataSource = dt;

            }
            catch
            {
                dtgvDSHH.DataSource = null;
            }
            return;
        }


        private void txtSearchHD_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-IQ8SNUJ;Initial Catalog=QL_BanHang;Integrated Security=True");
                kn.Open();
                string timkiem = "SELECT * FROM tb_HoaDon WHERE TenHD like '%" + txtSearchNV.Text.Trim() + "%' OR MaHD like '%" + txtSearchNV.Text.Trim() + "%'";
                SqlCommand commandsqltim = new SqlCommand(timkiem, kn);//thực thi các câu lệnh trong sql
                SqlDataAdapter comm = new SqlDataAdapter(commandsqltim);//vận chuyển dữ liệu
                DataTable tabletim = new DataTable();// tạo 1 bảng ảo trong hệ thống
                comm.Fill(tabletim);// đổ dữ liệu vào bảng ảo
                dtgvDSHD.DataSource = tabletim;
                //DTBDNhanVien();
                kn.Close();
            }
            catch
            {
                MessageBox.Show("Thao tác bị lỗi, xin kiểm tra lại!");
                //kn.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodeHD.Text))//kiểm tra mã có trống khống
            {
                if (kiemtraSL(cbbHH.SelectedValue.ToString(), int.Parse(txtNumberHH.Text.Trim())))
                {
                    if (!checktrung(cbbHH.SelectedValue.ToString()))
                    {
                        DataRow dr = dtDSCT.NewRow();
                        dr[0] = txtCodeHD.Text.Trim();
                        dr[1] = cbbHH.SelectedValue.ToString();
                        dr[2] = txtPriceHHHD.Text;
                        dr[3] = txtNumberHH.Text;
                        dr[4] = (double.Parse(txtPriceHHHD.Text) * int.Parse(txtNumberHH.Text)).ToString();
                        dtDSCT.Rows.Add(dr);
                    }
                    else
                    {
                        capnhatSL(cbbHH.SelectedValue.ToString(), int.Parse(txtPriceHHHD.Text));
                    }
                    dtgvDSHH.DataSource = dtDSCT;
                    total = total + int.Parse(lblThanhTien.Text);
                    lblTotal.Text = total.ToString();
                }
                else
                {
                    MessageBox.Show("Số lượng không dủ", "Lỗi");
                    txtPriceHHHD.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã hóa đơn không được trống", "Lỗi");
                txtCodeHD.Focus();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (vitriclick < dtDSCT.Rows.Count)
            {
                dtDSCT.Rows.RemoveAt(vitriclick);
                dtgvDSHH.DataSource = dtDSCT;
            }
        }

        private void txtCodeHD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ctCtr.GetData(txtCodeHD.Text.Trim());
                dtgvDSHH.DataSource = dt;

            }
            catch
            {
                dtgvDSHH.DataSource = null;
            }
            return;
        }

        private void btnDelHD_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (hdCtr.DelData(txtCodeHD.Text.Trim()))
                    MessageBox.Show("Xóa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Xóa không thành công", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(sender, e);
        }

        private void btnSaveHD_Click(object sender, EventArgs e)
        {
            if (flagLuu == 10)
            {
                HoaDonObj hdObj = new HoaDonObj();
                addDataHD(hdObj);
                if (hdCtr.AddData(hdObj))
                {
                    if (ctCtr.AddData(dtDSCT) && hhCtr.UpdSL(dtDSCT))
                    {
                        MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("Bạn có muốn in hoa don không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes) {
                            //todo
                            frmReportHD frmHD = new frmReportHD(txtCodeHD.Text);
                            frmHD.ShowDialog();
                        }
                        else
                            return;
                    }
                    else
                        MessageBox.Show("Thêm chi tiết không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Thêm hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            Form1_Load(sender, e);
        }

        private void btnCancleHD_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Form1_Load(sender, e);
            else
                return;
        }

        private void btnAddHD_Click(object sender, EventArgs e)
        {
            flagLuu = 10;
            DisEnlHD(true);
            clearDataHD();
            LoadcmbHH();
            LoadcmbKhachHang();
            if (i == 1)
            {
                dtDSCT.Rows.Clear();
                dtDSCT.Columns.Add("MaHD");
                dtDSCT.Columns.Add("HangHoa");
                dtDSCT.Columns.Add("DonGia");
                dtDSCT.Columns.Add("SoLuong");
                dtDSCT.Columns.Add("ThanhTien");
                i = i - 1;
            }
            else return;
        }

        private void lbTotal_Click(object sender, EventArgs e)
        {

        }

        private void lbTotal_TextChanged(object sender, EventArgs e)
        {
            lblThanhTien.Text = (double.Parse(txtPriceHHHD.Text) * int.Parse(txtNumberHH.Text)).ToString();
        }

        private void cbbHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = hhCtr.GetData("Where MaHH = '" + cbbHH.SelectedValue.ToString() + "'");
            if (dt.Rows.Count > 0)
            {
                double gia = double.Parse(dt.Rows[0][2].ToString());

                txtPriceHHHD.Text = (gia * 1.1).ToString();

                lblThanhTien.Text = (double.Parse(txtPriceHHHD.Text) * int.Parse(txtNumberHH.Text)).ToString();
            }
        }

        private void dtgvDSHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitriclick = e.RowIndex;
        }

        private void txtNumberHH_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNumberHH.Text.Trim() != "")
            {
                if(int.Parse(txtNumberHH.Text) > 0)
                {
                    lblThanhTien.Text = (double.Parse(txtPriceHHHD.Text) * int.Parse(txtNumberHH.Text)).ToString();
                }
            }
            

        }

        private void rpNhanVien_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReportNV frm = new frmReportNV();
            frm.ShowDialog();
        }
    }
}
