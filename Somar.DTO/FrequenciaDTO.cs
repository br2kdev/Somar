using System;

namespace Somar.DTO
{
    public partial class FrequenciaDTO
    {
        public int idFrequencia { get; set; }

        public int idFrequenciaAluno { get; set; }

        public int idPessoa { get; set; }

        public string nomePessoa { get; set; }

        public int idProjeto { get; set; }

        public int idTurma { get; set; }

        public int idDisciplina { get; set; }

        public string nomeProjeto { get; set; }

        public string nomeTurma { get; set; }

        public string nomeResponsavel { get; set; }

        public bool flagPresenca { get; set; }

        public DateTime dtCadastro { get; set; }

        public DateTime dtFrequencia { get; set; }

        public DateTime dtUltAlteracao { get; set; }

        public int idPessoaUltAlteracao { get; set; }

        public string nomePessoaUltAlteracao { get; set; }
    }
}
