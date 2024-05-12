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

namespace GUI
{
    public partial class ServiceManagement : Form
    {
        BUS_DichVu dv;
        AdminInterface mainForm;
        int currentPage = 1;
        int itemsPerPage = 6;
        string role = "";
        DataTable data;

        public ServiceManagement(AdminInterface form,string role)
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
            DateTime nowDate = DateTime.Now;

            dv = new BUS_DichVu("", "", 0, "", nowDate, "");
            if(dv.selectQuery().Rows.Count > 0)
            {
                data = dv.selectQuery();
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
                dataGridView1.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            AddService form = new AddService(mainForm, role);
            form.Show();
            mainForm.Hide();
        }

        private void DeleteSelectedService()
        {
            data = dv.selectQuery();
            if (currentPage > 1 && (currentPage - 1) * itemsPerPage >= data.Rows.Count)
            {
                currentPage--;
            }
            DisplayPage(currentPage);
            label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime nowDate = DateTime.Now;

            dv = new BUS_DichVu("", "", 0, "", nowDate, "");
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dv.updateQuery(dataGridView1);
                DeleteSelectedService();
                if (dataGridView1.SelectedRows.Count > 0)
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
            UpdateService form = new UpdateService(mainForm, role);
            DataGridViewSelectedRowCollection dt = dataGridView1.SelectedRows;
            if (dt.Count > 0)
            {
                form.updateCurrent(dt[0].Cells["MaDV"].Value.ToString());
                form.Show();
                mainForm.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin dịch vụ !");
                return;
            }
        }

        private char getTheLetter(string text)
        {
            return text[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string text = button6.Text;
            char c = getTheLetter(text);

            if (c == 'X')
            {
                button6.Text = "Khôi phục";
                button12.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                DateTime nowDate = DateTime.Now;
                dv = new BUS_DichVu("", "", 0, "", nowDate, "");
                data = dv.selectDeleteQuery();
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
            }
            else if (c == 'K')
            {
                button6.Text = "Xem xóa";
                button12.Enabled = true;
                button5.Enabled = true;
                button4.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                DateTime nowDate = DateTime.Now;
                dv = new BUS_DichVu("", "", 0, "", nowDate, "");
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn khôi phục ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dv.updateActiveQuery(dataGridView1);
                    Form_Load(sender, e);
                    MessageBox.Show("Đã khôi phục thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hủy khôi phục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            ViewService form = new ViewService(mainForm, role);
            DataGridViewSelectedRowCollection dt = dataGridView1.SelectedRows;
            if(dt.Count > 0)
            {
                form.updateCurrent(dt[0].Cells["MaDV"].Value.ToString());
                form.Show();
                mainForm.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin dịch vụ !");
                return;
            }
          
        }

        private void textBox1_TextClick(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dv = new BUS_DichVu("", "", 0, "", DateTime.Now, "");
            string text = textBox1.Text;
            if(text != "Nhập từ khóa :" || text == "")
            {
                data = dv.selectSearch(text);
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();

            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm !");
                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dv = new BUS_DichVu("", "", 0, "", DateTime.Now, "");
            string text = textBox1.Text;
            if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
            {
                data = dv.selectTimeFilter(dateTimePicker1.Value, dateTimePicker2.Value);
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();

            }
            else
            {
                MessageBox.Show("Thời gian đã chọn không hợp lệ !");
                return;
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
    }
}
