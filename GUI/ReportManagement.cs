using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace GUI
{
    public partial class ReportManagement : Form
    {
        AdminInterface mainForm;
        int currentPage = 1;
        int itemsPerPage = 5;
        string role = "";
        DataTable data;
        BUS_Toa toa;
        BUS_GiayChiDinh gcd;
        public ReportManagement(AdminInterface form, string role)
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
            DataTable dt = new DataTable();
            dt.Columns.Add("NgayLap", typeof(string));
            dt.Columns.Add("TongTienThuoc", typeof(string));
            dt.Columns.Add("TongTienDichVu", typeof(string));

            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now, 0);
            gcd = new BUS_GiayChiDinh("", "", "", "", "", "", "Active", DateTime.Now, DateTime.Now, 0);
            DataTable dtt = toa.selectNgayLap();

            if(dtt.Rows.Count > 0)
            {
                foreach (DataRow row in dtt.Rows)
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    string day = row["Day"].ToString().Trim();
                    string month = row["Month"].ToString().Trim();
                    string year = row["Year"].ToString().Trim();
                    string date = day + "-" + month + "-" + year;
                    string totalThuoc = "0";
                    string totalDV = "0";

                    DataTable dtThuoc = toa.selectTongTienThuoc(int.Parse(day), int.Parse(month), int.Parse(year));
                    DataTable dtDV = gcd.selectTongTienDV(int.Parse(day), int.Parse(month), int.Parse(year));
                    if (dtThuoc.Rows.Count > 0)
                    {
                        totalThuoc = dtThuoc.Rows[0]["Total"].ToString().Trim();
                    }
                    if (dtDV.Rows.Count > 0)
                    {
                        totalDV = dtDV.Rows[0]["Total"].ToString().Trim();
                    }

                    dt.Rows.Add(date, totalThuoc, totalDV);

                }
                data = dt;
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();

                BigInteger totalAll = gcd.getTongTienDichVu(dataGridView1) + toa.getTongTienThuoc(dataGridView1);
                textBox1.Text = totalAll.ToString();
                textBox2.Text = toa.getTongTienThuoc(dataGridView1).ToString();
                textBox3.Text = gcd.getTongTienDichVu(dataGridView1).ToString();
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu nào !");
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

        private void textBox1_TextClick(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
            {
                DateTime nowDate = DateTime.Now;
                DataTable dt = new DataTable();
                dt.Columns.Add("NgayLap", typeof(string));
                dt.Columns.Add("TongTienThuoc", typeof(string));
                dt.Columns.Add("TongTienDichVu", typeof(string));

                toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now, 0);
                gcd = new BUS_GiayChiDinh("", "", "", "", "", "", "Active", DateTime.Now, DateTime.Now, 0);
                DataTable dtt = toa.selectFilterNgayLap(dateTimePicker1.Value, dateTimePicker2.Value);

                if(dtt.Rows.Count > 0)
                {
                    foreach (DataRow row in dtt.Rows)
                    {
                        DataGridViewRow newRow = new DataGridViewRow();

                        string day = row["Day"].ToString().Trim();
                        string month = row["Month"].ToString().Trim();
                        string year = row["Year"].ToString().Trim();
                        string date = day + "-" + month + "-" + year;
                        string totalThuoc = "0";
                        string totalDV = "0";

                        DataTable dtThuoc = toa.selectTongTienThuoc(int.Parse(day), int.Parse(month), int.Parse(year));
                        DataTable dtDV = gcd.selectTongTienDV(int.Parse(day), int.Parse(month), int.Parse(year));
                        if (dtThuoc.Rows.Count > 0)
                        {
                            totalThuoc = dtThuoc.Rows[0]["Total"].ToString().Trim();
                        }
                        if (dtDV.Rows.Count > 0)
                        {
                            totalDV = dtDV.Rows[0]["Total"].ToString().Trim();
                        }

                        dt.Rows.Add(date, totalThuoc, totalDV);

                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                }

                data = dt;
                DisplayPage(currentPage);
                label1.Text = currentPage.ToString() + "/" + TotalPages.ToString();

                BigInteger totalAll = gcd.getTongTienDichVu(dataGridView1) + toa.getTongTienThuoc(dataGridView1);
                textBox1.Text = totalAll.ToString();
                textBox2.Text = toa.getTongTienThuoc(dataGridView1).ToString();
                textBox3.Text = gcd.getTongTienDichVu(dataGridView1).ToString();

            }
            else
            {
                MessageBox.Show("Thời gian đã chọn không hợp lệ !");
                return;
            }
        }

    }
}
