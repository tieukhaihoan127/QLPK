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
        BUS_TaiKhoan acc;
        public LoginForm()
        {
            InitializeComponent();
            this.Size = new Size(600, 430);
            this.MaximumSize = new Size(600, 430);
            this.MinimumSize = new Size(600, 430);
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tk = textBox1.Text;
            string mk = textBox2.Text;
            acc = new BUS_TaiKhoan("","","","", DateTime.Now);
            if(acc.checkQuery(tk,mk) == true)
            {
                DataTable dt = acc.selectVaiTro(tk, mk);
                DataTable nvID = acc.selectID(tk,mk);
                if(dt.Rows.Count > 0 && nvID.Rows.Count > 0)
                {
                    string role = dt.Rows[0]["VaiTro"].ToString().Trim();
                    string ma = nvID.Rows[0]["MaNV"].ToString().Trim();

                    AdminInterface form = new AdminInterface(role, ma);
                    form.Show();
                    this.Hide();
                    MessageBox.Show("Đăng nhập thành công");
                }
                else
                {
                    MessageBox.Show("Tài khoản chưa tồn tại !");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ !");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = false;
        }
    }
}
