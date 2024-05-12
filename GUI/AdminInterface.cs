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

namespace GUI
{
    public partial class AdminInterface : Form
    {
        string role,ma;
        BUS_NhanVien nv;
        public AdminInterface(string role, string ma)
        {
            InitializeComponent();
            this.Size = new Size(1080, 460);
            this.MaximumSize = new Size(1080, 460);
            this.MinimumSize = new Size(1080, 460);
            this.role = role;
            this.ma = ma;
        }

        public Form currentForm;

        public void openChildForm(Form childForm)
        {

            if(currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel10.Controls.Add(childForm);
            panel10.Tag = childForm;
            childForm.Show();
        }

        public void changeLabel ()
        {
            label9.Text = "Quản lý toa";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            openChildForm(new DoctorManagement(this, role));
            label9.Text = button1.Text;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            openChildForm(new ServiceManagement(this,role));
            label9.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            openChildForm(new PatientManagement(this, role));
            label9.Text = button3.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            openChildForm(new MedicineManagement(this,role));
            label9.Text = button6.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            openChildForm(new PrescriptionManagement(this, role));
            label9.Text = button4.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            openChildForm(new ReportManagement(this,role));
            label9.Text = "";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            ForgotPasswordForm form = new ForgotPasswordForm(role,ma);
            form.Show();
            this.Hide();     
        }

        private void AdminInterface_Load(object sender, EventArgs e)
        {
            nv = new BUS_NhanVien("", "", "", "", "", "", "", "", DateTime.Now, 0);
            DataTable dt = nv.selectDataByID(ma);
            string name = dt.Rows[0]["Ten"].ToString();

            label1.Text = name;

            if (role == "BacSi")
            {
                button1.Visible = false;
                button2.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button3.Location = new System.Drawing.Point(0, 59);
                button4.Location = new System.Drawing.Point(0, 99);
                button5.Location = new System.Drawing.Point(0, 139);
                button8.Location = new System.Drawing.Point(0, 179);
                button9.Location = new System.Drawing.Point(0, 219);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            ViewPersonalInformation form = new ViewPersonalInformation(role,ma);
            form.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất ?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm form = new LoginForm();
                form.Show();
                this.Hide();
            }
      
        }
    }
}
