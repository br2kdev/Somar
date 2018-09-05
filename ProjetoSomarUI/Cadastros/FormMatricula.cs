using ProjetoSomarUI.Properties;
using Somar.BLL;
using Somar.DTO;
using Somar.DTO.Models;
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
    public partial class FormMatricula : FormBase
    {
        public FormMatricula()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            #region ComboLists

            cmbTipoPessoa.SelectedIndexChanged += new EventHandler(cmbTipoPessoa_SelectedIndexChanged);
            cmbProjeto.SelectedIndexChanged += new EventHandler(cmbProjeto_SelectedIndexChanged);

            #endregion

            #region Button Events

            btnNovo.Click += new EventHandler(btnNew_Click);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnAll.Click += new EventHandler(btnAll_Click);

            btnEditar.Click += new EventHandler(btnEditar_Click);
            btnVoltar1.Click += new EventHandler(btnVoltar_Click);
            btnGravar.Click += new EventHandler(btnGravar_Click);

            #endregion

            Load += new EventHandler(FormMatricula_Load);

            InitializeGridView();
            InitializeGridView2();
        }

        private void FormMatricula_Load(object sender, EventArgs e)
        {
            CarregaGrid();
            CarregaComboProjeto();
            CarregaComboTipoPessoa();

            ClearForm1();
        }

        #region Events

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var param = new MatriculaDTO();

            param.nomePessoa = txtSearch.Text;
            param.idTipoPessoa = Convert.ToInt32(cmbTipoPessoa.SelectedValue);

            /*
            if (cmbTipoPessoa.SelectedItem.ToString() == "Nome do Aluno")
            {
                param.nomePessoa = txtSearch.Text;
            }
            else if (cmbSearchType.SelectedItem.ToString() == "Código do Aluno")
            {
                if (txtSearch.Text != string.Empty)
                    param.idPessoa = Convert.ToInt32(txtSearch.Text);
            }
            */

            List<MatriculaDTO> lista = new MatriculaBLL().GetSituacaoAluno(param);

            GridViewDataBind(lista);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ClearForm1();

            List<MatriculaDTO> lista = new MatriculaBLL().GetSituacaoAluno(new MatriculaDTO() { idTipoPessoa = Convert.ToInt32(TipoPessoa.Beneficiário) });

            GridViewDataBind(lista);
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

        #endregion

        #region Methods

        public void CarregaGrid()
        {
            var _idTipoPessoa = Convert.ToInt32(cmbTipoPessoa.SelectedValue);

            List<MatriculaDTO> lista = new MatriculaBLL().GetSituacaoAluno(new MatriculaDTO() { idTipoPessoa = _idTipoPessoa });

            GridViewDataBind(lista);
        }

        public void CarregaComboTipoPessoa()
        {
            List<GenericDTO> lista = new GenericBLL().GetAllData(new GenericDTO() { dominio = domains.TipoPessoa });

            lista.Add(new GenericDTO() { idGeneric = 0, descGeneric = "Todos..." });
            cmbTipoPessoa.DisplayMember = "descGeneric";
            cmbTipoPessoa.ValueMember = "idGeneric";
            cmbTipoPessoa.DataSource = lista;
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

        public void CarregaDetalhes(int _idPessoa)
        {
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

            
            /*
            cmbProjeto.SelectedValue = param.idProjeto;

            if (cmbProjeto.SelectedValue == null)
            {
                List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(true);

                lista.Add(new ProjetoDTO() { idProjeto = param.idProjeto, nomeProjeto = param.nomeProjeto });
                cmbProjeto.DataSource = lista;
            }

            txtNome.Text = param.nomePessoa;
            cmbStatus.SelectedIndex = (param.flagAtivo) ? 1 : 0;

            cmbPeriodo.Text = param.descricaoPeriodo;

            cmbHoraInicio.Text = param.horaInicio.Split(':')[0];
            cmbMinutoInicio.Text = param.horaInicio.Split(':')[1];
            cmbHoraFim.Text = param.horaTermino.Split(':')[0];
            cmbMinutoFim.Text = param.horaTermino.Split(':')[1];
            */
            /*

            txtdtCadastro.Text = param.dtCadastro.ToShortDateString();
            txtDataAlteracao.Text = param.dtUltAlteracao.ToShortDateString();
            txtNomeAlteracao.Text = param.nomePessoaUltAlteracao;
            */

            ControlFormEdit(false);
        }

        public void ClearForm1()
        {
            cmbTipoPessoa.SelectedValue = 0;
            txtSearch.Text = string.Empty;
        }

        public void ClearForm2()
        {
            /*
            lblCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;

            cmbPeriodo.Text = string.Empty;
            cmbHoraInicio.Text = string.Empty;
            cmbHoraFim.Text = string.Empty;
            cmbMinutoInicio.Text = string.Empty;
            cmbMinutoFim.Text = string.Empty;
            */
        }

        #endregion

        private void cmbTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void cmbProjeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProjeto = 0; 

            if (cmbProjeto.SelectedValue != null)
                idProjeto = Convert.ToInt32(cmbProjeto.SelectedValue.ToString());

            CarregaComboTurma(idProjeto);

        }

        #region Controls

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

            // ***************************************************************** //
            //  SET COLUMNS IN GRIDVIEW
            // ***************************************************************** //

            var fields = new GridViewControl().GetFields(new ModelMatricula());

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

                if (item.Key == "nomePessoa")
                {
                    dt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dt.AutoSizeMode = DataGridViewAutoSizeColumnMode.;
                }
                else if (item.Key == "descTipoPessoa" || item.Key == "descGenero")
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

        public void GridViewDataBind(List<MatriculaDTO> result)
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
            {
                e.Value = Resources.icon_search24x24;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int idPessoa = Convert.ToInt32(this.dataGridView1[1, e.RowIndex].Value);

                CarregaDetalhes(idPessoa);
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

        #region Gridview2

        public void InitializeGridView2()
        {
            // ***************************************************************** //
            //  SET CUSTOM STYLE IN GRIDVIEW 2
            // ***************************************************************** //
            this.dataGridView2.AutoSize = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            this.dataGridView2.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            // ***************************************************************** //
            //  SET COLUMNS IN GRIDVIEW
            // ***************************************************************** //

            var fields2 = new GridViewControl().GetFields(new MatriculaDTO());

            // Cancel Image
            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            img2.Name = "ImageCancel";
            img2.HeaderText = "Cancelar";
            img2.ToolTipText = "Cancelar Matricula";
            img2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            img2.Width = 60;
            this.dataGridView2.Columns.Add(img2);

            // -------------------------------------------------------------
            // All Fields
            foreach (var item in fields2)
            {
                DataGridViewTextBoxColumn dt2 = new DataGridViewTextBoxColumn();
                dt2.DataPropertyName = item.Key;
                dt2.HeaderText = item.Value;

                if (item.Key == "nomeTurma")
                {
                    dt2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else if (item.Key == "nomeProjeto")
                    dt2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView2.Columns.Add(dt2);
            }

            // Delete Image
            DataGridViewImageColumn img3 = new DataGridViewImageColumn();
            img3.Name = "ImageDelete";
            img3.HeaderText = "Excluir";
            img2.ToolTipText = "Excluir Matricula";
            img3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            img3.Width = 50;
            this.dataGridView2.Columns.Add(img3);

            this.dataGridView2.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView2_CellFormatting);
            this.dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);
            this.dataGridView2.CellMouseLeave += new DataGridViewCellEventHandler(dataGridView2_CellMouseLeave);
            this.dataGridView2.CellMouseEnter += new DataGridViewCellEventHandler(dataGridView2_CellMouseEnter);
        }

        public void GridViewDataBind2(List<MatriculaDTO> result)
        {
            if (result.Count == 0)
            {
                dataGridView2.Visible = false;
                panelMessage2.Visible = true;
                lblMessage2.Text = "Aluno ainda não possuí matricula!";
            }
            else
            {
                dataGridView2.Visible = true;
                panelMessage2.Visible = false;
                lblMessage2.Text = "";
                dataGridView2.DataSource = result;
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridView2.Columns["ImageDelete"].Index)
                e.Value = Resources.icon_delete24x24;
            else if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridView2.Columns["ImageCancel"].Index)
                e.Value = Resources.icon_cancel24x24;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idMatricula = Convert.ToInt32(this.dataGridView2[1, e.RowIndex].Value);

            if (e.ColumnIndex == 0)
            {
                if (MessageBox.Show("Deseja realmente cancelar a matricula?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnCancelaMatricula("cancelar", idMatricula);
                }
            }
            else if (e.ColumnIndex == 8)
            {
                if (MessageBox.Show("Deseja realmente excluir a matricula?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnCancelaMatricula("excluir", idMatricula);
                }
            }
        }

        private void dataGridView2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 8)
                dataGridView2.Cursor = Cursors.Hand;
        }

        private void dataGridView2_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 8)
                dataGridView2.Cursor = Cursors.Default;
        }

        #endregion

        #endregion

        #region EditMode

        private void btnCancelaMatricula(string acao, int _idMatricula)
        {
            int result = 0;

            var item = new MatriculaDTO()
            {
                idMatricula = _idMatricula,
                idPessoaUltAlteracao = Sessao.Usuario.idUsuario
            };

            if (acao == "cancelar")
            { 
                result = new MatriculaBLL().CancelarMatricula(item);
                MessageBox.Show("Matricula cancelada com sucesso", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(acao == "excluir")
            { 
                result = new MatriculaBLL().ExcluirMatricula(item);
                MessageBox.Show("Matricula excluída com sucesso", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            int _idPessoa = Convert.ToInt32(lblCodigo.Text);

            CarregaDetalhes(_idPessoa);
        }

        private void btnExcluirMatricula_Click(int _idMatricula)
        {
            var item = new MatriculaDTO()
            {
                idMatricula = _idMatricula,
                idPessoaUltAlteracao = Sessao.Usuario.idUsuario
            };

            
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
            /*
            txtEditMode.Text = flagEnable.ToString();

            btnVoltar1.Text = "Voltar";

            txtNome.Enabled = flagEnable;
            txtNomeAlteracao.Enabled = false;
            txtDataAlteracao.Enabled = false;
            txtdtCadastro.Enabled = false;

            txtNome.BackColor = Color.WhiteSmoke;
            txtdtCadastro.BackColor = Color.WhiteSmoke;
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
            */
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
            panelConsulta.Visible = true;

            ControlFormEdit(false);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            panelConsulta.Visible = true;
            panelEdit.Visible = false;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            int _idPessoa = Convert.ToInt32(lblCodigo.Text);
            int _idProjeto = Convert.ToInt32(this.cmbProjeto.SelectedValue);
            int _idTurma = Convert.ToInt32(this.cmbTurma.SelectedValue);

            MatriculaDTO param = new MatriculaDTO();
            param.idProjeto = _idProjeto;
            param.idTurma = _idTurma;
            param.idPessoa = _idPessoa;
            param.idPessoaUltAlteracao = Sessao.Usuario.idUsuario;
            param.dtUltAlteracao = DateTime.Now;

            MatriculaBLL cmd = new MatriculaBLL();
            var idMatricula = cmd.SaveMatricula(param);

            CarregaDetalhes(_idPessoa);
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

            PessoaBLL PessoaBLL = new PessoaBLL();

            Pessoas Pessoas = new Pessoas();
            Pessoas.PessoaId = Convert.ToInt32(celula);


            var retorno = PessoaBLL.Excluir(Pessoas);
            if (retorno == null)
            {
                throw new Exception("Erro de Gravação do Pessoa");

            }
            else
            {
                PessoaBLL PessoaRecarga = new PessoaBLL();

                List<Pessoas> proj = PessoaRecarga.GetPessoas();

                dataGridView1.DataSource = proj.ToList();
                Limpar();
            }
            */
        }

        #endregion

    }
}
