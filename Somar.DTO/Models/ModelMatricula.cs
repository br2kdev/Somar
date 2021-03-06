﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DTO.Models
{
    public class ModelMatricula
    {
        [DisplayName("Código")]
        public int idPessoa { get; set; }

        [DisplayName("Nome da Pessoa")]
        public string nomePessoa { get; set; }

        [DisplayName("Tipo")]
        public string descTipoPessoa { get; set; }

        [DisplayName("Situacao")]
        public string descSituacao { get; set; }

        [DisplayName("Qtde. Turmas")]
        public int qtdeMatricula { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime dtNascimento { get; set; }
    }
}
