using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ViewPersonalInformation : Form
    {
        private string ma = "";
        private string role = "";
        BUS_NhanVien nv;
        public ViewPersonalInformation(string role,string ma)
        {
            InitializeComponent();
            this.Size = new Size(525, 400);
            this.MaximumSize = new Size(525, 400);
            this.MinimumSize = new Size(525, 400);
            this.role = role;
            this.ma = ma;
        }

        private void Form_Load(object sender,EventArgs e)
        {
            nv = new BUS_NhanVien("", "", "", "", "", "", "", "", DateTime.Now, 0);
            DataTable r = nv.selectDataByID(ma);
            string ten = r.Rows[0]["Ten"].ToString();
            string sdt = r.Rows[0]["SDT"].ToString();
            string CMND = r.Rows[0]["CMND"].ToString();
            string gender = r.Rows[0]["GioiTinh"].ToString();
            string email = r.Rows[0]["Email"].ToString();
            DateTime time = DateTime.Parse(r.Rows[0]["NgaySinh"].ToString());
            string diachi = r.Rows[0]["DiaChiLienHe"].ToString();
            string vaiTro = r.Rows[0]["VaiTro"].ToString();

            textBox1.Text = ten;
            textBox2.Text = sdt;
            textBox3.Text = CMND;
            textBox5.Text = email;
            textBox6.Text = diachi;
            textBox9.Text = vaiTro;
            comboBox1.Text = gender;
            dateTimePicker1.Value = time;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminInterface form = new AdminInterface(role,ma);
            form.Show();
            this.Hide();
        }
    }
}
