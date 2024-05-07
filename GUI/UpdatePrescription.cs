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
    public partial class UpdatePrescription : Form
    {
        BUS_Toa toa;
        BUS_BenhNhan bn;
        BUS_DichVu dv;
        BUS_Thuoc t;
        AdminInterface mainForm;
        DataGridViewComboBoxColumn comboBoxColumn1 = new DataGridViewComboBoxColumn();
        DataGridViewComboBoxColumn comboBoxColumn2 = new DataGridViewComboBoxColumn();
        private static string id = "";
        public UpdatePrescription(AdminInterface form)
        {
            InitializeComponent();
            this.Height = 900;
            mainForm = form;
        }

        private void loadThuoc()
        {
            t = new BUS_Thuoc("", "", "", 0, 0, "", "", DateTime.Now, "", "");
            DataTable dt1 = t.getThuocName();
            comboBoxColumn1.HeaderText = "Tên thuốc";
            comboBoxColumn1.Name = "TenThuoc";
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                comboBoxColumn1.Items.Add(dt1.Rows[i]["TenThuoc"].ToString());
            }
            dataGridView1.Columns.Add(comboBoxColumn1);
            dataGridView1.Columns.Add("DonVi", "Đơn vị");
            dataGridView1.Columns.Add("SoLuong", "Số lượng");
            dataGridView1.Columns.Add("GiaBan", "Giá bán");
            dataGridView1.Columns.Add("CachDung", "Cách dùng");
        }

        private void loadDV()
        {
            dv = new BUS_DichVu("", "", 0, "", DateTime.Now, "");
            DataTable dt2 = dv.getDVName();
            comboBoxColumn2.HeaderText = "Tên dịch vụ";
            comboBoxColumn2.Name = "TenDichVu";
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                comboBoxColumn2.Items.Add(dt2.Rows[i]["Ten"].ToString());
            }
            dataGridView2.Columns.Add(comboBoxColumn2);
            dataGridView2.Columns.Add("DonVi", "Đơn vị");
            dataGridView2.Columns.Add("SoLuong", "Số lượng");
            dataGridView2.Columns.Add("GiaBan", "Giá bán");
        }

        private void loadTienSuComboBox()
        {
            comboBox1.Items.Add("Chốc Da Nhiễm Trùng");
            comboBox1.Items.Add("Cơn Đau Quăn Thận");
            comboBox1.Items.Add("Cơn Đau Thắt Ngực Điển Hình");
            comboBox1.Items.Add("Dị Ứng");
            comboBox1.Items.Add("Đái Tháo Đường");
            comboBox1.Items.Add("Đau Cột Sống");
            comboBox1.Items.Add("Đau Thần Kinh Liên Sườn");
            comboBox1.Items.Add("Đau Thần Kinh Tọa");
            comboBox1.Items.Add("Đau Vai Gáy");
            comboBox1.Items.Add("Gan Nhiêm Mỡ");
            comboBox1.Items.Add("Hạ Calci");
            comboBox1.Items.Add("Hạ Đường Huyết");
            comboBox1.Items.Add("Hem Phế Quản");
            comboBox1.Items.Add("Herpes Miệng");
            comboBox1.Items.Add("Hội Chứng Dạ Dày");
            comboBox1.Items.Add("Kiểm Tra Đường Huyết");
            comboBox1.Items.Add("Loét Dạ Dày Tràng Trắng");
            comboBox1.Items.Add("Mỡ Máu");
            comboBox1.Items.Add("Nấm Da");
            comboBox1.Items.Add("Nấm Miệng");
            comboBox1.Items.Add("Nấm Tóc");
            comboBox1.Items.Add("Ngộ Độc Rượu");
            comboBox1.Items.Add("Ngộ Độc Thực Phẩm");
            comboBox1.Items.Add("Nhiễm Siêu Vi");
            comboBox1.Items.Add("Nhiễm Trùng Đường Tiết Niệu");
            comboBox1.Items.Add("Rối Loạn Giấc Ngủ");
            comboBox1.Items.Add("Rối Loạn Tiết Niệu");
        }

        private void loadChanDoanComboBox()
        {
            comboBox2.Items.Add("Chốc Da Nhiễm Trùng");
            comboBox2.Items.Add("Cơn Đau Quăn Thận");
            comboBox2.Items.Add("Cơn Đau Thắt Ngực Điển Hình");
            comboBox2.Items.Add("Dị Ứng");
            comboBox2.Items.Add("Đái Tháo Đường");
            comboBox2.Items.Add("Đau Cột Sống");
            comboBox2.Items.Add("Đau Thần Kinh Liên Sườn");
            comboBox2.Items.Add("Đau Thần Kinh Tọa");
            comboBox2.Items.Add("Đau Vai Gáy");
            comboBox2.Items.Add("Gan Nhiêm Mỡ");
            comboBox2.Items.Add("Hạ Calci");
            comboBox2.Items.Add("Hạ Đường Huyết");
            comboBox2.Items.Add("Hem Phế Quản");
            comboBox2.Items.Add("Herpes Miệng");
            comboBox2.Items.Add("Hội Chứng Dạ Dày");
            comboBox2.Items.Add("Kiểm Tra Đường Huyết");
            comboBox2.Items.Add("Loét Dạ Dày Tràng Trắng");
            comboBox2.Items.Add("Mỡ Máu");
            comboBox2.Items.Add("Nấm Da");
            comboBox2.Items.Add("Nấm Miệng");
            comboBox2.Items.Add("Nấm Tóc");
            comboBox2.Items.Add("Ngộ Độc Rượu");
            comboBox2.Items.Add("Ngộ Độc Thực Phẩm");
            comboBox2.Items.Add("Nhiễm Siêu Vi");
            comboBox2.Items.Add("Nhiễm Trùng Đường Tiết Niệu");
            comboBox2.Items.Add("Rối Loạn Giấc Ngủ");
            comboBox2.Items.Add("Rối Loạn Tiết Niệu");
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
            textBox12.Text = dtt.Rows[0]["SoLuongDichVu"].ToString().Trim();

            dateTimePicker1.Value = DateTime.Parse(dtt.Rows[0]["NgayLap"].ToString());
            dateTimePicker2.Value = DateTime.Parse(dtbn.Rows[0]["NgaySinh"].ToString());
            dateTimePicker3.Value = DateTime.Parse(dtt.Rows[0]["NgayTaiKham"].ToString());

            comboBox1.Text = dtt.Rows[0]["TienSu"].ToString().Trim();
            comboBox2.Text = dtt.Rows[0]["ChanDoan"].ToString().Trim();
            richTextBox1.Text = dtt.Rows[0]["TrieuChung"].ToString().Trim();
            richTextBox2.Text = dtt.Rows[0]["LoiDan"].ToString().Trim();

        }

        private void FormLoad(object sender, EventArgs e)
        {
            loadThuoc();
            loadDV();
            loadChanDoanComboBox();
            loadTienSuComboBox();
            toa = new BUS_Toa("", "", "", "", "", "", "Active", 0, DateTime.Now, DateTime.Now,0);
            DataTable thuoc = toa.selectMaThuoc(id);
            DataTable dichVu = toa.selectMaDV(id);


            foreach (DataRow row in thuoc.Rows)
            {
                string maThuoc = row["MaThuoc"].ToString();

                t = new BUS_Thuoc("", "", "", 0, 0, "", "", DateTime.Now, "", "");
                DataTable thuocInfo = t.getThuocInfo(maThuoc);

                DataGridViewRow newRow = new DataGridViewRow();

                string first = thuocInfo.Rows[0]["TenThuoc"].ToString().Trim();
                string second = thuocInfo.Rows[0]["DonViTinh"].ToString().Trim();
                string third = row["SoLuong"].ToString().Trim();
                string fourth = thuocInfo.Rows[0]["GiaBan"].ToString().Trim();
                string fifth = thuocInfo.Rows[0]["CachDung"].ToString().Trim();

                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = first });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = second });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = third });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = fourth });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = fifth });

                dataGridView1.Rows.Add(newRow);
            }

            foreach (DataRow row in dichVu.Rows)
            {
                string maDV = row["MaDV"].ToString();

                dv = new BUS_DichVu("", "", 0, "", DateTime.Now, "");
                DataTable dvInfo = dv.getDVInfo(maDV);

                DataGridViewRow newRow = new DataGridViewRow();

                string first = dvInfo.Rows[0]["Ten"].ToString().Trim();
                string second = dvInfo.Rows[0]["DonVi"].ToString().Trim();
                string third = row["SoLuong"].ToString().Trim();
                string fourth = dvInfo.Rows[0]["Gia"].ToString().Trim();

                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = first });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = second });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = third });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = fourth });

                dataGridView2.Rows.Add(newRow);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bn = textBox1.Text;
            string tiensu = comboBox1.Text;
            string chandoan = comboBox2.Text;
            string trieuchung = richTextBox1.Text;
            string loidan = richTextBox2.Text;
            string slt = textBox11.Text;
            string sldv = textBox12.Text;
            DateTime tk = dateTimePicker3.Value;
            toa = new BUS_Toa(id, bn, tiensu, chandoan, trieuchung, loidan, "Active", int.Parse(slt), DateTime.Now, tk,0);
            toa.updateCurrentQuery();
            mainForm.openChildForm(new PrescriptionManagement(mainForm));
            this.Hide();
            mainForm.Show();
        }
    }
}
