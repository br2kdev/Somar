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

namespace ProjetoSomarUI.Cadastros
{
    public partial class FormProjetos : Form
    {
        public FormProjetos()
        {
            InitializeComponent();

            SetGridView();
            ClearForm1();
        }

        #region Events

        private void FormProjetos_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

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

            GridViewDataBind(lista);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
            panelConsulta.Visible = true;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ClearForm1();

            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData();

            GridViewDataBind(lista);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnEditar.Visible = false;
            panelEdit.Visible = true;
            panelConsulta.Visible = false;

            ClearForm2();
            ControlFormEdit(true);

            btnVoltar.Visible = true;
            btnVoltar.Text = "Voltar";
        }

        #endregion

        #region Methods

        public void CarregaGrid()
        {
            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData();

            GridViewDataBind(lista);
        }

        public void DetalhesProjeto(int idProjeto)
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
            txtDataInicio.Text = param.dataInicio.ToShortDateString();
            txtDataInicio.Text = param.dataTermino.ToShortDateString();
            txtDescricao.Text = param.descricaoProjeto;
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
            lblCodigo.Text = "";
            txtNome.Text = "";
            txtDataInicio.Text = "";
            txtDataInicio.Text = "";
            txtDuracao.Text = "";
            txtDescricao.Text = "";
            txtDataCadastro.Text = "";
            txtResponsavel.Text = "";
            cmbStatus.SelectedIndex = 1;
        }

        #endregion

        #region Controls

        #region Gridview Controls

        private void InitializeDataGridView()
        {
            /*
            // Add columns to the DataGridView, binding them to the
            // specified DataGridViewColumn properties.
            AddReadOnlyColumn("HeaderText", "Column");
            AddColumn("AutoSizeMode");
            AddColumn("FillWeight");
            AddColumn("MinimumWidth");
            AddColumn("Width");

            // Bind the DataGridView to its own Columns collection.
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dataGridView1.Columns;

            // Configure the DataGridView so that users can manually change 
            // only the column widths, which are set to fill mode. 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configure the top left header cell as a reset button.
            dataGridView1.TopLeftHeaderCell.Value = "reset";
            dataGridView1.TopLeftHeaderCell.Style.ForeColor = System.Drawing.Color.Blue;

            // Add handlers to DataGridView events.
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGridView1_ColumnWidthChanged);
            dataGridView1.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);
            dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
            dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            */
        }

        public void SetGridView()
        {
            // ***************************************************************** //
            //  SET CUSTOM STYLE IN GRIDVIEW
            // ***************************************************************** //
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.AutoResizeColumn.

            /*            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.AutoSize = true;

            // Configure the DataGridView so that users can manually change 
            // only the column widths, which are set to fill mode. 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            */

            // ***************************************************************** //
            //  SET COLUMNS IN GRIDVIEW
            // ***************************************************************** //

            var fields = new GridViewControl().GetFields(new ProjetoDTO());

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
                dataGridView1.Columns.Add(dt);
            }

            // -------------------------------------------------------------

            this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            this.dataGridView1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellMouseLeave);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellMouseEnter);

            // ***************************************************************** //
        }

        public void GridViewDataBind(List<ProjetoDTO> result)
        {
            if (result.Count == 0)
            {
                dataGridView1.Visible = false;
                panelMessage.Visible = true;
                lblMessage.Text = "Nenhum projeto encontrado";
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
                e.Value = ProjetoSomarUI.Properties.Resources.icon_search;

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
                int idProjeto = Convert.ToInt32(this.dataGridView1[1, e.RowIndex].Value);

                DetalhesProjeto(idProjeto);

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

            btnVoltar.Text = "Voltar";

            txtNome.Enabled = flagEnable;
            txtDataInicio.Enabled = flagEnable;
            txtDataTermino.Enabled = flagEnable;
            txtDescricao.Enabled = flagEnable;
            txtDuracao.Enabled = flagEnable;
            txtResponsavel.Enabled = flagEnable;
            txtNomeAlteracao.Enabled = false;
            txtDataAlteracao.Enabled = false;
            txtDataCadastro.Enabled = false;

            txtNome.BackColor = Color.WhiteSmoke;
            txtDataInicio.BackColor = Color.WhiteSmoke;
            txtDataTermino.BackColor = Color.WhiteSmoke;
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
             txtDataTermino.Text = retorno.DataTermino.ToString("dd/MM/yyyy");
             txtDuracao.Text = Convert.ToString(retorno.Duracao);
             txtDescricao.Text = retorno.Descricao;
             txtDataCadastro.Text = retorno.DataCadastro.ToString("dd/MM/yyyy");
             txtResponsavel.Text = Convert.ToString(retorno.ResponsavelPessoaId);
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
            panelEdit.Visible = false;
            panelConsulta.Visible = true;
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
            param.dataInicio = Convert.ToDateTime(txtDataInicio.Text);
            param.dataTermino = Convert.ToDateTime(txtDataTermino.Text);
            param.descricaoProjeto = txtDescricao.Text;
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
    }
}