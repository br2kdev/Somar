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
        private string gridMessage = "Nenhuma matrícula encontrada!";
        private string gridMessage2 = "Aluno ainda não possuí matricula!";
        
        delegate void UserControlMethod(int idMatricula);

        public FormMatricula()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            InitializeComponent();

            ClearForm1();

            #region ComboLists

            cmbTipoPessoa.SelectedIndexChanged += new EventHandler(cmbTipoPessoa_SelectedIndexChanged);
            cmbProjeto.SelectedIndexChanged += new EventHandler(cmbProjeto_SelectedIndexChanged);

            #endregion

            #region Button Events

            btnNovo.Visible = false;

            btnNovo.Click += new EventHandler(btnNew_Click);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnAll.Click += new EventHandler(btnAll_Click);

            btnVoltar1.Click += new EventHandler(btnVoltar_Click);
            btnGravar.Click += new EventHandler(btnGravar_Click);
            btnDetalhes.Click += new EventHandler(btnDetalhes_Click);

            #endregion

            Load += new EventHandler(FormMatricula_Load);

            //Grid 1
            Grid2.ImgButton1 = ProjetoSomarUI.Properties.Resources.icon_cancel24x24;
            Grid.CallingMethod1 = new UserControlMethod(CarregaDetalhes);
            Grid.InitializeGridView(new ModelMatricula());
            

            //Grid 2
            Grid2.EnableClickButton2 = true;
            Grid2.ImgButton2 = ProjetoSomarUI.Properties.Resources.icon_delete24x24;
            Grid2.CallingMethod1 = new UserControlMethod(btnCancelarMatricula);
            Grid2.CallingMethod2 = new UserControlMethod(btnExcluirMatricula);
            Grid2.InitializeGridView(new MatriculaDTO());
        }

        private void FormMatricula_Load(object sender, EventArgs e)
        {
            CarregaComboProjeto();
            CarregaComboTipoPessoa();
        }

        #region Methods

        public void CarregaGrid()
        {
            var _idTipoPessoa = Convert.ToInt32(cmbTipoPessoa.SelectedValue);

            List<MatriculaDTO> lista = new MatriculaBLL().GetSituacaoAluno(new MatriculaDTO() { idTipoPessoa = _idTipoPessoa });

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
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
            this.ControlBox = false;

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

            Grid2.GridViewDataBind(listMatr.ToDataTable(), gridMessage2);
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

        #region EditMode

        private void btnCancelarMatricula(int _idMatricula)
        {
            if (MessageBox.Show("Deseja realmente cancelar a matricula?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = 0;

                var item = new MatriculaDTO()
                {
                    idMatricula = _idMatricula,
                    idPessoaUltAlteracao = Sessao.Usuario.idUsuario
                };

                result = new MatriculaBLL().CancelarMatricula(item);
                MessageBox.Show("Matricula cancelada com sucesso", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int _idPessoa = Convert.ToInt32(lblCodigo.Text);

                CarregaDetalhes(_idPessoa);
            }
        }

        private void btnExcluirMatricula(int _idMatricula)
        {

            if (MessageBox.Show("Deseja realmente excluir a matricula?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = 0;

                var item = new MatriculaDTO()
                {
                    idMatricula = _idMatricula,
                    idPessoaUltAlteracao = Sessao.Usuario.idUsuario
                };

                result = new MatriculaBLL().ExcluirMatricula(item);
                MessageBox.Show("Matricula excluída com sucesso", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int _idPessoa = Convert.ToInt32(lblCodigo.Text);

                CarregaDetalhes(_idPessoa);
            }
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            int idPessoa = 0;

            try
            {
                idPessoa = Convert.ToInt32(lblCodigo.Text);

                Cadastros.FormPessoas from = new FormPessoas(idPessoa);
                from.ShowDialog();
            }
            catch(Exception)
            {

            }
        }

        #endregion

        #region Buttons 

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

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ClearForm1();

            cmbTipoPessoa.SelectedValue = 1;

            List<MatriculaDTO> lista = new MatriculaBLL().GetSituacaoAluno(new MatriculaDTO() { idTipoPessoa = Convert.ToInt32(TipoPessoa.Beneficiário) });

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = true;
            panelConsulta.Visible = false;
            this.ControlBox = false;

            ClearForm2();

            btnVoltar1.Visible = true;
            btnVoltar1.Text = "Voltar";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
            panelConsulta.Visible = true;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            panelConsulta.Visible = true;
            panelEdit.Visible = false;
            this.ControlBox = true;
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
