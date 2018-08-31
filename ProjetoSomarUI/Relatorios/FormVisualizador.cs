using Microsoft.Reporting.WinForms;
using Somar.BLL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ProjetoSomarUI.Relatorios
{
    public partial class FormVisualizador : Form
    {
        public FormVisualizador()
        {
            InitializeComponent();
        }

        private void FormVisualizador_Load(object sender, EventArgs e)
        {
            GerarRelatorio();
        }

        public void GerarRelatorio()
        {

            reportViewer1.ProcessingMode = ProcessingMode.Local;

            LocalReport localReport = reportViewer1.LocalReport;
            localReport.ReportPath = "RelProjetos.rdlc";

            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(false);

            // Create a report data source for the sales order data  
            ReportDataSource datasource = new ReportDataSource();
            datasource.Name = "Projetos";
            datasource.Value = lista;

            localReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.DataSources.Add(datasource);

            //reportViewer1.
            reportViewer1.Visible = true;
            // Refresh the report  
            reportViewer1.RefreshReport();
        }

    }
}
