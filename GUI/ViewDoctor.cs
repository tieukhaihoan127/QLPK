using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ViewDoctor : Form
    {
        BUS_NhanVien nv;
        BUS_BacSi bs;
        BUS_TaiKhoan acc;
        string role = "";
        private static string id = "";
        private AdminInterface mainForm;

        public ViewDoctor(AdminInterface form, string role)
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
            textBox12.Text = tk.Trim();
            textBox4.Text = mk.Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new DoctorManagement(mainForm, role));
            this.Hide();
            mainForm.Show(); ;
        }
    }
}
