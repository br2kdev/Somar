using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Somar.DAL.Utilities;

namespace Somar.DAL.Repository
{
    class RepGen<T> where T : class
    {
        public SqlConnection con;

        private void GetDBConnection()
        {
            con = new SqlConnection(Globals.stringConn);
        }

        public int ExecuteSQLCommand(string query, DynamicParameters param)
        {
            var result = 0;

            using (IDbConnection db = new SqlConnection(Globals.stringConn))
            {
                result = db.Execute(query, param, commandType: CommandType.Text);

                /*
                IList<T> Tlista = SqlMapper.Query<T>(db, query, null, null, true, null, commandType: CommandType.Text).ToList();

                return Tlista.ToList();
                */
            }

            return result;
            /*
            try
            {
                GetDBConnection();
                con.Open();
                con.Execute(query, param, commandType: CommandType.Text);
                con.Close();
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            */
        }

        /*
        private void connection()
        {
            //Remenber you must have this file--> c:\conn.xml
            string path = Utilities.Globals.path;
            Utilities.Globals.stringConn = ConnectionDB.xml_conn(path);
            string conn = Utilities.Globals.stringConn;

            con = new SqlConnection(Globals.stringConn);
        }
        */

        /*
    public string ExecuteSQLCommand(string query, DynamicParameters param)
    {
        try
        {
            GetDBConnection();
            con.Open();
            con.Execute(query, param, commandType: CommandType.Text);
            con.Close();
            return "0";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string executeNonQuery(string query, DynamicParameters param)
    {
        try
        {
            GetDBConnection();
            con.Open();
            con.Execute(query, param, commandType: CommandType.StoredProcedure);
            con.Close();
            return "0";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    */

        /*
        public string returnScalar(string query, DynamicParameters param)
        {
            try
            {
                string valor = "";
                connection();
                con.Open();
                valor = con.ExecuteScalar<string>(query, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return valor;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string returnNumericValue(string query, DynamicParameters param)
        {
            try
            {
                string valor = "";
                param.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                param.Add("@Returnvalue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                // Getting Return value   
                connection();
                con.Open();
                valor = con.ExecuteScalar<string>(query, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return valor;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        */
    }
}

