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
    public partial class PrescriptionManagement : Form
    {
        BUS_Toa toa;
        AdminInterface mainForm;
        int currentPage = 1;
        int itemsPerPage = 7;
        DataTable data;

        public PrescriptionManagement(AdminInterface form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void DisplayPage(int page)
        {
            int startIndex = (page - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage - 1, data.Rows.Count - 1);
            DataTable pageDataTable = data.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageDataTable.ImportRow(data.Rows[i]);
            }

            dataGridView1.DataSource = pageDataTable;

            if (startIndex == 0)
            {
                button8.Enabled = false;
            }
            else
            {
                button8.Enabled = true;
            }

            if ((currentPage * itemsPerPage) >= data.Rows.Count)
            {
                button9.Enabled = false;
            }
            else
            {
                button9.Enabled = true;
            }
        }

        private int TotalPages
        {
            get { return (int)Math.Ceiling((double)data.Rows.Count / itemsPerPage); }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now,0);
            data = toa.selectQuery();
            DisplayPage(currentPage);
            label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (currentPage < TotalPages)
            {
                currentPage++;
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now,0);
            toa.updateQuery(dataGridView1);
            Form_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateMedicine form = new UpdateMedicine(mainForm);
            DataGridViewSelectedRowCollection dt = dataGridView1.SelectedRows;
            form.updateCurrent(dt[0].Cells["MaThuoc"].Value.ToString());
            form.Show();
            mainForm.Hide();
        }

        private char getTheLetter(string text)
        {
            return text[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string text = button6.Text;
            char c = getTheLetter(text);

            if (c == 'T')
            {
                button6.Text = "Khôi phục";
                toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now,0);
                data = toa.selectDeleteQuery();
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
            }
            else if (c == 'K')
            {
                button6.Text = "Thùng rác";
                toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now,0);
                toa.updateActiveQuery(dataGridView1);
                Form_Load(sender, e);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ViewPrescription form = new ViewPrescription(mainForm);
            DataGridViewSelectedRowCollection dt = dataGridView1.SelectedRows;
            string ma = dt[0].Cells["MaToa"].Value.ToString();
            form.updateCurrent(ma);
            form.Show();
            mainForm.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            UpdatePrescription form = new UpdatePrescription(mainForm);
            DataGridViewSelectedRowCollection dt = dataGridView1.SelectedRows;
            string ma = dt[0].Cells["MaToa"].Value.ToString();
            form.updateCurrent(ma);
            form.Show();
            mainForm.Hide();
        }
    }
}
