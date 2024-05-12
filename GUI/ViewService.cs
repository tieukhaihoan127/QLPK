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

namespace GUI
{
    public partial class ViewService : Form
    {
        AdminInterface mainForm;
        BUS_DichVu dv;
        string role = "";
        private static string id = "";
        public ViewService(AdminInterface form, string role)
        {
            InitializeComponent();
            this.Size = new Size(380, 420);
            this.MaximumSize = new Size(380, 420);
            this.MinimumSize = new Size(380, 420);
            mainForm = form;
            this.role = role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new ServiceManagement(mainForm, role));
            this.Hide();
            mainForm.Show();
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
            textBox3.Text = dt.Rows[0]["MaDV"].ToString().Trim();
            dateTimePicker1.Value = DateTime.Parse(dt.Rows[0]["NgayLap"].ToString());

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
            textBox3.Enabled = false;
            dateTimePicker1.Enabled = false;
        }
    }
}
