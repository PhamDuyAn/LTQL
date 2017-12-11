using QLBanHang.Connection;
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

namespace QLBH.View
{
    public partial class EditPassWord : Form
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();
        public EditPassWord()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "")
            {
                errorProvider1.SetError(txtMa, "Bạn chưa nhập tài khoản.");//thông báo lỗi erroprovider
                return;
            }
            else
            if (txtMKC.Text == "")
            {
                errorProvider1.SetError(txtMKC, "Bạn chưa nhập mật khẩu cũ.");//thông báo lỗi erroprovider
                return;
            }
            else
            if (txtLMKM.Text == "")
            {
                errorProvider1.SetError(txtMKM, "Bạn chưa nhập Mật khẩu mới.");//thông báo lỗi erroprovider
                return;
            }
            else
            if (txtLMKM.Text == "")
            {
                errorProvider1.SetError(txtLMKM, "Bạn chưa nhập lại mật khẩu mới.");//thông báo lỗi erroprovider
                return;
            }
            else
            {
                try
                {

                    cmd.CommandText = "select COUNT(*) from tb_Account where TaiKhoan=@tk And MatKhau=@mk";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.Connection;
                    con.OpenConn();
                    cmd.Parameters.Add(new SqlParameter("@tk", txtMa.Text));
                    cmd.Parameters.Add(new SqlParameter("@mk", txtMKC.Text));
                    int x = (int)cmd.ExecuteScalar();
                    if (x == 1)
                    {
                        if (txtLMKM.Text.Trim() == txtMKM.Text.Trim())
                        {
                            try
                            {
                                cmd.CommandText = "Update tb_Account set MatKhau='" + txtLMKM.Text.Trim() + "' Where TaiKhoan = '" + txtMa.Text.Trim() + "'";//chuỗi kết nối đến bảng acount
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = con.Connection;
                                con.OpenConn();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                            }
                            catch
                            {
                                MessageBox.Show("Đổi mk thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Nhập lại mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {

                            cmd.CommandText = "select COUNT(*) from tb_NhanVien where MaNV=@Manv And MatKhau=@mknv";//chuỗi kết nối đến NV acount
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con.Connection;
                            con.OpenConn();
                            cmd.Parameters.Add(new SqlParameter("@Manv", txtMa.Text));
                            cmd.Parameters.Add(new SqlParameter("@mknv", txtMKC.Text));
                            int x1 = (int)cmd.ExecuteScalar();
                            if (x1 == 1)
                            {
                                if (txtLMKM.Text.Trim() == txtMKM.Text.Trim())
                                {
                                    try
                                    {
                                        cmd.CommandText = "Update tb_NhanVien set MatKhau='" + txtLMKM.Text + "' Where MaNV = '" + txtMa.Text + "'";//chuỗi kết nối đến bảng acount
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Connection = con.Connection;
                                        con.OpenConn();
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Đổi mk thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Nhập lại mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }


                        }
                        catch (Exception)
                        {
                            
                        }

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Kết nối thất bại");

                }
                finally
                {
                    con.CloseConn();
                }
                txtMa.Clear();
                txtMKC.Clear();
                txtMKM.Clear();
                txtLMKM.Clear();
                
            }
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EditPassWord_Load(object sender, EventArgs e)
        {

        }
    }
}
