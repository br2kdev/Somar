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

        public int ExecuteSQL(string query, DynamicParameters param)
        {
            int result = 0;

            using (IDbConnection db = new SqlConnection(Globals.stringConn))
            {
                int rowsAffected = db.Execute(query, param, commandType: CommandType.Text);
            }

            return result;
        }

        public int ExecuteSQLCommand(string query, DynamicParameters param)
        {
            var identity = 0;

            using (IDbConnection db = new SqlConnection(Globals.stringConn))
            {
                var result = db.ExecuteScalar(query, param, commandType: CommandType.Text);

                if (result != null)
                    identity = (int)result;
            }

            return identity;
        }

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

