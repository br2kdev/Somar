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
        public List<ProjetoDTO> GetAllData(ProjetoDTO _projeto)
        {
            ProjetoDAL cmd = new ProjetoDAL();
            return cmd.GetAllData();
        }

        public List<ProjetoDTO> GetDataWithParam(ProjetoDTO _projeto)
        {
            ProjetoDAL cmd = new ProjetoDAL();
            return cmd.GetDataWithParam(_projeto);
        }

        public List<ProjetoDTO> GetByID(ProjetoDTO _projeto)
        {
            ProjetoDAL cmd = new ProjetoDAL();
            return cmd.GetAllData();
        }
    }
}
