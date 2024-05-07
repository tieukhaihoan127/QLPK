﻿using BUS;
using Microsoft.Reporting.WinForms;
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
using ZXing;

namespace GUI
{
    public partial class ReferralPrinting : Form
    {
        BUS_GiayChiDinh gcd;
        BUS_BenhNhan bn;
        private string maBN;
        private string maGCD;
        public ReferralPrinting(string maBN, string maGCD)
        {
            InitializeComponent();
            this.Height = 900;
            this.Width = 700;
            this.maBN = maBN;
            this.maGCD = maGCD;
        }

        public void generateBarcode()
        {
            BarcodeWriter brcode = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128
            };

            pictureBox1.Image = brcode.Write(maGCD);
            label1.Text = maGCD;
        }

        private void ReferralPrinting_Load(object sender, EventArgs e)
        {
            gcd = new BUS_GiayChiDinh("", "", "", "", "", "", "Active", DateTime.Now, DateTime.Now, 0);
            DataTable dt1 = gcd.selectMaDV(maGCD);
            DataTable dt2 = gcd.getGCDInfo(maGCD);

            bn = new BUS_BenhNhan("", "", "", DateTime.Now, "", "", "", "", "", "", "", "", "", DateTime.Now);
            DataTable dt3 = bn.getBNInfo(maBN);

            string ma = dt3.Rows[0]["MaBN"].ToString().Trim();
            string name = dt3.Rows[0]["Ten"].ToString().Trim();
            string sdt = dt3.Rows[0]["SDT"].ToString().Trim();
            string diachi = dt3.Rows[0]["DiaChi"].ToString().Trim();
            string gioitinh = dt3.Rows[0]["GioiTinh"].ToString().Trim();
            string loidan = dt2.Rows[0]["LoiDan"].ToString().Trim();
            string chandoan = dt2.Rows[0]["ChanDoan"].ToString().Trim();
            DateTime ngaysinh = DateTime.Parse(dt3.Rows[0]["NgaySinh"].ToString().Trim());
            DateTime taikham = DateTime.Parse(dt2.Rows[0]["NgayTaiKham"].ToString().Trim());
            string tuoi = (DateTime.Now.Year - ngaysinh.Year).ToString();

            string tk = "Không";
            if (taikham.Year != 1900)
            {
                tk = "Ngày " + taikham.Day.ToString() + " tháng" + taikham.Month.ToString() + " năm" + taikham.Year.ToString();
            }

            string now = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            string total = "Tồng tiền : " + dt2.Rows[0]["TongTien"].ToString().Trim() + " VND";

            generateBarcode();

            this.reportViewer1.LocalReport.ReportPath = "../../Report2.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            reportParameters.Add(new ReportParameter("ReportParameter1", name));
            reportParameters.Add(new ReportParameter("ReportParameter2", diachi));
            reportParameters.Add(new ReportParameter("ReportParameter3", gioitinh));
            reportParameters.Add(new ReportParameter("ReportParameter4", chandoan));
            reportParameters.Add(new ReportParameter("ReportParameter5", ma));
            reportParameters.Add(new ReportParameter("ReportParameter6", loidan));
            reportParameters.Add(new ReportParameter("ReportParameter7", tuoi));
            reportParameters.Add(new ReportParameter("ReportParameter8", tk));
            reportParameters.Add(new ReportParameter("ReportParameter9", now));
            reportParameters.Add(new ReportParameter("ReportParameter10", total));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.LocalReport.DataSources.Clear();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = dt1;
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

    }
}
