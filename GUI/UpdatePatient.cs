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

namespace GUI
{
    public partial class UpdatePatient : Form
    {
        BUS_BenhNhan bn;
        private static string id = "";
        private AdminInterface mainForm;

        public UpdatePatient(AdminInterface form)
        {
            InitializeComponent();
            mainForm = form;
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
            mainForm.openChildForm(new PatientManagement(mainForm));
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
            mainForm.openChildForm(new PatientManagement(mainForm));
            this.Hide();
            mainForm.Show();
        }
    }
}
