using Somar.BLL;
using Somar.DTO;
using Somar.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoSomarUI.Administracao
{
    public partial class FormUsuarios : FormBase
    {
        private string gridMessage = "Nenhum usuário encontrado!";

        delegate void UserControlMethod(int idUsuario);

        public FormUsuarios()
        {
            InitializeComponent();

            InitializeForm();
        }

        private void InitializeForm()
        {
            #region ComboLists

            cmbSearchType.Items.Add("Nome do Usuário");
            cmbSearchType.Items.Add("Código do Usuário");
            cmbSearchType.Items.Add("Login");

            cmbStatus.Items.Add("Desativado");
            cmbStatus.Items.Add("Ativo");

            #endregion

            #region Button Events

            btnNovo.Click += new EventHandler(btnNew_Click);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnAll.Click += new EventHandler(btnAll_Click);

            btnEditar.Click += new EventHandler(btnEditar_Click);
            btnVoltar1.Click += new EventHandler(btnVoltar_Click);
            btnGravar.Click += new EventHandler(btnGravar_Click);

            #endregion

            btnPrint.Visible = false;

            Load += new EventHandler(FormUsuarios_Load);

            ClearForm1();

            Grid.InitializeGridView(new UsuarioDTO());
            Grid.CallingMethod1 = new UserControlMethod(CarregaDetalhes);
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CarregaGrid();
            CarregaComboPerfil();
        }

        #region Events

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var param = new UsuarioDTO();

            if (cmbSearchType.SelectedItem.ToString() == "Nome do Usuário")
            {
                param.nomeUsuario = txtSearch.Text;
            }
            else if (cmbSearchType.SelectedItem.ToString() == "Login")
            {
                param.login = txtSearch.Text;
            }
            else if (cmbSearchType.SelectedItem.ToString() == "Código do Usuário")
            {
                if (txtSearch.Text != string.Empty)
                    param.idUsuario = Convert.ToInt32(txtSearch.Text);
            }

            List<UsuarioDTO> lista = new UsuarioBLL().GetDataWithParam(param);

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ClearForm1();

            List<UsuarioDTO> lista = new UsuarioBLL().GetAllData(false);

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnEditar.Visible = false;
            panelEdit.Visible = true;
            this.ControlBox = false;
            panelConsulta.Visible = false;

            ClearForm2();
            ControlFormEdit(true);

            btnVoltar1.Visible = true;
            btnVoltar1.Text = "Voltar";
        }

        #endregion

        #region Methods

        public void CarregaGrid()
        {
            List<UsuarioDTO> lista = new UsuarioBLL().GetAllData(false);

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        public void CarregaDetalhes(int idUsuario)
        {
            this.panelEdit.Visible = true;
            this.panelConsulta.Visible = false;
            this.ControlBox = false;

            UsuarioDTO param = new UsuarioDTO();
            param.idUsuario = idUsuario;

            param = new UsuarioBLL().GetByID(param);

            // ************************************************** //
            // Preenche Tela de Detalhes
            // ************************************************** //
            lblCodigo.Text = param.idUsuario.ToString();
            txtNome.Text = param.nomeUsuario;
            txtLogin.Text = param.login;

            cmbPerfil.SelectedValue = param.idPerfil;

            if (cmbPerfil.SelectedValue == null)
            {
                List<GenericDTO> lista = new GenericBLL().GetAllData(new GenericDTO() { dominio = domains.Perfil });

                lista.Add(new GenericDTO() { idGeneric = param.idPerfil, descGeneric = param.descPerfil });
                cmbPerfil.DataSource = lista;
            }

            cmbStatus.SelectedIndex = (param.flagAtivo) ? 1 : 0;
            txtNomeAlteracao.Text = param.nomePessoaUltAlteracao;
            txtdtCadastro.Text = param.dtCadastro.ToShortDateString();
            txtDataAlteracao.Text = param.dtUltAlteracao.ToShortDateString();

            ControlFormEdit(false);
        }

        public void ClearForm1()
        {
            cmbSearchType.SelectedIndex = 0;
            txtSearch.Text = string.Empty;
        }

        public void ClearForm2()
        {
            lblCodigo.Text = "";
            txtLogin.Text = "";
            txtNome.Text = "";
            txtdtCadastro.Text = "";
            txtNomeAlteracao.Text = "";
            cmbStatus.SelectedIndex = 1;
        }

        public void CarregaComboPerfil()
        {
            List<GenericDTO> lista = new GenericBLL().GetAllData(new GenericDTO() { dominio = domains.Perfil });

            cmbPerfil.DisplayMember = "descGeneric";
            cmbPerfil.ValueMember = "idGeneric";
            cmbPerfil.DataSource = lista;
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
            if (cmbSearchType.SelectedItem.ToString() == "Código do Usuário")
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
            txtLogin.Enabled = flagEnable;
            cmbStatus.Enabled = flagEnable;
            txtNomeAlteracao.Enabled = false;
            txtDataAlteracao.Enabled = false;
            txtdtCadastro.Enabled = false;

            txtLogin.BackColor = Color.WhiteSmoke;
            txtNome.BackColor = Color.WhiteSmoke;
            txtdtCadastro.BackColor = Color.WhiteSmoke;
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
            this.panelConsulta.Visible = true;
            this.panelEdit.Visible = false;
            this.ControlBox = true;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            UsuarioDTO param = new UsuarioDTO();

            if (lblCodigo.Text == string.Empty)
                param.idUsuario = 0;
            else
                param.idUsuario = Convert.ToInt32(lblCodigo.Text);

            param.nomeUsuario = txtNome.Text;
            param.login = txtLogin.Text;
            param.flagAtivo = (cmbStatus.SelectedIndex == 0) ? false : true;
            param.idPerfil = Convert.ToInt32(cmbPerfil.SelectedValue);
            param.idPessoaUltAlteracao = Sessao.Usuario.idUsuario;
            //param.descricaoProjeto = txtDescricao.Text;
            //param.idPessoaResposavel = //txtResponsavel.Text;

            UsuarioBLL bus = new UsuarioBLL();
            var idUsuario = bus.SaveProject(param);

            if (idUsuario > 0)
            {
                lblCodigo.Text = idUsuario.ToString();
                MessageBox.Show("Usuário gravado com sucesso!");
                CarregaGrid();
            }
            else
                throw new Exception("Erro de Gravação do Usuário");
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

            UsuarioBLL UsuarioBLL = new UsuarioBLL();

            Projetos projetos = new Projetos();
            projetos.ProjetoId = Convert.ToInt32(celula);


            var retorno = UsuarioBLL.Excluir(projetos);
            if (retorno == null)
            {
                throw new Exception("Erro de Gravação do Projeto");

            }
            else
            {
                UsuarioBLL projetoRecarga = new UsuarioBLL();

                List<Projetos> proj = projetoRecarga.GetProjetos();

                dataGridView1.DataSource = proj.ToList();
                Limpar();
            }
            */
        }

        #endregion
    }
}
