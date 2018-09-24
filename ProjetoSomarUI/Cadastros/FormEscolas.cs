using Somar.BLL;
using Somar.DTO;
using Somar.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoSomarUI.Cadastros
{
    public partial class FormEscolas : FormBase
    {
        private string gridMessage = "Nenhuma escola encontrada!";

        delegate void UserControlMethod(int idEscola);

        public FormEscolas()
        {
            Inicialize();
        }

        private void Inicialize()
        {
            InitializeComponent();

            #region DropDownLists

            cmbStatus.Items.Add("Desativado");
            cmbStatus.Items.Add("Ativo");

            cmbSearchType.Items.Add("Nome da Escola");
            cmbSearchType.Items.Add("Código da Escola");

            #endregion

            #region Button Events

            btnNovo.Click += new EventHandler(btnNew_Click);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnAll.Click += new EventHandler(btnAll_Click);
            //btnPrint.Click += new EventHandler(btnPrint_Click);
            btnPrint.Visible = false;

            btnEditar.Click += new EventHandler(btnEditar_Click);
            btnVoltar1.Click += new EventHandler(btnVoltar_Click);
            btnGravar.Click += new EventHandler(btnGravar_Click);

            #endregion

            ClearForm1();

            Load += new EventHandler(FormEscolas_Load);

            Grid.InitializeGridView(new EscolaDTO());
            Grid.CallingMethod1 = new UserControlMethod(CarregaDetalhes);
        }

        private void FormEscolas_Load(object sender, EventArgs e)
        {
            CarregaGrid();
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
            txtObservacoes.Text = string.Empty;

            txtCEP.Text = string.Empty;
            txtIdEndereco.Text = string.Empty;
            
            LimpaEndereco();

            txtdtCadastro.Text = string.Empty;
            txtNomeAlteracao.Text = string.Empty;
            txtDataAlteracao.Text = string.Empty;
            cmbStatus.SelectedIndex = 1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnEditar.Visible = false;
            panelEdit.Visible = true;
            panelConsulta.Visible = false;

            ClearForm2();
            ControlFormEdit(true);

            btnVoltar1.Visible = true;
            btnVoltar1.Text = "Voltar";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var param = new EscolaDTO();

            if (cmbSearchType.SelectedItem.ToString() == "Nome da Escola")
            {
                param.nomeEscola = txtSearch.Text;
            }
            else if (cmbSearchType.SelectedItem.ToString() == "Código da Escola")
            {
                if (txtSearch.Text != string.Empty)
                    param.idEscola = Convert.ToInt32(txtSearch.Text);
            }

            List<EscolaDTO> lista = new EscolaBLL().GetDataWithParam(param);

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ClearForm1();

            var param = new EscolaDTO();

            List<EscolaDTO> lista = new EscolaBLL().GetDataWithParam(param);

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(txtEditMode.Text))
                ControlFormEdit(false);
            else
                ControlFormEdit(true);
        }

        public void ControlFormEdit(bool flagEnable)
        {
            txtEditMode.Text = flagEnable.ToString();

            btnVoltar1.Text = "Voltar";
            txtNome.Enabled = flagEnable;
            cmbStatus.Enabled = flagEnable;


            //Endereço
            txtCEP.Enabled = flagEnable;
            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtComplemento.Enabled = false;
            txtUF.Enabled = false;

            //Observações
            txtObservacoes.Enabled = flagEnable;


            //Footer
            txtNomeAlteracao.Enabled = false;
            txtDataAlteracao.Enabled = false;
            txtdtCadastro.Enabled = false;

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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            panelConsulta.Visible = true;
            panelEdit.Visible = false;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            EscolaDTO param = new EscolaDTO();

            if (lblCodigo.Text == string.Empty)
                param.idEscola = 0;
            else
                param.idEscola = Convert.ToInt32(lblCodigo.Text);

            param.nomeEscola = txtNome.Text;
            param.observacoes = txtObservacoes.Text;
            param.flagAtivo = (cmbStatus.SelectedIndex == 0) ? false : true;
            param.idEndereco = string.IsNullOrEmpty(txtIdEndereco.Text) ? 0 : Convert.ToInt32(txtIdEndereco.Text);
            param.idPessoaUltAlteracao = Sessao.Usuario.idUsuario;

            // *********************************************
            // ENDEREÇO
            // *********************************************
            param.endereco = new EnderecoDTO();
            param.endereco.CEP = txtCEP.Text;
            param.endereco.idBairro = string.IsNullOrEmpty(txtIdBairro.Text) ? 0 : Convert.ToInt32(txtIdBairro.Text);
            param.endereco.idCidade = string.IsNullOrEmpty(txtIdCidade.Text) ? 0 : Convert.ToInt32(txtIdCidade.Text);
            param.endereco.logradouro = txtLogradouro.Text;
            param.endereco.numero = txtNumero.Text;
            param.endereco.complemento = txtComplemento.Text;
            param.endereco.nomeBairro = txtBairro.Text;
            param.endereco.nomeCidade = txtCidade.Text;
            param.endereco.siglaUF = txtUF.Text;


            EscolaBLL bus = new EscolaBLL();
            var idEscola = bus.SaveEscola(param);

            if (idEscola > 0)
            {
                lblCodigo.Text = idEscola.ToString();
                MessageBox.Show("Escola cadastrada com sucesso!");
                CarregaGrid();
            }
            else
                throw new Exception("Erro no Cadastro da Escola");
        }

        public void CarregaGrid()
        {
            List<EscolaDTO> lista = new EscolaBLL().GetAllData();

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        private void btnSearchCEP_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCEP.Text.Replace("-", "").Trim()))
            {
                LimpaEndereco();

                var param = new EnderecoDTO();
                param.CEP = txtCEP.Text.Replace("-", "");

                EnderecoDTO itemCEP = new EnderecoBLL().GetCEP(param);

                CarregaEndereco(itemCEP, true);
            }
            else
            {
                MessageBox.Show("Favor inserir um CEP válido");
            }
        }

        public void LimpaEndereco()
        {
            txtLogradouro.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtIdBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtIdCidade.Text = string.Empty;
            txtUF.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtNumero.Text = string.Empty;
        }

        public void CarregaEndereco(EnderecoDTO item, bool enableFields)
        {
            if (enableFields)
            {
                txtLogradouro.Enabled = true;
                txtBairro.Enabled = true;
                txtCidade.Enabled = true;
                txtUF.Enabled = true;
                txtNumero.Enabled = true;
                txtComplemento.Enabled = true;
            }

            if (item != null)
            {
                txtCEP.Text = item.CEP;
                txtBairro.Text = item.nomeBairro;
                txtIdBairro.Text = item.idBairro.ToString();
                txtCidade.Text = item.nomeCidade;
                txtIdCidade.Text = item.idCidade.ToString();
                txtLogradouro.Text = item.logradouro;
                txtUF.Text = item.siglaUF;
                txtComplemento.Text = item.complemento;
                txtNumero.Text = item.numero;

                txtNumero.Focus();
            }
            else
            {
                LimpaEndereco();
                txtLogradouro.Focus();
            }
        }

        public void CarregaDetalhes(int idEscola)
        {
            panelEdit.Visible = true;
            panelConsulta.Visible = false;

            EscolaDTO param = new EscolaDTO();
            param.idEscola = idEscola;

            param = new EscolaBLL().GetByID(param);

            // ************************************************** //
            // Preenche Tela de Detalhes
            // ************************************************** //
            lblCodigo.Text = param.idEscola.ToString();
            txtNome.Text = param.nomeEscola;
            txtObservacoes.Text = param.observacoes;
            txtIdEndereco.Text = param.idEndereco.ToString();
            cmbStatus.SelectedIndex = (param.flagAtivo) ? 1 : 0;

            // ************************************************** //
            // Preenche Tela de Detalhes
            // ************************************************** //
            CarregaEndereco(param.endereco, false);

            // txtNomeAlteracao.Text = param.nomePessoaUltAlteracao;
            txtdtCadastro.Text = param.dtCadastro.ToShortDateString();
            txtDataAlteracao.Text = param.dtUltAlteracao.ToShortDateString();

            ControlFormEdit(false);
        }

        /*
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Grid.btnExport(Relatorio.Escolas);
        }
        */
    }
}
