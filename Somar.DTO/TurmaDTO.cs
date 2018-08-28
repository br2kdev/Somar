using System;
using System.ComponentModel;

namespace Somar.DTO
{
    public partial class TurmaDTO
    {
        [DisplayName("Código")]
        public int idTurma { get; set; }

        [DisplayName("Nome da Turma")]
        public string nomeTurma { get; set; }

        public string descricaoTurma { get; set; }

        [DisplayName("Período")]
        public string descricaoPeriodo { get; set; }

        [DisplayName("Horário")]
        public string horario { get; set; }

        public string horaInicio { get; set; }

        public string horaTermino { get; set; }

        public int idPessoaEducador { get; set; }

        [DisplayName("Educador")]
        public int nomeEducador { get; set; }

        public DateTime dataCadastro { get; set; }

        public bool flagAtivo { get; set; }

        [DisplayName("Status")]
        public string descricaoAtivo { get; set; }

        public DateTime dataUltAlteracao { get; set; }

        public int idPessoaUltAlteracao { get; set; }

        public string nomePessoaUltAlteracao { get; set; }

        public int idProjeto { get; set; }

        [DisplayName("Projeto")]
        public string nomeProjeto { get; set; }
    }
}
