using Somar.DAL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.BLL
{
    public class ProjetoBLL
    {
        public List<ProjetoDTO> GetAllData(bool onlyActive)
        {
            ProjetoDAL cmd = new ProjetoDAL();
            return cmd.GetDataInDataBase(new ProjetoDTO() { flagAtivo = onlyActive });
        }

        public List<ProjetoDTO> GetDataWithParam(ProjetoDTO _projeto)
        {
            ProjetoDAL cmd = new ProjetoDAL();
            return cmd.GetDataInDataBase(_projeto);
        }

        public ProjetoDTO GetByID(ProjetoDTO _projeto)
        {
            ProjetoDAL cmd = new ProjetoDAL();

            var result = cmd.GetDataInDataBase(_projeto);

            if (result.Count == 1)
                return result.SingleOrDefault();
            else
                throw new Exception("Erro de Gravação do Projeto");
        }

        public int SaveProject(ProjetoDTO _projeto)
        {
            ProjetoDAL cmd = new ProjetoDAL();

            int result = 0;

            if(_projeto.idProjeto == 0)
                result = cmd.InsertData(_projeto);
            else
            { 
                result = cmd.UpdateData(_projeto);

                if(result != 0)
                {
                    return _projeto.idProjeto;
                }
            }

            return result;
        }

        public int RemoveProject(ProjetoDTO _projeto)
        {
            ProjetoDAL cmd = new ProjetoDAL();

            return cmd.UpdateData(_projeto);
        }
    }
}
