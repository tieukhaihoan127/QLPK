using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class DoctorManagement : Form
    {
        BUS_NhanVien nv;
        BUS_BacSi bs;
        AdminInterface mainForm;
        int currentPage = 1;
        int itemsPerPage = 6;
        DataTable data;

        public DoctorManagement(AdminInterface form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxLoad()
        {
            comboBox1.Items.Add("Mã bác sĩ tăng dần");
            comboBox1.Items.Add("Mã bác sĩ giảm dần");
            comboBox1.Items.Add("Lương tăng dần");
            comboBox1.Items.Add("Lương giảm dần");
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

            if(startIndex == 0)
            {
                button8.Enabled = false;
            }
            else
            {
                button8.Enabled = true;
            }

            if((currentPage*itemsPerPage) >= data.Rows.Count)
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
            int items = comboBox1.Items.Count;

            if(items <= 1)
            {
                comboBoxLoad();
            }

            DateTime nowDate = DateTime.Now;

            nv = new BUS_NhanVien("", "", "", "", "", "", "","", nowDate, 0);
            data = nv.selectQuery();
            DisplayPage(currentPage);
            label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
        }

        private void selectedIndexChange(object sender, EventArgs e)
        {
            int option = comboBox1.SelectedIndex;

            DateTime nowDate = DateTime.Now;
            nv = new BUS_NhanVien("", "", "", "", "", "", "", "", nowDate, 0);

            dataGridView1.DataSource = nv.selectedChangeQuery(option);
        }

        private void searchDoctor(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            DateTime nowDate = DateTime.Now;
            nv = new BUS_NhanVien("", "", "", "", "", "", "", "", nowDate, 0);
            dataGridView1.DataSource = nv.searchDoctor(value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddDoctor form = new AddDoctor(mainForm);
            form.Show();
            mainForm.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bs = new BUS_BacSi("", "", "", "", "", "");
            bs.updateQuery(dataGridView1);
            Form_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateDoctor form = new UpdateDoctor(mainForm);
            DataGridViewSelectedRowCollection dt = dataGridView1.SelectedRows;
            form.SetDataGridView(dt[0].Cells["MaNV"].Value.ToString());
            form.updateCurrent(dt[0].Cells["MaNV"].Value.ToString());
            form.Show();
            mainForm.Hide();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private char getTheLetter(string text)
        {
            return text[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string text = button6.Text;
            char c = getTheLetter(text);

            if(c == 'T')
            {
                button6.Text = "Khôi phục";
                DateTime nowDate = DateTime.Now;
                nv = new BUS_NhanVien("", "", "", "", "", "", "", "", nowDate, 0);
                dataGridView1.DataSource = nv.selectDeleteQuery();
            }
            else if(c == 'K')
            {
                button6.Text = "Thùng rác";
                bs = new BUS_BacSi("", "", "", "", "", "");
                bs.updateActiveQuery(dataGridView1);
                Form_Load(sender, e);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string text = button6.Text;
            char c = getTheLetter(text);

            if (c == 'T')
            {
                mainForm.openChildForm(new ChooseEmployee(mainForm));
            }
            else if (c == 'K')
            {
                button6.Text = "Thùng rác";
                Form_Load(sender, e);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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

        private void button12_Click(object sender, EventArgs e)
        {
            ViewDoctor form = new ViewDoctor(mainForm);
            DataGridViewSelectedRowCollection dt = dataGridView1.SelectedRows;
            form.SetDataGridView(dt[0].Cells["MaNV"].Value.ToString());
            form.updateCurrent(dt[0].Cells["MaNV"].Value.ToString());
            form.Show();
            mainForm.Hide();
        }
    }
}
