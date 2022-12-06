namespace _3_PL.View
{
    partial class FrmLichSuDiemTieuDung
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDatetime = new System.Windows.Forms.Button();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.dgridLichSu = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBac = new System.Windows.Forms.Label();
            this.txtDiemConLai = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtBac = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgridLichSu)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoad.Location = new System.Drawing.Point(352, 433);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(138, 46);
            this.btnLoad.TabIndex = 20;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDown
            // 
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(452, 102);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(33, 36);
            this.btnDown.TabIndex = 31;
            this.toolTip1.SetToolTip(this.btnDown, "Sắp xếp theo điểm giảm dần");
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(413, 102);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(33, 36);
            this.btnUp.TabIndex = 32;
            this.toolTip1.SetToolTip(this.btnUp, "Sắp xếp theo điểm tăng dần");
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnDatetime
            // 
            this.btnDatetime.FlatAppearance.BorderSize = 0;
            this.btnDatetime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatetime.Location = new System.Drawing.Point(374, 102);
            this.btnDatetime.Name = "btnDatetime";
            this.btnDatetime.Size = new System.Drawing.Size(33, 36);
            this.btnDatetime.TabIndex = 33;
            this.toolTip1.SetToolTip(this.btnDatetime, "Sắp xếp theo tgian mua hàng");
            this.btnDatetime.UseVisualStyleBackColor = true;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(387, 67);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(103, 27);
            this.txtMa.TabIndex = 34;
            // 
            // dgridLichSu
            // 
            this.dgridLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridLichSu.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dgridLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridLichSu.Location = new System.Drawing.Point(12, 144);
            this.dgridLichSu.Name = "dgridLichSu";
            this.dgridLichSu.RowHeadersWidth = 51;
            this.dgridLichSu.RowTemplate.Height = 29;
            this.dgridLichSu.Size = new System.Drawing.Size(495, 272);
            this.dgridLichSu.TabIndex = 30;
            this.dgridLichSu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridLichSu_CellClick);
            this.dgridLichSu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridLichSu_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(312, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Mã KH:";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTen.Location = new System.Drawing.Point(12, 67);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(144, 23);
            this.lblTen.TabIndex = 23;
            this.lblTen.Text = "Tên khách hàng: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 60);
            this.panel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lịch sử dùng điểm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(131, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 23);
            this.label6.TabIndex = 29;
            this.label6.Text = "Số điểm còn lại";
            // 
            // lblBac
            // 
            this.lblBac.AutoSize = true;
            this.lblBac.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBac.Location = new System.Drawing.Point(12, 103);
            this.lblBac.Name = "lblBac";
            this.lblBac.Size = new System.Drawing.Size(43, 23);
            this.lblBac.TabIndex = 27;
            this.lblBac.Text = "Bậc:";
            // 
            // txtDiemConLai
            // 
            this.txtDiemConLai.Location = new System.Drawing.Point(265, 103);
            this.txtDiemConLai.Name = "txtDiemConLai";
            this.txtDiemConLai.Size = new System.Drawing.Size(103, 27);
            this.txtDiemConLai.TabIndex = 35;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(149, 66);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(103, 27);
            this.txtTenKH.TabIndex = 36;
            // 
            // txtBac
            // 
            this.txtBac.Location = new System.Drawing.Point(53, 102);
            this.txtBac.Name = "txtBac";
            this.txtBac.Size = new System.Drawing.Size(103, 27);
            this.txtBac.TabIndex = 37;
            // 
            // FrmLichSuDiemTieuDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(525, 498);
            this.Controls.Add(this.txtBac);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.txtDiemConLai);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.dgridLichSu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDatetime);
            this.Controls.Add(this.lblBac);
            this.Name = "FrmLichSuDiemTieuDung";
            this.Text = "FrmLichSuDiemTieuDung";
            ((System.ComponentModel.ISupportInitialize)(this.dgridLichSu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnLoad;
        private ToolTip toolTip1;
        public Button btnDown;
        public Button btnUp;
        public Button btnDatetime;
        public TextBox txtMa;
        public DataGridView dgridLichSu;
        public Label label4;
        public Label lblTen;
        private Panel panel1;
        private Label label1;
        public Label label6;
        public Label lblBac;
        public TextBox txtDiemConLai;
        public TextBox txtTenKH;
        public TextBox txtBac;
    }
}