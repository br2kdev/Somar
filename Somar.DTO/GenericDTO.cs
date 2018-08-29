using Somar.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DTO
{
    public partial class GenericDTO
    {
        [DisplayName("Código")]
        public int idGeneric { get; set; }

        public string descGeneric { get; set; }

        public bool? flagAtivo { get; set; }

        public domains dominio { get; set; }
    }
}
