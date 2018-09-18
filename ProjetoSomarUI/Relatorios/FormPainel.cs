using Somar.Shared;
using System;
using System.Windows.Forms;

namespace ProjetoSomarUI.Relatorios
{
    public partial class FormPainel : Form
    {
        public FormPainel()
        {
            InitializeComponent();
        }

        private void btnProjetos_Click(object sender, EventArgs e)
        {
            FormReport frm = new FormReport(Relatorio.Projetos, null);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnTurmas_Click(object sender, EventArgs e)
        {
            Relatorios.FormReport frm = new Relatorios.FormReport(Relatorio.Turmas, null);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Relatorios.FormReport frm = new Relatorios.FormReport(Relatorio.Dashboard, null);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }
    }
}
