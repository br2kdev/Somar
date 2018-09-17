using Somar.BLL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoSomarUI.Administracao
{
    public partial class FormAlterarSenha : FormBase
    {
        public FormAlterarSenha()
        {
            InitializeComponent();

            Load += new EventHandler(FormAlterarSenha_Load);
        }

        private void FormAlterarSenha_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = Sessao.Usuario.login;

            txtUsuario.Enabled = false;

        }

        private void btnVoltar_Click(object sender, EventArgs e)
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
