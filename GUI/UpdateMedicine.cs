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
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class UpdateMedicine : Form
    {
        BUS_Thuoc t;
        private static string id = "";
        string role = "";
        AdminInterface mainForm;
        public UpdateMedicine(AdminInterface form, string role)
        {
            InitializeComponent();
            this.Size = new Size(533, 570);
            this.MaximumSize = new Size(533, 570);
            this.MinimumSize = new Size(533, 570);
            mainForm = form;
            this.role = role;
        }

        private void loadComboBox()
        {
            comboBox1.Items.Add("Kháng sinh");
            comboBox1.Items.Add("Cơ xương khớp");
            comboBox1.Items.Add("Tim mạch");
            comboBox1.Items.Add("Thần kinh");
            comboBox1.Items.Add("Vitamin và thuốc bổ");
            comboBox1.Items.Add("Tiết niệu");
            comboBox1.Items.Add("Dị ứng");
            comboBox1.Items.Add("Hạ sốt, giảm đau");
            comboBox1.Items.Add("Kháng viêm");
            comboBox1.Items.Add("Kháng virus");
            comboBox1.Items.Add("Tai - mũi - họng");
            comboBox1.Items.Add("Thuốc dùng ngoài");

            comboBox2.Items.Add("Viên");
            comboBox2.Items.Add("Chai");
            comboBox2.Items.Add("Lọ");
            comboBox2.Items.Add("Vĩ");
            comboBox2.Items.Add("Hộp");
            comboBox2.Items.Add("Ống");
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
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Tên thuốc !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Nhà sản xuất !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Giá bán !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Giá nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
            }

            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Cách dùng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBox1.Focus();
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            loadComboBox();
        }

        public void updateCurrent(string MaThuoc)
        {
            id = MaThuoc;
            DateTime nowDate = DateTime.Now;
            t = new BUS_Thuoc("", "", "", 0, 0, "", "", nowDate, "", "");
            DataTable dt = t.getThuocInfo(MaThuoc);

            textBox1.Text = dt.Rows[0]["TenThuoc"].ToString().Trim();
            textBox2.Text = dt.Rows[0]["NSX"].ToString().Trim();
            textBox3.Text = dt.Rows[0]["GiaBan"].ToString().Trim();
            textBox4.Text = dt.Rows[0]["GiaNhap"].ToString().Trim();
            comboBox1.Text = dt.Rows[0]["DanhMuc"].ToString().Trim();
            comboBox2.Text = dt.Rows[0]["DonViTinh"].ToString().Trim();
            richTextBox1.Text = dt.Rows[0]["CachDung"].ToString().Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new MedicineManagement(mainForm, role));
            this.Hide();
            mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ten = textBox1.Text;
            string nsx = textBox2.Text;
            string dm = comboBox1.Text;
            string dvt = comboBox2.Text;
            string cd = richTextBox1.Text;

            BigInteger gn = BigInteger.Parse(textBox4.Text);
            BigInteger gb = BigInteger.Parse(textBox3.Text);

            t = new BUS_Thuoc(id, ten, dvt, gn, gb, dm, nsx, DateTime.Now, cd, "Active");
            t.updateCurrentQuery();
            mainForm.openChildForm(new MedicineManagement(mainForm, role));
            this.Hide();
            mainForm.Show();
        }
    }
}
