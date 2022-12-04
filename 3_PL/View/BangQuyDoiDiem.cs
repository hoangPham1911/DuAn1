using _2_BUS.IService;
using _2_BUS.IServices;
using _2_BUS.Service;
using _2_BUS.Services;
using _2_BUS.ViewModels;
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
    public partial class BangQuyDoiDiem : Form
    {
        IBangQuyDoiDiemServices _QuyDoiDiemService;
        public BangQuyDoiDiem()
        {
            InitializeComponent();
            _QuyDoiDiemService = new BangQuyDoiDiemServices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BangQuyDoiDiemViewModels bangQuyDoi = new BangQuyDoiDiemViewModels();
            bangQuyDoi.TyLeQuyDoi = decimal.Parse(textBox2.Text);
            bangQuyDoi.TrangThai = "Hoạt Đông";
            _QuyDoiDiemService.add(bangQuyDoi);
            
        }
    }
}
