using QLBanHang.Connection;
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

namespace QLBH.View
{
    public partial class AddNewAccount : Form
    {
        string connection = @"Data Source=DESKTOP-IQ8SNUJ;Initial Catalog=QL_BanHang;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        public AddNewAccount()
        {
            InitializeComponent();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            if (txtTen.Text.Trim() == "")
            {
                errorProvider1.SetError(txtTen, "Bạn chưa nhập tài khoản!");
                return;

            }
            if (txtMK.Text.Trim() == "")
            {
                errorProvider1.SetError(txtMK, "Bạn chưa nhập tài khoản!");
                return;
            }
            if (txtLMK.Text.Trim() == "")
            {
                errorProvider1.SetError(txtLMK, "Bạn chưa nhập tài khoản!");
                return;
            }
            try
            {

                if (txtMK.Text.Trim() == txtLMK.Text.Trim())
                {
                    try
                    {
                        con = new SqlConnection(connection);
                        con.Open();
                        string sql1 = "Insert into tb_Account values('" + txtTenTK.Text.Trim() + "','" + txtLMK.Text.Trim() + "',N'" + txtTen.Text.Trim() + "')";//chuỗi kết nối đến bảng acount
                        cmd = new SqlCommand(sql1, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Nhập lại mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối thất bại");
            }
            finally
            {
                con.Close();
            }
            txtTen.Clear();
            txtTenTK.Clear();
            txtMK.Clear();
            txtLMK.Clear();
        }

        private void txtTenTK_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (txtTenTK.Text.Trim() == "")
            {
                errorProvider1.SetError(txtTenTK, "Bạn chưa nhập tài khoản!");
                return;
            }
            try
            {
                con = new SqlConnection(connection);
                con.Open();


                string sql = "select COUNT(*) from tb_Account where TaiKhoan=@taiKhoan";//chuỗi kết nối đến bảng acount
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@taiKhoan", txtTenTK.Text.Trim()));

                int x = (int)cmd.ExecuteScalar();
                if (x == 1)

                    lbShow.Text = "Tên tài khoản đã tồn tại";
                else
                    lbShow.Text = "Bạn có thể sử dụng tài khoản này";


            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối thất bại");
            }
            finally
            {
                con.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddNewAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
