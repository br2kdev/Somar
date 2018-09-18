using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.Shared
{
    public enum domains
    {
        Perfil,
        TipoPessoa,
        Genero
    };

    public enum TipoPessoa
    {
        Todos = 0,
        Beneficiário = 1,
        Educador = 2,
        Funcionário = 3,
        Professor = 4,
        Voluntário = 5
    };

    public enum Relatorio
    {
        Projetos = 0,
        Turmas = 1,
        Dashboard = 2,
    };
}
