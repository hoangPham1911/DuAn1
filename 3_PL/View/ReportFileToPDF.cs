using _2_BUS.IService;
using _2_BUS.Service;
using _3_GUI_PresentaionLayers;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class ReportFileToPDF : Form
    {
        private IQlyHangHoaServices qlhhser; 
        public ReportFileToPDF()
        {
            InitializeComponent();
            qlhhser = new QlyHangHoaServices();
        }

        void loaddata()
        {
            dgrid_sanpham.ColumnCount = 15;
            dgrid_sanpham.Columns[0].Name = "IDHH";
            dgrid_sanpham.Columns[0].Visible = false;
            dgrid_sanpham.Columns[1].Name = "IDCTHH";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[2].Name = "Mã Hàng Hóa";
            dgrid_sanpham.Columns[3].Name = "Tên Hàng Hóa";
            dgrid_sanpham.Columns[4].Name = "Mã vạch";
            dgrid_sanpham.Columns[5].Name = "Nhà sản xuất";
            dgrid_sanpham.Columns[6].Name = "Số lượng";
            dgrid_sanpham.Columns[7].Name = "Ảnh";
            dgrid_sanpham.Columns[8].Name = "Trạng thái";
            dgrid_sanpham.Columns[9].Name = "Giá nhập";
            dgrid_sanpham.Columns[10].Name = "Đơn giá bán";
            dgrid_sanpham.Columns[11].Name = "Tên chất liệu chính";
            dgrid_sanpham.Columns[12].Name = "Size giày";
            dgrid_sanpham.Columns[13].Name = "Tên quốc gia";
            dgrid_sanpham.Columns[14].Name = "Loại giày";
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.TrangThai == 1))
            {
                dgrid_sanpham.Rows.Add(x.IdSp, x.Id, x.Ma, x.Ten, x.Mavach, x.TenNsx, x.SoLuongTon, x.DuongDanAnh, x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.GiaNhap, x.GiaBan, x.TenChatLieu, x.SoSize, x.TenQuocGia, x.TenLoaiGiay);
            }
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
        public void exportdata(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfPTable = new PdfPTable(dgw.Columns.Count);
            pdfPTable.DefaultCell.Padding = 3;
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            //Add header;
            foreach (DataGridViewColumn col in dgrid_sanpham.Columns)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(col.HeaderText));
                pdfPTable.AddCell(pdfPCell);
            }
            foreach (DataGridViewRow row in dgrid_sanpham.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfPTable.AddCell(new Phrase(Convert.ToString(cell.Value), text));
                }



            }
            var savefiledialog = new SaveFileDialog();
            savefiledialog.FileName = filename;
            savefiledialog.DefaultExt = ".pdf";
            if (savefiledialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A1, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdfPTable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("bạn có muốn Xuất Ra File PDF Hay Không", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    exportdata(dgrid_sanpham, "test");
                    for (int i = 0; i < 2; i++)
                    {

                        this.Alert("Xuất Ra File PDF Thành Công");

                    }
                    return;
                }
                if (dialogResult == DialogResult.No)
                {
                    for (int i = 0; i < 2; i++)
                    {

                        this.Alert("Xuất Ra File PDF Thất Bại");

                    }
                    return;
                }

            }
            catch (Exception ex)
            {
                for (int i = 0; i < 2; i++)
                {

                    this.Alert("Lỗi Rồi" + ex.Message);

                }

                return;
            }
        }
    }
}
