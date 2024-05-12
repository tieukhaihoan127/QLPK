using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using System.Windows.Forms;
using System.Numerics;

namespace GUI
{
    public partial class UpdateDoctor : Form
    {
        BUS_NhanVien nv;
        BUS_BacSi bs;
        BUS_TaiKhoan acc;
        private static string id = "";
        string role = "";
        private AdminInterface mainForm;
        public UpdateDoctor(AdminInterface form, string role)
        {
            InitializeComponent();
            this.Size = new Size(533, 650);
            this.MaximumSize = new Size(533, 650);
            this.MinimumSize = new Size(533, 650);
            mainForm = form;
            this.role = role;
        }

        public void SetDataGridView(string ID)
        {
            nv = new BUS_NhanVien("", "", "", "", "", "", "", "", DateTime.Now, 0);
            DataTable r = nv.selectNVByID(ID);
            DataTable s = nv.selectStatusNV(ID);
            string ten = r.Rows[0]["Ten"].ToString();
            string sdt = r.Rows[0]["SDT"].ToString();
            string CMND = r.Rows[0]["CMND"].ToString();
            string gender = r.Rows[0]["GioiTinh"].ToString();
            string email = r.Rows[0]["Email"].ToString();
            DateTime time = DateTime.Parse(r.Rows[0]["NgaySinh"].ToString());
            string diachi = r.Rows[0]["DiaChiLienHe"].ToString();
            BigInteger luong = BigInteger.Parse(r.Rows[0]["Luong"].ToString());
            string chuyen = r.Rows[0]["ChuyenNganh"].ToString();
            string hocvan = r.Rows[0]["HocVan"].ToString();
            string KinhNghiem = r.Rows[0]["KinhNghiem"].ToString();
            string NgonNgu = r.Rows[0]["NgonNgu"].ToString();
            string tk = s.Rows[0]["TrangThai"].ToString();
            string mk = r.Rows[0]["MatKhau"].ToString();

            textBox1.Text = ten.Trim();
            textBox2.Text = sdt.Trim();
            textBox3.Text = CMND.Trim();
            textBox5.Text = email.Trim();
            textBox6.Text = diachi.Trim();
            comboBox1.Text = gender.Trim();
            dateTimePicker1.Value = time;
            textBox7.Text = luong.ToString();
            textBox9.Text = chuyen.Trim();
            textBox8.Text = KinhNghiem.Trim();
            textBox11.Text = hocvan.Trim();
            textBox10.Text = NgonNgu.Trim();
            comboBox2.Text = tk.Trim();
            textBox4.Text = mk.Trim();
        }

        public void updateCurrent(string MaNV)
        {
            id = MaNV;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Họ tên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus(); 
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Số điện thoại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô CMND !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Email !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Địa chỉ liên hệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox6.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Lương !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox7.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Kinh nghiệm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox8.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox9.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Chuyên ngành !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox9.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox10.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Ngôn ngữ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox10.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox11.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Học vấn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox11.Focus();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string ten = textBox1.Text;
            string sdt = textBox2.Text;
            string CMND = textBox3.Text;
            string gender = comboBox1.Text;
            string email = textBox5.Text;
            DateTime time = dateTimePicker1.Value;
            string diachi = textBox6.Text;
            BigInteger luong = BigInteger.Parse(textBox7.Text);
            string chuyen = textBox9.Text;
            string hocvan = textBox11.Text;
            string KinhNghiem = textBox8.Text;
            string NgonNgu = textBox10.Text;
            string tt = comboBox2.Text;
            string matkhau = textBox4.Text;
            nv = new BUS_NhanVien(id, ten, sdt, gender, email, diachi, CMND, "", time, luong);
            bs = new BUS_BacSi(id, chuyen, hocvan, KinhNghiem, NgonNgu, "");
            acc = new BUS_TaiKhoan("", "", "", id, DateTime.Now);

            nv.updateQuery();
            bs.updateCurrentQuery();
            acc.updatePasswod(matkhau);

            if(tt == "Active")
            {
                acc.updateStatusActive(id);
            }
            else
            {
                acc.updateStatusInactive(id);
            }

            mainForm.openChildForm(new DoctorManagement(mainForm, role));
            this.Hide();
            mainForm.Show(); ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new DoctorManagement(mainForm, role));
            this.Hide();
            mainForm.Show(); ;
        }
    }
}
