using Somar.DAL.Repository;
using Somar.DTO;
using System.Collections.Generic;

namespace Somar.DAL
{
    public class EnderecoDAL
    {
        public List<EnderecoDTO> GetDataInDataBase(EnderecoDTO objectDTO)
        {
            RepList<EnderecoDTO> listProjeto = new RepList<EnderecoDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += "SELECT *, ";
            query += " descricaoAtivo = CASE WHEN flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += "FROM TB_Projetos";

            if (objectDTO.idEndereco != 0)
                whereClause += " AND idProjeto = " + objectDTO.idEndereco.ToString();

            if (objectDTO.idPessoa != 0)
                whereClause += " AND idPessoa = " + objectDTO.idPessoa.ToString();

            query += whereClause;

            return listProjeto.GetDataInDatabase(query);
        }

        public List<EnderecoDTO> GetEndereco(EnderecoDTO objectDTO)
        {
            RepList<EnderecoDTO> listProjeto = new RepList<EnderecoDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += "SELECT *, ";
            query += " descricaoAtivo = CASE WHEN flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += "FROM TB_Projetos";

            if (objectDTO.idEndereco != 0)
                whereClause += " AND idProjeto = " + objectDTO.idEndereco.ToString();

            if (objectDTO.CEP != string.Empty)
                whereClause += " AND CEP like '%" + objectDTO.CEP + "%'";

            query += whereClause;

            return listProjeto.GetDataInDatabase(query);
        }
    }
}
