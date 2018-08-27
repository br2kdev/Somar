using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSomarUI.Modules
{
    public static class Sessao
    {
        //usuario

        private static Int32 _usuarioId;
        private static String _nomeUsuario;
        private static String _emailUsuario;

        //get e set
        public static Int32 UsuarioId
        {
            get { return Sessao._usuarioId; }
            set { Sessao._usuarioId = value; }
        }

        public static String NomeUsuario
        {
            get { return Sessao._nomeUsuario; }
            set { Sessao._nomeUsuario = value; }
        }


        public static String EmailUsuario
        {
            get { return Sessao._emailUsuario; }
            set { Sessao._emailUsuario = value; }
        }
    }
}
