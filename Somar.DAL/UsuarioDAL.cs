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
    public class UsuarioDAL
    {
        public List<UsuarioDTO> GetDataInDataBase(UsuarioDTO objectDTO)
        {
            RepList<UsuarioDTO> listProjeto = new RepList<UsuarioDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, b.descPerfil, ";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END, C.nomeUsuario as nomePessoaUltAlteracao ";
            query += " FROM TB_Usuarios A ";
            query += " LEFT JOIN TB_Perfis   B ON A.idPerfil = B.idPerfil ";
            query += " LEFT JOIN TB_Usuarios C ON A.idPessoaUltAlteracao = C.idUsuario";

            if (objectDTO.idUsuario != 0)
                whereClause += " AND A.idUsuario = " + objectDTO.idUsuario.ToString();
            else if (!string.IsNullOrEmpty(objectDTO.nomeUsuario))
                whereClause += " AND nomeUsuario like '%" + objectDTO.nomeUsuario + "%'";
            else if (!string.IsNullOrEmpty(objectDTO.login))
                whereClause += " AND login like '%" + objectDTO.login + "%'";

            if (objectDTO.flagAtivo == true)
                whereClause += " AND A.flagAtivo = 1";

            query += whereClause;

            return listProjeto.GetDataInDatabase(query);
        }

        public List<UsuarioDTO> GetUserByLogin(UsuarioDTO objectDTO)
        {
            RepList<UsuarioDTO> listProjeto = new RepList<UsuarioDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += "SELECT A.*, b.descPerfil, ";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += "FROM TB_Usuarios A ";
            query += "LEFT JOIN TB_Perfis  B ON A.idPerfil = B.idPerfil ";

            whereClause += " AND login = '" + objectDTO.login + "'";

            whereClause += " AND senha = '" + objectDTO.senha + "'";

            if (objectDTO.flagAtivo == true)
                whereClause += " AND A.flagAtivo = 1";

            query += whereClause;

            return listProjeto.GetDataInDatabase(query);
        }

        public int InsertData(UsuarioDTO objectDTO)
        {
            RepList<UsuarioDTO> listProjeto = new RepList<UsuarioDTO>();
            RepGen<UsuarioDTO> sqlCommand = new RepGen<UsuarioDTO>();

            string query = "INSERT INTO TB_Usuarios VALUES (";
            var param = new DynamicParameters();

            param.Add("@nomeUsuario", objectDTO.nomeUsuario, DbType.String);
            param.Add("@login", objectDTO.login, DbType.String);
            param.Add("@senha", objectDTO.senha, DbType.String);
            param.Add("@idPerfil", objectDTO.idPerfil, DbType.Int32);
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

        public int UpdateData(UsuarioDTO objectDTO)
        {
            RepList<UsuarioDTO> listProjeto = new RepList<UsuarioDTO>();
            RepGen<UsuarioDTO> sqlCommand = new RepGen<UsuarioDTO>();

            string query = "UPDATE TB_Usuarios SET ";
            string where = string.Empty;

            var param = new DynamicParameters();

            param.Add("@nomeUsuario", objectDTO.nomeUsuario, DbType.String);
            param.Add("@login", objectDTO.login, DbType.String);
            //param.Add("@senha", objectDTO.senha, DbType.String);
            param.Add("@idPerfil", objectDTO.idPerfil, DbType.Int32);
            param.Add("@flagAtivo", objectDTO.flagAtivo, DbType.Boolean);
            param.Add("@dtUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", objectDTO.idPessoaUltAlteracao, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += " " + item + " = @" + item + ",";

            query = query.Remove(query.Length - 1);

            where += " WHERE idUsuario = " + objectDTO.idUsuario.ToString();
            query += where;

            var result = sqlCommand.ExecuteSQL(query, param);

            return result;
        }

        public int UpdatePassword(UsuarioDTO objectDTO)
        {
            RepList<UsuarioDTO> listProjeto = new RepList<UsuarioDTO>();
            RepGen<UsuarioDTO> sqlCommand = new RepGen<UsuarioDTO>();

            string query = "UPDATE TB_Usuarios SET ";
            string where = string.Empty;

            var param = new DynamicParameters();

            param.Add("@senha", objectDTO.senha, DbType.String);
            
            foreach (var item in param.ParameterNames)
                query += " " + item + " = @" + item + ",";

            query = query.Remove(query.Length - 1);

            where += " WHERE idUsuario = " + objectDTO.idUsuario.ToString();
            query += where;

            var result = sqlCommand.ExecuteSQL(query, param);

            return result;
        }

        public DataSet Consultar(string Sql)
        {
            DataTable _datatable = new DataTable();
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(Globals.stringConn))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM TB_Projeto", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    ds.Tables.Add("Customers");
                    ds.Tables.Add("Employees");
                }

                con.Close();

            }

            return ds;
        }
    }
}
