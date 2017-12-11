using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLBanHang.Connection;
using System.Data.SqlClient;
using QLBanHang.Object;

namespace QLBanHang.Model
{
    class NhaCCMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select MaNCC, TenNCC, DiaChi, SDT from tb_NhaCC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);//lưu dl vào da
                sda.Fill(dt);//đổ dl vào bảng ảo
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return dt;
        }

        public bool AddData(NhaCCObj nccObj)
        {
            cmd.CommandText = "Insert into tb_NhaCC values ('" + nccObj.MaNCC + "',N'" + nccObj.TenNCC + "',N'" + nccObj.DiaChi + "','" + nccObj.SDT + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }

        public bool UpdData(NhaCCObj nccObj)
        {
            cmd.CommandText = "Update tb_NhaCC set TenNCC =  N'" + nccObj.TenNCC + "', DiaChi = N'" + nccObj.DiaChi + "', SDT = '" + nccObj.SDT + "' Where MaNCC = '" + nccObj.MaNCC + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }



        public bool DelData(string ma)
        {
            cmd.CommandText = "Delete tb_NhaCC Where MaNCC = '" + ma + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
    }
}
