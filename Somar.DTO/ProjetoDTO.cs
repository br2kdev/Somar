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
        public DateTime dataInicio { get; set; }

        [DisplayName("Data de Término")]
        public DateTime dataTermino { get; set; }

        public int idPessoaResposavel { get; set; }

        [DisplayName("Responsável")]
        public int nomeResposavel { get; set; }

        public DateTime dataCadastro { get; set; }

        [DisplayName("Ativo")]
        public bool flagAtivo { get; set; }

        public DateTime dataUltAlteracao { get; set; }

        public int idPessoaUltAlteracao { get; set; }
    }
}
