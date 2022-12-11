using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using _2_BUS.Service;
using System.Windows.Forms.Design;
using System.Xml.Linq;
using _1_DAL.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using _2_BUS.IServices;
using _2_BUS.Services;

namespace _3_PL.View
{
    public partial class frmGIaoCa : Form
    {
        private IGiaoCaServices _iGiaoCaService;
        private INhanVienServices _iNhanVienService;
        private IHoaDonService _HoaDon;
        private List<GiaoCaViewModels> lstGiaoCa;
        private List<NhanVienViewModels> lstNhanVien;
        private IChucVuServices ichucvu;
        private GiaoCaViewModels _itemSelected;
        private NhanVienViewModels _userLoged;
        private NhanVienViewModels _nhanVienNhanCa;
        private ACTION_CLICK _actionClick = ACTION_CLICK.NONE;
        private static string caption = "Thông báo";
        private static Guid _IdGiaoCa;
        private decimal _TienCaTruoc;
        public frmGIaoCa()
        {
            InitializeComponent();
            _iGiaoCaService = new GiaoCaServices();
            _iNhanVienService = new NhanVienServices();
            _HoaDon = new HoaDonService();
            lstGiaoCa = new List<GiaoCaViewModels>();
            lstNhanVien = new List<NhanVienViewModels>();
            ichucvu = new ChucVuServices();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _actionClick = ACTION_CLICK.UPDATE;
            enableControl(true);
            visibleControl(true);
            clearForm();

        }

        //private void btnXoa_Click(object sender, EventArgs e)
        //{
        //    var resultConfirm = MessageBox.Show($"Bạn có chắc chắn muốn giao ca {_itemSelected.Ma} không?", caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (resultConfirm == DialogResult.Yes)
        //    {
        //        var result = _iGiaoCaService.Xoa(_itemSelected.Id);
        //        if (result)
        //        {
        //            MessageBox.Show($"Xoá thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            loadData();
        //        }
        //        else
        //        {
        //            MessageBox.Show($"Xoá giao ca không thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //}

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            getDataForm();
            var mess = string.Empty;
            var result = true;
            var resultConfirm = DialogResult.No;
            if (_actionClick == ACTION_CLICK.UPDATE)
            {
                mess = $"Bạn có chắc chắn muốn Luu không ?";
                resultConfirm = MessageBox.Show(mess, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultConfirm == DialogResult.Yes)
                {
                    result = _iGiaoCaService.Sua(_itemSelected);
                    if (result)
                    {
                        mess = $"Luu thành công !!!";
                        MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        mess = $"Luu không thành công !!!";
                        MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            if (result)
            {
                enableControl(false);
                visibleControl(false);
                _actionClick = ACTION_CLICK.NONE;
                reloadData();
            }

        }

        private void dgvGiaoCa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _itemSelected = lstGiaoCa[e.RowIndex];
            if (_itemSelected != null)
            {
                bindingDataToForm();
            }
        }

        private void frmGIaoCa_Load(object sender, EventArgs e)
        {
            init();
            loadData();
            decimal Money = 0;
            if (_HoaDon.Get().FirstOrDefault(p => p.IdNv == FrmDangNhap._IdStaff) != null)
            {
                foreach (var item in _HoaDon.Get().Where(p => p.IdNv == FrmDangNhap._IdStaff))
                {
                    Money += item.TongSoTienTrongCa;
                }
                label9.Text = Money.ToString();
            }
            else label9.Text = 0.ToString();
            if (_iGiaoCaService.GetAll().FirstOrDefault(p => p.Time == int.Parse(dtpThoiGianGiao.Text)) != null)
                txtTienCaTruoc.Text = _iGiaoCaService.GetAll().FirstOrDefault(p => p.Time == int.Parse(DateTime.Now.Hour.ToString())).TongTienCaTruoc.ToString();
        }

        private void init()
        {
            _iGiaoCaService = new GiaoCaServices();
            _iNhanVienService = new NhanVienServices();

            lstGiaoCa = new List<GiaoCaViewModels>();
            lstNhanVien = new List<NhanVienViewModels>();

            _itemSelected = new GiaoCaViewModels();
            _nhanVienNhanCa = new NhanVienViewModels();

            initData();
            enableControl(false);
            visibleControl(false);
        }

        private void initData()
        {
            lstNhanVien = _iNhanVienService.GetAll();
            //cbNhanVienNhan.DataSource = lstNhanVien;
            //cbNhanVienNhan.DisplayMember = "HoTen";
            //cbNhanVienNhan.ValueMember = "Id";

            if (lstNhanVien.Count > 0)
            {
                _nhanVienNhanCa = lstNhanVien[0];
            }

            _userLoged = Helpers.AccoutHelper.Instance.GetUserLoged();
            txtNhanVienGiao.Text = _userLoged.HoTen;
        }

        private void loadData()
        {
            lstGiaoCa = _iGiaoCaService.GetAll();
            getHoTen();
            dgvGiaoCa.DataSource = lstGiaoCa;
            if (lstGiaoCa.Count > 0)
            {
                _itemSelected = lstGiaoCa[0];
                bindingDataToForm();
            }
            var cv = ichucvu.GetChucVu().FirstOrDefault(p => p.IdNv == FrmDangNhap._IdStaff);

            if (cv != null)
            {
                label1.Text = cv.Ten;
            }
            if (label1.Text == "Nhân viên")
            {
                txtTongTienBanDau.Enabled = false;
                dgvGiaoCa.Visible = false;
                txtTimKiem.Visible = false;
                btnTimKiem.Visible = false;
            }
            if (_iGiaoCaService.GetAll().FirstOrDefault(p => p.Id == FrmDangNhap._IdStaff) != null)
            {
                txtTongTienBanDau.Text = _iGiaoCaService.GetAll().FirstOrDefault(p => p.Id == FrmDangNhap._IdStaff).TienBanDau.ToString();
            }
        }

        private void getHoTen()
        {
            foreach (var item in lstGiaoCa)
            {
                var nvTrongCa = lstNhanVien.Where(x => x.Id == item.IdNvTrongCa).FirstOrDefault();
                var nvCaTiep = lstNhanVien.Where(y => y.Id == item.IdNvNhanCaTiep).FirstOrDefault();
                item.NhanVienCaTiep = nvCaTiep?.HoTen;
                item.NhanVienTrongCa = nvTrongCa?.HoTen;
            }
        }

        private void reloadData()
        {
            lstGiaoCa.Clear();
            loadData();
        }

        private void clearForm()
        {
            txtGhiChu.Text
           = txtTienMat.Text = String.Empty;
            dtpThoiGianGiao.Value = dtpThoiGianNhan.Value = DateTime.Now;
        }

        private void bindingDataToForm()
        {
            txtGhiChu.Text = _itemSelected.GhiChuPhatSinh;
            var nvBanGiao = lstNhanVien.Where(x => x.Id == FrmDangNhap._IdStaff).FirstOrDefault();
            txtNhanVienGiao.Text = nvBanGiao != null ? nvBanGiao.HoTen : "";
            var nvNhan = lstNhanVien.Where(y => y.Id == _itemSelected.IdNvNhanCaTiep).FirstOrDefault();

            txtTienCaTruoc.Text = _itemSelected.TongTienCaTruoc.HasValue ? _itemSelected.TongTienCaTruoc.Value.ToString() : "";
            txtTienMat.Text = _itemSelected.TongTienMat.HasValue ? _itemSelected.TongTienMat.Value.ToString() : "";
            txt_tienPhatSinh.Text = _itemSelected.TienPhatSinh.HasValue ? _itemSelected.TienPhatSinh.Value.ToString() : "";
            txtTongTienBanDau.Text = _itemSelected.TienBanDau.HasValue ? $"{_itemSelected.TienBanDau.ToString()}đ" : "0đ";
            dtpThoiGianGiao.Value = _itemSelected.ThoiGianGiaoCa;
            dtpThoiGianNhan.Value = _itemSelected.ThoiGianNhanCa;

        }

        private void getDataForm()
        {
            if (_actionClick == ACTION_CLICK.ADD)
            {
                _itemSelected = new GiaoCaViewModels();
            }
            var timeNow = DateTime.Now;
            _itemSelected.Ma = $"GC{timeNow.Year}{timeNow.Month}{timeNow.Day}{timeNow.Hour}{timeNow.Minute}";
            _itemSelected.TienBanDau = Convert.ToDecimal(txtTongTienBanDau.Text.Replace("đ", ""))
                + decimal.Parse(label9.Text.Replace("đ", ""))
                - decimal.Parse(txt_tienPhatSinh.Text.Replace("đ", ""))
                - decimal.Parse(textBox2.Text.Replace("đ", ""));
            _itemSelected.GhiChuPhatSinh = txtGhiChu.Text;
            _itemSelected.TongTienCaTruoc = decimal.Parse(label9.Text);
            _itemSelected.TongTienMat = Convert.ToDecimal(!String.IsNullOrEmpty(txtTienMat.Text.Replace("đ", "")) ? txtTienMat.Text.Replace("đ", "") : "0");
            _itemSelected.IdNvNhanCaTiep = _nhanVienNhanCa.Id;
            _itemSelected.IdNvTrongCa = _userLoged.Id;
            _itemSelected.ThoiGianGiaoCa = dtpThoiGianGiao.Value;
            _itemSelected.ThoiGianNhanCa = dtpThoiGianNhan.Value;
            _itemSelected.TongTienTrongCa = decimal.Parse(label9.Text);
        }

        private void enableControl(bool isEnable)
        {
            txtGhiChu.Enabled
                = txtTienCaTruoc.Enabled = txtTienMat.Enabled
                = dtpThoiGianGiao.Enabled = dtpThoiGianNhan.Enabled
                = isEnable;
            if (label1.Text != "Nhân viên")
            {
                txtTongTienBanDau.Enabled = isEnable;
            }
        }

        private void visibleControl(bool isVisible)
        {
            btnClear.Visible = btnLuu.Visible = isVisible;
        }

        private void cbNhanVienNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //     _nhanVienNhanCa = cbNhanVienNhan.SelectedItem as NhanVienViewModels;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var timKiem = txtTimKiem.Text;
            var rutl = lstGiaoCa.FirstOrDefault(gc => gc.Ma == timKiem);
            dgvGiaoCa.DataSource = lstGiaoCa;
            dgvGiaoCa.DataSource = lstGiaoCa;
        }
    }
}
