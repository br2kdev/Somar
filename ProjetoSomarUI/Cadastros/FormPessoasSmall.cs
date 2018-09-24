using Somar.BLL;
using Somar.DTO;
using Somar.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoSomarUI.Cadastros
{
    public partial class FormPessoasSmall : Form
    {
        #region Variables & Delegates

        private string gridMessage = "Nenhuma responsável localizado!";

        private FormPessoas _form1;

        private string _siglaGenero;

        delegate void UserSelected(int idPessoa);

        #endregion

        public FormPessoasSmall(FormPessoas form1, string siglaGenero)
        {
            InitializeComponent();

            this._form1 = form1;
            this._siglaGenero = siglaGenero;

            InitializeForm();
        }

        private void InitializeForm()
        {
            #region ComboLists

            cmbSearchType.Items.Add("Nome da Pessoa");
            cmbSearchType.Items.Add("Código da Pessoa");

            #endregion

            #region Button Events

            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnAll.Click += new EventHandler(btnAll_Click);

            #endregion

            Load += new EventHandler(FormPessoas_Load);

            Grid.InitializeGridView(new PessoaDTO());
            ClearForm1();

            Grid.CallingMethod1 = new UserSelected(SelectedResponsavel);
        }

        private void FormPessoas_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        #region Buttons

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var param = new PessoaDTO();

            param.flagResponsavel = true;
            param.siglaGenero = _siglaGenero;

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

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ClearForm1();

            var param = new PessoaDTO();

            param.flagResponsavel = true;
            param.siglaGenero = _siglaGenero;

            List<PessoaDTO> lista = new PessoaBLL().GetDataWithParam(param);

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        #endregion

        public void CarregaGrid()
        {
            Grid.ImgButton1 = ProjetoSomarUI.Properties.Resources.icon_next24x24;

            List<PessoaDTO> lista = new PessoaBLL().GetDataWithParam(new PessoaDTO() { flagResponsavel = true, siglaGenero = _siglaGenero });

            Grid.GridViewDataBind(lista.ToDataTable(), gridMessage);
        }

        public void ClearForm1()
        {
            cmbSearchType.SelectedIndex = 0;
            txtSearch.Text = string.Empty;
        }

        public void SelectedResponsavel(int idPessoa)
        {
            _form1.SelectedResponsavel(idPessoa, _siglaGenero);

            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
