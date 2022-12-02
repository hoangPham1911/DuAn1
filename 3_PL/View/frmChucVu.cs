using _1_DAL.Models;
using _2_BUS.IService;
using _2_BUS.Service;
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
    public partial class frmChucVu : Form
    {
        private const string caption = "Thông báo";

        private IChucVuServices _iService;
        private List<ChucVuViewModels> lstchucVuViewModels;
        private ChucVuViewModels objSelected;

        private ACTION_CLICK _actionClick = ACTION_CLICK.NONE;

        public frmChucVu()
        {
            InitializeComponent();
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            visibleControl(false);
            _iService = new ChucVuServices();
            lstchucVuViewModels = new List<ChucVuViewModels>();

            enableControlInput(false);

            loadData();
        }

        private void loadData()
        {
            bindingData();

            if (lstchucVuViewModels.Count > 0)
            {
                objSelected = lstchucVuViewModels[0];
                bindingDataForControl(objSelected);
            }
        }

        private void visibleControl(bool isVisible)
        {
            btnClear.Visible = btnLuu.Visible = isVisible;
        }

        private void enableControlInput(bool isEnable)
        {
            txtMa.Enabled = txtName.Enabled = cbTrangThai.Enabled = isEnable;
        }
        private void clearForm()
        {
            txtMa.Text = txtName.Text = String.Empty;
            cbTrangThai.Checked = true;
            txtName.Focus();
        }

        private void bindingData()
        {
            if (lstchucVuViewModels != null)
            {
                lstchucVuViewModels.Clear();
            }
            lstchucVuViewModels = _iService.GetAll();
            this.dgvChucVu.DataSource = lstchucVuViewModels;
        }

        private void bindingDataForControl(ChucVuViewModels obj)
        {
            this.txtMa.Text = obj.Ma;
            this.txtName.Text = obj.Ten;
            this.cbTrangThai.Checked = obj.TrangThai == 0;  // neu TrangThai == 0 thi dang su dung, nguoc lai thi khong su dung
        }

        private void getForm()
        {
            objSelected.Ten = txtName.Text;
            objSelected.Ma = txtMa.Text;
            objSelected.TrangThai = cbTrangThai.Checked ? 0 : 1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
            _actionClick = ACTION_CLICK.NONE;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            getForm();
            if (objSelected != null)
            {
                var mess = string.Empty;
                var result = true;
                var resultConfirm = DialogResult.No;
                if (_actionClick == ACTION_CLICK.ADD)
                {
                    mess = $"Bạn có chắc chắn muốn thêm mới chức vụ {objSelected.Ten} không ?";
                    resultConfirm = MessageBox.Show(mess, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultConfirm == DialogResult.Yes)
                    {
                        result = _iService.Them(objSelected);
                        if (result)
                        {
                            mess = $"Thêm mới chức vụ {objSelected.Ten} thành công !!!";
                            MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            mess = $"Thêm mới chức vụ {objSelected.Ten} không thành công !!!";
                            MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (_actionClick == ACTION_CLICK.UPDATE)
                {
                    mess = $"Bạn có chắc chắn muốn sửa chức vụ {objSelected.Ten} không ?";
                    resultConfirm = MessageBox.Show(mess, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultConfirm == DialogResult.Yes)
                    {
                        result = _iService.Sua(objSelected);
                        if (result)
                        {
                            mess = $"Sửa chức vụ {objSelected.Ten} thành công !!!";
                            MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            mess = $"Sửa chức vụ {objSelected.Ten} không thành công !!!";
                            MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                if (result)
                {
                    enableControlInput(false);
                    visibleControl(false);
                    _actionClick = ACTION_CLICK.NONE;
                    loadData();
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            var search = txtTimKiem.Text;
            if (string.IsNullOrEmpty(search))
            {
                this.dgvChucVu.DataSource = lstchucVuViewModels;
                return;
            }
            var dataTemp = lstchucVuViewModels.Where(x => x.Ma.ToLower().Contains(txtTimKiem.Text.ToLower()) || x.Ten.ToLower().Contains(txtTimKiem.Text.ToLower())).ToList();
            this.dgvChucVu.DataSource = dataTemp;
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            objSelected = lstchucVuViewModels[e.RowIndex];
            if (objSelected != null)
            {
                _actionClick = ACTION_CLICK.NONE;
                bindingDataForControl(objSelected);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            visibleControl(true);
            clearForm();
            enableControlInput(true);
            _actionClick = ACTION_CLICK.ADD;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            visibleControl(true);
            enableControlInput(true);
            _actionClick = ACTION_CLICK.UPDATE;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var resultConfirm = MessageBox.Show($"Bạn có chắc chắn muốn xoá chức vụ {objSelected.Ten} không?", caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultConfirm == DialogResult.Yes)
            {
                var result = _iService.Xoa(objSelected.Id);
                if (result)
                {
                    MessageBox.Show($"Xoá thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show($"Xoá chức vụ không thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
