using System;
using System.Threading;
using System.Windows.Forms;
using ProjetoSomarUI.Cadastros;
using Somar.Shared;

namespace ProjetoSomarUI
{
    public partial class FormPrincipal : Form
    {
        #region SplashScreen

        private SplashScreen splashScreen;

        private bool done = false;

        private void ShowSplashScreen()
        {
            splashScreen.Show();

            while (!done)
            {
                Application.DoEvents();
            }

            splashScreen.Close();
            this.splashScreen.Dispose();
        }

        private void HandleFormLoad(object sender, EventArgs e)
        {
            this.Hide();
            Thread thread = new Thread(new ThreadStart(this.ShowSplashScreen));
            thread.Start();

            Hardworker worker = new Hardworker();
            worker.ProgressChanged += (o, ex) => { this.splashScreen.UpdateProgress(ex.Progress); };
            worker.HardWorkDone += (o, ex) => { done = true; this.Show(); };
            worker.DoHardWork();
        }

        #endregion

        public FormPrincipal()
        {
            InitializeComponent();

            lblNome.Text = Sessao.Usuario.nomeUsuario;
            lblPerfil.Text = Sessao.Usuario.descPerfil;

            //this.Load += new EventHandler(HandleFormLoad);
            //this.splashScreen = new SplashScreen();

            this.timer1.Enabled = true;

            CarregarAniversariantes();
        }

        public void CarregarAniversariantes()
        {

        }

        #region MenuItem Click

        private void sairMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você deseja mesmo sair do software?", "PROJETO SOMAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPessoas frm = new FormPessoas();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void projetosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProjetos frm = new FormProjetos();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void turmasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTurmas frm = new FormTurmas();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
        
            Form1 frm = new Form1();
            frm.MdiParent = this;

            frm.Show();
            */
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracao.FormUsuarios frm = new Administracao.FormUsuarios();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDataAtual.Text = String.Format("{0:F}", DateTime.Now);
        }
    }
}
