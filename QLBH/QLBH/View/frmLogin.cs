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
    public partial class frmLogin : Form
    {
        string connection = @"Data Source=DESKTOP-IQ8SNUJ;Initial Catalog=QL_BanHang;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(connection);
                con.Open();
                string sql = "select COUNT(*) from tb_Account where TaiKhoan=@Acc And MatKhau=@Pass";//chuỗi kết nối đến bảng acount
                cmd = new SqlCommand(sql, con);//doc lenh
                cmd.Parameters.Add(new SqlParameter("@Acc", txtUser.Text));
                cmd.Parameters.Add(new SqlParameter("@Pass", txtPassword.Text));
                int x = (int)cmd.ExecuteScalar();
                if (x == 1)
                {
                    this.Hide();
                    Form1 b = new Form1(txtUser.Text);//
                    b.ShowDialog();
                }
                else
                {
                    con = new SqlConnection(connection);
                    con.Open();
                    string sql1 = "select COUNT(*) from tb_NhanVien where MaNV=@Manv And MatKhau=@mknv";//chuỗi kết nối đến bảng acount
                    cmd = new SqlCommand(sql1, con);
                    cmd.Parameters.Add(new SqlParameter("@Manv", txtUser.Text));
                    cmd.Parameters.Add(new SqlParameter("@mknv", txtPassword.Text));
                    int x1 = (int)cmd.ExecuteScalar();
                    if (x1 == 1)
                    {
                        this.Hide();
                        Form1 b = new Form1("Nhân viên");//
                        b.ShowDialog();
                    }
                    else
                    {
                        lbShow.Text = "Tài khoản hoặc mật khẩu không đúng";
                        txtPassword.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                string mex = ex.Message;

                MessageBox.Show("Kết nối thất bại"+mex);
            }
            finally
            {
                con.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            txtPassword.UseSystemPasswordChar = false;
            else txtPassword.UseSystemPasswordChar = true;
        }
    }
}
