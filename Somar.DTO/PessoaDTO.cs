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
        public DateTime dtNascimento { get; set; }

        public int idGenero { get; set; }

        public string siglaGenero { get; set; }

        [DisplayName("Gênero")]
        public string descGenero { get; set; }

        public bool flagResponsavel { get; set; }

        public int idSituacao { get; set; }

        public string descSituacao { get; set; }

        public string observacoes { get; set; }

        public string numeroRG { get; set; }

        public string numeroCPF { get; set; }

        public DateTime dtCadastro { get; set; }

        public DateTime dtAtivacao { get; set; }

        public bool flagAtivo { get; set; }

        [DisplayName("Status")]
        public string descricaoAtivo { get; set; }

        public DateTime dtUltAlteracao { get; set; }

        public int idPessoaUltAlteracao { get; set; }

        public string nomePessoaUltAlteracao { get; set; }

        public int idEndereco { get; set; }

        public int idContato { get; set; }

        public string fotoBase64 { get; set; }

        public int idEscola { get; set; }

        public EnderecoDTO endereco { get; set; }

        public ContatoDTO contatos { get; set; }

        public List<DadosVariaveisDTO> dadosVariaveis { get; set; }
    }
}
