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
    public partial class AddService : Form
    {
        BUS_DichVu dv;
        AdminInterface mainForm;
        string role = "";
        public AddService(AdminInterface mainForm, string role)
        {
            InitializeComponent();
            this.Size = new Size(380, 380);
            this.MaximumSize = new Size(380, 380);
            this.MinimumSize = new Size(380, 380);
            this.mainForm = mainForm;
            this.role = role;
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

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = textBox1.Text;
                string donvi = comboBox1.Text;
                BigInteger gia = 0;
                if(textBox2.Text != "")
                {
                    gia = BigInteger.Parse(textBox2.Text);
                }

                if(ten == "" || donvi == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin dịch vụ");
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    textBox2.Text = "";
                    return;
                }


                dv = new BUS_DichVu("", ten, gia, donvi, DateTime.Now, "Active");
                dv.addQuery();
                mainForm.openChildForm(new ServiceManagement(mainForm, role));
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
            mainForm.openChildForm(new ServiceManagement(mainForm, role));
            this.Hide();
            mainForm.Show();
        }
    }
}
