namespace QLBH.View
{
    partial class frmReportHD
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.viewHoaDonBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.qL_BanHangDataSet = new QLBH.QL_BanHangDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReportMaHD = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnReportDate = new System.Windows.Forms.Button();
            this.View_HoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetRpHD = new QLBH.DataSetRpHD();
            this.viewHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.View_ReportHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewReportHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewHoaDonBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetRpHD1 = new QLBH.DataSetRpHD();
            this.viewHoaDonBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.view_HoaDonTableAdapter = new QLBH.DataSetRpHDTableAdapters.View_HoaDonTableAdapter();
            this.view_HoaDonTableAdapter1 = new QLBH.QL_BanHangDataSetTableAdapters.View_HoaDonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.viewHoaDonBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qL_BanHangDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_HoaDonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetRpHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHoaDonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_ReportHDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewReportHDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHoaDonBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetRpHD1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHoaDonBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // viewHoaDonBindingSource3
            // 
            this.viewHoaDonBindingSource3.DataMember = "View_HoaDon";
            this.viewHoaDonBindingSource3.DataSource = this.qL_BanHangDataSet;
            // 
            // qL_BanHangDataSet
            // 
            this.qL_BanHangDataSet.DataSetName = "QL_BanHangDataSet";
            this.qL_BanHangDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Hóa Đơn";
            // 
            // txtReportMaHD
            // 
            this.txtReportMaHD.Location = new System.Drawing.Point(76, 6);
            this.txtReportMaHD.Name = "txtReportMaHD";
            this.txtReportMaHD.Size = new System.Drawing.Size(250, 20);
            this.txtReportMaHD.TabIndex = 1;
            this.txtReportMaHD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtReportMaHD_KeyUp);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.viewHoaDonBindingSource3;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLBH.ReportviewHD.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(8, 32);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(756, 325);
            this.reportViewer1.TabIndex = 7;
            // 
            // btnReportDate
            // 
            this.btnReportDate.Location = new System.Drawing.Point(332, 5);
            this.btnReportDate.Name = "btnReportDate";
            this.btnReportDate.Size = new System.Drawing.Size(62, 22);
            this.btnReportDate.TabIndex = 2;
            this.btnReportDate.Text = "Search";
            this.btnReportDate.UseVisualStyleBackColor = true;
            this.btnReportDate.Click += new System.EventHandler(this.btnReportDate_Click);
            // 
            // View_HoaDonBindingSource
            // 
            this.View_HoaDonBindingSource.DataMember = "View_HoaDon";
            this.View_HoaDonBindingSource.DataSource = this.dataSetRpHD;
            // 
            // dataSetRpHD
            // 
            this.dataSetRpHD.DataSetName = "DataSetRpHD";
            this.dataSetRpHD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewHoaDonBindingSource
            // 
            this.viewHoaDonBindingSource.DataMember = "View_HoaDon";
            this.viewHoaDonBindingSource.DataSource = this.dataSetRpHD;
            // 
            // View_ReportHDBindingSource
            // 
            this.View_ReportHDBindingSource.DataMember = "View_ReportHD";
            this.View_ReportHDBindingSource.DataSource = this.dataSetRpHD;
            // 
            // viewReportHDBindingSource
            // 
            this.viewReportHDBindingSource.DataMember = "View_ReportHD";
            this.viewReportHDBindingSource.DataSource = this.dataSetRpHD;
            // 
            // viewHoaDonBindingSource1
            // 
            this.viewHoaDonBindingSource1.DataMember = "View_HoaDon";
            this.viewHoaDonBindingSource1.DataSource = this.dataSetRpHD;
            // 
            // dataSetRpHD1
            // 
            this.dataSetRpHD1.DataSetName = "DataSetRpHD";
            this.dataSetRpHD1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewHoaDonBindingSource2
            // 
            this.viewHoaDonBindingSource2.DataMember = "View_HoaDon";
            this.viewHoaDonBindingSource2.DataSource = this.dataSetRpHD1;
            // 
            // view_HoaDonTableAdapter
            // 
            this.view_HoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // view_HoaDonTableAdapter1
            // 
            this.view_HoaDonTableAdapter1.ClearBeforeFill = true;
            // 
            // frmReportHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 369);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnReportDate);
            this.Controls.Add(this.txtReportMaHD);
            this.Controls.Add(this.label1);
            this.Name = "frmReportHD";
            this.Text = "frmReportHD";
            this.Load += new System.EventHandler(this.frmReportHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewHoaDonBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qL_BanHangDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_HoaDonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetRpHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHoaDonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_ReportHDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewReportHDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHoaDonBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetRpHD1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHoaDonBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReportMaHD;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetRpHD dataSetRpHD;
        private System.Windows.Forms.BindingSource viewReportHDBindingSource;
        private System.Windows.Forms.Button btnReportDate;
        private System.Windows.Forms.BindingSource View_ReportHDBindingSource;
        private System.Windows.Forms.BindingSource viewHoaDonBindingSource;
        private System.Windows.Forms.BindingSource viewHoaDonBindingSource1;
        private System.Windows.Forms.BindingSource View_HoaDonBindingSource;
        private DataSetRpHD dataSetRpHD1;
        private System.Windows.Forms.BindingSource viewHoaDonBindingSource2;
        private DataSetRpHDTableAdapters.View_HoaDonTableAdapter view_HoaDonTableAdapter;
        private QL_BanHangDataSet qL_BanHangDataSet;
        private System.Windows.Forms.BindingSource viewHoaDonBindingSource3;
        private QL_BanHangDataSetTableAdapters.View_HoaDonTableAdapter view_HoaDonTableAdapter1;
    }
}