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
        public List<ProjetoDTO> GetAllData()
        {
            ProjetoDAL cmd = new ProjetoDAL();
            return cmd.GetDataInDataBase(new ProjetoDTO());
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

        public bool SaveNewProject(ProjetoDTO _projeto)
        {
            ProjetoDAL cmd = new ProjetoDAL();

            return cmd.SaveDataInDataBase(_projeto);
        }

        public bool EditProject(ProjetoDTO _projeto)
        {
            ProjetoDAL cmd = new ProjetoDAL();

            return cmd.SaveDataInDataBase(_projeto);
        }
    }
}
