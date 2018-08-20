using Dapper;
using Somar.DAL.Repository;
using Somar.DTO;
using System.Collections.Generic;
using System.Data;

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

        public EnderecoDTO GetEndereco(int idEndereco)
        {
            RepList<EnderecoDTO> listEndereco = new RepList<EnderecoDTO>();

            string query = string.Empty;

            query += "SELECT * ";
            query += "FROM TB_Enderecos A ";
            query += "WHERE A.idEndereco = " + idEndereco.ToString();

            var resultList = listEndereco.GetDataInDatabase(query);

            if (resultList.Count > 0)
                return resultList[0];
            else
                return null;
        }

        public EnderecoDTO GetCEP(EnderecoDTO objectDTO)
        {
            RepList<EnderecoDTO> listProjeto = new RepList<EnderecoDTO>();

            var result = new EnderecoDTO();

            string query = string.Empty;
            
            query += "SELECT A.CEP,";
            query += "       A.LOG_NOME          AS Logradouro,";
            query += "       B.bai_nu_sequencial AS idBairro,";
            query += "       B.bai_no            AS nomeBairro,";
            query += "       B.loc_nu_sequencial AS idCidade,";
            query += "       C.loc_no            AS nomeCidade,";
            query += "       C.ufe_sg            AS siglaUF";
            query += " FROM  TB_CEP_Logradouro      A";
            query += " INNER JOIN TB_CEP_Bairro     B ON A.bai_nu_sequencial_ini = B.bai_nu_sequencial";
            query += " INNER JOIN TB_CEP_Localidade C ON A.loc_nu_sequencial     = C.loc_nu_sequencial";

            query += " WHERE A.CEP = " + objectDTO.CEP;

            var resultList = listProjeto.GetDataInDatabase(query);

            if (resultList.Count > 0)
                return resultList[0];
            else 
                return null;
        }

        public int InsertData(EnderecoDTO objectDTO)
        {
            RepList<EnderecoDTO> listProjeto = new RepList<EnderecoDTO>();
            RepGen<EnderecoDTO> sqlCommand = new RepGen<EnderecoDTO>();

            string query = "INSERT INTO TB_Enderecos VALUES (";
            var param = new DynamicParameters();

            param.Add("@CEP", objectDTO.CEP, DbType.String);
            param.Add("@logradouro", objectDTO.logradouro, DbType.String);
            param.Add("@complemento", objectDTO.complemento, DbType.String);
            param.Add("@numero", objectDTO.numero, DbType.String);
            param.Add("@idBairro", objectDTO.idBairro, DbType.Int32);
            param.Add("@nomeBairro", objectDTO.nomeBairro, DbType.String);
            param.Add("@idCidade", objectDTO.idCidade, DbType.Int32);
            param.Add("@nomeCidade", objectDTO.nomeCidade, DbType.String);
            param.Add("@siglaUF", objectDTO.siglaUF, DbType.String);

            foreach (var item in param.ParameterNames)
                query += "@" + item + ",";

            query = query.Remove(query.Length - 1) + ")";

            query += "; SELECT CAST(scope_identity() AS int)";

            var result = sqlCommand.ExecuteSQLCommand(query, param);

            return result;
        }

        public int UpdateData(EnderecoDTO objectDTO)
        {
            RepList<EnderecoDTO> listEndereco = new RepList<EnderecoDTO>();
            RepGen<EnderecoDTO> sqlCommand = new RepGen<EnderecoDTO>();

            string query = "UPDATE TB_Enderecos SET ";
            string where = string.Empty;

            var param = new DynamicParameters();

            param.Add("@CEP", objectDTO.CEP, DbType.String);
            param.Add("@logradouro", objectDTO.logradouro, DbType.String);
            param.Add("@complemento", objectDTO.complemento, DbType.String);
            param.Add("@numero", objectDTO.numero, DbType.String);
            param.Add("@idBairro", objectDTO.idBairro, DbType.Int32);
            param.Add("@nomeBairro", objectDTO.nomeBairro, DbType.String);
            param.Add("@idCidade", objectDTO.idCidade, DbType.Int32);
            param.Add("@nomeCidade", objectDTO.nomeCidade, DbType.String);
            param.Add("@siglaUF", objectDTO.siglaUF, DbType.String);

            foreach (var item in param.ParameterNames)
                query += " " + item + " = @" + item + ",";

            query = query.Remove(query.Length - 1);

            where += " WHERE idEndereco = " + objectDTO.idEndereco.ToString();
            query += where;

            var result = sqlCommand.ExecuteSQL(query, param);

            return result;
        }
    }
}
