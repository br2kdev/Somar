using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DTO.Models
{
    public partial class ModelFrequencia
    {
        [DisplayName("Código")]
        public int idFrequencia { get; set; }

        [DisplayName("Data da Aula")]
        public DateTime dataFrequencia { get; set; }

        [DisplayName("Nome da Turma")]
        public string nomeTurma { get; set; }

        [DisplayName("Nome do Projeto")]
        public string nomeProjeto { get; set; }
    }
}
