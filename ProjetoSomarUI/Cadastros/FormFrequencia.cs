using ProjetoSomarUI.Properties;
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
    public partial class FormFrequencia : Form
    {
        public FormFrequencia()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            #region ComboLists

            cmbProjeto.SelectedIndexChanged += new EventHandler(cmbProjeto_SelectedIndexChanged);
            cmbTurma.SelectedIndexChanged += new EventHandler(cmbTurma_SelectedIndexChanged);

            #endregion

            #region Button Events

            btnNovo.Click += new EventHandler(btnNew_Click);
            /*
            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnAll.Click += new EventHandler(btnAll_Click);

            btnEditar.Click += new EventHandler(btnEditar_Click);
            btnVoltar1.Click += new EventHandler(btnVoltar_Click);
            btnGravar.Click += new EventHandler(btnGravar_Click);
            */

            #endregion

            Load += new EventHandler(FormMatricula_Load);

            InitializeGridView();
        }

        private void FormMatricula_Load(object sender, EventArgs e)
        {
            CarregaComboProjeto();
            CarregaGrid();
            ClearForm1();
        }

        public void CarregaGrid()
        {
            int _idProjeto = 0;
            int _idTurma = 0;

            if (cmbProjeto.SelectedValue != null)
                _idProjeto = Convert.ToInt32(cmbProjeto.SelectedValue.ToString());

            if (cmbTurma.SelectedValue != null)
                _idTurma = Convert.ToInt32(cmbTurma.SelectedValue.ToString());

            FrequenciaDTO itemFrequencia = new FrequenciaDTO() { idProjeto = _idProjeto, idTurma = _idTurma };

            List<FrequenciaDTO> lista = new FrequenciaBLL().GetAllData(itemFrequencia);

            GridViewDataBind(lista);
        }

        /*
        public void CarregaDetalhes(int _idPessoa)
        {
            CarregaComboProjeto();

            panelEdit.Visible = true;
            panelConsulta.Visible = false;

            // ************************************************** //
            // Preenche Tela de Detalhes
            // ************************************************** //

            var itemAluno = new PessoaBLL().GetByID(new PessoaDTO() { idPessoa = _idPessoa });

            lblCodigo.Text = _idPessoa.ToString();
            txtNome.Text = itemAluno.nomePessoa;

            // ************************************************** //
            // Preenche Matricula
            // ************************************************** //

            MatriculaDTO param = new MatriculaDTO();
            param.idPessoa = _idPessoa;

            var listMatr = new MatriculaBLL().GetDataWithParam(param);

            GridViewDataBind2(listMatr);

            ControlFormEdit(false);
        }
        */

        public void ClearForm1()
        {
            cmbProjeto.SelectedValue = 0;
            cmbTurma.SelectedValue = 0;
        }

        public void ClearForm2()
        {
            lblCodigo.Text = string.Empty;

            cmbProjetoEdit.SelectedIndex = 1;
            cmbTurmaEdit.SelectedIndex = 1;

            /*
            cmbPeriodo.Text = string.Empty;
            cmbHoraInicio.Text = string.Empty;
            cmbHoraFim.Text = string.Empty;
            cmbMinutoInicio.Text = string.Empty;
            cmbMinutoFim.Text = string.Empty;

            txtDuracao.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtNomeAlteracao.Text = string.Empty;
            txtDataCadastro.Text = string.Empty;
            txtResponsavel.Text = string.Empty;
            cmbStatus.SelectedIndex = 1;
            */
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

        public void CarregaComboTurma(int idProjeto)
        {
            List<TurmaDTO> lista = new TurmaBLL().GetTurmasPorProjeto(idProjeto);

            lista.Insert(0, new TurmaDTO() { idTurma = 0, nomeTurma = "Selecione..." });

            this.cmbTurma.DataSource = null;
            this.cmbTurma.Items.Clear();

            this.cmbTurma.DisplayMember = "nomeTurma";
            this.cmbTurma.ValueMember = "idTurma";
            this.cmbTurma.DataSource = lista;

            this.cmbTurma.SelectedValue = 0;
        }

        private void cmbProjeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProjeto = 0;

            if (cmbProjeto.SelectedValue != null)
                idProjeto = Convert.ToInt32(cmbProjeto.SelectedValue.ToString());

            CarregaComboTurma(idProjeto);

        }

        private void cmbTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        #region Events

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

        #endregion

        #region Gridview Controls

        public void InitializeGridView()
        {
            // ***************************************************************** //
            //  SET CUSTOM STYLE IN GRIDVIEW
            // ***************************************************************** //
            this.dataGridView1.AutoSize = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            // ***************************************************************** //
            //  SET COLUMNS IN GRIDVIEW
            // ***************************************************************** //

            var fields = new GridViewControl().GetFields(new FrequenciaDTO());

            // Edit Image
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "Image";
            img.HeaderText = "";
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            img.Width = 40;
            this.dataGridView1.Columns.Add(img);

            // -------------------------------------------------------------
            // All Fields
            foreach (var item in fields)
            {
                DataGridViewTextBoxColumn dt = new DataGridViewTextBoxColumn();
                dt.DataPropertyName = item.Key;
                dt.HeaderText = item.Value;

                if (item.Key == "nomeProjeto")
                    dt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else if (item.Key == "nomeTurma")
                    dt.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(dt);
            }

            // -------------------------------------------------------------

            this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            this.dataGridView1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellMouseLeave);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellMouseEnter);

            // ***************************************************************** //
        }

        public void GridViewDataBind(List<FrequenciaDTO> result)
        {
            if (result.Count == 0)
            {
                dataGridView1.Visible = false;
                panelMessage.Visible = true;
                lblMessage.Text = "Nenhuma pessoa encontrada";
            }
            else
            {
                dataGridView1.Visible = true;
                panelMessage.Visible = false;
                lblMessage.Text = "";
                dataGridView1.DataSource = result;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridView1.Columns["Image"].Index)
                e.Value = Resources.icon_search24x24;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int idFrequencia = Convert.ToInt32(this.dataGridView1[1, e.RowIndex].Value);

                // CarregaDetalhes(idPessoa);

                // MessageBox.Show("You have selected in image in " + e.RowIndex + " row.");
                // MessageBox.Show("You have selected in image in " + this.dataGridView1[1, e.RowIndex].Value.ToString() + " row.");
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (GridViewControl.IsValidCellAddress(e.RowIndex, e.ColumnIndex))
                dataGridView1.Cursor = Cursors.Hand;
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (GridViewControl.IsValidCellAddress(e.RowIndex, e.ColumnIndex))
                dataGridView1.Cursor = Cursors.Default;
        }

        #endregion

        #region EditMode

        public void ControlFormEdit(bool flagEnable)
        {
            txtEditMode.Text = flagEnable.ToString();

            btnVoltar1.Text = "Voltar";

            cmbProjetoEdit.Enabled = flagEnable;
            cmbTurmaEdit.Enabled = flagEnable;

            txtNomeAlteracao.Enabled = false;
            txtDataAlteracao.Enabled = false;
            txtDataCadastro.Enabled = false;

            cmbProjetoEdit.BackColor = Color.WhiteSmoke;
            cmbTurmaEdit.BackColor = Color.WhiteSmoke;

            txtDataCadastro.BackColor = Color.WhiteSmoke;
            txtNomeAlteracao.BackColor = Color.WhiteSmoke;
            txtDataAlteracao.BackColor = Color.WhiteSmoke;

            if (flagEnable)
            {
                btnEditar.Visible = false;
                btnGravar.Visible = true;
                //txtNome.Focus();
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

            TurmaBLL TurmaBLL = new TurmaBLL();

            Turmas Turmas = new Turmas();
            Turmas.TurmaId = Convert.ToInt32(celula);


            Turmas retorno = TurmaBLL.Localizar(Turmas.TurmaId);
            
             txtNome.Text = retorno.Nome;
            
             txtDataInicio.Text = retorno.DataInicio.ToString("dd/MM/yyyy");            
             txtDataTermino.Text = retorno.DataTermino.ToString("dd/MM/yyyy");
             txtDuracao.Text = Convert.ToString(retorno.Duracao);
             txtDescricao.Text = retorno.Descricao;
             txtDataCadastro.Text = retorno.DataCadastro.ToString("dd/MM/yyyy");
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
            FrequenciaDTO param = new FrequenciaDTO();

            if (lblCodigo.Text == string.Empty)
                param.idFrequencia = 0;
            else
                param.idFrequencia = Convert.ToInt32(lblCodigo.Text);

            DateTime dataFrequencia = Convert.ToDateTime(txtDataFrequencia.Text);

            int idProjeto = Convert.ToInt32(cmbProjetoEdit.SelectedValue);
            int idTurma = Convert.ToInt32(cmbTurmaEdit.SelectedValue);

            //param.flagAtivo = (cmbStatus.SelectedIndex == 0) ? false : true;

            //param.idProjeto = Convert.ToInt32(cmbProjeto.SelectedValue);
            //param.idTurma = Convert.ToInt32(cmbProjeto.SelectedValue);

            param.idPessoaUltAlteracao = Sessao.Usuario.idPessoaUltAlteracao;

            FrequenciaBLL bus = new FrequenciaBLL();
            var idFrequencia = bus.SalvarFrequencia(param);

            if (idFrequencia > 0)
            {
                lblCodigo.Text = idFrequencia.ToString();
                MessageBox.Show("Frequencia gerada com sucesso!");
                CarregaGrid();
            }
            else
                throw new Exception("Erro na geração da Frequencia");

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
