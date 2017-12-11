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
    public partial class frmChooseReport : Form
    {
        public frmChooseReport()
        {
            InitializeComponent();
        }

        private void btnrpHoaDon_Click(object sender, EventArgs e)
        {
            frmReportHD frm = new frmReportHD();
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelReport.Controls.Add(frm);
            panelReport.Controls.Remove(btnrpHoaDon);
            panelReport.Controls.Remove(btnrpHangHoa);
            panelReport.Controls.Remove(btnrpKhachHang);
            panelReport.Controls.Remove(btnrpNhanVien);
            panelReport.Controls.Remove(button6);
            panelReport.Controls.Remove(btnrpNhaCC);

        }

        private void frmChooseReport_Load(object sender, EventArgs e)
        {

        }
    }
}
