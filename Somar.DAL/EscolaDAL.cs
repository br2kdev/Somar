using Dapper;
using Somar.DAL.Repository;
using Somar.DAL.Utilities;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DAL
{
    public class EscolaDAL
    {
        public List<EscolaDTO> GetDataInDataBase(EscolaDTO objectDTO)
        {
            RepList<EscolaDTO> listPessoa = new RepList<EscolaDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, B.*,";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += " FROM TB_ESCOLAS          A ";
            query += " LEFT JOIN TB_ENDERECOS     B ON A.idEndereco = B.idEndereco";
          

            if (objectDTO.idEscola != 0)
                whereClause += " AND A.idEscola = " + objectDTO.idEscola.ToString();

            if (!string.IsNullOrEmpty(objectDTO.nomeEscola))
                whereClause += " AND A.nomeEscola like '%" + objectDTO.nomeEscola + "%'";

         

            query += whereClause;

            return listPessoa.GetDataInDatabase(query);
        }

        public int InsertData(EscolaDTO objectDTO)
        {
            RepList<EscolaDTO> listProjeto = new RepList<EscolaDTO>();
            RepGen<EscolaDTO> sqlCommand = new RepGen<EscolaDTO>();

            string query = "INSERT INTO TB_ESCOLAS VALUES (";
            var param = new DynamicParameters();

            param.Add("@nomeEscola", objectDTO.nomeEscola, DbType.String);
            param.Add("@observacoes", objectDTO.observacoes, DbType.String);
            param.Add("@idEndereco", objectDTO.idEndereco, DbType.String);
            param.Add("@dataCadastro", DateTime.Now, DbType.DateTime);
            param.Add("@flagAtivo", objectDTO.flagAtivo, DbType.Boolean);
            param.Add("@dataUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", objectDTO.idPessoaUltAlteracao, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += "@" + item + ",";

            query = query.Remove(query.Length - 1) + ")";

            query += "; SELECT CAST(scope_identity() AS int)";
            
            var result = sqlCommand.ExecuteSQLCommand(query, param);

            return result;
        }

        public int UpdateData(EscolaDTO objectDTO)
        {
            RepList<EscolaDTO> listProjeto = new RepList<EscolaDTO>();
            RepGen<EscolaDTO> sqlCommand = new RepGen<EscolaDTO>();

            string query = "UPDATE TB_ESCOLAS SET ";
            string where = string.Empty;

            var param = new DynamicParameters();

            param.Add("@nomeEscola", objectDTO.nomeEscola, DbType.String);
            param.Add("@observacoes", objectDTO.observacoes, DbType.String);
            param.Add("@idEndereco", objectDTO.idEndereco, DbType.String);
            param.Add("@flagAtivo", objectDTO.flagAtivo, DbType.Boolean);
            param.Add("@dataUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", objectDTO.idPessoaUltAlteracao, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += " " + item + " = @" + item + ",";

            query = query.Remove(query.Length - 1);

            where += " WHERE idEscola = " + objectDTO.idEscola.ToString();
            query += where;

            var result = sqlCommand.ExecuteSQL(query, param);

            return result;
        }
        
    }
}
