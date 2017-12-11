﻿using QLBanHang.Connection;
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
    class HoaDonMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = @"select hd.MaHD, hd.NgayLap, nv.TenNV, kh.TenKH from tb_HoaDon hd, tb_KhachHang kh, tb_NhanVien nv where kh.MaKH = hd.KhachHang and nv.MaNV = hd.NguoiLap";
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
        //private DataTable GetHDKH(KhachHangObj khObj)
        //{
        //    DataTable dt = new DataTable();
        //    cmd.CommandText = @"select hd.MaHD, hd.NgayLap, nv.TenNV, kh.TenKH from tb_HoaDon hd, tb_KhachHang kh, tb_NhanVien nv where kh.MaKH = hd.KhachHang and nv.MaNV = hd.NguoiLap and kh.MaKH='"+khObj.MaKhachHang+"'";
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con.Connection;
        //    try
        //    {
        //        con.OpenConn();
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        sda.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        string mex = ex.Message;
        //        cmd.Dispose();
        //        con.CloseConn();
        //    }
        //    return dt;
        //}

        //public bool AddData(HoaDonObj hdObj)
        //{
        //    cmd.CommandText = "insert into tb_HoaDon values ('" + hdObj.MaHoaDon + "', CONVERT (date,'" + hdObj.NgayLap + "',103),'" + hdObj.NguoiLap + "','" + hdObj.KhachHang + "')";
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
        public bool AddData(HoaDonObj hdObj)
        {
            cmd.CommandText = "INSERT INTO tb_HoaDon values ('" + hdObj.MaHoaDon + "','" + hdObj.NgayLap + "','" + hdObj.NguoiLap + "', '" + hdObj.KhachHang + "' )";
            //cmd.CommandText = "INSERT INTO tb_HoaDon values ('" + hdObj.MaHoaDon + "', CONVERT(date,'" + hdObj.NgayLap + "',103),'" + hdObj.NguoiLap + "', '" + hdObj.KhachHang + "' )";
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
            DelDataCTHD(ma);
            //cmd.CommandText = "Delete tb_CTHD Where MaHD = '" + ma + "'";
            cmd.CommandText = "Delete tb_HoaDon Where MaHD = '" + ma + "'";
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
        public bool DelDataCTHD(string ma)
        {
            cmd.CommandText = "Delete tb_CTHD Where MaHD = '" + ma + "'";
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
