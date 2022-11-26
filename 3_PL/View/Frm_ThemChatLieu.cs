using _1_DAL.IRepositories;
using _1_DAL.Repositores;
using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.ViewModels;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
    public partial class Frm_ThemChatLieu : Form
    {
        public IChatLieuServices chatLieuServices;
        public Frm_ThemChatLieu()
        {
            InitializeComponent();
            chatLieuServices = new ChatLieuServices();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!rd_ch.Checked && !rd_hh.Checked)
            {
                MessageBox.Show("Mời chọn trạng thái");
            }
            ChatLieuViewModels cl = new ChatLieuViewModels();
            cl.Id = new Guid();
            cl.Ma = tb_Ma.Text;
            cl.Ten = tb_ten.Text;
            cl.TrangThai = rd_ch.Checked ? 1 : 0;
            MessageBox.Show(chatLieuServices.add(cl));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
