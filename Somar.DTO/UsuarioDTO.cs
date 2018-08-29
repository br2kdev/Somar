using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DTO
{
    public partial class UsuarioDTO
    {
        [DisplayName("Código")]
        public int idUsuario { get; set; }

        [DisplayName("Nome")]
        public string nomeUsuario { get; set; }

        [DisplayName("Login")]
        public string login { get; set; }

        public string senha { get; set; }

        public int idPerfil { get; set; }

        [DisplayName("Perfil")]
        public string descPerfil { get; set; }

        [DisplayName("Data do Cadastro")]
        public DateTime dataCadastro { get; set; }

        public bool flagAtivo { get; set; }

        [DisplayName("Status")]
        public string descricaoAtivo { get; set; }

        public DateTime dataUltAlteracao { get; set; }

        public int idPessoaUltAlteracao { get; set; }
    }
}
