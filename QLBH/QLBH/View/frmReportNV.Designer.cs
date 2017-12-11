namespace QLBH.View
{
    partial class frmReportNV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetNhanVien = new QLBH.DataSetNhanVien();
            this.dataSetNhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbNhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_NhanVienTableAdapter = new QLBH.DataSetNhanVienTableAdapters.tb_NhanVienTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNhanVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSetNhanVien";
            reportDataSource1.Value = this.tbNhanVienBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLBH.ReportNhanVien.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 42);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(811, 343);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetNhanVien
            // 
            this.dataSetNhanVien.DataSetName = "DataSetNhanVien";
            this.dataSetNhanVien.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetNhanVienBindingSource
            // 
            this.dataSetNhanVienBindingSource.DataSource = this.dataSetNhanVien;
            this.dataSetNhanVienBindingSource.Position = 0;
            // 
            // tbNhanVienBindingSource
            // 
            this.tbNhanVienBindingSource.DataMember = "tb_NhanVien";
            this.tbNhanVienBindingSource.DataSource = this.dataSetNhanVienBindingSource;
            // 
            // tb_NhanVienTableAdapter
            // 
            this.tb_NhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 397);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportNV";
            this.Text = "frmReportNV";
            this.Load += new System.EventHandler(this.frmReportNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNhanVienBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataSetNhanVienBindingSource;
        private DataSetNhanVien dataSetNhanVien;
        private System.Windows.Forms.BindingSource tbNhanVienBindingSource;
        private DataSetNhanVienTableAdapters.tb_NhanVienTableAdapter tb_NhanVienTableAdapter;
    }
}