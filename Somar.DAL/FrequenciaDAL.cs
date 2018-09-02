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
    public class FrequenciaDAL
    {
        public List<FrequenciaDTO> GetDataInDataBase(FrequenciaDTO objectDTO)
        {
            RepList<FrequenciaDTO> listProjeto = new RepList<FrequenciaDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, B.idTurma, B.nomeTurma, C.idProjeto, C.nomeProjeto ";
            query += " FROM TB_Frequencia    A ";
            query += " INNER JOIN TB_Turmas   B ON A.idTurma   = B.idTurma";
            query += " INNER JOIN TB_Projetos C ON B.idProjeto = C.idProjeto";
            query += " LEFT  JOIN TB_Usuarios D ON A.idPessoaUltAlteracao = D.idUsuario";

            if (objectDTO.idFrequencia != 0)
                whereClause += " AND A.idFrequencia = " + objectDTO.idFrequencia.ToString();

            if (objectDTO.idProjeto != 0)
                whereClause += " AND C.idProjeto = " + objectDTO.idProjeto.ToString();

            if (objectDTO.idTurma != 0)
                whereClause += " AND A.idTurma = " + objectDTO.idTurma.ToString();

            query += whereClause;

            return listProjeto.GetDataInDatabase(query);
        }

        public int InsertData(FrequenciaDTO _item)
        {
            RepGen<FrequenciaDTO> sqlCommand = new RepGen<FrequenciaDTO>();

            string query = "INSERT INTO TB_Frequencia VALUES (";
            var param = new DynamicParameters();

            param.Add("@dataFrequencia", _item.dataFrequencia, DbType.DateTime);
            param.Add("@idTurma", _item.idTurma, DbType.Int32);
            param.Add("@idDisciplina", _item.idDisciplina, DbType.Int32);
            param.Add("@dataCadastro", DateTime.Now, DbType.DateTime);
            param.Add("@dataUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", _item.idPessoaUltAlteracao, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += "@" + item + ",";

            query = query.Remove(query.Length - 1) + ")";

            query += "; SELECT CAST(scope_identity() AS int)";

            var result = sqlCommand.ExecuteSQLCommand(query, param);

            return result;
        }

        public int UpdateData(FrequenciaDTO _item)
        {
            RepGen<FrequenciaDTO> sqlCommand = new RepGen<FrequenciaDTO>();

            string query = "UPDATE TB_Frequencia SET ";
            string where = string.Empty;

            var param = new DynamicParameters();

            param.Add("@dataFrequencia", _item.dataFrequencia, DbType.DateTime);
            param.Add("@idTurma", _item.idTurma, DbType.Int32);
            param.Add("@idDisciplina", _item.idDisciplina, DbType.Int32);
            param.Add("@dataUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", _item.idPessoaUltAlteracao, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += " " + item + " = @" + item + ",";

            query = query.Remove(query.Length - 1);

            where += " WHERE idFrequencia = " + _item.idTurma.ToString();
            query += where;

            var result = sqlCommand.ExecuteSQL(query, param);

            return result;
        }
    }
}
