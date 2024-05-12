﻿using System;
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
        int itemsPerPage = 5;
        string role = "";
        DataTable data;

        public DoctorManagement(AdminInterface form, string role)
        {
            InitializeComponent();
            mainForm = form;
            this.role = role;
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

            DateTime nowDate = DateTime.Now;

            nv = new BUS_NhanVien("", "", "", "", "", "", "","", nowDate, 0);
            if(nv.selectQuery().Rows.Count > 0)
            {
                data = nv.selectQuery();
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
                dataGridView1.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            else
            {
                button12.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = false;
                label1.Text = "0/0";
                button8.Enabled = false;
                button9.Enabled = false;
                button7.Enabled = false;
            }
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
            AddDoctor form = new AddDoctor(mainForm,role);
            form.Show();
            mainForm.Hide();
        }

        private void DeleteSelectedEmployee()
        {
            data = nv.selectQuery();
            if (currentPage > 1 && (currentPage - 1) * itemsPerPage >= data.Rows.Count)
            {
                currentPage--;
            }
            DisplayPage(currentPage);
            label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bs = new BUS_BacSi("", "", "", "", "", "");
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bs.updateQuery(dataGridView1);
                DeleteSelectedEmployee();
                if(dataGridView1.SelectedRows.Count > 0)
                {
                    MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Hủy xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateDoctor form = new UpdateDoctor(mainForm,role);
            DataGridViewSelectedRowCollection dt = dataGridView1.SelectedRows;
            if(dt.Count > 0)
            {
                form.SetDataGridView(dt[0].Cells["MaNV"].Value.ToString());
                form.updateCurrent(dt[0].Cells["MaNV"].Value.ToString());
                form.Show();
                mainForm.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin bệnh nhân !");
                return;
            }
        }

        private void textBox1_TextClick(object sender, EventArgs e)
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

            if(c == 'X')
            {
                button6.Text = "Khôi phục";
                button12.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                DateTime nowDate = DateTime.Now;
                nv = new BUS_NhanVien("", "", "", "", "", "", "", "", nowDate, 0);
                data = nv.selectDeleteQuery();
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
                dataGridView1.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            else if(c == 'K')
            {
                button6.Text = "Xem xóa";
                button12.Enabled = true;
                button5.Enabled = true;
                button4.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                bs = new BUS_BacSi("", "", "", "", "", "");
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn khôi phục ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bs.updateActiveQuery(dataGridView1);
                    Form_Load(sender, e);
                    MessageBox.Show("Đã khôi phục thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hủy khôi phục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form_Load(sender, e);
            textBox1.Text = "Nhập từ khóa :";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            button6.Text = "Xem xóa";
            button12.Enabled = true;
            button5.Enabled = true;
            button4.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
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
            ViewDoctor form = new ViewDoctor(mainForm,role);
            DataGridViewSelectedRowCollection dt = dataGridView1.SelectedRows;
            if(dt.Count > 0)
            {
                form.SetDataGridView(dt[0].Cells["MaNV"].Value.ToString());
                form.Show();
                mainForm.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin bệnh nhân !");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nv = new BUS_NhanVien("", "", "", "", "", "", "", "", DateTime.Now, 0);
            string text = textBox1.Text;
            if (text != "Nhập từ khóa :" || text == "")
            {
                data = nv.searchDoctor(text);
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();

            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm !");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nv = new BUS_NhanVien("", "", "", "", "", "", "", "", DateTime.Now, 0);
            if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
            {
                data = nv.selectTimeFilter(dateTimePicker1.Value, dateTimePicker2.Value);
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();

            }
            else
            {
                MessageBox.Show("Thời gian đã chọn không hợp lệ !");
                return;
            }
        }
    }
}
