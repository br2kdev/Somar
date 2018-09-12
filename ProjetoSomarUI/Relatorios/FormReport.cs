using Microsoft.Reporting.WinForms;
using Somar.BLL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Somar.Shared;
using System.Drawing.Printing;

namespace ProjetoSomarUI.Relatorios
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void LoadReport()
        {
            this.reportViewer1.Reset();

            ConfigurePrint();

            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelProjetos.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSetProjetos", GetProjetos());
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            /*
            ReportParameter CustID = new ReportParameter("CustomerID", CustomerList.CustomerID);
            this.reportViewer1.LocalReport.SetParameters(CustID);
            */

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            //ViewButtonClicked();
        }

        private void ConfigurePrint()
        {
            this.reportViewer1.ZoomMode = ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.ZoomMode = ZoomMode.FullPage;

            PageSettings ps = new PageSettings(); //Declare a new PageSettings for printing
            ps.Landscape = false; //Set True for landscape, False for Portrait

            ps.Margins = new Margins(0, 0, 0, 0); //Set margins
            //ps.PaperSize = new PaperSize("MyPaperSize", 8, 11);

            reportViewer1.SetPageSettings(ps);
        }

        private DataTable GetProjetos()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "DataSetProjetos";

            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(false);

            var dt = lista.ToDataTable();

            return dt;

            /*
            SqlConnection con = new SqlConnection(Home.ConString);
            string sql = "SELECT * FROM Customers";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
            */
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            LoadReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
