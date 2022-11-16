using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
namespace _3_PL.View
{
    public partial class FormBanHang : Form
    {
        VideoCaptureDevice videoCaptureDevice; // camera dung de ghi hinh
        FilterInfoCollection filterInfoCollection; // check xem co bao nhieu cai camera ket noi voi may tinh
        public FormBanHang()
        {
            InitializeComponent();           

        }

        private void btn_FormdatHang_Click(object sender, EventArgs e)
        {
            btn_FormdatHang.Visible = true;
        }
        private void FormBanHang_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in filterInfoCollection)
            {
                cbo_webcam.Items.Add(item.Name);
            }
            cbo_webcam.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Mở Camera Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbo_webcam.SelectedIndex].MonikerString);
                    videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                    videoCaptureDevice.Start();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;
            }
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pic_cam.Image = bit;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice.IsRunning ==true)
            {
                videoCaptureDevice.Stop();
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (videoCaptureDevice.IsRunning == true)
            {
                videoCaptureDevice.Stop();
            }
        }
    }
}
