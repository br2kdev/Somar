using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ProjetoSomarUI.Cadastros;
using Somar.BLL;
using Somar.DTO;
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
            this.splashScreen = new SplashScreen();

            this.timer1.Enabled = true;

            CarregarAniversariantes();
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

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMatricula frm = new FormMatricula();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void escolasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEscolas frm = new FormEscolas();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void alterarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlterarSenha frm = new FormAlterarSenha();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void frequenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFrequencia frm = new FormFrequencia();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        #endregion

        #region Load Widgets

        public void CarregarAniversariantes()
        {
            List<PessoaDTO> lista = new PessoaBLL().GetAniversariantes();

            int iCount = 0;

            ListViewAniversariantes.Clear();

            ListViewAniversariantes.Columns.Add("Nome", 220);
            ListViewAniversariantes.Columns.Add("Dt.Nascimento", 85, HorizontalAlignment.Center);
            ListViewAniversariantes.Columns.Add("Idade", 56, HorizontalAlignment.Center);

            ListViewAniversariantes.HideSelection = true;
            ListViewAniversariantes.View = View.Details;
            ListViewAniversariantes.GridLines = true;
            ListViewAniversariantes.FullRowSelect = false;
            ListViewAniversariantes.Width = 365;

            foreach (var item in lista)
            {
                iCount++;

                ListViewItem itemBirth;

                string[] arr = new string[3];

                arr[0] = item.nomePessoa;
                arr[1] = item.dtNascimento.ToShortDateString();
                arr[2] = Functions.CalcularIdade(item.dtNascimento).ToString();

                itemBirth = new ListViewItem(arr);

                ListViewAniversariantes.Items.Add(itemBirth);
            }

            if (iCount > 0)
                panelAniversario.Visible = true;
            else
                panelAniversario.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDataAtual.Text = Functions.FirstCharToUpper(String.Format("{0:D}", DateTime.Now));
            lblHora.Text = String.Format("{0:T}", DateTime.Now);

            if (DateTime.Now.Second == 0)
                CarregarAniversariantes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Relatorios.FormReport frm = new Relatorios.FormReport();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }


        #endregion

    
    }
}
