using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Somar.DAL.Utilities;

namespace Somar.DAL.Repository
{
    class RepList<T> where T : class
    {
        public SqlConnection con;

        private void GetDBConnection()
        {
            con = new SqlConnection(Globals.stringConn);
        }

        public List<T> GetAllData(string query)
        {
            using (IDbConnection db = new SqlConnection(Globals.stringConn))
            {
                IList<T> Tlista = SqlMapper.Query<T>(db, query, null, null, true, null, commandType: CommandType.Text).ToList();

                return Tlista.ToList();
            }
        }

        public List<T> GetDataWithParam(string query, DynamicParameters param)
        {
            using (IDbConnection db = new SqlConnection(Globals.stringConn))
            {
                //return db.Query<ProjetoDTO>("Select * From Author " + "WHERE Id = " @Id, new { id }).SingleOrDefault();
                IList<T> Tlista = SqlMapper.Query<T>(db, query, param, null, true, null, commandType: CommandType.Text).ToList();

                return Tlista.ToList();
            }
        }



        /*
        public List<T> returnListClass(string query, DynamicParameters param)
        {
            try
            {
                connection();
                con.Open();
                IList<T> Tlista = SqlMapper.Query<T>(con, query, param, null, true, null, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return Tlista.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T returnClass(string query, DynamicParameters param)
        {
            try
            {
                connection();
                con.Open();
                //     return this.con.Query( query, param, null, true, null, commandType: CommandType.StoredProcedure).FirstOrDefault();
                T Tlista = SqlMapper.Query<T>(con, query, param, null, true, null, commandType: CommandType.StoredProcedure).FirstOrDefault();
                con.Close();
                return Tlista;
            }
            catch (Exception)
            {
                throw;
            }
        }
        */
    }
}
