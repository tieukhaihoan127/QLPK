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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class UpdatePatient : Form
    {
        BUS_BenhNhan bn;
        private static string id = "";
        private AdminInterface mainForm;
        string role = "";

        public UpdatePatient(AdminInterface form, string role)
        {
            InitializeComponent();
            this.Size = new Size(700, 450);
            this.MaximumSize = new Size(700, 450);
            this.MinimumSize = new Size(700, 450);
            mainForm = form;
            this.role = role;
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
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Tên bệnh nhân !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Số điện thoại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Địa chỉ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Cân nặng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Sp02 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Nhiệt độ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox6.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Mạch !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox7.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Nhịp thở !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox8.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox9.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Huyết áp !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox9.Focus();
            }
        }

        public void updateCurrent(string MaBN)
        {
            id = MaBN;
            DateTime nowDate = DateTime.Now;

            bn = new BUS_BenhNhan("", "", "", nowDate, "", "", "", "", "", "", "", "", "", nowDate);
            DataTable dt = bn.getBNInfo(MaBN);

            textBox1.Text = dt.Rows[0]["Ten"].ToString().Trim();
            textBox2.Text = dt.Rows[0]["SDT"].ToString().Trim();
            dateTimePicker1.Value = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            comboBox1.Text = dt.Rows[0]["GioiTinh"].ToString().Trim().Trim();
            textBox3.Text = dt.Rows[0]["DiaChi"].ToString().Trim();

            textBox4.Text = dt.Rows[0]["CanNang"].ToString().Trim();
            textBox5.Text = dt.Rows[0]["sp02"].ToString().Trim();
            textBox6.Text = dt.Rows[0]["NhietDo"].ToString().Trim();
            textBox7.Text = dt.Rows[0]["Mach"].ToString().Trim();
            textBox9.Text = dt.Rows[0]["HuyetAp"].ToString().Trim();
            textBox8.Text = dt.Rows[0]["NhipTho"].ToString().Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new PatientManagement(mainForm, role));
            this.Hide();
            mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ten = textBox1.Text;
            string sdt = textBox2.Text;
            DateTime ngaysinh = dateTimePicker1.Value;
            string gioitinh = comboBox1.Text;
            string diachi = textBox3.Text;

            string cannang = textBox4.Text;
            string sp02 = textBox5.Text;
            string nhietdo = textBox6.Text;
            string mach = textBox7.Text;
            string huyetap = textBox9.Text;
            string nhiptho = textBox8.Text;

            bn = new BUS_BenhNhan(id, ten, sdt, ngaysinh, gioitinh, diachi, cannang, sp02, nhietdo, mach, huyetap, nhiptho, "Active", DateTime.Now);
            bn.updateCurrentQuery();
            mainForm.openChildForm(new PatientManagement(mainForm, role));
            this.Hide();
            mainForm.Show();
        }
    }
}
