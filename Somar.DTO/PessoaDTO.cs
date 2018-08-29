using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DTO
{
    public partial class PessoaDTO
    {
        [DisplayName("Código")]
        public int idPessoa { get; set; }

        [DisplayName("Nome da Pessoa")]
        public string nomePessoa { get; set; }

        public int idTipoPessoa { get; set; }

        [DisplayName("Tipo")]
        public string descTipoPessoa { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime dataNascimento { get; set; }

        public int idGenero { get; set; }

        [DisplayName("Gênero")]
        public string descGenero { get; set; }

        public string observacoes { get; set; }

        public string numeroRG { get; set; }

        public string numeroCPF { get; set; }

        public DateTime dataCadastro { get; set; }

        public DateTime dataAtivacao { get; set; }

        public bool flagAtivo { get; set; }

        [DisplayName("Status")]
        public string descricaoAtivo { get; set; }

        public DateTime dataUltAlteracao { get; set; }

        public int idPessoaUltAlteracao { get; set; }

        public string nomePessoaUltAlteracao { get; set; }

        public int idEndereco { get; set; }

        public int idContato { get; set; }

        public EnderecoDTO endereco { get; set; }

        public ContatoDTO contatos { get; set; }
    }
}
