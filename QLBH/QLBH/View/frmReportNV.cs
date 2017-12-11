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
    public partial class frmReportNV : Form
    {
        public frmReportNV()
        {
            InitializeComponent();
        }

        private void frmReportNV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetNhanVien.tb_NhanVien' table. You can move, or remove it, as needed.
            this.tb_NhanVienTableAdapter.Fill(this.dataSetNhanVien.tb_NhanVien);

            this.reportViewer1.RefreshReport();
        }
    }
}
