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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class ViewMedicine : Form
    {
        AdminInterface mainForm;
        BUS_Thuoc t;
        private static string id = "";
        public ViewMedicine(AdminInterface form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new MedicineManagement(mainForm));
            this.Hide();
            mainForm.Show();
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
            textBox5.Text = dt.Rows[0]["MaThuoc"].ToString().Trim();
            comboBox1.Text = dt.Rows[0]["DanhMuc"].ToString().Trim();
            comboBox2.Text = dt.Rows[0]["DonViTinh"].ToString().Trim();
            richTextBox1.Text = dt.Rows[0]["CachDung"].ToString().Trim();
            dateTimePicker1.Value = DateTime.Parse(dt.Rows[0]["NgayNhapHang"].ToString());

        }
    }
}
