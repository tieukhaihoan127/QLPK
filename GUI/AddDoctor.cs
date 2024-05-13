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
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class AddDoctor : Form
    {
        BUS_NhanVien nv;
        BUS_BacSi bs;
        BUS_TaiKhoan tk;
        AdminInterface mainForm;
        string role = "";

        public AddDoctor(AdminInterface form,string role)
        {
            InitializeComponent();
            this.Size = new Size(533, 580);
            this.MaximumSize = new Size(533, 580);
            this.MinimumSize = new Size(533, 580);
            this.role = role;
            mainForm = form;    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new DoctorManagement(mainForm, role));
            this.Hide();
            mainForm.Show();
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            string emailAddress = textBox5.Text;
            if (IsEmailValid(emailAddress))
            {
                MessageBox.Show("Địa chỉ email hợp lệ.");
            }
            else
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.");
                textBox5.Text = "";
                textBox5.Focus(); 
            }
        }

        private bool IsEmailValid(string emailAddress)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(emailAddress);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_KeyPress_Length(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ ! Vui lòng nhập lại");
                textBox2.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length != 12)
            {
                MessageBox.Show("CCCD/CMND không hợp lệ ! Vui lòng nhập lại");
                textBox3.Text = "";
            }
        }

        private void disableText()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            comboBox1.Text = "";
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
                BigInteger salary = 0;
                if(textBox7.Text != "")
                {
                    salary = BigInteger.Parse(textBox7.Text);
                }
                string chuyen = textBox9.Text;
                string yoe = textBox8.Text;
                string hv = textBox11.Text;
                string lang = textBox10.Text;
                string gender = comboBox1.Text;

                if(ten == ""  || phone == ""  || email == "" || date == DateTime.Now || gender == "" )
                {
                    MessageBox.Show("Chưa điền đủ tối thiểu thông tin nhân viên");
                    disableText();
                    return;
                }

                nv = new BUS_NhanVien("", ten, phone, gender, email, contact, CMND, "BacSi", date, salary);
                bs = new BUS_BacSi("", chuyen, hv, yoe, lang, "Active");

                if(nv.selectPhone(phone).Rows.Count > 0)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại !");
                    disableText();
                    return;
                }

                if (nv.selectCMND(CMND).Rows.Count > 0)
                {
                    MessageBox.Show("Chứng Minh Nhân Dân đã tồn tại !");
                    disableText();
                    return;
                }

                string username = nv.getName(ten) + phone;
                string pass = nv.getPass(ten);

                nv.addQuery();
                bs.addQuery();

                string id = nv.getDoctorDesc().Rows[0]["MaNV"].ToString().Trim();
                tk = new BUS_TaiKhoan(username, pass, "Active", id, DateTime.Now);
                tk.addQuery();

                mainForm.openChildForm(new DoctorManagement(mainForm, role));
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
