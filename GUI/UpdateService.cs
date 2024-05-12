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
    public partial class UpdateService : Form
    {

        BUS_DichVu dv;
        private static string id = "";
        string role = "";
        AdminInterface mainForm;
        public UpdateService(AdminInterface form, string role)
        {
            InitializeComponent();
            this.Size = new Size(380, 380);
            this.MaximumSize = new Size(380, 380);
            this.MinimumSize = new Size(380, 380);
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
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Tên dịch vụ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô Giá !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
            }
        }

        private void loadComboBox()
        {
            comboBox1.Items.Add("VND");
            comboBox1.Items.Add("LẦN");
            comboBox1.Items.Add("USD");
            comboBox1.Items.Add("AUD");
        }

        private void FormLoad(object sender, EventArgs e)
        {
            loadComboBox();
        }

        public void updateCurrent(string MaDV)
        {
            id = MaDV;
            DateTime nowDate = DateTime.Now;
            dv = new BUS_DichVu("", "", 0, "", nowDate, "");
            DataTable dt = dv.getDVInfo(MaDV);

            textBox1.Text = dt.Rows[0]["Ten"].ToString().Trim();
            textBox2.Text = dt.Rows[0]["Gia"].ToString().Trim();
            comboBox1.Text = dt.Rows[0]["DonVi"].ToString().Trim();
;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new ServiceManagement(mainForm, role));
            this.Hide();
            mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ten = textBox1.Text;
            BigInteger gia = BigInteger.Parse(textBox2.Text);
            string donvi = comboBox1.Text;


            dv = new BUS_DichVu(id, ten, gia, donvi, DateTime.Now, "");
            dv.updateCurrentQuery();
            mainForm.openChildForm(new ServiceManagement(mainForm, role));
            this.Hide();
            mainForm.Show();
        }

    }
}
