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

namespace GUI
{
    public partial class ForgotPasswordForm : Form
    {
        private int vCode = 1000;
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Verification code sent successful ! Go to Gmail and verify","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == vCode.ToString())
            {
                MessageBox.Show("Valid");
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }
    }
}
