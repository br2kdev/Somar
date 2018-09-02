using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DTO
{
    public partial class MatriculaDTO
    {
        [DisplayName("Código")]
        public int idMatricula { get; set; }

        public int idPessoa { get; set; }

        public string nomePessoa { get; set; }

        public int idProjeto { get; set; }

        [DisplayName("Nome do Projeto")]
        public string nomeProjeto { get; set; }

        public int idTurma { get; set; }

        [DisplayName("Nome da Turma")]
        public string nomeTurma { get; set; }

        [DisplayName("Data de Matricula")]
        public DateTime? dataMatricula { get; set; }

        [DisplayName("Data de Cancelamento")]
        public DateTime? dataCancelamento { get; set; }

        public DateTime dataUltAlteracao { get; set; }

        public int idPessoaUltAlteracao { get; set; }

        public string nomePessoaUltAlteracao { get; set; }
    }
}
