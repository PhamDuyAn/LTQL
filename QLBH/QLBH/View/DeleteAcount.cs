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
    public partial class DeleteAcount : Form
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();
        public DeleteAcount()
        {
            InitializeComponent();
        }

        private void DeleteAcount_Load(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                errorProvider1.SetError(txtTen, "Bạn chưa nhập tài khỏan");//thông báo lỗi erroprovider
                return;
            }

            else if (txtTen.Text.Trim() == "admin")
            {
                MessageBox.Show("Bạn không thể xóa tài khoản admin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Clear();
            }
            else
            {
                try
                {
                    cmd.CommandText = "select COUNT(*) from tb_Account where TaiKhoan=@taiKhoan";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.Connection;
                    con.OpenConn();
                    cmd.Parameters.Add(new SqlParameter("@taiKhoan", txtTen.Text.Trim()));

                    int x = (int)cmd.ExecuteScalar();
                    if (x == 1)
                    {
                        try
                        {
                            DialogResult hoi;
                            hoi = MessageBox.Show("Bạn có muốn Xóa không", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (hoi == DialogResult.Yes)
                            {
                                try
                                {
                                    cmd.CommandText = "Delete tb_Account Where TaiKhoan = '" + txtTen.Text.Trim() + "'";
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = con.Connection;
                                    con.OpenConn();
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Hide();
                                }
                                catch
                                {
                                    MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            return;

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Kết nối thất bại");
                        }
                        txtTen.Clear();
                    }
                    else
                        lbShow.Text = "Tài khoản không tồn tại";


                }
                catch (Exception)
                {
                    MessageBox.Show("Kết nối thất bại");
                }
                finally
                {
                    con.CloseConn();
                }
            }
        }
    }
}
