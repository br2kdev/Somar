using Somar.DAL.Repository;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DAL
{
    public class PerfilDAL
    {
        public List<PerfilDTO> GetDataInDataBase(PerfilDTO objectDTO)
        {
            RepList<PerfilDTO> listGenero = new RepList<PerfilDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += "SELECT * ";
            query += "FROM TB_Perfis A ";
            query += whereClause;

            return listGenero.GetDataInDatabase(query);
        }
    }
}
