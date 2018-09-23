using Somar.DAL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.BLL
{
    public partial class DadosVariaveisBLL
    {
        public List<DadosVariaveisDTO> GetAllData()
        {
            DadosVariaveisDAL cmd = new DadosVariaveisDAL();
            return cmd.GetDataInDataBase(new DadosVariaveisDTO());
        }

        public List<DadosVariaveisDTO> GetDadosPorIdPessoa(int idPessoa)
        {
            DadosVariaveisDAL cmd = new DadosVariaveisDAL();
            return cmd.GetDadosPorIdPessoa(idPessoa);
        }
        
    }
}
