namespace _3_PL.View
{
    partial class frmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.llQuanMatKhau = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPasswork = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbHienThiMatKhau = new System.Windows.Forms.CheckBox();
            this.txtHienThiMatKhau = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(61, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(158, 102);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderText = "ex: tranvanquy@gmail.com";
            this.txtUserName.Size = new System.Drawing.Size(268, 23);
            this.txtUserName.TabIndex = 1;
            // 
            // llQuanMatKhau
            // 
            this.llQuanMatKhau.AutoSize = true;
            this.llQuanMatKhau.Location = new System.Drawing.Point(337, 188);
            this.llQuanMatKhau.Name = "llQuanMatKhau";
            this.llQuanMatKhau.Size = new System.Drawing.Size(89, 15);
            this.llQuanMatKhau.TabIndex = 3;
            this.llQuanMatKhau.TabStop = true;
            this.llQuanMatKhau.Text = "Quên mật khẩu";
            this.llQuanMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llQuanMatKhau_LinkClicked);
            this.llQuanMatKhau.Click += new System.EventHandler(this.llQuanMatKhau_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(90, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu:";
            // 
            // txtPasswork
            // 
            this.txtPasswork.Location = new System.Drawing.Point(158, 146);
            this.txtPasswork.Name = "txtPasswork";
            this.txtPasswork.PasswordChar = '*';
            this.txtPasswork.Size = new System.Drawing.Size(268, 23);
            this.txtPasswork.TabIndex = 1;
            this.txtPasswork.TextChanged += new System.EventHandler(this.txtPasswork_TextChanged);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.RosyBrown;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDangNhap.ForeColor = System.Drawing.Color.Black;
            this.btnDangNhap.Location = new System.Drawing.Point(188, 224);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(143, 39);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("NSimSun", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(158, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 43);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đăng nhập";
            // 
            // cbHienThiMatKhau
            // 
            this.cbHienThiMatKhau.AutoSize = true;
            this.cbHienThiMatKhau.ForeColor = System.Drawing.Color.Black;
            this.cbHienThiMatKhau.Location = new System.Drawing.Point(158, 184);
            this.cbHienThiMatKhau.Name = "cbHienThiMatKhau";
            this.cbHienThiMatKhau.Size = new System.Drawing.Size(121, 19);
            this.cbHienThiMatKhau.TabIndex = 5;
            this.cbHienThiMatKhau.Text = "Hiển thị mật khẩu";
            this.cbHienThiMatKhau.UseVisualStyleBackColor = true;
            this.cbHienThiMatKhau.CheckedChanged += new System.EventHandler(this.cbHienThiMatKhau_CheckedChanged);
            // 
            // txtHienThiMatKhau
            // 
            this.txtHienThiMatKhau.Location = new System.Drawing.Point(158, 146);
            this.txtHienThiMatKhau.Name = "txtHienThiMatKhau";
            this.txtHienThiMatKhau.Size = new System.Drawing.Size(268, 23);
            this.txtHienThiMatKhau.TabIndex = 1;
            this.txtHienThiMatKhau.Visible = false;
            this.txtHienThiMatKhau.TextChanged += new System.EventHandler(this.txtHienThiMatKhau_TextChanged);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(499, 300);
            this.Controls.Add(this.cbHienThiMatKhau);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.llQuanMatKhau);
            this.Controls.Add(this.txtPasswork);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHienThiMatKhau);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.TransparencyKey = System.Drawing.Color.PaleTurquoise;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtUserName;
        private LinkLabel llQuanMatKhau;
        private Label label2;
        private TextBox txtPasswork;
        private Button btnDangNhap;
        private Label label3;
        private CheckBox cbHienThiMatKhau;
        private TextBox txtHienThiMatKhau;
    }
}