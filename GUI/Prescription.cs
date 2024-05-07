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
using System.Data.Common;
using System.Numerics;

namespace GUI
{
    public partial class Prescription : Form
    {
        BUS_Thuoc t;
        BUS_Toa toa;
        BUS_DichVu dv;
        BUS_BenhNhan bn;
        AdminInterface mainForm;
        private string id;
        private int quantities;
        bool check = false;
        DataGridViewComboBoxColumn comboBoxColumn1 = new DataGridViewComboBoxColumn();
        DataGridViewComboBoxColumn comboBoxColumn2 = new DataGridViewComboBoxColumn();
        public Prescription(string id, AdminInterface mainForm)
        {
            InitializeComponent();
            this.Height = 900;
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
            this.id = id;
            this.mainForm = mainForm;
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
            dataGridView1.Columns.Add("CachDung", "Cách dùng");
            dataGridView1.Columns.Add("GiaBan", "Giá bán");
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

        private void FormLoad(object sender,EventArgs e)
        {
            loadTienSuComboBox();
            loadChanDoanComboBox();
            loadThuoc();

            bn = new BUS_BenhNhan("", "", "", DateTime.Now, "", "", "", "", "", "", "", "", "", DateTime.Now);
            DataTable dt = bn.getBNInfo(id);

            textBox1.Text = dt.Rows[0]["MaBN"].ToString().Trim();
            textBox2.Text = dt.Rows[0]["Ten"].ToString().Trim();
            textBox3.Text = dt.Rows[0]["DiaChi"].ToString().Trim();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            textBox4.Text = dt.Rows[0]["SDT"].ToString().Trim();

            textBox5.Text = dt.Rows[0]["CanNang"].ToString().Trim().Trim();
            textBox6.Text = dt.Rows[0]["sp02"].ToString().Trim();
            textBox7.Text = dt.Rows[0]["HuyetAp"].ToString().Trim();
            textBox8.Text = dt.Rows[0]["NhietDo"].ToString().Trim();
            textBox9.Text = dt.Rows[0]["NhipTho"].ToString().Trim();
            textBox10.Text = dt.Rows[0]["Mach"].ToString().Trim();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;
        }

        private void DataGridView1_RowsAdded(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void cellContentClick(object sender,EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows.Add();
            
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox comboBox)
            {
                comboBox.SelectedIndexChanged += ComboBox_SelectedThuocIndexChanged;
            }
        }

        private void ComboBox_SelectedThuocIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                string selectedValue = comboBox.SelectedItem.ToString();
                DataTable thuoc = t.getThuocInfoByName(selectedValue);
                int currentRowIndex = dataGridView1.CurrentCell.RowIndex;

                if (dataGridView1.Rows[currentRowIndex].Cells[1].Value == null)
                {
                    dataGridView1.Rows[currentRowIndex].Cells[1].Value = thuoc.Rows[0]["DonViTinh"].ToString().Trim();
                }

                if (dataGridView1.Rows[currentRowIndex].Cells[2].Value == null)
                {
                    dataGridView1.Rows[currentRowIndex].Cells[2].Value = 1;
                }

                if (dataGridView1.Rows[currentRowIndex].Cells[3].Value == null)
                {
                    dataGridView1.Rows[currentRowIndex].Cells[3].Value = thuoc.Rows[0]["CachDung"].ToString().Trim();
                }

                if (dataGridView1.Rows[currentRowIndex].Cells[4].Value == null)
                {
                    dataGridView1.Rows[currentRowIndex].Cells[4].Value = thuoc.Rows[0]["GiaBan"].ToString().Trim();
                }

            }
        }

        private int getTongSoLuongThuoc()
        {
            int TongSoLuong = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["SoLuong"].Value != null)
                {
                    TongSoLuong += (int.Parse(row.Cells["SoLuong"].Value.ToString()));
                }
            }
            return TongSoLuong;
        }

        private int getTongTien()
        {
            int TongTien = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["GiaBan"].Value != null)
                {
                    TongTien += (int.Parse(row.Cells["GiaBan"].Value.ToString()));
                }
            }
            return TongTien;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCell.RowIndex;
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "SoLuong")
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                check = true;
                if (cell.Value != null)
                {
                    quantities = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString());
                    if (quantities <= 0)
                    {
                        MessageBox.Show("Số lượng hiện tại không hợp lệ!");
                        dataGridView1.Rows.RemoveAt(currentRowIndex);
                        return;
                    }
                    else
                    {
                        textBox11.Text = getTongSoLuongThuoc().ToString();
                        if(dataGridView1.Rows[e.RowIndex].Cells["GiaBan"].Value != null && check == true)
                        {
                            BigInteger total = BigInteger.Parse(dataGridView1.Rows[e.RowIndex].Cells["GiaBan"].Value.ToString());
                            total = total * quantities;
                            dataGridView1.Rows[e.RowIndex].Cells["GiaBan"].Value = total;
                            textBox12.Text = getTongTien().ToString();
                            check = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không hợp lệ");
                }
            }
            else if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "GiaBan")
            {
                textBox12.Text = getTongTien().ToString();
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateTimePicker3.Enabled = true;
            }
            else
            {
                dateTimePicker3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewPatient form = new ViewPatient(mainForm);
            form.updateCurrent(id);
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bn = textBox1.Text;
            string tiensu = comboBox1.Text;
            string chandoan = comboBox2.Text;
            string trieuchung = richTextBox1.Text;
            string slt = textBox11.Text;
            string loidan = richTextBox2.Text;
            DateTime tk = dateTimePicker3.Value;
            BigInteger tongtien = getTongTien();

            if(radioButton1.Checked == true)
            {
                toa = new BUS_Toa("", bn, tiensu, chandoan, trieuchung, loidan, "Active", int.Parse(slt), DateTime.Now, tk,tongtien);
            }
            else
            {
                toa = new BUS_Toa("", bn, tiensu, chandoan, trieuchung, loidan, "Active", int.Parse(slt), DateTime.Now, DateTime.Now,tongtien);
            }

            toa.addQuery();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string name = row.Cells[0].Value.ToString();
                    string dvt = row.Cells[1].Value.ToString();
                    int sl = int.Parse(row.Cells[2].Value.ToString());
                    t = new BUS_Thuoc("", "", "", 0, 0, "", "", DateTime.Now, "", "");
                    DataTable dt1 = t.getThuocInfoByName(name);
                    string mat = dt1.Rows[0]["MaThuoc"].ToString().Trim();
                    BigInteger gia = BigInteger.Parse(row.Cells[4].Value.ToString());
                    string cachdung = row.Cells[3].Value.ToString();
                    toa.addDetailMedicine(mat, name, dvt,sl, gia,cachdung);
                }
            }

            string maToa = toa.getCurrentMaToa();

            PrescriptionPrinting form = new PrescriptionPrinting(id,maToa);
            this.Hide();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(currentRowIndex);
        }
    }
}
