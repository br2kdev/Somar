using Somar.DAL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.BLL
{
    public class PerfilBLL
    {
        public List<PerfilDTO> GetAllData()
        {
            PerfilDAL cmd = new PerfilDAL();
            return cmd.GetDataInDataBase(new PerfilDTO());
        }
    }
}
