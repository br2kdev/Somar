using Microsoft.Reporting.WinForms;
using Somar.BLL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Somar.Shared;
using System.Drawing.Printing;
using ProjetoSomarUI.SomarDatabaseDataSetTableAdapters;

namespace ProjetoSomarUI.Relatorios
{
    public partial class FormReport : Form
    {
        #region Load Configurations
        
        public Dictionary<string, string> param
        {
            get
            {
                return _param;
            }
            set
            {
                _param = value;
            }
        }

        private DataTable _dataTable;

        private Relatorio _relatorio;

        private Dictionary<string, string> _param;

        private void FormReport_Load(object sender, EventArgs e)
        {

        }

        public FormReport(Relatorio relatorio, DataTable dataTable)
        {
            InitializeComponent();

            _dataTable = dataTable;
            _relatorio = relatorio;
            
            this.reportViewer1.RefreshReport();
        }

        public void ShowReport(Dictionary<string, string> param = null)
        {
            var result = new Dictionary<string, object>();

            if (_relatorio == Relatorio.Dashboard)
            {
                LoadDashboard();
            }
            else
            {
                switch (_relatorio)
                {
                    case Relatorio.Projetos:
                        result = LoadReportProjetos(_dataTable);
                        break;
                    case Relatorio.Turmas:
                        result = LoadReportTurmas(_dataTable);
                        break;
                    case Relatorio.ListaPresenca:
                        result = LoadReportListaPresenca(_dataTable);
                        break;
                    case Relatorio.Pessoas:
                        result = LoadReportPessoas(_dataTable);
                        break;
                    case Relatorio.AlunosPorProjeto:
                        result = LoadReportAlunosProjetos(_dataTable);
                        break;
                    case Relatorio.AlunosPorTurma:
                        result = LoadReportAlunosTurma(_dataTable);
                        break;
                    /*
                    case Relatorio.Dashboard:
                        _dataTable = LoadReportTurmas(_dataTable);
                        break;
                    */
                    default:
                        break;
                }

                if(result != null)
                {
                    foreach (var item in result)
                    {
                        ReportDataSource rds = new ReportDataSource(item.Key, item.Value);
                        this.reportViewer1.LocalReport.DataSources.Add(rds);
                    }
                }
                else
                {
                    ReportDataSource rds = new ReportDataSource("DataSet", _dataTable);
                    this.reportViewer1.LocalReport.DataSources.Add(rds);
                }

            }

            ConfigurePrint();

            this.reportViewer1.Update();
            this.reportViewer1.RefreshReport();
        }

        private void LoadDashboard()
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelDashboard.rdlc";

            dtAlunosPorEscolaTableAdapter dt1 = new dtAlunosPorEscolaTableAdapter();
            dtAlunosPorProjetoTableAdapter dt2 = new dtAlunosPorProjetoTableAdapter();
            dtPessoasPorBairroTableAdapter dt3 = new dtPessoasPorBairroTableAdapter();
            dtAlunosPorEducadorTableAdapter dt4 = new dtAlunosPorEducadorTableAdapter();
            dtSituacaoPessoasTableAdapter dt5 = new dtSituacaoPessoasTableAdapter();

            var result1 = dt1.GetData().CopyToDataTable();
            var result2 = dt2.GetData().CopyToDataTable();
            var result3 = dt3.GetData().CopyToDataTable();
            var result4 = dt4.GetData().CopyToDataTable();
            var result5 = dt5.GetData().CopyToDataTable();

            ReportDataSource rds1 = new ReportDataSource("dsAlunosPorEscola", result1);    // Alunos por Escola
            ReportDataSource rds2 = new ReportDataSource("dsAlunosPorProjeto", result2);   // Alunos por Projeto
            ReportDataSource rds3 = new ReportDataSource("dsPessoasPorBairro", result3);   // Pessoas por Bairro
            ReportDataSource rds4 = new ReportDataSource("dsAlunosPorEducador", result4);  // Alunos por Educador
            ReportDataSource rds5 = new ReportDataSource("dsSituacaoPessoas", result5);    // Pessoas por Situacao

            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.LocalReport.DataSources.Add(rds2);
            this.reportViewer1.LocalReport.DataSources.Add(rds3);
            this.reportViewer1.LocalReport.DataSources.Add(rds4);
            this.reportViewer1.LocalReport.DataSources.Add(rds5);
        }

        private void ConfigurePrint()
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.ShowProgress = true;
            this.reportViewer1.LocalReport.EnableExternalImages = false;
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

        private Dictionary<string, object> LoadReportProjetos(DataTable _dataTable)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelProjetos.rdlc";

            if (_dataTable == null)
            {
                dtProjetosTableAdapter dt = new dtProjetosTableAdapter();
                /*
                dt.Connection.Close();
                dt.Connection.ConnectionString = Globals.stringConn;
                dt.Connection.Open();
                */
                _dataTable = dt.GetData().CopyToDataTable();
            }

            result.Add("DataSet", _dataTable);

            return result;

            /*
            ReportParameter CustID = new ReportParameter("CustomerID", CustomerList.CustomerID);
            this.reportViewer1.LocalReport.SetParameters(CustID);
            */
        }

        private Dictionary<string, object> LoadReportAlunosProjetos(DataTable _dataTable)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelAlunosPorProjeto.rdlc";

            int idProjeto = Convert.ToInt32(_param["idProjeto"]);

            dtAlunosProjetosDetalhesTableAdapter dt2 = new dtAlunosProjetosDetalhesTableAdapter();
            var _dataTable2 = dt2.GetData(idProjeto).CopyToDataTable();

            result.Add("DataSet", _dataTable2);

            return result;
        }

        private Dictionary<string, object> LoadReportAlunosTurma(DataTable _dataTable)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelAlunosPorTurma.rdlc";

            int idTurma = Convert.ToInt32(_param["idTurma"]);

            dtAlunosTurmaDetalhesTableAdapter dt2 = new dtAlunosTurmaDetalhesTableAdapter();
            var _dataTable2 = dt2.GetData(idTurma).CopyToDataTable();

            result.Add("DataSet", _dataTable2);

            return result;
        }

        private Dictionary<string, object> LoadReportTurmas(DataTable _dataTable)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelTurmas.rdlc";

            if (_dataTable == null)
            {
                try
                {
                    dtTurmasTableAdapter dt = new dtTurmasTableAdapter();
                    _dataTable = dt.GetData().CopyToDataTable();
                }
                catch(Exception)
                {

                }

            }

            result.Add("DataSet", _dataTable);

            return result;
        }

        private Dictionary<string, object> LoadReportListaPresenca(DataTable _dataTable)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelFrequencia.rdlc";

            try
            {
                int idFrequencia = Convert.ToInt32(_param["idFrequencia"]);
                string flagPresenca = string.Empty;

                try
                {
                    flagPresenca = _param["flagPresenca"];
                }
                catch(Exception)
                {

                }

                if (_dataTable == null)
                {
                    SPR_GetListaChamadaTableAdapter dt = new SPR_GetListaChamadaTableAdapter();
                    _dataTable = dt.GetData(idFrequencia).CopyToDataTable();

                    if(string.IsNullOrEmpty(flagPresenca))
                    {
                        foreach (DataRow dr in _dataTable.Rows)
                        {
                            dr["descPresenca"] = "";
                        }
                    }
                }

                result.Add("DataSet", _dataTable);

                GetListaChamadaDetalhesTableAdapter dt2 = new GetListaChamadaDetalhesTableAdapter();
                var _dataTable2 = dt2.GetData(idFrequencia).CopyToDataTable();
                result.Add("DataSet2", _dataTable2);
            }
            catch(Exception)
            {

            }

            return result;
        }

        private Dictionary<string, object> LoadReportPessoas(DataTable _dataTable)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"ProjetoSomarUI.Relatorios.RelPessoas.rdlc";

            if (_dataTable == null)
            {
                try
                {
                    dtPessoasTableAdapter dt = new dtPessoasTableAdapter();
                    _dataTable = dt.GetData().CopyToDataTable();
                }
                catch (Exception)
                {

                }

            }

            result.Add("DataSet", _dataTable);

            return result;
        }
        #endregion

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            ShowReport();
        }

    }
}
