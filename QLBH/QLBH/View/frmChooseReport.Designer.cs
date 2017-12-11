namespace QLBH.View
{
    partial class frmChooseReport
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
            this.btnrpNhanVien = new System.Windows.Forms.Button();
            this.btnrpHangHoa = new System.Windows.Forms.Button();
            this.btnrpHoaDon = new System.Windows.Forms.Button();
            this.btnrpKhachHang = new System.Windows.Forms.Button();
            this.btnrpNhaCC = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panelReport = new System.Windows.Forms.Panel();
            this.panelReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnrpNhanVien
            // 
            this.btnrpNhanVien.Location = new System.Drawing.Point(11, 29);
            this.btnrpNhanVien.Name = "btnrpNhanVien";
            this.btnrpNhanVien.Size = new System.Drawing.Size(183, 82);
            this.btnrpNhanVien.TabIndex = 0;
            this.btnrpNhanVien.Text = "Nhân Viên";
            this.btnrpNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnrpHangHoa
            // 
            this.btnrpHangHoa.Location = new System.Drawing.Point(200, 29);
            this.btnrpHangHoa.Name = "btnrpHangHoa";
            this.btnrpHangHoa.Size = new System.Drawing.Size(183, 82);
            this.btnrpHangHoa.TabIndex = 0;
            this.btnrpHangHoa.Text = "Hàng Hóa";
            this.btnrpHangHoa.UseVisualStyleBackColor = true;
            // 
            // btnrpHoaDon
            // 
            this.btnrpHoaDon.Location = new System.Drawing.Point(389, 29);
            this.btnrpHoaDon.Name = "btnrpHoaDon";
            this.btnrpHoaDon.Size = new System.Drawing.Size(183, 82);
            this.btnrpHoaDon.TabIndex = 0;
            this.btnrpHoaDon.Text = "Hóa Dơn";
            this.btnrpHoaDon.UseVisualStyleBackColor = true;
            this.btnrpHoaDon.Click += new System.EventHandler(this.btnrpHoaDon_Click);
            // 
            // btnrpKhachHang
            // 
            this.btnrpKhachHang.Location = new System.Drawing.Point(11, 117);
            this.btnrpKhachHang.Name = "btnrpKhachHang";
            this.btnrpKhachHang.Size = new System.Drawing.Size(183, 82);
            this.btnrpKhachHang.TabIndex = 0;
            this.btnrpKhachHang.Text = "Khách Hàng";
            this.btnrpKhachHang.UseVisualStyleBackColor = true;
            // 
            // btnrpNhaCC
            // 
            this.btnrpNhaCC.Location = new System.Drawing.Point(200, 117);
            this.btnrpNhaCC.Name = "btnrpNhaCC";
            this.btnrpNhaCC.Size = new System.Drawing.Size(183, 82);
            this.btnrpNhaCC.TabIndex = 0;
            this.btnrpNhaCC.Text = "Nhà Cung Cấp";
            this.btnrpNhaCC.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(389, 117);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(183, 82);
            this.button6.TabIndex = 0;
            this.button6.Text = "button1";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // panelReport
            // 
            this.panelReport.Controls.Add(this.button6);
            this.panelReport.Controls.Add(this.btnrpNhaCC);
            this.panelReport.Controls.Add(this.btnrpKhachHang);
            this.panelReport.Controls.Add(this.btnrpHoaDon);
            this.panelReport.Controls.Add(this.btnrpHangHoa);
            this.panelReport.Controls.Add(this.btnrpNhanVien);
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReport.Location = new System.Drawing.Point(0, 0);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(599, 318);
            this.panelReport.TabIndex = 1;
            // 
            // frmChooseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 318);
            this.Controls.Add(this.panelReport);
            this.Name = "frmChooseReport";
            this.Text = "frmChooseReport";
            this.Load += new System.EventHandler(this.frmChooseReport_Load);
            this.panelReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnrpNhanVien;
        private System.Windows.Forms.Button btnrpHangHoa;
        private System.Windows.Forms.Button btnrpHoaDon;
        private System.Windows.Forms.Button btnrpKhachHang;
        private System.Windows.Forms.Button btnrpNhaCC;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panelReport;
    }
}