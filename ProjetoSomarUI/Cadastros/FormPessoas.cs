using Somar.BLL;
using Somar.DTO;
using Somar.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoSomarUI.Cadastros
{
    public partial class FormPessoas : Form
    {
        public FormPessoas()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            #region ComboLists

            cmbSearchType.Items.Add("Nome da Pessoa");
            cmbSearchType.Items.Add("Código da Pessoa");

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

            //txtCEP.LostFocus += new EventHandler(txtCEP_LostFocus);

            #endregion

            Load += new EventHandler(FormPessoas_Load);

            //txtDataInicio.CustomFormat = txtDataNascimento.CustomFormat = "HH:mm";
            //txtDataInicio.ShowUpDown = txtDataNascimento.ShowUpDown = true;

            InitializeGridView();

            ClearForm1();
        }

        private void FormPessoas_Load(object sender, EventArgs e)
        {
            CarregaGrid();
            CarregaComboGenero();
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

            if (cmbSearchType.SelectedItem.ToString() == "Nome da Pessoa")
            {
                param.nomePessoa = txtSearch.Text;
            }
            else if (cmbSearchType.SelectedItem.ToString() == "Código da Pessoa")
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

            List<PessoaDTO> lista = new PessoaBLL().GetAllData();

            GridViewDataBind(lista);
        }

        #endregion

        #region Methods

        public void CarregaGrid()
        {
            List<PessoaDTO> lista = new PessoaBLL().GetAllData();

            GridViewDataBind(lista);
        }

        public void CarregaComboGenero()
        {
            List<GeneroDTO> lista = new GeneroBLL().GetAllData();

            cmbGenero.DisplayMember = "nomeGenero";
            cmbGenero.ValueMember = "idGenero";
            cmbGenero.DataSource = lista;
        }

        public void CarregaDetalhes(int idPessoa)
        {
            panelEdit.Visible = true;
            panelConsulta.Visible = false;

            PessoaDTO param = new PessoaDTO();
            param.idPessoa = idPessoa;

            param = new PessoaBLL().GetByID(param);

            // ************************************************** //
            // Preenche Tela de Detalhes
            // ************************************************** //
            lblCodigo.Text = param.idPessoa.ToString();
            txtNome.Text = param.nomePessoa;
            txtRG.Text = param.numeroRG;
            txtCPF.Text = param.numeroCPF;
            txtDataAtivacao.Text = param.dataAtivacao.ToShortDateString();
            txtDataNascimento.Text = param.dataNascimento.ToShortDateString();

            if (param.dataNascimento != null)
               txtIdade.Text = new Functions().CalcularIdade(param.dataNascimento).ToString();

            cmbGenero.SelectedValue = param.idGenero;
            cmbStatus.SelectedIndex = (param.flagAtivo) ? 1 : 0;

            /*
            txtNome.Text = param.nomeTurma;
            txtDataInicio.Text = param.horaInicio.ToShortTimeString();
            txtDataNascimento.Text = param.horaTermino.ToShortTimeString();
            txtDescricao.Text = param.descricaoTurma;
            */
            txtNomeAlteracao.Text = param.nomePessoaUltAlteracao;
            txtDataCadastro.Text = param.dataCadastro.ToShortDateString();
            txtDataAlteracao.Text = param.dataUltAlteracao.ToShortDateString();
            

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
            txtRG.Text = string.Empty;
            txtCPF.Text = string.Empty;
            txtDataAtivacao.Text = string.Empty;
            txtDataNascimento.Text = string.Empty;
            cmbStatus.SelectedIndex = 1;

            /*
            txtDataNascimento.Enabled = false;
            txtDataNascimento.Format = DateTimePickerFormat.Custom;
            txtDataNascimento.CustomFormat = " ";
            */
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
            img.Width = 50;
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

        #region Combobox Controls

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        #endregion

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbSearchType.SelectedItem.ToString() == "Código da Pessoa")
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
            txtRG.Enabled = flagEnable;
            txtCPF.Enabled = flagEnable;
            txtDataNascimento.Enabled = flagEnable;
            txtIdade.Enabled = false;
            cmbGenero.Enabled = flagEnable;
            cmbStatus.Enabled = flagEnable;
            txtDataAtivacao.Enabled = flagEnable;


            //Endereço
            txtCEP.Enabled = flagEnable;

            /*
            txtLogradouro.Enabled = flagEnable;
            txtNumero.Enabled = flagEnable;
            txtBairro.Enabled = flagEnable;
            txtCidade.Enabled = flagEnable;
            txtComplemento.Enabled = flagEnable;
            txtUF.Enabled = flagEnable;
            */

            //Contatos

            //Observações
            txtDescricao.Enabled = flagEnable;


            //Footer
            txtNomeAlteracao.Enabled = false;
            txtDataAlteracao.Enabled = false;
            txtDataCadastro.Enabled = false;

            txtNome.BackColor = Color.WhiteSmoke;
            txtDataNascimento.BackColor = Color.WhiteSmoke;
            txtDescricao.BackColor = Color.WhiteSmoke;
            txtDataCadastro.BackColor = Color.WhiteSmoke;
            txtIdade.BackColor = Color.WhiteSmoke;
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

            // *********************************************
            // PESSOA
            // *********************************************
            PessoaDTO param = new PessoaDTO();

            if (lblCodigo.Text == string.Empty)
                param.idPessoa = 0;
            else
                param.idPessoa = Convert.ToInt32(lblCodigo.Text);

            param.nomePessoa = txtNome.Text;
            param.numeroRG = txtRG.Text;
            param.numeroCPF = txtCPF.Text;
            param.dataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
            param.idGenero = Convert.ToInt32(cmbGenero.SelectedValue);
            param.dataAtivacao = Convert.ToDateTime(txtDataAtivacao.Text);
            param.flagAtivo = (cmbStatus.SelectedIndex == 0) ? false : true;

            // *********************************************
            // ENDEREÇO
            // *********************************************
            /*
            param.endereco = new EnderecoDTO();
            param.endereco.CEP = txtCEP.Text;
            param.endereco.logradouro = txtLogradouro.Text;
            param.endereco.numero = txtNumero.Text;
            param.endereco.complemento = txtComplemento.Text;
            param.endereco.nomeBairro = txtBairro.Text;
            param.endereco.nomeCidade = txtCidade.Text;
            param.endereco.siglaUF = txtUF.Text;
            */
            // *********************************************
            // CONTATO
            // *********************************************
            /*
            param.contato = new EnderecoDTO();
            param.contato.CEP = txtCEP.Text;
            param.contato.logradouro = txtLogradouro.Text;
            param.contato.numero = txtNumero.Text;
            param.contato.complemento = txtComplemento.Text;
            param.contato.nomeBairro = txtBairro.Text;
            param.contato.nomeCidade = txtCidade.Text;
            param.contato.siglaUF = txtUF.Text;
            */
            /*
            param.horaInicio = Convert.ToDateTime(txtDataInicio.Text);
            param.horaTermino = Convert.ToDateTime(txtDataNascimento.Text);
            param.descricaoTurma = txtDescricao.Text;
            param.idProjeto = Convert.ToInt32(cmbProjeto.SelectedValue);
            */
            //param.idPessoaResposavel = //txtResponsavel.Text;

            PessoaBLL bus = new PessoaBLL();
            var idPessoa = bus.SaveProject(param);

            if (idPessoa > 0)
            {
                lblCodigo.Text = idPessoa.ToString();
                MessageBox.Show("Pessoa cadastrada com sucesso!");
                CarregaGrid();
            }
            else
                throw new Exception("Erro de Gravação!");

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
