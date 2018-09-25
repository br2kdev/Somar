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
    public class ProjetoDAL
    {
        public List<ProjetoDTO> GetDataInDataBase(ProjetoDTO objectDTO)
        {
            RepList<ProjetoDTO> listProjeto = new RepList<ProjetoDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, B.nomeUsuario as nomePessoaUltAlteracao, ";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += " FROM TB_Projetos      A ";
            query += " LEFT JOIN TB_Usuarios B ON A.idPessoaUltAlteracao = B.idUsuario";

            if (objectDTO.idProjeto != 0)
                whereClause += " AND A.idProjeto = " + objectDTO.idProjeto.ToString();

            if (objectDTO.nomeProjeto != string.Empty)
                whereClause += " AND A.nomeProjeto like '%" + objectDTO.nomeProjeto + "%'";

            if (objectDTO.flagAtivo == true)
                whereClause += " AND A.flagAtivo = 1";

            query += whereClause;

            return listProjeto.GetDataInDatabase(query);
        }

        public int InsertData(ProjetoDTO objectDTO)
        {
            RepList<ProjetoDTO> listProjeto = new RepList<ProjetoDTO>();
            RepGen<ProjetoDTO> sqlCommand = new RepGen<ProjetoDTO>();

            string query = "INSERT INTO TB_Projetos VALUES (";
            var param = new DynamicParameters();

            param.Add("@nomeProjeto", objectDTO.nomeProjeto, DbType.String);
            param.Add("@descricaoProjeto", objectDTO.descricaoProjeto, DbType.String);

            param.Add("@dtInicio", objectDTO.dtInicio, DbType.Date);
            param.Add("@dtTermino", objectDTO.dtTermino, DbType.Date);

            //param.Add("@idPessoaResposavel", objectDTO.idPessoaResposavel, DbType.Int32);
            param.Add("@nomeResposavel", objectDTO.nomeResposavel, DbType.String);
            param.Add("@dtCadastro", DateTime.Now, DbType.DateTime);
            param.Add("@flagAtivo", objectDTO.flagAtivo, DbType.Boolean);
            param.Add("@dtUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", objectDTO.idPessoaUltAlteracao, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += "@" +item + ",";

            query = query.Remove(query.Length - 1) + ")";

            query += "; SELECT CAST(scope_identity() AS int)";

            var result = sqlCommand.ExecuteSQLCommand(query, param);

            return result;
        }

        public int UpdateData(ProjetoDTO objectDTO)
        {
            RepList<ProjetoDTO> listProjeto = new RepList<ProjetoDTO>();
            RepGen<ProjetoDTO> sqlCommand = new RepGen<ProjetoDTO>();

            string query = "UPDATE TB_Projetos SET ";
            string where = string.Empty;

            var param = new DynamicParameters();

            param.Add("@nomeProjeto", objectDTO.nomeProjeto, DbType.String);
            param.Add("@descricaoProjeto", objectDTO.descricaoProjeto, DbType.String);

            param.Add("@dtInicio", objectDTO.dtInicio, DbType.Date);
            param.Add("@dtTermino", objectDTO.dtTermino, DbType.Date);

            //param.Add("@idPessoaResposavel", objectDTO.idPessoaResposavel, DbType.Int32);
            param.Add("@nomeResposavel", objectDTO.nomeResposavel, DbType.String);
            param.Add("@flagAtivo", objectDTO.flagAtivo, DbType.Boolean);
            param.Add("@dtUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", objectDTO.idPessoaUltAlteracao, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += " " + item + " = @" + item + ",";

            query = query.Remove(query.Length - 1);

            where += " WHERE idProjeto = " + objectDTO.idProjeto.ToString();
            query += where;

            var result = sqlCommand.ExecuteSQL(query, param);

            return result;
        }
    }
}
