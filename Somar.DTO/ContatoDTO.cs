using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DTO
{
    public partial class ContatoDTO
    {
        public int idContato { get; set; }

        public int idPai { get; set; }

        public string nomePai { get; set; }

        public int idMae { get; set; }

        public string nomeMae { get; set; }

        public string telefone1 { get; set; }

        public string telefone2 { get; set; }

        public string telefone3 { get; set; }

        public string contato1 { get; set; }

        public string contato2 { get; set; }

        public string contato3 { get; set; }

    }
}
