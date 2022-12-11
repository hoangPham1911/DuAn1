using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_PL.View
{
    public partial class frmQLDiem : Form
    {
        public frmQLDiem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BangQuyDoiDiem bangQuyDoiDiem = new BangQuyDoiDiem();
            bangQuyDoiDiem.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmLichSuDiemTieuDung bangQuyDoiDiem = new FrmLichSuDiemTieuDung();
            bangQuyDoiDiem.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }
    }
}
