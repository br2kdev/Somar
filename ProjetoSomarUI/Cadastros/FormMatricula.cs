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
    public partial class FormMatricula : Form
    {
        public FormMatricula()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            #region ComboLists

            cmbSearchType.Items.Add("Nome do Turma");
            cmbSearchType.Items.Add("Código do Turma");

            cmbStatus.Items.Add("Desativado");
            cmbStatus.Items.Add("Ativo");

            /*
            cmbPeriodo.Items.Add("Selecione...");
            cmbPeriodo.Items.Add("Manhã");
            cmbPeriodo.Items.Add("Tarde");
            cmbPeriodo.Items.Add("Noite");
            cmbPeriodo.Items.Add("Integral");
            */

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

            ClearForm1();
        }

        private void FormMatricula_Load(object sender, EventArgs e)
        {
            CarregaGrid();
            CarregaComboProjeto();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var param = new PessoaDTO();

            if (cmbSearchType.SelectedItem.ToString() == "Nome do Aluno")
            {
                param.nomePessoa = txtSearch.Text;
            }
            else if (cmbSearchType.SelectedItem.ToString() == "Código do Aluno")
            {
                if (txtSearch.Text != string.Empty)
                    param.idPessoa = Convert.ToInt32(txtSearch.Text);
            }

            List<PessoaDTO> lista = new PessoaBLL().GetDataWithParam(param);

            GridViewDataBind(lista);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ClearForm1();

            List<PessoaDTO> lista = new PessoaBLL().GetPessoasPorTipo(TipoPessoa.Beneficiário);

            GridViewDataBind(lista);
        }

        #endregion

        #region Methods

        public void CarregaGrid()
        {
            List<PessoaDTO> lista = new PessoaBLL().GetAllData();

            GridViewDataBind(lista);
        }

        public void CarregaComboProjeto()
        {
            /*
            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(true);

            cmbProjeto.DisplayMember = "nomeProjeto";
            cmbProjeto.ValueMember = "idProjeto";
            cmbProjeto.DataSource = lista;
            */
        }

        public void CarregaDetalhes(int idTurma)
        {
            /*
            panelEdit.Visible = true;
            panelConsulta.Visible = false;

            TurmaDTO param = new TurmaDTO();
            param.idTurma = idTurma;

            param = new TurmaBLL().GetByID(param);

            // ************************************************** //
            // Preenche Tela de Detalhes
            // ************************************************** //
            lblCodigo.Text = param.idTurma.ToString();
            cmbProjeto.SelectedValue = param.idProjeto;

            if (cmbProjeto.SelectedValue == null)
            {
                List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(true);

                lista.Add(new ProjetoDTO() { idProjeto = param.idProjeto, nomeProjeto = param.nomeProjeto });
                cmbProjeto.DataSource = lista;
            }

            txtNome.Text = param.nomeTurma;
            cmbStatus.SelectedIndex = (param.flagAtivo) ? 1 : 0;

            cmbPeriodo.Text = param.descricaoPeriodo;

            cmbHoraInicio.Text = param.horaInicio.Split(':')[0];
            cmbMinutoInicio.Text = param.horaInicio.Split(':')[1];
            cmbHoraFim.Text = param.horaTermino.Split(':')[0];
            cmbMinutoFim.Text = param.horaTermino.Split(':')[1];

            txtDescricao.Text = param.descricaoTurma;
            txtDataCadastro.Text = param.dataCadastro.ToShortDateString();
            txtDataAlteracao.Text = param.dataUltAlteracao.ToShortDateString();
            txtNomeAlteracao.Text = param.nomePessoaUltAlteracao;
            */

            ControlFormEdit(false);
        }

        public void ClearForm1()
        {
            cmbSearchType.SelectedIndex = 0;
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

            txtDuracao.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtNomeAlteracao.Text = string.Empty;
            txtDataCadastro.Text = string.Empty;
            txtResponsavel.Text = string.Empty;
            cmbStatus.SelectedIndex = 1;
        }

        #endregion

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
            /*
            this.dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            */

            /*            


            // Configure the DataGridView so that users can manually change 
            // only the column widths, which are set to fill mode. 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            */

            // ***************************************************************** //
            //  SET COLUMNS IN GRIDVIEW
            // ***************************************************************** //

            var fields = new GridViewControl().GetFields(new PessoaDTO());

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

        public void GridViewDataBind(List<PessoaDTO> result)
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
                e.Value = ProjetoSomarUI.Properties.Resources.icon_search24x24;

                /*
                if (this.dataGridView1["c2", e.RowIndex].Value != null)
                {
                    string s = this.dataGridView1["c2", e.RowIndex].Value.ToString();

                    switch (s)
                    {
                        case "Laptop":
                            e.Value = Image.FromFile(@"c:\test\Laptop.gif");
                            break;
                        case "Desktop":
                            e.Value = Image.FromFile(@"c:\test\Desktop.gif");
                            break;
                    }

                }
                */
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int idPessoa = Convert.ToInt32(this.dataGridView1[1, e.RowIndex].Value);

                CarregaDetalhes(idPessoa);

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

        #endregion

        #region EditMode

        public void ControlFormEdit(bool flagEnable)
        {
            /*
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
            txtResponsavel.Enabled = flagEnable;
            cmbStatus.Enabled = flagEnable;
            txtNomeAlteracao.Enabled = false;
            txtDataAlteracao.Enabled = false;
            txtDataCadastro.Enabled = false;

            txtNome.BackColor = Color.WhiteSmoke;
            cmbPeriodo.BackColor = Color.WhiteSmoke;
            cmbHoraInicio.BackColor = Color.WhiteSmoke;
            cmbHoraFim.BackColor = Color.WhiteSmoke;
            cmbMinutoInicio.BackColor = Color.WhiteSmoke;
            cmbMinutoFim.BackColor = Color.WhiteSmoke;
            txtDescricao.BackColor = Color.WhiteSmoke;
            txtDataCadastro.BackColor = Color.WhiteSmoke;
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
            */
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(txtEditMode.Text))
                ControlFormEdit(false);
            else
                ControlFormEdit(true);
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
            /*
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
            */
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

        #endregion
    }
}
