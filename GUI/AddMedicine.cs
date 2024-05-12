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

namespace GUI
{
    public partial class AddMedicine : Form
    {
        BUS_Thuoc t;
        AdminInterface mainForm;
        string role = "";
        public AddMedicine(AdminInterface mainForm, string role)
        {
            InitializeComponent();
            this.Size = new Size(533, 570);
            this.MaximumSize = new Size(533, 570);
            this.MinimumSize = new Size(533, 570);
            this.mainForm = mainForm;
            this.role = role;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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

        private void FormLoad(object sender,EventArgs e)
        {
            loadComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = textBox1.Text;
                string NSX = textBox2.Text;
                string dm = comboBox1.Text;
                string dvt = comboBox2.Text;
                BigInteger gianhap = BigInteger.Parse(textBox4.Text);
                BigInteger giaban = BigInteger.Parse(textBox3.Text);
                string cachdung = richTextBox1.Text;


                t = new BUS_Thuoc("", ten, dvt, gianhap, giaban, dm, NSX, DateTime.Now, cachdung, "Active");
                t.addQuery();
                mainForm.openChildForm(new MedicineManagement(mainForm, role));
                this.Hide();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new MedicineManagement(mainForm,role));
            this.Hide();
            mainForm.Show();
        }
    }
}
