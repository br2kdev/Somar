using Dapper;
using Somar.DAL.Repository;
using Somar.DTO;
using Somar.Shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace Somar.DAL
{
    public class PessoaDAL
    {
        public List<PessoaDTO> GetDataInDataBase(PessoaDTO objectDTO)
        {
            RepList<PessoaDTO> listPessoa = new RepList<PessoaDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, B.siglaGenero, B.descGenero, C.nomeUsuario as nomePessoaUltAlteracao, D.descTipoPessoa ";
            query += " ,descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            //query += " ,descSituacao = CASE WHEN A.idSituacao = 1 then 'Ativo' else 'Desativado' END ";
            query += " FROM TB_Pessoas          A ";
            query += " LEFT JOIN TB_Generos     B ON A.idGenero = B.idGenero";
            query += " LEFT JOIN TB_Usuarios    C ON A.idPessoaUltAlteracao = C.idUsuario";
            query += " LEFT JOIN TB_TipoPessoas D ON A.idTipoPessoa = D.idTipoPessoa";

            if (objectDTO.idPessoa != 0)
                whereClause += " AND A.idPessoa = " + objectDTO.idPessoa.ToString();

            if (!string.IsNullOrEmpty(objectDTO.nomePessoa))
                whereClause += " AND A.nomePessoa like '%" + objectDTO.nomePessoa + "%'";

            if (objectDTO.idTipoPessoa != 0)
                whereClause += " AND A.idTipoPessoa = " + objectDTO.idTipoPessoa;

            if (objectDTO.flagResponsavel)
                whereClause += " AND A.flagResponsavel = 1";

            query += whereClause;

            return listPessoa.GetDataInDatabase(query);
        }

        public int InsertData(PessoaDTO objectDTO)
        {
            RepList<PessoaDTO> listProjeto = new RepList<PessoaDTO>();
            RepGen<PessoaDTO> sqlCommand = new RepGen<PessoaDTO>();

            string query = "INSERT INTO TB_Pessoas VALUES (";
            var param = new DynamicParameters();

            param.Add("@nomePessoa", objectDTO.nomePessoa, DbType.String);
            param.Add("@dtNascimento", objectDTO.dtNascimento, DbType.DateTime);
            param.Add("@idTipoPessoa", objectDTO.idTipoPessoa, DbType.Int32);
            param.Add("@idGenero", objectDTO.idGenero, DbType.Int32);
            param.Add("@dtAtivacao", objectDTO.dtAtivacao, DbType.DateTime);
            param.Add("@numeroRG", objectDTO.numeroRG, DbType.String);
            param.Add("@numeroCPF", objectDTO.numeroCPF, DbType.String);
            param.Add("@observacoes", objectDTO.observacoes, DbType.String);
            param.Add("@idEndereco", objectDTO.idEndereco, DbType.Int32);
            param.Add("@idContato", objectDTO.idContato, DbType.Int32);
            param.Add("@idEscola", objectDTO.idEscola, DbType.Int32);
            param.Add("@fotoBase64", objectDTO.fotoBase64, DbType.String);
            param.Add("@flagResponsavel", objectDTO.flagResponsavel, DbType.Int32);
            param.Add("@idSituacao", objectDTO.idSituacao, DbType.Int32);
            param.Add("@dtCadastro", DateTime.Now, DbType.DateTime);
            param.Add("@flagAtivo", objectDTO.flagAtivo, DbType.Boolean);
            param.Add("@dtUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", objectDTO.idPessoaUltAlteracao, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += "@" + item + ",";

            query = query.Remove(query.Length - 1) + ")";

            query += "; SELECT CAST(scope_identity() AS int)";
            
            var result = sqlCommand.ExecuteSQLCommand(query, param);

            return result;
        }

        public int UpdateData(PessoaDTO objectDTO)
        {
            RepList<PessoaDTO> listProjeto = new RepList<PessoaDTO>();
            RepGen<PessoaDTO> sqlCommand = new RepGen<PessoaDTO>();

            string query = "UPDATE TB_Pessoas SET ";
            string where = string.Empty;

            var param = new DynamicParameters();

            param.Add("@nomePessoa", objectDTO.nomePessoa, DbType.String);
            param.Add("@dtNascimento", objectDTO.dtNascimento, DbType.DateTime);
            param.Add("@idTipoPessoa", objectDTO.idTipoPessoa, DbType.Int32);
            param.Add("@idGenero", objectDTO.idGenero, DbType.Int32);
            param.Add("@dtAtivacao", objectDTO.dtAtivacao, DbType.DateTime);
            param.Add("@numeroRG", objectDTO.numeroRG, DbType.String);
            param.Add("@numeroCPF", objectDTO.numeroCPF, DbType.String);
            param.Add("@observacoes", objectDTO.observacoes, DbType.String);
            param.Add("@idEndereco", objectDTO.idEndereco, DbType.Int32);
            param.Add("@idContato", objectDTO.idContato, DbType.Int32);
            param.Add("@idEscola", objectDTO.idEscola, DbType.Int32);
            param.Add("@fotoBase64", objectDTO.fotoBase64, DbType.String);
            param.Add("@flagResponsavel", objectDTO.flagResponsavel, DbType.Int32);
            param.Add("@idSituacao", objectDTO.idSituacao, DbType.Int32);
            param.Add("@flagAtivo", objectDTO.flagAtivo, DbType.Boolean);
            param.Add("@dtUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", objectDTO.idPessoaUltAlteracao, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += " " + item + " = @" + item + ",";

            query = query.Remove(query.Length - 1);

            where += " WHERE idPessoa = " + objectDTO.idPessoa.ToString();
            query += where;

            var result = sqlCommand.ExecuteSQL(query, param);

            return result;
        }

        public List<PessoaDTO> GetAniversariantes(PessoaDTO objectDTO)
        {
            RepList<PessoaDTO> listPessoa = new RepList<PessoaDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, ";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += " FROM TB_Pessoas          A ";

            whereClause += " AND month(dtNascimento) = month(getdate())";
            whereClause += " AND flagAtivo = 1";

            //if (objectDTO.flagAtivo != null)
            //    whereClause += " AND flagAtivo like '%" + objectDTO.nomeProjeto + "%'";

            query += whereClause;

            return listPessoa.GetDataInDatabase(query);
        }

        public List<PessoaDTO> GetPessoasPorTipo(TipoPessoa enumTipoPessoa)
        {
            RepList<PessoaDTO> listPessoa = new RepList<PessoaDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, ";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += " FROM TB_Pessoas          A ";

            whereClause += " AND idTipoPessoa = " + Convert.ToInt32(enumTipoPessoa);
            whereClause += " AND flagAtivo = 1";

            //if (objectDTO.flagAtivo != null)
            //    whereClause += " AND flagAtivo like '%" + objectDTO.nomeProjeto + "%'";

            query += whereClause;

            return listPessoa.GetDataInDatabase(query);
        }

        public List<PessoaDTO> GetPessoasPorTipoID(int idTipoPessoa)
        {
            RepList<PessoaDTO> listPessoa = new RepList<PessoaDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, ";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += " FROM TB_Pessoas          A ";

            if(idTipoPessoa != 0)
                whereClause += " AND idTipoPessoa = " + idTipoPessoa;

            whereClause += " AND flagAtivo = 1";

            //if (objectDTO.flagAtivo != null)
            //    whereClause += " AND flagAtivo like '%" + objectDTO.nomeProjeto + "%'";

            query += whereClause;

            return listPessoa.GetDataInDatabase(query);
        }
    }
}
