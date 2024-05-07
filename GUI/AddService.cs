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
        public AddService(AdminInterface mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = textBox1.Text;
                string donvi = comboBox1.Text;
                BigInteger gia = BigInteger.Parse(textBox2.Text);


                dv = new BUS_DichVu("", ten, gia, donvi, DateTime.Now, "Active");
                dv.addQuery();
                mainForm.openChildForm(new ServiceManagement(mainForm));
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
            mainForm.openChildForm(new ServiceManagement(mainForm));
            this.Hide();
            mainForm.Show();
        }
    }
}
