using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ViewPrescription : Form
    {
        BUS_Toa toa;
        BUS_BenhNhan bn;
        BUS_DichVu dv;
        BUS_Thuoc t;
        AdminInterface mainForm;
        string role = "";
        private static string id = "";
        public ViewPrescription(AdminInterface form, string role)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(930, 750);
            this.MaximumSize = new System.Drawing.Size(930, 750);
            this.MinimumSize = new System.Drawing.Size(930, 750);
            mainForm = form;
            this.role = role;
        }

        private void loadThuoc()
        {
            dataGridView1.Columns.Add("TenThuoc","Tên thuốc");
            dataGridView1.Columns.Add("DonVi", "Đơn vị");
            dataGridView1.Columns.Add("SoLuong", "Số lượng");
            dataGridView1.Columns.Add("GiaBan", "Giá bán");
            dataGridView1.Columns.Add("CachDung", "Cách dùng");
        }

        public void updateCurrent(string MaToa)
        {
            id = MaToa;
            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now,0);
            DataTable dtt = toa.getToaInfo(MaToa);

            string maBN = dtt.Rows[0]["MaBN"].ToString();
            bn = new BUS_BenhNhan("", "", "", DateTime.Now, "", "", "", "", "", "", "", "", "", DateTime.Now);
            DataTable dtbn = bn.getBNInfo(maBN);

            textBox1.Text = dtt.Rows[0]["MaBN"].ToString().Trim();
            textBox2.Text = dtbn.Rows[0]["Ten"].ToString().Trim();
            textBox3.Text = dtbn.Rows[0]["DiaChi"].ToString().Trim();
            textBox4.Text = dtbn.Rows[0]["SDT"].ToString().Trim();
            textBox5.Text = dtbn.Rows[0]["CanNang"].ToString().Trim();
            textBox6.Text = dtbn.Rows[0]["sp02"].ToString().Trim();
            textBox7.Text = dtbn.Rows[0]["HuyetAp"].ToString().Trim();
            textBox8.Text = dtbn.Rows[0]["NhietDo"].ToString().Trim();
            textBox9.Text = dtbn.Rows[0]["NhipTho"].ToString().Trim();
            textBox10.Text = dtbn.Rows[0]["Mach"].ToString().Trim();
            textBox11.Text = dtt.Rows[0]["SoLuongThuoc"].ToString().Trim();
            textBox12.Text = dtt.Rows[0]["TongTien"].ToString().Trim();

            dateTimePicker1.Value = DateTime.Parse(dtt.Rows[0]["NgayLap"].ToString());
            dateTimePicker2.Value = DateTime.Parse(dtbn.Rows[0]["NgaySinh"].ToString());
            dateTimePicker3.Value = DateTime.Parse(dtt.Rows[0]["NgayTaiKham"].ToString());

            comboBox1.Text = dtt.Rows[0]["TienSu"].ToString().Trim();
            comboBox2.Text = dtt.Rows[0]["ChanDoan"].ToString().Trim();
            richTextBox1.Text = dtt.Rows[0]["TrieuChung"].ToString().Trim();
            richTextBox2.Text = dtt.Rows[0]["LoiDan"].ToString().Trim();

        }

        private void FormLoad(object sender,EventArgs e)
        {
            loadThuoc();
            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now,0);
            DataTable thuoc = toa.selectMaThuoc(id);


            foreach (DataRow row in thuoc.Rows)
            {
                string maThuoc = row["MaThuoc"].ToString();

                t = new BUS_Thuoc("", "", "", 0, 0, "", "", DateTime.Now, "", "");
                DataTable thuocInfo = t.getThuocInfo(maThuoc);

                DataGridViewRow newRow = new DataGridViewRow();

                string first = row["TenThuoc"].ToString().Trim();
                string second = row["DonViTinh"].ToString().Trim();
                string third = row["SoLuong"].ToString().Trim();
                string fourth = row["GiaBan"].ToString().Trim();
                string fifth = row["CachDung"].ToString().Trim();

                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = first });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = second });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = third });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = fourth });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = fifth });

                dataGridView1.Rows.Add(newRow);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.openChildForm(new PrescriptionManagement(mainForm, role));
            this.Hide();
            mainForm.Show();
        }
    }
}
