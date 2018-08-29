using Somar.DAL.Repository;
using Somar.DTO;
using Somar.Shared;
using System.Collections.Generic;

namespace Somar.DAL
{
    public class GenericDAL
    {
        public List<GenericDTO> GetAllGeneric(GenericDTO generic)
        {
            RepList<GenericDTO> listGenero = new RepList<GenericDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += "SELECT ";

            switch (generic.dominio)
            {
                case domains.Perfil:
                    query += " idGeneric = idPerfil, descGeneric = descPerfil ";
                    query += " FROM TB_Perfis A ";
                    break;
                case domains.Genero:
                    query += " idGeneric = idGenero, descGeneric = descGenero ";
                    query += " FROM TB_Generos A ";
                    break;
                case domains.TipoPessoa:
                    query += " idGeneric = idTipoPessoa, descGeneric = descTipoPessoa ";
                    query += " FROM TB_TipoPessoas A ";
                    break;
                default:
                    break;
            }

            if (generic.flagAtivo == true)
                whereClause += " and A.flagAtivo = 1";
            else if (generic.flagAtivo == false)
                whereClause += " and A.flagAtivo = 0";

            query += whereClause;

            return listGenero.GetDataInDatabase(query);
        }
    }
}
