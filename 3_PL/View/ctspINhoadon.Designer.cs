namespace _3_PL.View
{
    partial class ctspINhoadon
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
            this.dtg_showHD = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_showHD)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg_showHD
            // 
            this.dtg_showHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_showHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_showHD.Location = new System.Drawing.Point(0, 0);
            this.dtg_showHD.Name = "dtg_showHD";
            this.dtg_showHD.RowTemplate.Height = 25;
            this.dtg_showHD.Size = new System.Drawing.Size(800, 450);
            this.dtg_showHD.TabIndex = 1;
            // 
            // ctspINhoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtg_showHD);
            this.Name = "ctspINhoadon";
            this.Text = "ctspINhoadon";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_showHD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dtg_showHD;
    }
}