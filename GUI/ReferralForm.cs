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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace GUI
{
    public partial class ReferralForm : Form
    {

        BUS_GiayChiDinh gcd;
        BUS_DichVu dv;
        BUS_BenhNhan bn;
        AdminInterface mainForm;
        string role = "";
        private string id;
        private bool comboBoxEventRegistered = false;
        private int numDichVu = 0;
        DataGridViewComboBoxColumn comboBoxColumn1 = new DataGridViewComboBoxColumn();
        public ReferralForm(string id, AdminInterface mainForm)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(930, 750);
            this.MaximumSize = new System.Drawing.Size(930, 750);
            this.MinimumSize = new System.Drawing.Size(930, 750);
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
            this.id = id;
            this.mainForm = mainForm;
        }

        private void loadDV()
        {
            dv = new BUS_DichVu("", "", 0, "", DateTime.Now, "");
            DataTable dt1 = dv.getDVName();
            comboBoxColumn1.HeaderText = "Tên dịch vụ";
            comboBoxColumn1.Name = "TenDV";
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                comboBoxColumn1.Items.Add(dt1.Rows[i]["Ten"].ToString());
            }
            dataGridView1.Columns.Add(comboBoxColumn1);
            dataGridView1.Columns.Add("DonVi", "Đơn vị");
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

        private void FormLoad(object sender, EventArgs e)
        {
            loadTienSuComboBox();
            loadChanDoanComboBox();
            loadDV();

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

        private void cellContentClick(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows.Add();

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.Rows.Count - 1 && e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                dataGridView1.Rows.Add();
            }

        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox comboBox)
            {
                comboBox.SelectedIndexChanged -= ComboBox_SelectedThuocIndexChanged;
                comboBox.SelectedIndexChanged += ComboBox_SelectedThuocIndexChanged;
            }
        }

        private void ComboBox_SelectedThuocIndexChanged(object sender, EventArgs e)
        {
            dv = new BUS_DichVu("", "", 0, "", DateTime.Now, "");
            BUS_GiayChiDinh ttt = new BUS_GiayChiDinh("", "", "", "", "", "", "", DateTime.Now, DateTime.Now, 0);
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                string selectedValue = comboBox.SelectedItem.ToString();
                DataTable dichVu = dv.getDVInfoByName(selectedValue);
                int currentRowIndex = dataGridView1.CurrentCell.RowIndex;

                if (currentRowIndex > 0)
                {
                    int indexValue = ttt.getIndexValueExistInColumn(selectedValue, dataGridView1);
                    if (indexValue != -1)
                    {
                        MessageBox.Show("Dịch vụ đã tồn tại !");
                        dataGridView1.Rows.RemoveAt(currentRowIndex);
                        return;
                    }
                }

                if (dataGridView1.Rows[currentRowIndex].Cells[1].Value == null)
                {
                    dataGridView1.Rows[currentRowIndex].Cells[1].Value = dichVu.Rows[0]["DonVi"].ToString().Trim();
                }

                if (dataGridView1.Rows[currentRowIndex].Cells[2].Value == null)
                {
                    numDichVu++;
                    textBox11.Text = numDichVu.ToString();
                    dataGridView1.Rows[currentRowIndex].Cells[2].Value = dichVu.Rows[0]["Gia"].ToString().Trim();
                    textBox12.Text = ttt.getTongTien(dataGridView1).ToString();
                }

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
            ViewPatient form = new ViewPatient(mainForm, role);
            form.updateCurrent(id);
            form.Show();
            this.Hide();
        }

        public bool IsDataGridViewEmpty(DataGridView dataGridView)
        {
            if (dataGridView == null || dataGridView.Rows.Count == 0)
                return true;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(IsDataGridViewEmpty(dataGridView1) == false)
            {
                BUS_GiayChiDinh ttt = new BUS_GiayChiDinh("", "", "", "", "", "", "", DateTime.Now, DateTime.Now, 0);
                string bn = textBox1.Text;
                string tiensu = comboBox1.Text;
                string chandoan = comboBox2.Text;
                string trieuchung = richTextBox1.Text;
                string loidan = richTextBox2.Text;
                BigInteger total = ttt.getTongTien(dataGridView1);
                DateTime tk = dateTimePicker3.Value;

                if (radioButton1.Checked == true)
                {
                    gcd = new BUS_GiayChiDinh("", bn, tiensu, chandoan, trieuchung, loidan, "Active", DateTime.Now, tk, total);
                }
                else
                {
                    gcd = new BUS_GiayChiDinh("", bn, tiensu, chandoan, trieuchung, loidan, "Active", DateTime.Now, DateTime.Now, total);
                }

                gcd.addQuery();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string name = row.Cells[0].Value.ToString();
                        string dvt = row.Cells[1].Value.ToString();
                        BigInteger gia = BigInteger.Parse(row.Cells[2].Value.ToString());
                        dv = new BUS_DichVu("", "", 0, "", DateTime.Now, "");
                        DataTable dt1 = dv.getDVInfoByName(name);
                        string mat = dt1.Rows[0]["MaDV"].ToString().Trim();
                        gcd.addDetailService(mat, name, dvt, gia);
                    }
                }

                string maToa = gcd.getCurrentMaToa();

                ReferralPrinting form = new ReferralPrinting(id, maToa);
                form.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Bạn chưa chỉ định dịch vụ nào !");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BUS_GiayChiDinh ttt = new BUS_GiayChiDinh("", "", "", "", "", "", "", DateTime.Now, DateTime.Now, 0);
            if (dataGridView1.Rows.Count != 0)
            {
                int currentRowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(currentRowIndex);
                textBox12.Text = ttt.getTongTien(dataGridView1).ToString();
            }
            else
            {
                MessageBox.Show("Không còn hàng nào để xóa !");
                return;
            }
        }
    }
}
