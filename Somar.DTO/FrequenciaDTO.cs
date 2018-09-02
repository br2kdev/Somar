using System;

namespace Somar.DTO
{
    public partial class FrequenciaDTO
    {
        public int idFrequencia { get; set; }

        public int idProjeto { get; set; }

        public int idTurma { get; set; }

        public int idDisciplina { get; set; }
        
        public string nomeProjeto { get; set; }

        public string nomeTurma { get; set; }

        public string nomeResponsavel { get; set; }

        public DateTime dataCadastro { get; set; }

        public DateTime dataFrequencia { get; set; }

        public DateTime dataUltAlteracao { get; set; }

        public int idPessoaUltAlteracao { get; set; }

        public string nomePessoaUltAlteracao { get; set; }
    }
}
