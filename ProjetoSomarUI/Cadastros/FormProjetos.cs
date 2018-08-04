using Somar.BLL;
using Somar.DTO;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoSomarUI.Cadastros
{
    public partial class FormProjetos : Form
    {
        public FormProjetos()
        {
            InitializeComponent();

        }

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

            /*
            using (IRepositorio<Projeto> context = new Repositorio<Projeto>())
            {

                var lista = from p in context.GetAll()
                            select p;
            }
            /
            /*
            using (var ctxProjetos = new ProjetoDAL())
            {
                new List<Projeto>
                {
                    new Projeto { Nome="Microsoft", Ativo=true, CNPJ="9394.4343/0001-55", Endereco="1, Microsoft One", Telefone="11574739494"},
                    new Projeto { Nome="Google", Ativo=true, CNPJ="1234.9494/0001-33", Endereco="12, Santa Clara, CA", Telefone="1185858483"},
                    new Projeto { Nome="Oracle", Ativo=true, CNPJ="9876.4433/0002-44", Endereco="54, Santa Monica", Telefone="4884848592"}
                }.ForEach(ctxProjetos.Adicionar);

                ctxProjetos.SalvarTodos();

                System.Console.WriteLine("Clientes adicionadas com sucesso.");

                System.Console.WriteLine("=======  clientes cadastrados ===========");
                

                System.Console.ReadKey();
            }
            */
        }

        private void FormProjetos_Load(object sender, EventArgs e)
        {
            //lblDados.Visible = false;
            tabDadosCadastro.Visible = false;

            cblTipoPesquisa.Items.Add("Codigo");
            cblTipoPesquisa.Items.Add("Nome");
            cblTipoPesquisa.SelectedIndex = 0;

            cblTipoPesquisa.SelectedIndex = 0;

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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tabDadosCadastro.Visible = true;
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
            tabDadosCadastro.Visible = false;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

    




