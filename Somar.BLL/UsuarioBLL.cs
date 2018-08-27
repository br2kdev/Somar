using Somar.DAL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.BLL
{
    public class UsuarioBLL
    {
        public List<UsuarioDTO> GetAllData(bool onlyActive)
        {
            UsuarioDAL cmd = new UsuarioDAL();
            return cmd.GetDataInDataBase(new UsuarioDTO() { flagAtivo = onlyActive });
        }

        public List<UsuarioDTO> GetDataWithParam(UsuarioDTO _projeto)
        {
            UsuarioDAL cmd = new UsuarioDAL();
            return cmd.GetDataInDataBase(_projeto);
        }

        public UsuarioDTO GetByID(UsuarioDTO _projeto)
        {
            UsuarioDAL cmd = new UsuarioDAL();

            var result = cmd.GetDataInDataBase(_projeto);

            if (result.Count == 1)
                return result.SingleOrDefault();
            else
                throw new Exception("Erro de Gravação do Projeto");
        }

        public UsuarioDTO GetUserByLogin(string user, string pass)
        {
            UsuarioDAL cmd = new UsuarioDAL();

            UsuarioDTO _item = new UsuarioDTO(){ login = user, senha = pass };

            var result = cmd.GetUserByLogin(_item);

            if (result.Count == 1)
                return result.SingleOrDefault();
            else
                return null;
        }

        public int SaveProject(UsuarioDTO _projeto)
        {
            UsuarioDAL cmd = new UsuarioDAL();

            int result = 0;

            if (_projeto.idUsuario == 0)
                result = cmd.InsertData(_projeto);
            else
            {
                result = cmd.UpdateData(_projeto);

                if (result != 0)
                {
                    return _projeto.idUsuario;
                }
            }

            return result;
        }

        public int RemoveProject(UsuarioDTO _projeto)
        {
            UsuarioDAL cmd = new UsuarioDAL();

            return cmd.UpdateData(_projeto);
        }
    }
}
