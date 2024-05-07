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
    public partial class UpdateService : Form
    {

        BUS_DichVu dv;
        private static string id = "";
        AdminInterface mainForm;
        public UpdateService(AdminInterface form)
        {
            InitializeComponent();
            mainForm = form;
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
            mainForm.openChildForm(new ServiceManagement(mainForm));
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
            mainForm.openChildForm(new ServiceManagement(mainForm));
            this.Hide();
            mainForm.Show();
        }

    }
}
