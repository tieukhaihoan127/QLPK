using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using BUS;

namespace GUI
{
    public partial class ForgotPasswordForm : Form
    {
        BUS_TaiKhoan tk;
        BUS_NhanVien nv;
        private int vCode = 1000;
        private string role;
        private string ma;
        public ForgotPasswordForm(string role,string ma)
        {
            InitializeComponent();
            this.Size = new Size(625, 500);
            this.MaximumSize = new Size(625, 500);
            this.MinimumSize = new Size(625, 500);
            this.role = role;
            this.ma = ma;
            textBox1.PasswordChar = '*';
            textBox2.PasswordChar = '*';
        }

        private void sendMail()
        {
            nv = new BUS_NhanVien("", "", "", "", "", "", "", "", DateTime.Now, 0);
            DataTable dt = nv.selectDataByID(ma);
            string name = dt.Rows[0]["Email"].ToString();
            timer1.Stop();
            string to, from, pass, mail;
            to = "lengocmanhhung0108@gmail.com";
            from = "tieukhaihoan127@gmail.com";
            Random rnd = new Random();
            vCode = rnd.Next(10000, 100000);
            mail = vCode.ToString();
            pass = "omwr iotr hkky widi";
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mail;
            message.Subject = mail;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Verification code sent successful ! Go to Gmail and verify", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nv = new BUS_NhanVien("", "", "", "", "", "", "", "", DateTime.Now, 0);
            DataTable dt = nv.selectDataByID(ma);
            string name = dt.Rows[0]["Email"].ToString();
            timer1.Stop();
            string to, from, pass, mail;
            to = name;
            from = "tieukhaihoan127@gmail.com";
            Random rnd = new Random();
            vCode = rnd.Next(10000, 100000);
            mail = vCode.ToString();
            pass = "omwr iotr hkky widi";
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mail;
            message.Subject = mail;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Verification code sent successful ! Go to Gmail and verify", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            AdminInterface form = new AdminInterface(role, ma);
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tk = new BUS_TaiKhoan("", "", "", ma, DateTime.Now);
            DataTable dt = tk.selectTKByID(ma);
            string currentPass = dt.Rows[0]["MatKhau"].ToString();
            MessageBox.Show(currentPass);
            string mkOld = textBox1.Text;
            MessageBox.Show(mkOld);
            string mkNew = textBox2.Text;

            if(mkOld != currentPass.Trim())
            {
                MessageBox.Show("Mật khẩu của tài khoản không chính xác !");
                return;
            }

            if (textBox3.Text == vCode.ToString())
            {
                tk.updatePasswod(mkNew);
                MessageBox.Show("Đổi mật khẩu thành công !");
                AdminInterface form = new AdminInterface(role, ma);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mã OTP không hợp lệ !");
            }
        }
    }
}
