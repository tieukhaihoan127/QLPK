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
        int itemsPerPage = 6;
        DataTable data;
        BUS_Toa toa;
        BUS_GiayChiDinh gcd;
        public ReportManagement(AdminInterface form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void loadComboBox()
        {
            comboBox2.Items.Add("Báo cáo tổng hợp");
            comboBox2.Items.Add("Báo cáo danh sách bệnh khám");
            comboBox2.Items.Add("Báo cáo doanh thu chi tiết từng dịch vụ");

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

        private BigInteger getTongTienThuoc()
        {
            int TongSoLuong = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TongTienThuoc"].Value != null)
                {
                    TongSoLuong += (int.Parse(row.Cells["TongTienThuoc"].Value.ToString()));
                }
            }
            return TongSoLuong;
        }

        private BigInteger getTongTienDichVu()
        {
            int TongSoLuong = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TongTienDIchVu"].Value != null)
                {
                    TongSoLuong += (int.Parse(row.Cells["TongTienDichVu"].Value.ToString()));
                }
            }
            return TongSoLuong;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            loadComboBox();
            DateTime nowDate = DateTime.Now;
            DataTable dt = new DataTable();
            dt.Columns.Add("NgayLap", typeof(string));
            dt.Columns.Add("TongTienThuoc", typeof(string));
            dt.Columns.Add("TongTienDichVu", typeof(string));

            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now, 0);
            gcd = new BUS_GiayChiDinh("", "", "", "", "", "", "Active", DateTime.Now, DateTime.Now, 0);
            DataTable dtt = toa.selectNgayLap();

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

            BigInteger totalAll = getTongTienDichVu() + getTongTienThuoc();
            textBox1.Text = totalAll.ToString();
            textBox2.Text = getTongTienThuoc().ToString();
            textBox3.Text = getTongTienDichVu().ToString();
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

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            string value = comboBox2.Text;

            if(value == "Báo cáo tổng hợp")
            {
                MessageBox.Show("ok");
            }
        }
    }
}
