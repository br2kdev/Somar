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
    public class ProjetoDAL : BaseDAL
    {
        public List<ProjetoDTO> GetDataInDataBase(ProjetoDTO objectDTO)
        {
            RepList<ProjetoDTO> listProjeto = new RepList<ProjetoDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += "SELECT *, ";
            query += " descricaoAtivo = CASE WHEN flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += "FROM TB_Projetos";

            if (objectDTO.idProjeto != 0)
                whereClause += " AND idProjeto = " + objectDTO.idProjeto.ToString();

            if (objectDTO.nomeProjeto != string.Empty)
                whereClause += " AND nomeProjeto like '%" + objectDTO.nomeProjeto + "%'";

            //if (objectDTO.flagAtivo != null)
            //    whereClause += " AND flagAtivo like '%" + objectDTO.nomeProjeto + "%'";

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
            param.Add("@dataInicio", objectDTO.dataInicio, DbType.DateTime);
            param.Add("@dataTermino", objectDTO.dataTermino, DbType.DateTime);
            param.Add("@idPessoaResposavel", objectDTO.idPessoaResposavel, DbType.Int32);
            param.Add("@dataCadastro", DateTime.Now, DbType.DateTime);
            param.Add("@flagAtivo", objectDTO.flagAtivo, DbType.Boolean);
            param.Add("@dataUltAlteracao", DateTime.Now, DbType.DateTime);
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
            param.Add("@dataInicio", objectDTO.dataInicio, DbType.DateTime);
            param.Add("@dataTermino", objectDTO.dataTermino, DbType.DateTime);
            param.Add("@idPessoaResposavel", objectDTO.idPessoaResposavel, DbType.Int32);
            param.Add("@flagAtivo", objectDTO.flagAtivo, DbType.Boolean);
            param.Add("@dataUltAlteracao", DateTime.Now, DbType.DateTime);
            param.Add("@idPessoaUltAlteracao", objectDTO.idPessoaUltAlteracao, DbType.Int32);

            foreach (var item in param.ParameterNames)
                query += " " + item + " = @" + item + ",";

            query = query.Remove(query.Length - 1);

            where += " WHERE idProjeto = " + objectDTO.idProjeto.ToString();
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


                /*
                ds.EnforceConstraints = false;

                ds.Tables["Customers"].BeginLoadData();
                da.Fill(ds.Tables["Customers"]);
                ds.Tables["Customers"].EndLoadData();
                ds.Tables["Employees"].BeginLoadData();
                da.Fill(ds.Tables["Employees"]);
                ds.Tables["Employees"].EndLoadData();

                dataGrid1.DataSource = ds.Tables["Customers"];
                dataGrid2.DataSource = ds.Tables["Employees"];
                */
                /*
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    }
                }
                */
                con.Close();

            }

            return ds;

            /*
            

            cmd = new SqlCommand(Sql, conn);
            conn.Open();

            //Diz que o comando é uma query(Texto) e não uma StoredProcedure
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(cliente);
            dgv.DataSource = cliente;
            conn.Close();
            */

        }

    }
}
