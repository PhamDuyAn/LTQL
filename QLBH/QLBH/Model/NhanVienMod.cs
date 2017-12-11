using QLBanHang.Connection;
using QLBanHang.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Model
{
    class NhanVienMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select MaNV, TenNV, GioiTinh, NamSinh, Luong, DiaChi, SDT, MatKhau  from tb_NhanVien";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return dt;
        }
        //public NhanVienObj GetDataByID(String ID)
        //{
        //    NhanVienObj nv = new NhanVienObj();
        //    DataTable dt = new DataTable();
        //    cmd.CommandText = "select MaNV, TenNV, GioiTinh, NamSinh, Luong, DiaChi, SDT, MatKhau  from tb_NhanVien WHERE MaNV = '"+ID+"'";
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con.Connection;
        //    try
        //    {
        //        con.OpenConn();
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        sda.Fill(nv);
        //    }
        //    catch (Exception ex)
        //    {
        //        string mex = ex.Message;
        //        cmd.Dispose();
        //        con.CloseConn();
        //    }
        //    return dt;
        //}

        public bool AddData(NhanVienObj nvObj)
        {

            cmd.CommandText = "Insert into tb_NhanVien values ('" + nvObj.MaNhanVien + "',N'" + nvObj.TenNhanVien + "',N'" + nvObj.GioiTinh + "',CONVERT(DATE,'" + nvObj.NamSinh + "',103),N'" + nvObj.DiaChi + "','" + nvObj.DienThoai + "','" + nvObj.MatKhau + "','" + nvObj.Luong + "')";
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
                return false;
            }
        }

        public bool UpdData(NhanVienObj nvObj)
        {
            cmd.CommandText = "Update tb_NhanVien set TenNV =  N'" + nvObj.TenNhanVien + "', GioiTinh = N'" + nvObj.GioiTinh + "', NamSinh = CONVERT(DATE,'" + nvObj.NamSinh + "',103), DiaChi = N'" + nvObj.DiaChi + "',SDT = '" + nvObj.DienThoai + "',Luong='" + nvObj.Luong + "',MatKhau= '" + nvObj.MatKhau + "' Where MaNV = '" + nvObj.MaNhanVien + "'";
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


        //public bool UpdMK(NhanVienObj nvObj)
        //{
        //    cmd.CommandText = "Update tb_NhanVien set MatKhau ='" + nvObj.MatKhau + "' Where MaNV = '" + nvObj.MaNhanVien + "'";
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con.Connection;
        //    try
        //    {
        //        con.OpenConn();
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string mex = ex.Message;
        //        cmd.Dispose();
        //        con.CloseConn();
        //    }
        //    return false;
        //}

        public bool DelData(string ma)
        {
            cmd.CommandText = "Delete tb_NhanVien Where MaNV = '" + ma + "'";
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
