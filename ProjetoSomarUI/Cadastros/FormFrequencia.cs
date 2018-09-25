using ProjetoSomarUI.Properties;
using Somar.BLL;
using Somar.DTO;
using Somar.DTO.Models;
using Somar.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoSomarUI.Cadastros
{
    public partial class FormFrequencia : Form
    {
        private string gridMessage = "Nenhuma frequência encontrada!";

        delegate void UserDetalhes(int idPessoa);

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

            cmbProjetoEdit.SelectedIndexChanged += new EventHandler(cmbProjetoEdit_SelectedIndexChanged);
            cmbTurmaEdit.SelectedIndexChanged += new EventHandler(cmbTurmaEdit_SelectedIndexChanged);

            #endregion

            #region Button Events

            btnNovo.Click += new EventHandler(btnNew_Click);
            btnGravar.Click += new EventHandler(btnGravar_Click);
            btnVoltar1.Click += new EventHandler(btnVoltar_Click);
            //btnEditar.Click += new EventHandler(btnEditar_Click);

            /*
            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnAll.Click += new EventHandler(btnAll_Click);
            */

            #endregion

            Load += new EventHandler(FormMatricula_Load);

            Grid.InitializeGridView(new ModelFrequencia());
            Grid.CallingMethod1 = new UserDetalhes(CarregaDetalhes);

            InitializeGridView2();
            ClearForm1();
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

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        public void CarregaDetalhes(int _idFrequencia)
        {
            CarregaComboProjetoEdit();

            panelEdit.Visible = true;
            panelConsulta.Visible = false;

            // ************************************************** //
            // Preenche Tela de Detalhes
            // ************************************************** //

            var itemFreq = new FrequenciaBLL().GetByID(new FrequenciaDTO() { idFrequencia = _idFrequencia });

            lblCodigo.Text = _idFrequencia.ToString();
            cmbProjetoEdit.SelectedValue = itemFreq.idProjeto;
            cmbTurmaEdit.SelectedValue = itemFreq.idTurma;
            txtdtFrequencia.Text = itemFreq.dtFrequencia.ToShortDateString();

            txtdtCadastro.Text = itemFreq.dtCadastro.ToShortDateString();
            txtDataAlteracao.Text = itemFreq.dtUltAlteracao.ToShortDateString();
            txtNomeAlteracao.Text = itemFreq.nomePessoaUltAlteracao;
            
            var listPresenca = new FrequenciaBLL().GetAlunos(new FrequenciaDTO() { idFrequencia = _idFrequencia });

            GridViewDataBind2(listPresenca);

            // ************************************************** //
            // Preenche Matricula
            // ************************************************** //
            /*
            MatriculaDTO param = new MatriculaDTO();
            param.idPessoa = _idPessoa;

            var listMatr = new MatriculaBLL().GetDataWithParam(param);
            */

            ControlFormEdit(false);
        }
        
        public void ClearForm1()
        {
            cmbProjeto.SelectedValue = 0;
            cmbTurma.SelectedValue = 0;
        }

        public void ClearForm2()
        {
            lblCodigo.Text = string.Empty;

            cmbProjetoEdit.SelectedIndex = -1;
            cmbTurmaEdit.SelectedIndex = -1;
            dataGridView2.Visible = false;


            /*
            cmbPeriodo.Text = string.Empty;
            cmbHoraInicio.Text = string.Empty;
            cmbHoraFim.Text = string.Empty;
            cmbMinutoInicio.Text = string.Empty;
            cmbMinutoFim.Text = string.Empty;

            txtDuracao.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtNomeAlteracao.Text = string.Empty;
            txtdtCadastro.Text = string.Empty;
            txtResponsavel.Text = string.Empty;
            cmbStatus.SelectedIndex = 1;
            */
        }

        #region ComboLists

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

        public void CarregaComboProjetoEdit()
        {
            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(true);

            lista.Insert(0, new ProjetoDTO() { idProjeto = 0, nomeProjeto = "Selecione..." });

            this.cmbProjetoEdit.DataSource = null;
            this.cmbProjetoEdit.Items.Clear();

            this.cmbProjetoEdit.DisplayMember = "nomeProjeto";
            this.cmbProjetoEdit.ValueMember = "idProjeto";
            this.cmbProjetoEdit.DataSource = lista;

            this.cmbProjetoEdit.SelectedValue = 0;
        }

        public void CarregaComboTurmaEdit(int idProjeto)
        {
            List<TurmaDTO> lista = new TurmaBLL().GetTurmasPorProjeto(idProjeto);

            lista.Insert(0, new TurmaDTO() { idTurma = 0, nomeTurma = "Selecione..." });

            this.cmbTurmaEdit.DataSource = null;
            this.cmbTurmaEdit.Items.Clear();

            this.cmbTurmaEdit.DisplayMember = "nomeTurma";
            this.cmbTurmaEdit.ValueMember = "idTurma";
            this.cmbTurmaEdit.DataSource = lista;

            this.cmbTurmaEdit.SelectedValue = 0;
        }

        #endregion

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

        private void cmbProjetoEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProjeto = 0;

            if (cmbProjetoEdit.SelectedValue != null)
                idProjeto = Convert.ToInt32(cmbProjetoEdit.SelectedValue.ToString());

            CarregaComboTurmaEdit(idProjeto);

        }

        private void cmbTurmaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CarregaGrid();
        }

        #region Events

        private void btnNew_Click(object sender, EventArgs e)
        {
            //btnEditar.Visible = false;
            panelEdit.Visible = true;
            panelConsulta.Visible = false;
            
            ControlFormEdit(true);

            CarregaComboProjetoEdit();

            ClearForm2();

            btnVoltar1.Visible = true;
            btnVoltar1.Text = "Voltar";
        }

        #endregion

        #region Gridview Controls

        #region Gridview2

        public void InitializeGridView2()
        {
            // ***************************************************************** //
            //  SET CUSTOM STYLE IN GRIDVIEW 2
            // ***************************************************************** //
            this.dataGridView2.AutoSize = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            this.dataGridView2.AllowUserToAddRows = true;
            this.dataGridView2.AllowUserToDeleteRows = true;

            this.dataGridView2.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            // ***************************************************************** //
            //  SET COLUMNS IN GRIDVIEW
            // ***************************************************************** //
            
            var fields2 = new GridViewControlUtils().GetFields(new ModelListaPresenca());

            // Edit Image
            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            img2.Name = "Image";
            img2.HeaderText = "";
            img2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            img2.Width = 40;
            this.dataGridView2.Columns.Add(img2);

            // -------------------------------------------------------------
            // All Fields
            foreach (var item in fields2)
            {
                DataGridViewTextBoxColumn dt2 = new DataGridViewTextBoxColumn();
                dt2.DataPropertyName = item.Key;
                dt2.HeaderText = item.Value;

                if (item.Key == "nomePessoa")
                {
                    dt2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView2.Columns.Add(dt2);
                }
                else if (item.Key == "nomeTurma")
                { 
                    dt2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dataGridView2.Columns.Add(dt2);
                }
                else if (item.Key == "flagPresenca")
                {
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    chk.HeaderText = "Presença";
                    chk.Name = "flagPresenca";
                    chk.DataPropertyName = item.Key;
                    chk.Width = 80;
                    this.dataGridView2.Columns.Add(chk);
                }
                else
                {
                    this.dataGridView2.Columns.Add(dt2);
                }
                
            }
            
            this.dataGridView2.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView2_CellFormatting);
            this.dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);
            this.dataGridView2.CellMouseLeave += new DataGridViewCellEventHandler(dataGridView2_CellMouseLeave);
            this.dataGridView2.CellMouseEnter += new DataGridViewCellEventHandler(dataGridView2_CellMouseEnter);
        }

        public void GridViewDataBind2(List<FrequenciaDTO> result)
        {
            if (result.Count == 0)
            {
                dataGridView2.Visible = false;
                panelMessage2.Visible = true;
                lblMessage2.Text = "Nenhum aluno matriculado para esta data!";
            }
            else
            {
                dataGridView2.Visible = true;
                dataGridView2.DataSource = result;
                panelMessage2.Visible = false;
                lblMessage2.Text = "";
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridView2.Columns["Image"].Index)
                e.Value = Resources.icon_search24x24;
            else if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridView2.Columns["flagPresenca"].Index)
            {


            }

            /*
            else if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridView2.Columns["ImageCancel"].Index)
                e.Value = Resources.icon_cancel24x24;
            //else if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridView2.Columns["flagPresenca"].Index)
            //    e.Value = Resources.icon_add32x32;
            */

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int idPessoa = Convert.ToInt32(this.dataGridView2[1, e.RowIndex].Value);

                // CarregaDetalhes(idPessoa);

                // MessageBox.Show("You have selected in image in " + e.RowIndex + " row.");
                // MessageBox.Show("You have selected in image in " + this.dataGridView1[1, e.RowIndex].Value.ToString() + " row.");
            }
            else if (e.ColumnIndex == dataGridView2.Columns["flagPresenca"].Index)
            {
                bool _out = false;
                bool chkChecked = false;

                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView2.Rows[e.RowIndex].Cells["flagPresenca"];

                if (bool.TryParse(chk.Value.ToString(), out _out))
                    chkChecked = Convert.ToBoolean(chk.Value);

                if (chkChecked == true)
                    chk.Value = false;
                else
                    chk.Value = true;

                int _idPessoa = Convert.ToInt32(this.dataGridView2[1, e.RowIndex].Value);

                var _item = new FrequenciaDTO()
                {
                    idPessoa = _idPessoa,
                    idFrequencia = Convert.ToInt32(lblCodigo.Text),
                    flagPresenca = Convert.ToBoolean(chk.Value)
                };

                dataGridView2.EndEdit();  //Stop editing of cell.

                var result = new FrequenciaBLL().UpdateListaChamada(_item);

                /*
                //dataGridView2.Rows[e.RowIndex].Cells["flagPresenca"].Value = true;
                if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["chkcol"].Value) == false)
                {
                    for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                    {
                        dataGridView1.Rows[i].Cells["chkcol"].Value = false;
                    }
                }
                */

                /*
                var bid = dataGridView2.Rows[e.RowIndex];

                var selectedRow = this.dataGridView2[1, e.RowIndex];

                if (selectedRow == null)
                    return;

                selectedRow.Selected = !selectedRow.Selected;
                */
            }
        }

        private void dataGridView2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (GridViewControlUtils.IsValidCellAddress(e.RowIndex, e.ColumnIndex))
                dataGridView2.Cursor = Cursors.Hand;
        }

        private void dataGridView2_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (GridViewControlUtils.IsValidCellAddress(e.RowIndex, e.ColumnIndex))
                dataGridView2.Cursor = Cursors.Default;
        }

        #endregion

        #endregion

        #region EditMode

        public void ControlFormEdit(bool flagEnable)
        {
            txtEditMode.Text = flagEnable.ToString();

            btnVoltar1.Text = "Voltar";

            txtdtFrequencia.Enabled = flagEnable;
            cmbProjetoEdit.Enabled = flagEnable;
            cmbTurmaEdit.Enabled = flagEnable;

            txtNomeAlteracao.Enabled = false;
            txtDataAlteracao.Enabled = false;
            txtdtCadastro.Enabled = false;

            cmbProjetoEdit.BackColor = Color.WhiteSmoke;
            cmbTurmaEdit.BackColor = Color.WhiteSmoke;

            txtdtCadastro.BackColor = Color.WhiteSmoke;
            txtNomeAlteracao.BackColor = Color.WhiteSmoke;
            txtDataAlteracao.BackColor = Color.WhiteSmoke;

            if (flagEnable)
            {
                //btnEditar.Visible = false;
                btnGravar.Visible = true;
                txtdtFrequencia.Focus();
            }
            else
            {
                //btnEditar.Visible = true;
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
            FrequenciaDTO param = new FrequenciaDTO();

            if (lblCodigo.Text == string.Empty)
                param.idFrequencia = 0;
            else
                param.idFrequencia = Convert.ToInt32(lblCodigo.Text);

            param.idProjeto = Convert.ToInt32(cmbProjetoEdit.SelectedValue);
            param.idTurma = Convert.ToInt32(cmbTurmaEdit.SelectedValue);
            param.dtFrequencia = Convert.ToDateTime(txtdtFrequencia.Text);
            param.idPessoaUltAlteracao = Sessao.Usuario.idUsuario;

            FrequenciaBLL bus = new FrequenciaBLL();
            var idFrequencia = bus.SalvarFrequencia(param);

            if (idFrequencia > 0)
            {
                lblCodigo.Text = idFrequencia.ToString();
                MessageBox.Show("Frequencia gerada com sucesso!");

                CarregaGrid();
                CarregaDetalhes(idFrequencia);
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
