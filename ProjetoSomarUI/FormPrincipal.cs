using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoSomarUI.Cadastros;
using Somar.Shared;

namespace ProjetoSomarUI
{
    public partial class FormPrincipal : Form
    {
        private SplashScreen splashScreen;

        private bool done = false;

        public FormPrincipal()
        {
            InitializeComponent();
            
            this.Load += new EventHandler(HandleFormLoad);
            this.splashScreen = new SplashScreen();
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
    }
}
