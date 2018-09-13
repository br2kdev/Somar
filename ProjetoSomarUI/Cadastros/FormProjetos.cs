using Somar.BLL;
using Somar.DTO;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using Somar.Shared;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using ProjetoSomarUI.Modules;

namespace ProjetoSomarUI.Cadastros
{

    public partial class FormProjetos : FormBase
    {
        delegate void UserControlMethod(int idProjeto);

        public FormProjetos()
        {
            Inicialize();
        }

        private void Inicialize()
        {
            InitializeComponent();
            ClearForm1();
            Grid.InitializeGridView(new ProjetoDTO(), "Nenhum projeto encontrado!");

            UserControlMethod CellClicked = new UserControlMethod(CarregaDetalhes);
            Grid.CallingPageMethod = CellClicked;
        }

        private void FormProjetos_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        #region Events

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var param = new ProjetoDTO();

            if (cmbSearchType.SelectedItem.ToString() == "Nome do Projeto")
            {
                param.nomeProjeto = txtSearch.Text;
            }
            else if (cmbSearchType.SelectedItem.ToString() == "Código do Projeto")
            {
                if (txtSearch.Text != string.Empty)
                    param.idProjeto = Convert.ToInt32(txtSearch.Text);
            }

            List<ProjetoDTO> lista = new ProjetoBLL().GetDataWithParam(param);

            Grid.GridViewDataBind(lista.ToDataTable());
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ClearForm1();

            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(false);

            Grid.GridViewDataBind(lista.ToDataTable());
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnEditar.Visible = false;
            panelEdit.Visible = true;
            panelConsulta.Visible = false;

            cmbTempoProjeto.SelectedItem = "Definido";
            pnlTempoProjeto.Visible = true;
            txtdtTermino.Format = DateTimePickerFormat.Short;

            ClearForm2();
            ControlFormEdit(true);

            btnVoltar1.Visible = true;
            btnVoltar1.Text = "Voltar";
        }

        #endregion

        #region Methods

        public void CarregaGrid()
        {
            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(false);

            Grid.GridViewDataBind(lista.ToDataTable());
        }

        /*
        public void CarregaComboResponsavel()
        {
            
            List<PessoaDTO> lista = new PessoaBLL().GetPessoasPorTipo(TipoPessoa.);

            cmbResponsavel.DisplayMember = "nomePessoa";
            cmbResponsavel.ValueMember = "idPessoa";
            cmbResponsavel.DataSource = lista;
        }
        */

        public void CarregaDetalhes(int idProjeto)
        {
            panelEdit.Visible = true;
            panelConsulta.Visible = false;

            ProjetoDTO param = new ProjetoDTO();
            param.idProjeto = idProjeto;

            param = new ProjetoBLL().GetByID(param);

            // ************************************************** //
            // Preenche Tela de Detalhes
            // ************************************************** //
            lblCodigo.Text = param.idProjeto.ToString();
            txtNome.Text = param.nomeProjeto;
            cmbStatus.SelectedIndex = (param.flagAtivo) ? 1 : 0;

            txtDataInicio.Text = Convert.ToDateTime(param.dtInicio).ToShortDateString();

            if (param.dtTermino != null)
            {
                pnlTempoProjeto.Visible = true;
                cmbTempoProjeto.SelectedItem = "Definido";
                txtdtTermino.Text = Convert.ToDateTime(param.dtTermino).ToShortDateString();
            }
            else
            {
                pnlTempoProjeto.Visible = false;
                cmbTempoProjeto.SelectedItem = "Indeterminado";
                txtdtTermino.Text = string.Empty;
            }

            txtResponsavel.Text = param.nomeResposavel;
            txtDescricao.Text = param.descricaoProjeto;
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
            txtDataInicio.Text = string.Empty;
            txtdtTermino.Text = string.Empty;

            txtDuracao.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtdtCadastro.Text = string.Empty;
            txtResponsavel.Text = string.Empty;
            txtNomeAlteracao.Text = string.Empty;
            txtDataAlteracao.Text = string.Empty;
            cmbStatus.SelectedIndex = 1;
        }

        #endregion

        #region Controls

        #region Gridview Controls

        /*
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int idProjeto = Convert.ToInt32(this.Grid.dataGridView1[1, e.RowIndex].Value);

                CarregaDetalhes(idProjeto);

                // MessageBox.Show("You have selected in image in " + e.RowIndex + " row.");
                // MessageBox.Show("You have selected in image in " + this.dataGridView1[1, e.RowIndex].Value.ToString() + " row.");
            }
        }
        */

        #endregion

        #region Combobox Controls

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        #endregion

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbSearchType.SelectedItem.ToString() == "Código do Projeto")
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
            txtDataInicio.Enabled = flagEnable;
            txtdtTermino.Enabled = flagEnable;
            txtDescricao.Enabled = flagEnable;
            txtDuracao.Enabled = flagEnable;
            txtResponsavel.Enabled = flagEnable;
            cmbStatus.Enabled = flagEnable;
            cmbTempoProjeto.Enabled = flagEnable;
            txtNomeAlteracao.Enabled = false;
            txtDataAlteracao.Enabled = false;
            txtdtCadastro.Enabled = false;

            txtNome.BackColor = Color.WhiteSmoke;
            txtDataInicio.BackColor = Color.WhiteSmoke;
            txtdtTermino.BackColor = Color.WhiteSmoke;
            txtDescricao.BackColor = Color.WhiteSmoke;
            txtdtCadastro.BackColor = Color.WhiteSmoke;
            txtDuracao.BackColor = Color.WhiteSmoke;
            txtResponsavel.BackColor = Color.WhiteSmoke;
            txtNomeAlteracao.BackColor = Color.WhiteSmoke;
            txtDataAlteracao.BackColor = Color.WhiteSmoke;

            if (flagEnable)
            {
                btnEditar.Visible = false;
                btnGravar.Visible = true;
                txtNome.Focus();
            }
            else
            {
                btnEditar.Visible = true;
                btnGravar.Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(txtEditMode.Text))
                ControlFormEdit(false);
            else
                ControlFormEdit(true);

            /*
            lblDados.Visible = true;
            tabDadosCadastro.Visible = true;

            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            var linha = dataGridView1.Rows[linhaAtual.Index];       
            var celula = linha.Cells[0].Value;

            ProjetoBLL projetoBLL = new ProjetoBLL();

            Projetos projetos = new Projetos();
            projetos.ProjetoId = Convert.ToInt32(celula);


            Projetos retorno = projetoBLL.Localizar(projetos.ProjetoId);
            
             txtNome.Text = retorno.Nome;
            
             txtDataInicio.Text = retorno.DataInicio.ToString("dd/MM/yyyy");            
             txtdtTermino.Text = retorno.dtTermino.ToString("dd/MM/yyyy");
             txtDuracao.Text = Convert.ToString(retorno.Duracao);
             txtDescricao.Text = retorno.Descricao;
             txtdtCadastro.Text = retorno.dtCadastro.ToString("dd/MM/yyyy");
             txtResponsavel.Text = Convert.ToString(retorno.ResponsavelPessoaId);
             */
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
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ProjetoDTO param = new ProjetoDTO();

            if (lblCodigo.Text == string.Empty)
                param.idProjeto = 0;
            else
                param.idProjeto = Convert.ToInt32(lblCodigo.Text);

            param.nomeProjeto = txtNome.Text;
            param.flagAtivo = (cmbStatus.SelectedIndex == 0) ? false : true;

            if (!string.IsNullOrWhiteSpace(txtDataInicio.Text))
                param.dtInicio = Convert.ToDateTime(txtDataInicio.Text);

            if (!string.IsNullOrWhiteSpace(txtdtTermino.Text))
                param.dtTermino = Convert.ToDateTime(txtdtTermino.Text);

            param.descricaoProjeto = txtDescricao.Text;
            param.idPessoaUltAlteracao = Sessao.Usuario.idUsuario;
            param.nomeResposavel = txtResponsavel.Text;
            //param.idPessoaResposavel = //txtResponsavel.Text;

            ProjetoBLL bus = new ProjetoBLL();
            var idProjeto = bus.SaveProject(param);

            if (idProjeto > 0)
            {
                lblCodigo.Text = idProjeto.ToString();
                MessageBox.Show("Projeto gravado com sucesso!");
                CarregaGrid();
            }
            else
                throw new Exception("Erro de Gravação do Projeto");

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

            ProjetoBLL projetoBLL = new ProjetoBLL();

            Projetos projetos = new Projetos();
            projetos.ProjetoId = Convert.ToInt32(celula);


            var retorno = projetoBLL.Excluir(projetos);
            if (retorno == null)
            {
                throw new Exception("Erro de Gravação do Projeto");

            }
            else
            {
                ProjetoBLL projetoRecarga = new ProjetoBLL();

                List<Projetos> proj = projetoRecarga.GetProjetos();

                dataGridView1.DataSource = proj.ToList();
                Limpar();
            }
            */
        }

        #endregion

        private void cmbTempoProjeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTempoProjeto.SelectedItem.ToString() == "Indeterminado")
            {
                pnlTempoProjeto.Visible = false;

                txtdtTermino.Format = DateTimePickerFormat.Custom;
                txtdtTermino.CustomFormat = " ";

                txtdtTermino.Text = string.Empty;
            }
            else
            {
                pnlTempoProjeto.Visible = true;
                txtdtTermino.Format = DateTimePickerFormat.Short;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Grid.btnExport();
        }
        
    }
}