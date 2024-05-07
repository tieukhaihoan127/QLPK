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
    public partial class ChooseEmployee : Form
    {
        private AdminInterface parentForm;
        public ChooseEmployee(AdminInterface form)
        {
            InitializeComponent();
            parentForm = form;
        }

        public void openChildForm(Form childForm)
        {
            AdminInterface adminInterface = new AdminInterface();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            adminInterface.panel10.Controls.Add(childForm);
            adminInterface.panel10.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            parentForm.openChildForm(new DoctorManagement(parentForm));
        }

        private void label10_Click(object sender, EventArgs e)
        {
          
        }
    }
}
