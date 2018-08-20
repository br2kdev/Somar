using Dapper;
using Somar.DAL.Repository;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DAL
{
    public class ContatoDAL
    {
        public ContatoDTO GetContatos(int idContato)
        {
            RepList<ContatoDTO> listContato = new RepList<ContatoDTO>();

            string query = string.Empty;

            query += "SELECT * ";
            query += "FROM TB_Contatos A ";
            query += "WHERE A.idContato = " + idContato.ToString();

            var resultList = listContato.GetDataInDatabase(query);

            if (resultList.Count > 0)
                return resultList[0];
            else
                return null;
        }

        public int InsertData(ContatoDTO objectDTO)
        {
            RepList<ContatoDTO> listProjeto = new RepList<ContatoDTO>();
            RepGen<ContatoDTO> sqlCommand = new RepGen<ContatoDTO>();

            string query = "INSERT INTO TB_Contatos VALUES (";
            var param = new DynamicParameters();

            param.Add("@nomePai", objectDTO.nomePai, DbType.String);
            param.Add("@nomeMae", objectDTO.nomeMae, DbType.String);
            param.Add("@telefone1", objectDTO.telefone1, DbType.String);
            param.Add("@contato1", objectDTO.contato1, DbType.String);
            param.Add("@telefone2", objectDTO.telefone2, DbType.String);
            param.Add("@contato2", objectDTO.contato2, DbType.String);
            param.Add("@telefone3", objectDTO.telefone3, DbType.String);
            param.Add("@contato3", objectDTO.contato3, DbType.String);

            foreach (var item in param.ParameterNames)
                query += "@" + item + ",";

            query = query.Remove(query.Length - 1) + ")";

            query += "; SELECT CAST(scope_identity() AS int)";

            var result = sqlCommand.ExecuteSQLCommand(query, param);

            return result;
        }

        public int UpdateData(ContatoDTO objectDTO)
        {
            RepList<ContatoDTO> listEndereco = new RepList<ContatoDTO>();
            RepGen<ContatoDTO> sqlCommand = new RepGen<ContatoDTO>();

            string query = "UPDATE TB_Contatos SET ";
            string where = string.Empty;

            var param = new DynamicParameters();

            param.Add("@nomePai", objectDTO.nomePai, DbType.String);
            param.Add("@nomeMae", objectDTO.nomeMae, DbType.String);
            param.Add("@telefone1", objectDTO.telefone1, DbType.String);
            param.Add("@contato1", objectDTO.contato1, DbType.String);
            param.Add("@telefone2", objectDTO.telefone2, DbType.String);
            param.Add("@contato2", objectDTO.contato2, DbType.String);
            param.Add("@telefone3", objectDTO.telefone3, DbType.String);
            param.Add("@contato3", objectDTO.contato3, DbType.String);

            foreach (var item in param.ParameterNames)
                query += " " + item + " = @" + item + ",";

            query = query.Remove(query.Length - 1);

            where += " WHERE idContato = " + objectDTO.idContato.ToString();
            query += where;

            var result = sqlCommand.ExecuteSQL(query, param);

            return result;
        }
    }
}
