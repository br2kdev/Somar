using System;
using System.ComponentModel;

namespace Somar.DTO.Models
{
    public class ModelListaPresenca
    {
        [DisplayName("Código")]
        public int idFrequenciaAluno { get; set; }

        [DisplayName("Data da Aula")]
        public DateTime dataFrequencia { get; set; }

        [DisplayName("Aluno")]
        public string nomePessoa { get; set; }

    }
}
