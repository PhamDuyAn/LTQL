using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH.View
{
    public partial class frmReportHD : Form
    {
        private string _message;
        public frmReportHD()
        {
            InitializeComponent();
        }

        public frmReportHD(string message):this()//tạo hàm chứa tham số
        {
            _message = message;
            txtReportMaHD.Text = _message;//gán biến đó bằng lbS
        }
        private void frmReportHD_Load(object sender, EventArgs e)
        {
            this.view_HoaDonTableAdapter1.Fill(this.qL_BanHangDataSet.View_HoaDon,txtReportMaHD.Text);
            this.view_HoaDonTableAdapter.Fill(this.dataSetRpHD1.View_HoaDon, txtReportMaHD.Text);

            this.reportViewer1.RefreshReport();
        }

        private void btnReportDate_Click(object sender, EventArgs e)
        {
            //this.view_ReportHDTableAdapter.Fill(this.dataSetRpHD.View_ReportHD, txtReportMaHD.Text);
            this.view_HoaDonTableAdapter1.Fill(this.qL_BanHangDataSet.View_HoaDon, txtReportMaHD.Text);
            this.reportViewer1.RefreshReport();
           
        }

        private void txtReportMaHD_KeyUp(object sender, KeyEventArgs e)
        {
            this.view_HoaDonTableAdapter1.Fill(this.qL_BanHangDataSet.View_HoaDon, txtReportMaHD.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
