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
    public class PessoaDAL
    {
        public List<PessoaDTO> GetDataInDataBase(PessoaDTO objectDTO)
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

        public int InsertData(PessoaDTO objectDTO)
        {
            RepList<PessoaDTO> listProjeto = new RepList<PessoaDTO>();
            RepGen<PessoaDTO> sqlCommand = new RepGen<PessoaDTO>();

            string query = "INSERT INTO TB_Pessoas VALUES (";
            var param = new DynamicParameters();

            param.Add("@nomePessoa", objectDTO.nomePessoa, DbType.String);
            param.Add("@dataNascimento", objectDTO.dataNascimento, DbType.DateTime);
            param.Add("@idTipoPessoa", objectDTO.idTipoPessoa, DbType.Int32);
            param.Add("@idGenero", objectDTO.idGenero, DbType.Int32);
            param.Add("@dataAtivacao", objectDTO.dataAtivacao, DbType.DateTime);
            param.Add("@numeroRG", objectDTO.numeroRG, DbType.String);
            param.Add("@numeroCPF", objectDTO.numeroCPF, DbType.String);
            param.Add("@observacoes", objectDTO.observacoes, DbType.String);
            param.Add("@idEndereco", objectDTO.idEndereco, DbType.Int32);
            param.Add("@idContato", objectDTO.idContato, DbType.Int32);
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

        public int UpdateData(PessoaDTO objectDTO)
        {
            RepList<PessoaDTO> listProjeto = new RepList<PessoaDTO>();
            RepGen<PessoaDTO> sqlCommand = new RepGen<PessoaDTO>();

            string query = "UPDATE TB_Pessoas SET ";
            string where = string.Empty;

            var param = new DynamicParameters();

            param.Add("@nomePessoa", objectDTO.nomePessoa, DbType.String);
            param.Add("@dataNascimento", objectDTO.dataNascimento, DbType.DateTime);
            param.Add("@idTipoPessoa", objectDTO.idTipoPessoa, DbType.Int32);
            param.Add("@idGenero", objectDTO.idGenero, DbType.Int32);
            param.Add("@dataAtivacao", objectDTO.dataAtivacao, DbType.DateTime);
            param.Add("@numeroRG", objectDTO.numeroRG, DbType.String);
            param.Add("@numeroCPF", objectDTO.numeroCPF, DbType.String);
            param.Add("@observacoes", objectDTO.observacoes, DbType.String);
            param.Add("@idEndereco", objectDTO.idEndereco, DbType.Int32);
            param.Add("@idContato", objectDTO.idContato, DbType.Int32);

            param.Add("@flagAtivo", objectDTO.flagAtivo, DbType.Boolean);
            param.Add("@dataUltAlteracao", DateTime.Now, DbType.DateTime);
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

            query += " SELECT A.*, B.descGenero, ";
            query += " C.nomeUsuario as nomePessoaUltAlteracao,";
            query += " D.descTipoPessoa, ";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += " FROM TB_Pessoas          A ";
            query += " LEFT JOIN TB_Generos     B ON A.idGenero = B.idGenero";
            query += " LEFT JOIN TB_Usuarios    C ON A.idPessoaUltAlteracao = C.idUsuario";
            query += " LEFT JOIN TB_TipoPessoas D ON A.idTipoPessoa = D.idTipoPessoa";

            whereClause += " AND A.nomePessoa like '%" + objectDTO.nomePessoa + "%'";

            //if (objectDTO.flagAtivo != null)
            //    whereClause += " AND flagAtivo like '%" + objectDTO.nomeProjeto + "%'";

            query += whereClause;

            return listPessoa.GetDataInDatabase(query);
        }
        

    }
}
