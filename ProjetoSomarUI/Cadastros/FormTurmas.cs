using Somar.BLL;
using Somar.DTO;
using Somar.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace ProjetoSomarUI.Cadastros
{
    public partial class FormTurmas : FormBase
    {
        private string gridMessage = "Nenhuma turma encontrada!";

        delegate void UserControlMethod(int idTurma);

        public FormTurmas()
        {
            Inicialize();            
        }

        private void Inicialize()
        {
            InitializeComponent();

            #region ComboLists

            cmbSearchType.Items.Add("Nome da Turma");
            cmbSearchType.Items.Add("Código da Turma");

            cmbStatus.Items.Add("Desativado");
            cmbStatus.Items.Add("Ativo");

            cmbPeriodo.Items.Add("Selecione...");
            cmbPeriodo.Items.Add("Manhã");
            cmbPeriodo.Items.Add("Tarde");
            cmbPeriodo.Items.Add("Noite");
            cmbPeriodo.Items.Add("Integral");

            #endregion

            #region Button Events

            btnNovo.Click += new EventHandler(btnNew_Click);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnAll.Click += new EventHandler(btnAll_Click);
            btnPrint.Click += new EventHandler(btnPrint_Click);

            btnEditar.Click += new EventHandler(btnEditar_Click);
            btnVoltar1.Click += new EventHandler(btnVoltar_Click);
            btnGravar.Click += new EventHandler(btnGravar_Click);

            #endregion

            Load += new EventHandler(FormTurmas_Load);

            //txtDataInicio.CustomFormat = txtdtTermino.CustomFormat = "HH:mm";
            //txtDataInicio.ShowUpDown = txtdtTermino.ShowUpDown = true;

            Grid.InitializeGridView(new TurmaDTO());
            ClearForm1();

            Grid.CallingMethod1 = new UserControlMethod(CarregaDetalhes);
        }

        private void FormTurmas_Load(object sender, EventArgs e)
        {
            CarregaGrid();
            CarregaComboProjeto();
            CarregaComboEducador();
        }

        #region Events

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var param = new TurmaDTO();

            if (cmbSearchType.SelectedItem.ToString() == "Nome da Turma")
            {
                param.nomeTurma = txtSearch.Text;
            }
            else if (cmbSearchType.SelectedItem.ToString() == "Código da Turma")
            {
                if (txtSearch.Text != string.Empty)
                    param.idTurma = Convert.ToInt32(txtSearch.Text);
            }

            List<TurmaDTO> lista = new TurmaBLL().GetDataWithParam(param);

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnEditar.Visible = false;
            panelEdit.Visible = true;
            panelConsulta.Visible = false;
            this.ControlBox = false;

            ClearForm2();
            ControlFormEdit(true);

            btnVoltar1.Visible = true;
            btnVoltar1.Text = "Voltar";
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ClearForm1();

            List<TurmaDTO> lista = new TurmaBLL().GetAllData();

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        #endregion

        #region Methods

        public void CarregaGrid()
        {
            List<TurmaDTO> lista = new TurmaBLL().GetAllData();

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        public void CarregaComboProjeto()
        {
            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(true);

            lista.Insert(0, new ProjetoDTO() { idProjeto = 0, nomeProjeto = "Selecione..." });

            this.cmbProjeto.DataSource = null;
            this.cmbProjeto.Items.Clear();

            this.cmbProjeto.DisplayMember = "nomeProjeto";
            this.cmbProjeto.ValueMember = "idProjeto";
            this.cmbProjeto.DataSource = lista;

            this.cmbProjeto.SelectedValue = 0;
        }

        public void CarregaComboEducador()
        {
            List<PessoaDTO> lista = new PessoaBLL().GetPessoasPorTipo(TipoPessoa.Educador);

            lista.Insert(0, new PessoaDTO() { idPessoa = 0, nomePessoa = "Selecione..." });

            this.ddlEducador.DataSource = null;
            this.ddlEducador.Items.Clear();

            this.ddlEducador.DisplayMember = "nomePessoa";
            this.ddlEducador.ValueMember = "idPessoa";
            this.ddlEducador.DataSource = lista;

            this.ddlEducador.SelectedValue = 0;
        }

        public void CarregaDetalhes(int idTurma)
        {
            panelEdit.Visible = true;
            panelConsulta.Visible = false;
            this.ControlBox = false;

            TurmaDTO param = new TurmaDTO();
            param.idTurma = idTurma;

            param = new TurmaBLL().GetByID(param);

            // ************************************************** //
            // Preenche Tela de Detalhes
            // ************************************************** //
            lblCodigo.Text = param.idTurma.ToString();
            cmbProjeto.SelectedValue = param.idProjeto;

            if (param.idProjeto != 0 && cmbProjeto.SelectedValue == null)
            {
                List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(true);

                lista.Add(new ProjetoDTO() { idProjeto = param.idProjeto, nomeProjeto = param.nomeProjeto });
                cmbProjeto.DataSource = lista;
            }

            txtNome.Text = param.nomeTurma;
            cmbStatus.SelectedIndex = (param.flagAtivo) ? 1 : 0;

            ddlEducador.SelectedValue = param.idPessoaEducador;

            if (param.idPessoaEducador != 0 && ddlEducador.SelectedValue == null)
            {
                List<PessoaDTO> lista = new PessoaBLL().GetPessoasPorTipo(TipoPessoa.Educador);

                lista.Add(new PessoaDTO() { idPessoa = param.idPessoaEducador, nomePessoa = param.nomeEducador });
                cmbProjeto.DataSource = lista;
            }

            cmbPeriodo.Text = param.descricaoPeriodo;

            cmbHoraInicio.Text = param.horaInicio.Split(':')[0];
            cmbMinutoInicio.Text = param.horaInicio.Split(':')[1];
            cmbHoraFim.Text = param.horaTermino.Split(':')[0];
            cmbMinutoFim.Text = param.horaTermino.Split(':')[1];

            txtDescricao.Text = param.descricaoTurma;
            txtdtCadastro.Text = param.dtCadastro.ToShortDateString();
            txtDataAlteracao.Text = param.dtUltAlteracao.ToShortDateString();
            txtNomeAlteracao.Text = param.nomePessoaUltAlteracao;

            ControlFormEdit(false);
        }

        public void ClearForm1()
        {
            cmbSearchType.SelectedIndex = 0;
            txtSearch.Text = string.Empty;
        }

        public void ClearForm2()
        {
            lblCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;

            cmbPeriodo.Text = string.Empty;
            cmbHoraInicio.Text = string.Empty;
            cmbHoraFim.Text = string.Empty;
            cmbMinutoInicio.Text = string.Empty;
            cmbMinutoFim.Text = string.Empty;

            txtDuracao.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtNomeAlteracao.Text = string.Empty;
            txtdtCadastro.Text = string.Empty;
            ddlEducador.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 1;
        }

        #endregion

        #region Controls

        #region Combobox Controls

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        #endregion

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbSearchType.SelectedItem.ToString() == "Código do Turma")
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                    MessageBox.Show("A consulta por código permite apenas a digitação de números.");
                }
            }
        }

        #endregion

        #region EditMode

        public void ControlFormEdit(bool flagEnable)
        {
            txtEditMode.Text = flagEnable.ToString();

            btnVoltar1.Text = "Voltar";

            txtNome.Enabled = flagEnable;
            cmbProjeto.Enabled = flagEnable;
            cmbPeriodo.Enabled = flagEnable;
            cmbHoraInicio.Enabled = flagEnable;
            cmbHoraFim.Enabled = flagEnable;
            cmbMinutoInicio.Enabled = flagEnable;
            cmbMinutoFim.Enabled = flagEnable;
            txtDescricao.Enabled = flagEnable;
            txtDuracao.Enabled = flagEnable;
            ddlEducador.Enabled = flagEnable;
            cmbStatus.Enabled = flagEnable;
            txtNomeAlteracao.Enabled = false;
            txtDataAlteracao.Enabled = false;
            txtdtCadastro.Enabled = false;

            txtNome.BackColor = Color.WhiteSmoke;
            cmbPeriodo.BackColor = Color.WhiteSmoke;
            cmbHoraInicio.BackColor = Color.WhiteSmoke;
            cmbHoraFim.BackColor = Color.WhiteSmoke;
            cmbMinutoInicio.BackColor = Color.WhiteSmoke;
            cmbMinutoFim.BackColor = Color.WhiteSmoke;
            txtDescricao.BackColor = Color.WhiteSmoke;
            txtdtCadastro.BackColor = Color.WhiteSmoke;
            txtDuracao.BackColor = Color.WhiteSmoke;
            ddlEducador.BackColor = Color.WhiteSmoke;
            txtNomeAlteracao.BackColor = Color.WhiteSmoke;
            txtDataAlteracao.BackColor = Color.WhiteSmoke;

            btnGravar.Enabled = flagEnable;

            if (flagEnable)
            {
                btnEditar.Visible = false;
                txtNome.Focus();
            }
            else
            {
                btnEditar.Visible = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(txtEditMode.Text))
                ControlFormEdit(false);
            else
                ControlFormEdit(true);
        }

        /*
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
            panelConsulta.Visible = true;

            ControlFormEdit(false);
        }
        */

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            panelConsulta.Visible = true;
            panelEdit.Visible = false;
            this.ControlBox = true;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            TurmaDTO param = new TurmaDTO();

            if (lblCodigo.Text == string.Empty)
                param.idTurma = 0;
            else
                param.idTurma = Convert.ToInt32(lblCodigo.Text);

            param.nomeTurma = txtNome.Text;
            param.flagAtivo = (cmbStatus.SelectedIndex == 0) ? false : true;

            param.descricaoPeriodo = cmbPeriodo.SelectedItem.ToString();

            param.horaInicio = cmbHoraInicio.SelectedItem + ":" + cmbMinutoInicio.SelectedItem;
            param.horaTermino = cmbHoraFim.SelectedItem + ":" + cmbMinutoFim.SelectedItem;
            param.descricaoTurma = txtDescricao.Text;
            param.idProjeto = Convert.ToInt32(cmbProjeto.SelectedValue);
            param.idPessoaUltAlteracao = Sessao.Usuario.idPessoaUltAlteracao;
            param.idPessoaEducador = Convert.ToInt32(ddlEducador.SelectedValue);

            TurmaBLL bus = new TurmaBLL();
            var idTurma = bus.SaveProject(param);

            if (idTurma > 0)
            {
                lblCodigo.Text = idTurma.ToString();
                MessageBox.Show("Turma gravado com sucesso!");
                CarregaGrid();
            }
            else
                throw new Exception("Erro de Gravação do Turma");

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            /*
            tabDadosCadastro.Visible = false;
            lblDados.Visible = false;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            var linha = dataGridView1.Rows[linhaAtual.Index];       //i é o número  da linha seleccionada
            var celula = linha.Cells[0].Value;

            TurmaBLL TurmaBLL = new TurmaBLL();

            Turmas Turmas = new Turmas();
            Turmas.TurmaId = Convert.ToInt32(celula);


            var retorno = TurmaBLL.Excluir(Turmas);
            if (retorno == null)
            {
                throw new Exception("Erro de Gravação do Turma");

            }
            else
            {
                TurmaBLL TurmaRecarga = new TurmaBLL();

                List<Turmas> proj = TurmaRecarga.GetTurmas();

                dataGridView1.DataSource = proj.ToList();
                Limpar();
            }
            */
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Grid.btnExport(Relatorio.Turmas);
        }

        #endregion

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> _param = new Dictionary<string, string>();
            _param.Add("idTurma", lblCodigo.Text);

            Relatorios.FormReport frm = new Relatorios.FormReport(Relatorio.AlunosPorTurma, null);
            frm.param = _param;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }
    }
}
