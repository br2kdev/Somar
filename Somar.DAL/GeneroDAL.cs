using Somar.DAL.Repository;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DAL
{
    public class GeneroDAL
    {
        public List<GeneroDTO> GetDataInDataBase(GeneroDTO objectDTO)
        {
            RepList<GeneroDTO> listGenero = new RepList<GeneroDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += "SELECT * ";
            query += "FROM TB_Genero A ";
            query += whereClause;

            return listGenero.GetDataInDatabase(query);
        }
    }
}
