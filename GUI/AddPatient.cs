﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class AddPatient : Form
    {
        BUS_BenhNhan bn;
        AdminInterface mainForm;
        public AddPatient(AdminInterface form)
        {
            InitializeComponent();
            mainForm  = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = textBox1.Text;
                string sdt = textBox2.Text;
                DateTime ngaysinh = dateTimePicker1.Value;
                string gioitinh = comboBox1.Text;
                string diachi = textBox3.Text;

                string cannang = textBox4.Text;
                string sp02 = textBox5.Text;
                string nhietdo = textBox6.Text;
                string mach = textBox7.Text;
                string huyetap = textBox9.Text;
                string nhiptho = textBox8.Text;

                bn = new BUS_BenhNhan("", ten, sdt, ngaysinh, gioitinh, diachi, cannang, sp02, nhietdo, mach, huyetap, nhiptho, "Active", DateTime.Now);
                bn.addQuery();
                mainForm.openChildForm(new PatientManagement(mainForm));
                this.Hide();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new PatientManagement(mainForm));
            this.Hide();
            mainForm.Show();
        }
    }
}