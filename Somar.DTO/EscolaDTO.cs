using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DTO
{
    public partial class EscolaDTO
    {
        [DisplayName("Código")]
        public int idEscola{ get; set; }

        [DisplayName("Nome")]
        public string nomeEscola { get; set; }

        public string observacoes { get; set; }

        [DisplayName("Data do Cadastro")]
        public DateTime dtCadastro { get; set; }

        public bool flagAtivo { get; set; }

        public int idEndereco { get; set; }

        [DisplayName("Status")]
        public string descricaoAtivo { get; set; }

        public DateTime dtUltAlteracao { get; set; }

        public int idPessoaUltAlteracao { get; set; }

        public EnderecoDTO endereco { get; set;  }
    }
}
