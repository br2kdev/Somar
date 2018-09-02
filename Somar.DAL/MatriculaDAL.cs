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
    public class MatriculaDAL
    {
        public List<PessoaDTO> GetAlunoMatricula(PessoaDTO objectDTO)
        {
            RepList<PessoaDTO> listPessoa = new RepList<PessoaDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, B.descGenero, C.nomeUsuario as nomePessoaUltAlteracao, D.descTipoPessoa, ";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += " FROM TB_Pessoas          A ";
            query += " LEFT JOIN TB_Generos     B ON A.idGenero = B.idGenero";
            query += " LEFT JOIN TB_Usuarios    C ON A.idPessoaUltAlteracao = C.idUsuario";
            query += " LEFT JOIN TB_TipoPessoas D ON A.idTipoPessoa = D.idTipoPessoa";


            if (objectDTO.idPessoa != 0)
                whereClause += " AND A.idPessoa = " + objectDTO.idPessoa.ToString();

            if (!string.IsNullOrEmpty(objectDTO.nomePessoa))
                whereClause += " AND A.nomePessoa like '%" + objectDTO.nomePessoa + "%'";

            //if (objectDTO.flagAtivo != null)
            //    whereClause += " AND flagAtivo like '%" + objectDTO.nomeProjeto + "%'";

            query += whereClause;

            return listPessoa.GetDataInDatabase(query);
        }

        public List<MatriculaDTO> GetDataInDataBase(MatriculaDTO objectDTO)
        {
            RepList<MatriculaDTO> listPessoa = new RepList<MatriculaDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, B.nomePessoa, C.nomeTurma, D.nomeProjeto ";
            //query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += " FROM TB_Matricula        A ";
            query += " LEFT JOIN TB_Pessoas     B ON A.idPessoa   = B.idPessoa";
            query += " LEFT JOIN TB_Turmas      C ON A.idTurma    = C.idTurma";
            query += " LEFT JOIN TB_Projetos    D ON C.idProjeto  = D.idProjeto";

            if (objectDTO.idPessoa != 0)
                whereClause += " AND A.idPessoa = " + objectDTO.idPessoa.ToString();

            //if (objectDTO.flagAtivo != null)
            //    whereClause += " AND flagAtivo like '%" + objectDTO.nomeProjeto + "%'";

            query += whereClause;

            return listPessoa.GetDataInDatabase(query);
        }

        public int InsertData(MatriculaDTO _item)
        {
            RepGen<MatriculaDTO> sqlCommand = new RepGen<MatriculaDTO>();

            string query = "INSERT INTO TB_Matricula VALUES (";
            var param = new DynamicParameters();

            param.Add("@idPessoa", _item.idPessoa, DbType.Int32);
            param.Add("@idTurma", _item.idTurma, DbType.Int32);
            param.Add("@dataMatricula", DateTime.Now, DbType.DateTime);
            param.Add("@dataCancelamento", _item.dataCancelamento, DbType.DateTime);
            param.Add("@dataUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", _item.idPessoaUltAlteracao, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += "@" + item + ",";

            query = query.Remove(query.Length - 1) + ")";

            query += "; SELECT CAST(scope_identity() AS int)";

            var result = sqlCommand.ExecuteSQLCommand(query, param);

            return result;
        }

        public int UpdateData(MatriculaDTO _item)
        {
            RepGen<MatriculaDTO> sqlCommand = new RepGen<MatriculaDTO>();

            string query = "UPDATE TB_Matricula SET ";
            string where = string.Empty;

            var param = new DynamicParameters();

            param.Add("@idPessoa", _item.idPessoa, DbType.Int32);
            param.Add("@idTurma", _item.idTurma, DbType.Int32);
            param.Add("@dataMatricula", _item.dataMatricula, DbType.DateTime);
            param.Add("@dataCancelamento", _item.dataCancelamento, DbType.DateTime);
            param.Add("@dataUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", _item.idPessoaUltAlteracao, DbType.Int32);
            
            foreach (var item in param.ParameterNames)
                query += " " + item + " = @" + item + ",";

            query = query.Remove(query.Length - 1);

            where += " WHERE idMatricula = " + _item.idTurma.ToString();
            query += where;

            var result = sqlCommand.ExecuteSQL(query, param);

            return result;
        }
    }
}
