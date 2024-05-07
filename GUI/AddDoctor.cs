using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BUS;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Web.Caching;

namespace GUI
{
    public partial class AddDoctor : Form
    {
        BUS_NhanVien nv;
        BUS_BacSi bs;
        BUS_TaiKhoan tk;
        AdminInterface mainForm;

        public AddDoctor(AdminInterface form)
        {
            InitializeComponent();
            mainForm = form;    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new DoctorManagement(mainForm));
            this.Hide();
            mainForm.Show();
        }

        private string getName(string name)
        {
            string lower = name.ToLower();
            string[] nameParts = lower.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return nameParts[nameParts.Length - 1];
        }

        private string getPass(string pass)
        {
            string lower = pass.ToLower();
            string[] nameParts = lower.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string mk = string.Join(" ", nameParts);
            return mk;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = textBox1.Text;
                string phone = textBox2.Text;
                string CMND = textBox3.Text;
                string email = textBox5.Text;
                DateTime date = dateTimePicker1.Value;
                string contact = textBox6.Text;
                BigInteger salary = BigInteger.Parse(textBox7.Text);
                string chuyen = textBox9.Text;
                string yoe = textBox8.Text;
                string hv = textBox11.Text;
                string lang = textBox10.Text;
                string gender = comboBox1.Text;

                string username = getName(ten) + phone;
                string pass = getPass(ten);

                nv = new BUS_NhanVien("", ten, phone, gender, email, contact, CMND, "BacSi", date, salary);
                bs = new BUS_BacSi("", chuyen, hv, yoe, lang, "Active");
                nv.addQuery();
                bs.addQuery();
                string id = nv.getDoctorDesc().Rows[0]["MaNV"].ToString().Trim();
                tk = new BUS_TaiKhoan(username, pass, "Active", id, DateTime.Now);
                tk.addQuery();
                mainForm.openChildForm(new DoctorManagement(mainForm));
                this.Hide();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
