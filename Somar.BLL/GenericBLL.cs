using Somar.DAL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.BLL
{
    public class GenericBLL
    {
        public List<GenericDTO> GetAllData(GenericDTO generic)
        {
            GenericDAL cmd = new GenericDAL();
            return cmd.GetAllGeneric(generic);
        }
    }
}
