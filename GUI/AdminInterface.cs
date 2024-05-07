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
        public AdminInterface()
        {
            InitializeComponent();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new ChooseEmployee(this));
            label9.Text = button1.Text;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new ServiceManagement(this));
            label9.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new PatientManagement(this));
            label9.Text = button3.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new MedicineManagement(this));
            label9.Text = button6.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new PrescriptionManagement(this));
            label9.Text = button4.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new ReportManagement(this));
            label9.Text = button7.Text;

        }
    }
}
