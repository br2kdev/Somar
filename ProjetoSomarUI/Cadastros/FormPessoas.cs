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

            btnSearchCEP.Click += new EventHandler(btnSearchCEP_Click);

            //txtCEP.LostFocus += new EventHandler(txtCEP_LostFocus);
            txtCEP.Enter += new EventHandler(txtCEP_Focus);
            txtCEP.Click += new EventHandler(txtCEP_Focus);

            #endregion

            Load += new EventHandler(FormPessoas_Load);

            //txtDataInicio.CustomFormat = txtDataNascimento.CustomFormat = "HH:mm";
            //txtDataInicio.ShowUpDown = txtDataNascimento.ShowUpDown = true;

            InitializeGridView();

            ClearForm1();
        }

        private void txtCEP_Focus(object sender, EventArgs e)
        {
            var cep = txtCEP.Text.Replace("-", "").Trim();

            if (cep == string.Empty)
                txtCEP.Select(0, 0);
            else
                txtCEP.SelectionStart = cep.Length + 1;
        }

        private void txtCEP_LostFocus(object sender, EventArgs e)
        {
            txtCEP.SelectionStart = txtCEP.Text.Length + 1;
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

        private void btnSearchCEP_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCEP.Text))
            {
                LimpaEndereco();

                var param = new EnderecoDTO();
                param.CEP = txtCEP.Text.Replace("-", "");

                EnderecoDTO itemCEP = new EnderecoBLL().GetCEP(param);

                CarregaEndereco(itemCEP, true);
            }
        }

        #endregion

        #region Methods

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

        public void LimpaContatos()
        {
            txtNomePai.Text = string.Empty;
            txtNomeMae.Text = string.Empty;
            txtTelefone1.Text = string.Empty;
            txtTelefone2.Text = string.Empty;
            txtTelefone3.Text = string.Empty;
            txtNomeContato1.Text = string.Empty;
            txtNomeContato2.Text = string.Empty;
            txtNomeContato3.Text = string.Empty;
        }

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
            txtIdEndereco.Text = param.idEndereco.ToString();

            if (param.dataNascimento != null)
                txtIdade.Text = new Functions().CalcularIdade(param.dataNascimento).ToString();

            cmbGenero.SelectedValue = param.idGenero;
            cmbStatus.SelectedIndex = (param.flagAtivo) ? 1 : 0;

            // ************************************************** //
            // Preenche Tela de Detalhes
            // ************************************************** //
            CarregaEndereco(param.endereco, false);
            CarregaContatos(param.contatos);

            txtNomeAlteracao.Text = param.nomePessoaUltAlteracao;
            txtDataCadastro.Text = param.dataCadastro.ToShortDateString();
            txtDataAlteracao.Text = param.dataUltAlteracao.ToShortDateString();

            ControlFormEdit(false);
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
                txtIdContato.Text = string.Empty;
                LimpaEndereco();
                txtLogradouro.Focus();
            }
        }

        public void CarregaContatos(ContatoDTO item)
        {
            if (item != null)
            {
                txtNomePai.Text = item.nomePai;
                txtNomeMae.Text = item.nomeMae;
                txtTelefone1.Text = item.telefone1;
                txtTelefone2.Text = item.telefone2;
                txtTelefone3.Text = item.telefone3;
                txtNomeContato1.Text = item.contato1;
                txtNomeContato2.Text = item.contato2;
                txtNomeContato3.Text = item.contato3;
            }
            else
            {
                txtIdContato.Text = string.Empty;
                LimpaContatos();
            }
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

            txtCEP.Text = string.Empty;
            txtIdEndereco.Text = string.Empty;
            txtIdContato.Text = string.Empty;

            LimpaEndereco();
            LimpaContatos();

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
            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtComplemento.Enabled = false;
            txtUF.Enabled = false;

            //Contatos
            txtNomePai.Enabled = flagEnable;
            txtNomeMae.Enabled = flagEnable;
            txtTelefone1.Enabled = flagEnable;
            txtTelefone2.Enabled = flagEnable;
            txtTelefone3.Enabled = flagEnable;
            txtNomeContato1.Enabled = flagEnable;
            txtNomeContato2.Enabled = flagEnable;
            txtNomeContato3.Enabled = flagEnable;

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

            param.idEndereco = string.IsNullOrEmpty(txtIdEndereco.Text) ? 0 : Convert.ToInt32(txtIdEndereco.Text);
            param.idContato = string.IsNullOrEmpty(txtIdContato.Text) ? 0 : Convert.ToInt32(txtIdContato.Text);

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

            // *********************************************
            // CONTATO
            // *********************************************
            param.contatos = new ContatoDTO();
            param.contatos.nomePai = txtNomePai.Text;
            param.contatos.nomeMae = txtNomeMae.Text;
            param.contatos.telefone1 = txtTelefone1.Text;
            param.contatos.telefone2 = txtTelefone2.Text;
            param.contatos.telefone3 = txtTelefone3.Text;
            param.contatos.contato1 = txtNomeContato1.Text;
            param.contatos.contato2 = txtNomeContato2.Text;
            param.contatos.contato3 = txtNomeContato3.Text;

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
