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
            ClearForm();
        }

        #region Events

        private void FormProjetos_Load(object sender, EventArgs e)
        {
            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(new ProjetoDTO());

            GridViewDataBind(lista);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ProjetoDTO> lista = new ProjetoBLL().GetDataWithParam(new ProjetoDTO());

            GridViewDataBind(lista);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
            panelConsulta.Visible = true;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            List<ProjetoDTO> lista = new ProjetoBLL().GetAllData(new ProjetoDTO());

            GridViewDataBind(lista);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //tabDadosCadastro.Visible = true;
            panelEdit.Visible = true;
            panelConsulta.Visible = false;
        }

        #endregion

        #region Methods

        public void ClearForm()
        {
            cmbTipoPesquisa.SelectedIndex = 0;
            txtSearch.Text = string.Empty;
        }

        #endregion

        #region Controls

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
                panelEdit.Visible = true;
                panelConsulta.Visible = false;

                // MessageBox.Show("You have selected in image in " + e.RowIndex + " row.");
                // MessageBox.Show("You have selected in image in " + this.dataGridView1[1, e.RowIndex].Value.ToString() + " row.");
            }
        }

        #endregion

        public void Consultar()
        {
            try
            {
                /*
                ProjetoBLL projetoBLL = new ProjetoBLL();

                List<Projetos> proj = projetoBLL.GetProjetos();

                dataGridView1.DataSource = proj.ToList();
                */
            }
            catch (Exception ex)
            {

            }
        }

        private void rdoAluno_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                tabDadosCadastro.Visible = false;
                ProjetoBLL projetoBLL = new ProjetoBLL();

                DataTable table = new DataTable();

                table.Columns.Add("projetoId", typeof(int));
                table.Columns.Add("Nome", typeof(string));
                table.Columns.Add("Data Inicio", typeof(DateTime));
                table.Columns.Add("Data Termino", typeof(DateTime));
                table.Columns.Add("Duração", typeof(int));
                table.Columns.Add("Descrição", typeof(string));
                table.Columns.Add("Data Cadastro", typeof(DateTime));
                table.Columns.Add("Responsavel", typeof(int));

                if (string.IsNullOrEmpty(txtTermoPesquisa.Text))
                {                   

                    List<Projetos> proj = projetoBLL.GetProjetos();
                    

                   

                    foreach (var valor in proj)
                    {   
                        table.Rows.Add(valor.ProjetoId, valor.Nome, valor.DataInicio, valor.DataTermino, valor.Duracao, valor.Descricao, valor.DataCadastro, valor.ResponsavelPessoaId);
                    }     

                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].Visible = false;
                }
                else {

                    List <Projetos> proj = projetoBLL.GetProjetosPorID(Convert.ToInt32(txtTermoPesquisa.Text)).ToList();
                    foreach (var valor in proj)
                    {

                        table.Rows.Add(valor.ProjetoId,
                                       valor.Nome,
                                       valor.DataInicio,
                                       valor.DataTermino,
                                       valor.Duracao,
                                       valor.Descricao,
                                       valor.DataCadastro,
                                       valor.ResponsavelPessoaId);


                    }


                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].Visible = false;

                }
                */
            }
            catch (Exception ex)
            {

            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            /*
            Projetos projetos = new Projetos();

            projetos.Nome = txtNome.Text;
            projetos.DataInicio = Convert.ToDateTime(txtDataInicio.Text);
            projetos.DataTermino = Convert.ToDateTime(txtDataTermino.Text);
            projetos.Duracao = Convert.ToInt32(txtDuracao.Text);
            projetos.Descricao = txtDescricao.Text;
            projetos.DataCadastro = Convert.ToDateTime(txtDataCadastro.Text);
            projetos.ResponsavelPessoaId = Convert.ToInt32(txtResponsavel.Text);

            ProjetoBLL projetoBLL = new ProjetoBLL();
            var retorno = projetoBLL.AdicionarProjeto(projetos);
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

        private void Descrição_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            //tabDadosCadastro.Visible = false;
        }

        private void Limpar()
        {
            txtNome.Text = "";
            txtDataInicio.Text = "";
            txtDataTermino.Text = "";
            txtDuracao.Text = "";
            txtDescricao.Text = "";
            txtDataCadastro.Text = "";
            txtResponsavel.Text = "";
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

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {
            MessageBox.Show(e.RowIndex.ToString() + " 1");
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString() + " 2");
        }

    }
}

    




