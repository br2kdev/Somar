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
        #region Load Configurations

        private DataTable _dataTable;

        private Relatorio _relatorio;

        public FormReport(Relatorio relatorio, DataTable dataTable)
        {
            InitializeComponent();

            _dataTable = dataTable;
            _relatorio = relatorio;

            this.reportViewer1.LocalReport.DataSources.Clear();
        }

        public void ShowReport()
        {
            if (_relatorio == Relatorio.Dashboard)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelDashboard.rdlc";
                
                var _dataTable1 = new ProjetoBLL().GetAllData(false).ToDataTable();
                ReportDataSource rds1 = new ReportDataSource("DataSetAlunosPorEscola", _dataTable1);
                this.reportViewer1.LocalReport.DataSources.Add(rds1);

                var _dataTable2 = new ProjetoBLL().GetAllData(false).ToDataTable();
                ReportDataSource rds2 = new ReportDataSource("DataSetAlunosPorProjeto", _dataTable2);
                this.reportViewer1.LocalReport.DataSources.Add(rds2);

                var _dataTable3 = new ProjetoBLL().GetAllData(false).ToDataTable();
                ReportDataSource rds3 = new ReportDataSource("DataSetPessoasPorBairro", _dataTable3);
                this.reportViewer1.LocalReport.DataSources.Add(rds3);

                /*
                var _dataTable1 = new ProjetoBLL().GetAllData(false).ToDataTable();
                ReportDataSource rds1 = new ReportDataSource("DataSetProjetos", _dataTable1);
                this.reportViewer1.LocalReport.DataSources.Add(rds1);

                var _dataTable2 = new TurmaBLL().GetAllData().ToDataTable();
                ReportDataSource rds2 = new ReportDataSource("DataSetTurmas", _dataTable2);
                this.reportViewer1.LocalReport.DataSources.Add(rds2);
                */

            }
            else
            {
                switch (_relatorio)
                {
                    case Relatorio.Projetos:
                        _dataTable = LoadReportProjetos(_dataTable);
                        break;
                    case Relatorio.Turmas:
                        _dataTable = LoadReportTurmas(_dataTable);
                        break;
                    /*
                    case Relatorio.Dashboard:
                        _dataTable = LoadReportTurmas(_dataTable);
                        break;
                    */
                    default:
                        break;
                }

                ReportDataSource rds = new ReportDataSource("DataSet", _dataTable);
                this.reportViewer1.LocalReport.DataSources.Add(rds);
            }

            ConfigurePrint();

            this.reportViewer1.Update();
            this.reportViewer1.RefreshReport();
        }

        private void ConfigurePrint()
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.ShowProgress = true;
            this.reportViewer1.LocalReport.EnableExternalImages = false; ;
            this.reportViewer1.ZoomMode = ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.ZoomMode = ZoomMode.FullPage;

            PageSettings ps = new PageSettings();               // Declare a new PageSettings for printing
            ps.Landscape = false;                               // Set True for landscape, False for Portrait
            ps.Margins = new Margins(10, 10, 10, 10);           // Set margins
            ps.PaperSize = new PaperSize("A4", 850, 1100);

            //this.reportViewer1.SetPageSettings(ps);
        }

        #endregion

        #region Reports

        private DataTable LoadReportProjetos(DataTable _dataTable)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelProjetos.rdlc";

            if (_dataTable == null)
                _dataTable = new ProjetoBLL().GetAllData(false).ToDataTable();

            return _dataTable;

            /*
            ReportParameter CustID = new ReportParameter("CustomerID", CustomerList.CustomerID);
            this.reportViewer1.LocalReport.SetParameters(CustID);
            */
        }

        private DataTable LoadReportTurmas(DataTable _dataTable)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelTurmas.rdlc";

            if (_dataTable == null)
                _dataTable = new TurmaBLL().GetAllData().ToDataTable();

            return _dataTable;
        }

        private DataTable LoadReportDashboard(DataTable _dataTable)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelDashboard.rdlc";

            if (_dataTable == null)
                _dataTable = new TurmaBLL().GetAllData().ToDataTable();

            return _dataTable;
        }

        #endregion

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            ShowReport();
        }
    }
}
