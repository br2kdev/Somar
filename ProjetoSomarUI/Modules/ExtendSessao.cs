using Somar.DTO;

namespace ProjetoSomarUI
{
    public static class Sessao
    {
        private static UsuarioDTO _usuario;

        public static UsuarioDTO Usuario
        {
            get { return Sessao._usuario; }
            set { Sessao._usuario = value; }
        }
    }
}
