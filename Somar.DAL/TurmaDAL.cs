﻿using Dapper;
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
    public class TurmaDAL
    {
        public List<TurmaDTO> GetDataInDataBase(TurmaDTO _turmaDTO)
        {
            RepList<TurmaDTO> listTurma = new RepList<TurmaDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += "SELECT A.*, B.nomeProjeto, ";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += "FROM TB_Turmas A ";
            query += "LEFT JOIN TB_Projetos B ON A.idProjeto = B.idProjeto";

            if (_turmaDTO.idTurma != 0)
                whereClause += " AND A.idTurma = " + _turmaDTO.idTurma.ToString();

            if (!string.IsNullOrEmpty(_turmaDTO.nomeTurma))
                whereClause += " AND A.nomeTurma like '%" + _turmaDTO.nomeTurma + "%'";

            query += whereClause;

            return listTurma.GetDataInDatabase(query);
        }

        public int InsertData(TurmaDTO _turmaDTO)
        {
            RepList<TurmaDTO> listProjeto = new RepList<TurmaDTO>();
            RepGen<TurmaDTO> sqlCommand = new RepGen<TurmaDTO>();

            string query = "INSERT INTO TB_Turmas VALUES (";
            var param = new DynamicParameters();

            param.Add("@nomeTurma", _turmaDTO.nomeTurma, DbType.String);
            param.Add("@descricaoTurma", _turmaDTO.descricaoTurma, DbType.String);
            param.Add("@horaInicio", _turmaDTO.horaInicio, DbType.String);
            param.Add("@horaTermino", _turmaDTO.horaTermino, DbType.String);
            param.Add("@idPessoaEducador", _turmaDTO.idPessoaEducador, DbType.Int32);
            param.Add("@dataCadastro", DateTime.Now, DbType.DateTime);
            param.Add("@flagAtivo", _turmaDTO.flagAtivo, DbType.Boolean);
            param.Add("@dataUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", _turmaDTO.idPessoaUltAlteracao, DbType.Int32);
            param.Add("@idProjeto", _turmaDTO.idProjeto, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += "@" + item + ",";

            query = query.Remove(query.Length - 1) + ")";

            query += "; SELECT CAST(scope_identity() AS int)";

            var result = sqlCommand.ExecuteSQLCommand(query, param);

            return result;
        }

        public int UpdateData(TurmaDTO _turmaDTO)
        {
            RepList<TurmaDTO> listProjeto = new RepList<TurmaDTO>();
            RepGen<TurmaDTO> sqlCommand = new RepGen<TurmaDTO>();

            string query = "UPDATE TB_Turmas SET ";
            string where = string.Empty;

            var param = new DynamicParameters();

            param.Add("@nomeTurma", _turmaDTO.nomeTurma, DbType.String);
            param.Add("@descricaoTurma", _turmaDTO.descricaoTurma, DbType.String);
            param.Add("@horaInicio", _turmaDTO.horaInicio, DbType.String);
            param.Add("@horaTermino", _turmaDTO.horaTermino, DbType.String);
            param.Add("@idPessoaEducador", _turmaDTO.idPessoaEducador, DbType.Int32);
            param.Add("@flagAtivo", _turmaDTO.flagAtivo, DbType.Boolean);
            param.Add("@dataUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", _turmaDTO.idPessoaUltAlteracao, DbType.Int32);
            param.Add("@idProjeto", _turmaDTO.idProjeto, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += " " + item + " = @" + item + ",";

            query = query.Remove(query.Length - 1);

            where += " WHERE idTurma = " + _turmaDTO.idTurma.ToString();
            query += where;

            var result = sqlCommand.ExecuteSQL(query, param);

            return result;
        }

    }
}