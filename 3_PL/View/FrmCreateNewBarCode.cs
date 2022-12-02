using _3_PL.View;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmCreateNewBarCode : Form
    {
        private string mahh = "";
        Guid id;
        Guid idct;
        private string tenhh = "";
        private string nsx = "";
        private string danhmuc = "";
        private string trangthai = "";
        private string mavach = "";
        private string soluong = "";
        private string gianhap = "";
        private string giaban = "";
        private string chatlieu = "";
        private string sizegiay = "";
        private string loaigiay = "";
        private string tennquocgia = "";
        private string anh = "";
        public string sender = "";
        public FrmCreateNewBarCode(Guid idct, Guid id,string mahh, string tenhh, string nsx, string trangthai, string mavach, string soluong,
            string gianhap, string giaban, string chatlieu, string sizegiay, string loaigiay, string tenquocgia, string anh)
        {
            InitializeComponent();

            this.mahh = mahh;
            this.tenhh = tenhh;
            this.nsx = nsx;
            this.trangthai = trangthai;
            this.mavach = mavach;
            this.soluong = soluong;
            this.gianhap = gianhap;
            this.giaban = giaban;
            this.chatlieu = chatlieu;
            this.sizegiay = sizegiay;
            this.loaigiay = loaigiay;
            this.tennquocgia = tenquocgia;
            this.anh = anh;

        }
        public void Alert(string mess)
        {
            FrmAlert frmAlert = new FrmAlert();
            frmAlert.showAlert(mess);
        }
        public void AlertErr(string mess)
        {
            FrmThatBaiAlert frmThatBaiAlert = new FrmThatBaiAlert();
            frmThatBaiAlert.showAlert(mess);
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có muốn tạo mã QR Code hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                QRCodeGenerator qRCode = new QRCodeGenerator();
                QRCodeData qRCodeData = qRCode.CreateQrCode(txt_QRcode.Text, QRCodeGenerator.ECCLevel.L);
                QRCode qR = new QRCode(qRCodeData);
                Pic_QRcode.Image = qR.GetGraphic(5);
                for (int i = 0; i < 2; i++)
                {

                    this.Alert("Tạo Mã QR Code Thành Công");

                }

                return;
            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {

                    this.AlertErr("Tạo Mã QR Code Thất Bại ");

                }
                return;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có muốn thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                FrmChiTietHangHoa frm_EditHangHoa = new FrmChiTietHangHoa(idct,id,mahh,tenhh, nsx, trangthai, Convert.ToString(txt_QRcode.Text), soluong,
             gianhap, giaban, chatlieu, sizegiay, loaigiay, tennquocgia, anh);

                this.Hide();
                for (int i = 0; i < 2; i++)
                {

                    this.Alert("Thêm Mã Vạch Thành Công");

                }

            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {

                    this.Alert("Thêm Mã Vạch Thất Bại ");

                }
                return;
            }
        }
        private void print(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(Pic_QRcode.Width, Pic_QRcode.Height);
            Pic_QRcode.DrawToBitmap(bitmap, new Rectangle(0, 0, Pic_QRcode.Width, Pic_QRcode.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);
            bitmap.Dispose();

        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có in mã QR code thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                PrintDialog pd = new PrintDialog();
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += print;
                pd.Document = printDocument;

                if (pd.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }


                return;
            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {

                    this.AlertErr("Tạo File PDF Thất Bại ");

                }
                return;
            }
        }


    }
}
