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
    public partial class FormAlterarSenha : Form
    {
        public FormAlterarSenha()
        {
            InitializeComponent();
            ControlFormEdit(true);
        }

        public void ControlFormEdit(bool flagEnable)
        {
            txtEditMode.Text = flagEnable.ToString();

            btnVoltar1.Text = "Voltar";
            txtSenha.Enabled = flagEnable;

            //Footer
            txtNomeAlteracao.Enabled = false;
            txtDataAlteracao.Enabled = false;
            txtDataCadastro.Enabled = false;

            txtSenha.BackColor = Color.WhiteSmoke;
            txtDataCadastro.BackColor = Color.WhiteSmoke;
            txtNomeAlteracao.BackColor = Color.WhiteSmoke;
            txtDataAlteracao.BackColor = Color.WhiteSmoke;

            if (flagEnable)
            {
                btnGravar.Visible = true;
                btnVoltar1.Visible = true;
                txtSenha.Focus();

            }
            else
            {
                btnGravar.Visible = false;
            }
        }


        private void btnVoltar1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            UsuarioDTO param = new UsuarioDTO();


            if (txtSenha.Text == txtConfirmarSenha.Text)
            {
                param.idUsuario = Sessao.Usuario.idUsuario;
                param.senha = txtSenha.Text;
                param.idPessoaUltAlteracao = Sessao.Usuario.idUsuario;
            }
            else
            {
                MessageBox.Show("As senhas informaras não conferem!");
                return;
            }

            UsuarioBLL bus = new UsuarioBLL();
            var retorno = bus.UpdatePassword(param);

            if (retorno > 0)
            {
                MessageBox.Show("Senha alterada com sucesso!");

            }
            else
                throw new Exception("Erro na alteração da senha");

        }



    }
}
