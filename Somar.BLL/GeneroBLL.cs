using Somar.DAL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.BLL
{
    public class GeneroBLL
    {
        public List<GeneroDTO> GetAllData()
        {
            GeneroDAL cmd = new GeneroDAL();
            return cmd.GetDataInDataBase(new GeneroDTO());
        }
    }
}
