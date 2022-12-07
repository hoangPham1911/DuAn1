using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.ViewModels;
using OfficeOpenXml;
namespace _3_PL.View
{
    public partial class Frm_ImportExcel : Form
    {
        IHangHoaServices _ProducterService;
        ILoaiGiayServices _LoaiGiayServices;
        IQuocGiaServices _QuocGiaServices;
        IChatLieuServices _ChatLieuService;
        INsxServices _NsxServices;
        ISizeGiayServices _SizeGiayServices;
        IQlyHangHoaServices _QlyHangHoaServices;
        string maSp;
        string tenSp;
        int namBH;
        string moTa;
        decimal giaNhap;
        decimal giaBan;
        int SoLuongTon;
        int soSize;
        string QuocGia;
        string Nsx;
        string loaiGiay;
        string ChatLieu;

        public Frm_ImportExcel()
        {
            InitializeComponent();
            dgv_product.AllowUserToAddRows = false;
            _ProducterService = new HangHoaServices();
            _LoaiGiayServices = new LoaiGiayServices();
            _QuocGiaServices = new QuocGiaServices();
            _ChatLieuService = new ChatLieuServices();
            _NsxServices = new NsxServices();
            _SizeGiayServices = new SizeGiayServices();
            _QlyHangHoaServices = new QlyHangHoaServices();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = txtFilePath.Text;
                openFileDialog.Filter = "Excel Spreadsheet (*.XLSX;*.XLSM)|*.XLSX;*.XLSM";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                }
                

                var package = new ExcelPackage(new FileInfo(txtFilePath.Text));
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                DataTable dt = new DataTable();
                dt.Columns.Add("STT");
                dt.Columns.Add("Mã SP");
                dt.Columns.Add("Tên SP");
                dt.Columns.Add("Năm BH");
                dt.Columns.Add("Mô tả");
                dt.Columns.Add("Gía Nhập");
                dt.Columns.Add("Gía Bán");
                dt.Columns.Add("Số Lượng Ton");
                dt.Columns.Add("Nhà Sản Xuất");
                dt.Columns.Add("Quốc Gia");
                dt.Columns.Add("Loại Gìay");
                dt.Columns.Add("Chất Liệu");
                dt.Columns.Add("Size Gìay");
                try
                {
                    // mo file excel
                   
                    for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                    {
                        try
                        {
                            int j = 1;
                            var stt = worksheet.Cells[i, j++].Value;
                            var maSp = worksheet.Cells[i, j++].Value;
                            var tenSp = worksheet.Cells[i, j++].Value;
                            var namBH = worksheet.Cells[i, j++].Value;
                            var moTa = worksheet.Cells[i, j++].Value;
                            var giaNhap = worksheet.Cells[i, j++].Value;
                            var giaBan = worksheet.Cells[i, j++].Value;
                            var soLuong = worksheet.Cells[i, j++].Value;
                            var loaiGiay = worksheet.Cells[i, j++].Value;
                            var Nsx = worksheet.Cells[i, j++].Value;
                            var chatLieu = worksheet.Cells[i, j++].Value;
                            var QuocGia = worksheet.Cells[i, j++].Value;
                            var SoSize = worksheet.Cells[i, j++].Value;
                            dt.Rows.Add(stt, maSp, tenSp, namBH, moTa, giaNhap, giaBan, soLuong, Nsx, loaiGiay, chatLieu, QuocGia, SoSize);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error");
                            throw;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                    throw;
                }
                dgv_product.DataSource = dt.DefaultView;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Muốn Lưu Dữ Liệu chứ ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < dgv_product.Rows.Count; i++)
                {
                    try
                    {
                        maSp = dgv_product.Rows[i].Cells[1].Value.ToString();
                        tenSp = dgv_product.Rows[i].Cells[2].Value.ToString();
                        namBH = int.Parse(dgv_product.Rows[i].Cells[3].Value.ToString());
                        moTa = dgv_product.Rows[i].Cells[4].Value.ToString();
                        giaNhap = decimal.Parse(dgv_product.Rows[i].Cells[5].Value.ToString());
                        giaBan = decimal.Parse(dgv_product.Rows[i].Cells[6].Value.ToString());
                        SoLuongTon = int.Parse(dgv_product.Rows[i].Cells[7].Value.ToString());
                        QuocGia = dgv_product.Rows[i].Cells[9].Value.ToString();
                        Nsx = dgv_product.Rows[i].Cells[8].Value.ToString();
                        loaiGiay = dgv_product.Rows[i].Cells[10].Value.ToString();
                        QuocGia = dgv_product.Rows[i].Cells[11].Value.ToString();
                        ChatLieu = dgv_product.Rows[i].Cells[12].Value.ToString();

                        var chatLieu = new ChatLieuViewModels()
                        {
                            Ma = (_ChatLieuService.GetChatLieu().Count + 1).ToString(),
                            Ten = ChatLieu,
                            TrangThai = 1
                        };

                        Guid IdChatLieu = _ChatLieuService.IdChatLieu(chatLieu);
                        //// MessageBox.Show(dongSp.ToString());

                        var LoaiGiay = new LoaiGiayViewModels()
                        {
                            Ma = (_LoaiGiayServices.GetLoaiGiay().Count + 1).ToString(),
                            Ten = loaiGiay,
                            TrangThai = 1
                        };
                        Guid idLoaiGiay = _LoaiGiayServices.IdSize(LoaiGiay);

                        var nsx = new NsxViewModels()
                        {
                            Ma = (_NsxServices.GetNhasanxuat().Count + 1).ToString(),
                            Ten = Nsx,
                            TrangThai = 1
                        };
                        Guid nhaSx = _NsxServices.IdSize(nsx);

                        var Size = new SizeGiayViewModels()
                        {
                            Ma = (_SizeGiayServices.GetSizeGiay().Count + 1).ToString(),
                            SoSize = soSize,
                            TrangThai = 1
                        };
                        Guid IdSize = _SizeGiayServices.IdSize(Size);

                        var QuocGiaa = new QuocGiaViewModels()
                        {
                            Ma = (_QuocGiaServices.GetQuocGia().Count + 1).ToString(),
                            Ten = QuocGia,
                            TrangThai = 1
                        };
                        Guid IdQuocGia = _QuocGiaServices.IdQuocGia(QuocGiaa);

                        var product = new HangHoaViewModels()
                        {
                            Ma = maSp,
                            Ten = tenSp,
                            TrangThai = 1,
                            IdNsx = nhaSx
                        };
                        Guid sp = _QlyHangHoaServices.IdSp(product);


                        var spCt = new ChiTietHangHoaThemViewModels()
                        {
                            MoTa = moTa,
                            TrangThai = 1,
                            SoLuongTon = SoLuongTon,
                            GiaBan = giaBan,
                            GiaNhap = giaNhap,
                            IdSizeGiay = IdSize,
                            IdSp = sp,
                            IdLoaiGiay = idLoaiGiay,
                            IdChatLieu = IdChatLieu,
                            NamBh = namBH,
                            IdQuocGia = IdQuocGia
                        };
                        _QlyHangHoaServices.addcthanghoa(spCt);

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                MessageBox.Show("Them Thanh Cong");


            }
        }

    }
}

