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

namespace GUI
{
    public partial class LoginForm : Form
    {
        BUS_TKAdmin b;
        public LoginForm()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string tk = textBox1.Text;
            string mk = textBox2.Text;
            b = new BUS_TKAdmin(tk, mk);
            if(b.checkQuery() == true)
            {
                AdminInterface adminForm = new AdminInterface();
                adminForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
