namespace _3_PL.View
{
    partial class Frm_ImportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ImportExcel));
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.dgv_product = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.Connection = null;
            this.sqlCommand1.Notification = null;
            this.sqlCommand1.Transaction = null;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.RosyBrown;
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(969, 393);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(135, 28);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // dgv_product
            // 
            this.dgv_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_product.Location = new System.Drawing.Point(3, 3);
            this.dgv_product.Name = "dgv_product";
            this.dgv_product.RowTemplate.Height = 25;
            this.dgv_product.Size = new System.Drawing.Size(1101, 375);
            this.dgv_product.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(969, 426);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.AutoSize = true;
            this.txtFilePath.Location = new System.Drawing.Point(715, 406);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(38, 15);
            this.txtFilePath.TabIndex = 11;
            this.txtFilePath.Text = "label1";
            // 
            // Frm_ImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 525);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_product);
            this.Controls.Add(this.pictureBox6);
            this.Name = "Frm_ImportExcel";
            this.Text = "Frm_ImportExcel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private PictureBox pictureBox6;
        private DataGridView dgv_product;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button1;
        private Label txtFilePath;
    }
}