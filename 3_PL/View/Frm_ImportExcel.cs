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

        int stt;
        string maSp;
        string tenSp;
        int namBH;
        int TrangThai;
        string moTa;
        decimal giaNhap;
        decimal giaBan;
        int SoLuongTon;
        string color;
        string QuocGia;
        string Nsx;
        string loaiGiay;
        string ChatLieu;

        public Frm_ImportExcel()
        {
            InitializeComponent();
        }
        
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = txtFilePath.Text;
            openFileDialog.Filter = "Excel Spreadsheet (*.XLSX;*.XLSM)|*.XLSX;*.XLSM";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
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
            
            try
            {
                // mo file excel
                var package = new ExcelPackage(new FileInfo(txtFilePath.Text));
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
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

                        dt.Rows.Add(stt, maSp, tenSp, namBH, moTa, giaNhap, giaBan, soLuong, Nsx, QuocGia,loaiGiay,chatLieu);
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

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_product.Rows.Count; i++)
            {
                try
                {
                    stt = int.Parse(dgv_product.Rows[i].Cells[0].Value.ToString());
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

                    var product = new HangHoaViewModels()
                    {
                        Ma = maSp,
                        Ten = tenSp,
                    };
                    Guid sp = _QlyHangHoaServices.IdSp(product);

                    //var sameProduct = new SameProductCreate()
                    //{
                    //    Ma = (_ManagerSameProduct.getAllProduct().Count + 1).ToString(),
                    //    Ten = tenSp,
                    //};

                    //Guid dongSp = _ManagerSameProduct.Id(sameProduct);
                    //// MessageBox.Show(dongSp.ToString());

                    //var mauSac = new ColorCreateView()
                    //{
                    //    Ma = (_ManagerColor.getAllProduct().Count + 1).ToString(),
                    //    Ten = color

                    //};
                    //Guid idMauSac = _ManagerColor.IdColor(mauSac);
                    //var nsx = new ProducterrCreateView()
                    //{
                    //    Ma = (_ProducterService.getAllProduct().Count + 1).ToString(),
                    //    Ten = Nsx
                    //};
                    //Guid nhaSx = _ProducterService.Id(nsx);
                    //var spCt = new ProductDetailCreateNew()
                    //{
                    //    MoTa = moTa,
                    //    SoLuongTon = soLuong,
                    //    GiaBan = giaBan,
                    //    GiaNhap = giaNhap,
                    //    IdDongSp = dongSp,
                    //    IdSp = sp,
                    //    IdMauSac = idMauSac,
                    //    IdNsx = nhaSx,
                    //    NamBh = namBH
                    //};
                    //_productsDetailService.add(spCt);
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

