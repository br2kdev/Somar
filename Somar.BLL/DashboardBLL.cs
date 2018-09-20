using Somar.DAL;
using Somar.DTO;
using Somar.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.BLL
{
    public class DashboardBLL
    {
        public List<DashboardDTO> GetDashboard(Dashboard _report)
        {
            List<DashboardDTO> result = new List<DashboardDTO>();

            DashboardDAL cmd = new DashboardDAL();

            switch (_report)
            {
                case Dashboard.AlunosPorEscola:
                    result = cmd.GetAlunosPorEscola();
                    break;
                case Dashboard.AlunosPorBairro:
                    result = cmd.GetAlunosPorBairro();
                    break;
                case Dashboard.AlunosPorProjeto:
                    result = cmd.GetAlunosPorProjeto();
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
