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

            query += "SELECT * ";
            query += "FROM TB_Projetos";

            if (objectDTO.idProjeto != 0)
                whereClause += " AND idProjeto = " + objectDTO.idProjeto.ToString();

            if (objectDTO.nomeProjeto != string.Empty)
                whereClause += " AND nomeProjeto like '%" + objectDTO.nomeProjeto + "%'";

            query += whereClause;

            return listProjeto.GetDataInDatabase(query);
        }

        public bool SaveDataInDataBase(ProjetoDTO objectDTO)
        {
            RepList<ProjetoDTO> listProjeto = new RepList<ProjetoDTO>();
            RepGen<ProjetoDTO> sqlCommand = new RepGen<ProjetoDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += "insert into TB_Projetos values ('PROJETO 1', 'DESCRICAO DO PROJETO', GETDATE(), GETDATE(), 1, GETDATE(), 1, GETDATE(), 1)";
            /*
            if (objectDTO.idProjeto != 0)
                whereClause += " AND idProjeto = " + objectDTO.idProjeto.ToString();

            if (objectDTO.nomeProjeto != string.Empty)
                whereClause += " AND nomeProjeto like '%" + objectDTO.nomeProjeto + "%'";
            */
            //query += whereClause;

            sqlCommand.ExecuteSQLCommand(query, new DynamicParameters());

            return true;
        }

        /*
        public List<ProjetoDTO> ReadAll()
        {
            RepList<ProjetoDTO> listProjeto = new RepList<ProjetoDTO>();

            return listProjeto.GetAllData("SELECT * FROM TB_Projetos");

            using (IDbConnection db = new SqlConnection(Globals.stringConn))
            {
                try
                {
                    listProjeto = db.Query<ProjetoDTO>("SELECT * FROM Projetos").ToList();
                }
                finally
                {

                }
            }

            return listProjeto;
        }
        */

        /*
        public List<ProjetoDTO> GetAll(ProjetoDTO _projeto)
        {
            RepList<ProjetoDTO> lista = new RepList<ProjetoDTO>();

            param.Add(pair.Key, pair.Value);
            param.Add()

            return lista.returnListClass2("USP_Projeto", param);
        }
        */

        /*
        public List<ProjetoDTO> GetAll(ProjetoDTO _projeto)
        {
            RepList<ProjetoDTO> lista = new RepList<ProjetoDTO>();

            DynamicParameters param = new DynamicParameters();

            return lista.returnListClass("USP_Projeto", param);
        }
        */

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

        /*
        public string insertUpdate(ProjetoDTO _projeto)
        {
            RepGen reposGen = new Repository.RepGen();
            DynamicParameters param = new DynamicParameters();
            param.Add("@idProjeto", _projeto.idProjeto);
            param.Add("@nomeProjeto", _projeto.nomeProjeto);
            param.Add("@descricaoProjeto", _projeto.descricaoProjeto);
            param.Add("@dataInicio", _projeto.dataInicio);
            param.Add("@dataTermino", _projeto.dataTermino);
            param.Add("@idPessoaResposavel", _projeto.idPessoaResposavel);
            param.Add("@dataCadastro", _projeto.dataCadastro);
            param.Add("@flagAtivo", _projeto.flagAtivo);
            param.Add("@dataUltAlteracao", _projeto.dataUltAlteracao);
            param.Add("@idPessoaUltAlteracao", _projeto.idPessoaUltAlteracao);

            return reposGen.executeNonQuery("users_Insert_Update", param);
        }
        */

        /*
        public string delete(ProjetoDTO _projeto)
        {
            RepGen reposGen = new Repository.RepGen();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", _projeto.id);
            return reposGen.executeNonQuery("users_DeleteRow_By_id", param);
        }
        */

        /*
        public List<ProjetoDTO> AllRecordsById(string id)
        {
            RepList<ProjetoDTO> lista = new RepList<ProjetoDTO>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            return lista.returnListClass("users_SelectRow_By_id", param);
        }

        public ProjetoDTO findById(string id)
        {
            RepList<ProjetoDTO> class_usu = new RepList<ProjetoDTO>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            return class_usu.returnClass("users_SelectRow_By_id", param);
        }

        public List<dynamic> dynamicsList()
        {
            Funciones FG = new Funciones();
            DynamicParameters param = new DynamicParameters();
            Repository.RepList<dynamic> repo = new Repository.RepList<dynamic>();
            var items = repo.returnListClass("users_SelectwithDate", param);
            return items;
        }
        */
    }
}
