using Microsoft.Reporting.WinForms;
using Somar.BLL;
using Somar.DTO;
using Somar.Shared;
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
            // TODO: This line of code loads data into the 'somarDatabaseDataSet.Projetos' table. You can move, or remove it, as needed.
            this.projetosTableAdapter.Fill(this.somarDatabaseDataSet.Projetos);
            GerarRelatorio();
            this.reportViewer1.RefreshReport();
            GerarRelatorio();
        }

        public static void ShowReport(string path, bool isEmbeddedResource, Dictionary<string, object> dataSources, Dictionary<string, object> reportParameters = null)
        {
            var formRelatorio = new FormVisualizador(path, isEmbeddedResource, dataSources, reportParameters);
            formRelatorio.Show();
        }

        private void GenerateReport_Click(object sender, EventArgs e)
        {

            //Me.BindingSource1.DataSource = myDatasource
            //Me.ReportViewer1.RefreshReport()

            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(false);

            var dataset = Functions.ToDataSet(lista);

            FormVisualizador.ShowReport("RelProjetos.rdlc", false, new Dictionary<string, object>() { { "result", lista } });
        }

        private FormVisualizador(string path, bool isEmbeddedResource, Dictionary<string, object> dataSources, Dictionary<string, object> reportParameters = null)
        {
            InitializeComponent();

            if (isEmbeddedResource)
                this.reportViewer1.LocalReport.ReportEmbeddedResource = path;
            else
                this.reportViewer1.LocalReport.ReportPath = path;

            // dataSources.
            foreach (var dataSource in dataSources)
            {
                var reportDataSource = new ReportDataSource(dataSource.Key, dataSource.Value);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            }

            if (reportParameters != null)
            {
                var reportParameterCollection = new List<ReportParameter>();

                foreach (var parameter in reportParameters)
                {
                    var reportParameter = new ReportParameter(parameter.Key, parameter.Value.ToString());
                    reportParameterCollection.Add(reportParameter);
                }

                this.reportViewer1.LocalReport.SetParameters(reportParameterCollection);
            }
        }

        public void GerarRelatorio()
        {

            reportViewer1.ProcessingMode = ProcessingMode.Local;

            LocalReport localReport = reportViewer1.LocalReport;
            //localReport.ReportPath = "/RelProjetos.rdlc";

            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(false);

            /*
            // Create a report data source for the sales order data  
            ReportDataSource datasource = new ReportDataSource();
            datasource.Name = "Projetos";
            datasource.Value = lista;

            localReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.DataSources.Add(datasource);

            reportViewer1.Visible = true;
            //reportViewer1.RefreshReport();
            */

            //string path = Directory.GetCurrentDirectory();
            //string replace = path.Replace("\\bin\\Debug", "") + "\\App_Data\\"+"ReportExtraMove.rdlc";

            //ReportDataSource rds = new ReportDataSource("extraMove", lista);

            //this.reportViewer1.LocalReport.DataSources.Add(rds);
            //this.reportViewer1.LocalReport.SetParameters(param);
            //this.reportViewer1.RefreshReport();
        }
    }
}
