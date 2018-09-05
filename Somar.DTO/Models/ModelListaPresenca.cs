using System;
using System.ComponentModel;

namespace Somar.DTO.Models
{
    public class ModelListaPresenca
    {
        [DisplayName("Código")]
        public int idPessoa { get; set; }

        [DisplayName("Data da Aula")]
        public DateTime dtFrequencia { get; set; }

        [DisplayName("Aluno")]
        public string nomePessoa { get; set; }

        [DisplayName("Presença")]
        public bool flagPresenca { get; set; }

    }
}
