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
using IronSoftware.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ZXing;

namespace GUI
{
    public partial class ViewPatient : Form
    {
        BUS_BenhNhan bn;
        AdminInterface mainForm;
        string role = "";
        private static string id = "";
        public ViewPatient(AdminInterface mainForm, string role)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(800, 650);
            this.MaximumSize = new System.Drawing.Size(800, 650);
            this.MinimumSize = new System.Drawing.Size(800, 650);
            this.mainForm = mainForm;
            this.role = role;
        }

        public void generateBarcode()
        {
            BarcodeWriter brcode = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128
            };

            pictureBox1.Image = brcode.Write(textBox1.Text);
        }

        public void updateCurrent(string MaBN)
        {
            id = MaBN;
            DateTime nowDate = DateTime.Now;

            bn = new BUS_BenhNhan("", "", "", nowDate, "", "", "", "", "", "", "", "", "", nowDate);
            DataTable dt = bn.getBNInfo(MaBN);

            textBox1.Text = dt.Rows[0]["MaBN"].ToString().Trim();
            textBox2.Text = dt.Rows[0]["Ten"].ToString().Trim();
            textBox3.Text = dt.Rows[0]["SDT"].ToString().Trim();
            dateTimePicker1.Value = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            dateTimePicker2.Value = DateTime.Parse(dt.Rows[0]["NgayLap"].ToString());
            textBox5.Text = dt.Rows[0]["GioiTinh"].ToString().Trim().Trim();
            textBox4.Text = dt.Rows[0]["DiaChi"].ToString().Trim();

            textBox7.Text = dt.Rows[0]["CanNang"].ToString().Trim();
            textBox6.Text = dt.Rows[0]["sp02"].ToString().Trim();
            textBox8.Text = dt.Rows[0]["NhietDo"].ToString().Trim();
            textBox9.Text = dt.Rows[0]["Mach"].ToString().Trim();
            textBox10.Text = dt.Rows[0]["HuyetAp"].ToString().Trim();
            textBox11.Text = dt.Rows[0]["NhipTho"].ToString().Trim();
        }

        private void FormLoad(object sender,EventArgs e)
        {
            label19.Text = id;
            generateBarcode();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new PatientManagement(mainForm, role));
            this.Hide();
            mainForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Prescription form = new Prescription(id,mainForm, role);
            this.Hide();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReferralForm form = new ReferralForm(id, mainForm);
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrescriptionManagement form = new PrescriptionManagement(mainForm, id);
            form.loadCurrentPatientPresciption();
            this.Hide();
        }
    }
}
