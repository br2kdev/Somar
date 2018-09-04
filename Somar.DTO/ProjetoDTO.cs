using System;
using System.ComponentModel;

namespace Somar.DTO
{
    public partial class ProjetoDTO
    {
        [DisplayName("Código")]
        public int idProjeto { get; set; }

        [DisplayName("Nome do Projeto")]
        public string nomeProjeto { get; set; }

        public string descricaoProjeto { get; set; }

        [DisplayName("Data de Início")]
        public DateTime? dtInicio { get; set; }

        [DisplayName("Data de Término")]
        public DateTime? dtTermino { get; set; }

        public int idPessoaResposavel { get; set; }

        [DisplayName("Responsável")]
        public string nomeResposavel { get; set; }

        public DateTime dtCadastro { get; set; }

        public bool flagAtivo { get; set; }

        [DisplayName("Status")]
        public string descricaoAtivo { get; set; }

        public DateTime dtUltAlteracao { get; set; }

        public int idPessoaUltAlteracao { get; set; }

        public string nomePessoaUltAlteracao { get; set; }
    }
}
