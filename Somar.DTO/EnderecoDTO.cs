using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DTO
{
    public class EnderecoDTO
    {
        public int idEndereco { get; set; }

        public string CEP { get; set; }

        public string logradouro { get; set; }

        public string complemento { get; set; }

        public string numero { get; set; }

        public int idBairro { get; set; }

        public string nomeBairro { get; set; }

        public int idCidade { get; set; }

        public string nomeCidade { get; set; }

        public string siglaUF { get; set; }

        public int idPessoa { get; set; }
    }
}
