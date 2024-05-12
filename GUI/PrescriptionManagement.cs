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
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    public partial class PrescriptionManagement : Form
    {
        BUS_Toa toa;
        AdminInterface mainForm;
        int currentPage = 1;
        int itemsPerPage = 6;
        string role = "";
        DataTable data;

        public PrescriptionManagement(AdminInterface form, string role)
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
            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now,0);
            if(toa.selectQuery().Rows.Count > 0)
            {
                if (role.Contains("BN"))
                {
                    data = toa.selectDataByID(role);
                }
                else
                {
                    data = toa.selectQuery();
                }
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
                dataGridView1.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            else
            {
                button12.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button1.Enabled = false;
                label1.Text = "0/0";
                button8.Enabled = false;
                button9.Enabled = false;
                button7.Enabled = false;
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

        private void textBox1_TextClick(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void DeleteSelectedPrescription()
        {
            data = toa.selectQuery();
            if (currentPage > 1 && (currentPage - 1) * itemsPerPage >= data.Rows.Count)
            {
                currentPage--;
            }
            DisplayPage(currentPage);
            label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now,0);
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                toa.updateQuery(dataGridView1);
                DeleteSelectedPrescription();
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
                button1.Enabled = false;
                button2.Enabled = false;
                toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now,0);
                data = toa.selectDeleteQuery();
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();
            }
            else if (c == 'K')
            {
                button6.Text = "Xem xóa";
                button12.Enabled = true;
                button5.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now,0);
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn khôi phục ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    toa.updateActiveQuery(dataGridView1);
                    Form_Load(sender, e);
                    MessageBox.Show("Đã khôi phục thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hủy khôi phục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ViewPrescription form = new ViewPrescription(mainForm, role);
            DataGridViewSelectedRowCollection dt = dataGridView1.SelectedRows;
            if(dt.Count > 0)
            {
                string ma = dt[0].Cells["MaToa"].Value.ToString();
                form.updateCurrent(ma);
                form.Show();
                mainForm.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin toa !");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now, 0);
            string text = textBox1.Text;
            if (text != "Nhập từ khóa :" || text == "")
            {
                data = toa.selectSearch(text);
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();

            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm !");
                return;
            }
        }

        public void loadCurrentPatientPresciption()
        {
            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now, 0);
            if(toa.selectDataByID(role).Rows.Count > 0)
            {
                mainForm.changeLabel();
                mainForm.openChildForm(this);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Bệnh nhân này chưa có toa thuốc nào !");
                PatientManagement form = new PatientManagement(mainForm, role);
                mainForm.openChildForm(form);
                mainForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now, 0);
            if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
            {
                data = toa.selectFilterTime(dateTimePicker1.Value, dateTimePicker2.Value);
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
            button1.Enabled = true;
            button2.Enabled = true;
        }
    }
}
