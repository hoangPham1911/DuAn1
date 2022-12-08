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

namespace _3_PL.View
{
    public partial class frmGIaoCa : Form
    {
        private IGiaoCaServices _iGiaoCaService;
        private INhanVienServices _iNhanVienService;

        private List<GiaoCaViewModels> lstGiaoCa;
        private List<NhanVienViewModels> lstNhanVien;

        private GiaoCaViewModels _itemSelected;
        private NhanVienViewModels _userLoged;
        private NhanVienViewModels _nhanVienNhanCa;
        private ACTION_CLICK _actionClick = ACTION_CLICK.NONE;
        private static string caption = "Thông báo";

        public frmGIaoCa()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _actionClick = ACTION_CLICK.ADD;
            clearForm();
            enableControl(true);
            visibleControl(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _actionClick = ACTION_CLICK.UPDATE;
            enableControl(true);
            visibleControl(true);
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
            if (_actionClick == ACTION_CLICK.ADD)
            {
                mess = $"Bạn có chắc chắn muốn giao ca cho nhân viên {cbNhanVienNhan.Text} không ?";
                resultConfirm = MessageBox.Show(mess, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultConfirm == DialogResult.Yes)
                {
                    result = _iGiaoCaService.Them(_itemSelected);
                    if (result)
                    {
                        mess = $"Tạo giao ca cho nhân viên {_nhanVienNhanCa.HoTen} thành công !!!";
                        MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        mess = $"Tạo giao ca cho nhân viên {_nhanVienNhanCa.HoTen} không thành công !!!";
                        MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (_actionClick == ACTION_CLICK.UPDATE)
            {
                mess = $"Bạn có chắc chắn muốn sửa thông tin giao ca {_itemSelected.Ma} không ?";
                resultConfirm = MessageBox.Show(mess, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultConfirm == DialogResult.Yes)
                {
                    result = _iGiaoCaService.Sua(_itemSelected);
                    if (result)
                    {
                        mess = $"Thay đổi giao ca {_itemSelected.Ma} thành công !!!";
                        MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        mess = $"Thay đổi giao ca {_itemSelected.Ma} không thành công !!!";
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
            cbNhanVienNhan.DataSource = lstNhanVien;
            cbNhanVienNhan.DisplayMember = "HoTen";
            cbNhanVienNhan.ValueMember = "Id";

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
                = txtTienKhac.Text = txtTienMat.Text
                = txtTienTrongCa.Text = txtTimKiem.Text = String.Empty;

            dtpThoiGianGiao.Value = dtpThoiGianNhan.Value = DateTime.Now;
            txtTongTienBanDau.Text = "0đ";
        }

        private void bindingDataToForm()
        {
            txtGhiChu.Text = _itemSelected.GhiChuPhatSinh;
            var nvBanGiao = lstNhanVien.Where(x => x.Id == _itemSelected.IdNvTrongCa).FirstOrDefault();
            txtNhanVienGiao.Text = nvBanGiao != null ? nvBanGiao.HoTen : "";
            var nvNhan = lstNhanVien.Where(y => y.Id == _itemSelected.IdNvNhanCaTiep).FirstOrDefault();
            cbNhanVienNhan.SelectedItem = nvNhan;
            txtTienKhac.Text = _itemSelected.TongTienKhac.HasValue ? _itemSelected.TongTienKhac.Value.ToString() : "";
            txtTienMat.Text = _itemSelected.TongTienMat.HasValue ? _itemSelected.TongTienMat.Value.ToString() : "";
            txtTienTrongCa.Text = _itemSelected.TongTienTrongCa.HasValue ? _itemSelected.TongTienTrongCa.ToString() : "";
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
            _itemSelected.TienBanDau = Convert.ToDecimal(txtTongTienBanDau.Text.Replace("đ", ""));
            _itemSelected.GhiChuPhatSinh = txtGhiChu.Text;
            _itemSelected.TongTienKhac = Convert.ToDecimal(!String.IsNullOrEmpty(txtTienKhac.Text.Replace("đ", "")) ? txtTienKhac.Text.Replace("đ", "") : "0");
            _itemSelected.TongTienMat = Convert.ToDecimal(!String.IsNullOrEmpty(txtTienMat.Text.Replace("đ", "")) ? txtTienMat.Text.Replace("đ", "") : "0");
            _itemSelected.TongTienTrongCa = Convert.ToDecimal(!String.IsNullOrEmpty(txtTienTrongCa.Text.Replace("đ", "")) ? txtTienTrongCa.Text.Replace("đ", "") : "0");
            _itemSelected.IdNvNhanCaTiep = _nhanVienNhanCa.Id;
            _itemSelected.IdNvTrongCa = _userLoged.Id;
            _itemSelected.ThoiGianGiaoCa = dtpThoiGianGiao.Value;
            _itemSelected.ThoiGianNhanCa = dtpThoiGianNhan.Value;
        }

        private void enableControl(bool isEnable)
        {
            txtGhiChu.Enabled
                = txtTienKhac.Enabled = txtTienMat.Enabled
                = txtTienTrongCa.Enabled = txtTongTienBanDau.Enabled
                = dtpThoiGianGiao.Enabled = dtpThoiGianNhan.Enabled
                = cbNhanVienNhan.Enabled = isEnable;
        }

        private void visibleControl(bool isVisible)
        {
            btnClear.Visible = btnLuu.Visible = isVisible;
        }

        private void cbNhanVienNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            _nhanVienNhanCa = cbNhanVienNhan.SelectedItem as NhanVienViewModels;
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
