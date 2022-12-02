using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_PL.View
{
    public partial class Frm_Anh : Form
    {
        private IAnhService ianhser;
        private AnhService _anhSer;
        private AnhViewModels _anh;

        public Frm_Anh()
        {
            InitializeComponent();
            _anhSer = new AnhService();
            _anh = new AnhViewModels();
            _anhSer.GetAnh();
            dgv_anh.AllowUserToAddRows = false;
            loadata();
        }

        void loadata()
        {
            try
            {
                ArrayList row = new ArrayList();

                row = new ArrayList();
                row.Add("Thêm");
                row.Add("Sửa");

                // combobox


                dgv_anh.ColumnCount = 5;
                dgv_anh.Columns[0].Name = "ID Ảnh";
                dgv_anh.Columns[0].Visible = false;
                dgv_anh.Columns[1].Name = "Mã Ảnh";
                dgv_anh.Columns[2].Name = "Tên Ảnh";
                dgv_anh.Columns[3].Name = "Đường dẫn";
                dgv_anh.Columns[4].Name = "Trạng thái";
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgv_anh.Columns.Add(cbo);


                ////button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Xác Nhận";
                btn.HeaderText = "Xác Nhận";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                dgv_anh.Columns.Add(btn);
                dgv_anh.Rows.Clear();
                foreach (var x in _anhSer.GetAnh())
                {
                    dgv_anh.Rows.Add(x.ID, x.MaAnh, x.Ten, x.DuongDan, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
                }

                txt_MaAnh.ReadOnly = true;
                txt_MaAnh.BackColor = Color.White;
                txt_TenAnh.ReadOnly = true;
                txt_TenAnh.BackColor = Color.White;
                txt_ddan.ReadOnly = true;
                txt_ddan.BackColor = Color.White;

            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Hiếu để khắc phục");
            }
        }
        public bool checkup()
        {
            if (string.IsNullOrEmpty(txt_MaAnh.Text))
            {
                MessageBox.Show("Mã Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_TenAnh.Text))
            {
                MessageBox.Show("Tên Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_ddan.Text))
            {
                MessageBox.Show("Đường dẫn Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            //Mã 
            if (txt_MaAnh.Text.Length <= 3)
            {
                MessageBox.Show("Mã Ảnh phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_MaAnh.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã Ảnh Bắt buộc phải chứa số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_MaAnh.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Mã Ảnh không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            //tên
            if (txt_TenAnh.Text.Length <= 3)
            {
                MessageBox.Show("Tên Ảnh phải trên 3 ký tự", "ERR");
                return false;
            }
            if (txt_ddan.Text.Length <= 3)
            {
                MessageBox.Show("Đường dẫn Ảnh phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenAnh.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Ảnh không được chứa số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenAnh.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Tên Ảnh không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            //Trạng thái
            if (cbx_CoAnh.Checked == false && cbx_Kcoanh.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái", "ERR");
                return false;
            }
            return true;
        }
        public bool Check()
        {
            if (string.IsNullOrEmpty(txt_TenAnh.Text))
            {
                MessageBox.Show("Tên Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_MaAnh.Text))
            {
                MessageBox.Show("Mã Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_ddan.Text))
            {
                MessageBox.Show("Đường dẫn Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            //mã 

            if (Regex.IsMatch(txt_MaAnh.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã Ảnh Bắt buộc phải chứa số", "ERR");
                return false;

            }
            if (Regex.IsMatch(txt_MaAnh.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Mã Ảnh không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            for (int i = 0; i < _anhSer.GetAnh().Count; i++)
            {
                if (_anhSer.GetAnh().ToList()[i].MaAnh == txt_MaAnh.Text)
                {
                    MessageBox.Show("Mã Ảnh Đã tồn Tại yêu cầu nhập mã Ảnh khác", "ERR");
                    return false;
                }
            }
            //tên
            if (txt_TenAnh.Text.Length <= 3)
            {
                MessageBox.Show("Tên Ảnh phải trên 3 ký tự", "ERR");
                return false;
            }

            if (Regex.IsMatch(txt_TenAnh.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Ảnh không được chứa số", "ERR");
                return false;
            }

            if (txt_ddan.Text.Length <= 3)
            {
                MessageBox.Show("Đường dẫn Ảnh phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenAnh.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Tên Ảnh không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            //Trạng thái
            if (cbx_CoAnh.Checked == false && cbx_Kcoanh.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái", "ERR");
                return false;
            }
            return true;
        }

        private void dgv_anh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rd = e.RowIndex;
                dgv_anh.AllowUserToAddRows = false;


                //thêm
                if (e.ColumnIndex == 6 && string.IsNullOrEmpty(dgv_anh.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgv_anh.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                    if (commnad == "Thêm")
                    {
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (Check() == false)
                            {
                                return;
                            }
                            _anhSer.add(new AnhViewModels()
                            {
                                MaAnh = txt_MaAnh.Text,
                                Ten = txt_TenAnh.Text,
                                DuongDan = txt_ddan.Text,
                                TrangThai = Convert.ToInt32(cbx_CoAnh.Checked)

                            });
                            MessageBox.Show("Thêm Thành Công", "Thông Báo");
                            _anhSer.GetAnh();
                            loadata();
                            return;
                        }
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }


                }
                //sửa
                if (e.ColumnIndex == 6 && string.IsNullOrEmpty(dgv_anh.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgv_anh.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                    if (commnad == "Sửa")
                    {
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (checkup() == false)
                            {
                                return;
                            }
                            _anhSer.update(new AnhViewModels()
                            {
                                ID = Guid.Parse(dgv_anh.Rows[e.RowIndex].Cells[0].Value.ToString()),
                                MaAnh = txt_MaAnh.Text,
                                Ten = txt_TenAnh.Text,
                                DuongDan = txt_ddan.Text,
                                TrangThai = Convert.ToInt32(cbx_CoAnh.Checked)

                            });
                            MessageBox.Show("Sửa Thành Công", "Thông Báo");
                            _anhSer.GetAnh();
                            loadata();
                            return;
                        }
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ để khắc phục");
            }
        }

        private void dgv_anh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == _anhSer.GetAnh().Count || rowindex == -1) return;
                _anh = _anhSer.GetAnh().ToList().FirstOrDefault(c => c.ID == Guid.Parse(dgv_anh.Rows[rowindex].Cells[0].Value.ToString()));
                txt_MaAnh.Text = Convert.ToString(dgv_anh.Rows[rowindex].Cells[1].Value);
                txt_TenAnh.Text = Convert.ToString(dgv_anh.Rows[rowindex].Cells[2].Value);
                txt_ddan.Text = Convert.ToString(dgv_anh.Rows[rowindex].Cells[3].Value);
                cbx_CoAnh.Checked = Convert.ToString(dgv_anh.Rows[rowindex].Cells[4].Value) == "Hoạt động";
                cbx_Kcoanh.Checked = Convert.ToString(dgv_anh.Rows[rowindex].Cells[4].Value) == "Không hoạt động";
                var request = WebRequest.Create(Convert.ToString(dgv_anh.Rows[rowindex].Cells[3].Value));
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ để khắc phục");
            }
        }

        private void cbx_CoAnh_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbx_CoAnh.Checked)
                {
                    cbx_Kcoanh.Checked = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ để khắc phục");
            }
        }

        private void cbx_Kcoanh_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbx_Kcoanh.Checked)
                {
                    cbx_CoAnh.Checked = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ để khắc phục");
            }
        }

        private void dgv_anh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //string Maanh = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[1].Value);
                //string Tenanh = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[2].Value);
                //string DuongDan = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[3].Value);
                //string trangthai = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[4].Value);
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ để khắc phục");
            }
        }

        void loadatafortimkiem(string ma)
        {
            try
            {
                ArrayList row = new ArrayList();

                row = new ArrayList();
                row.Add("Thêm");
                row.Add("Sửa");

                dgv_anh.ColumnCount = 5;
                dgv_anh.Columns[0].Name = "ID ảnh";
                dgv_anh.Columns[0].Visible = false;
                dgv_anh.Columns[1].Name = "Mã ảnh";
                dgv_anh.Columns[2].Name = "Tên ảnh";
                dgv_anh.Columns[3].Name = "Đường dẫn";
                dgv_anh.Columns[4].Name = "Trạng thái";

                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgv_anh.Columns.Add(cbo);

                ////button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Xác Nhận";
                btn.HeaderText = "Xác Nhận";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                dgv_anh.Columns.Add(btn);
                dgv_anh.Rows.Clear();
                foreach (var x in _anhSer.GetAnh().Where(c => c.MaAnh.Contains(ma)))
                {

                    dgv_anh.Rows.Add(x.ID, x.MaAnh, x.Ten, x.DuongDan, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ để khắc phục");
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(open.FileName);
                    dgv_anh.CurrentRow.Cells[3].Value = open.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ để khắc phục");
            }
        }

        private void txt_timkiem_KeyUp(object sender, KeyEventArgs e)
        {
            loadatafortimkiem(txt_timkiem.Text);
        }
    }
}
