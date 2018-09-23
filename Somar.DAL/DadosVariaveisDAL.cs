using Dapper;
using Somar.DAL.Repository;
using Somar.DTO;
using System.Collections.Generic;
using System.Data;

namespace Somar.DAL
{
    public class DadosVariaveisDAL
    {
        public List<DadosVariaveisDTO> GetDataInDataBase(DadosVariaveisDTO objectDTO)
        {
            RepList<DadosVariaveisDTO> listItens = new RepList<DadosVariaveisDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, ";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += " FROM TB_DadosVariaveis A ";

            if (objectDTO.idDadoVariavel != 0)
                whereClause += " AND A.idDadoVariavel = " + objectDTO.idDadoVariavel.ToString();

            query += whereClause;

            return listItens.GetDataInDatabase(query);
        }

        public List<DadosVariaveisDTO> GetDadosPorIdPessoa(int idPessoa)
        {
            RepList<DadosVariaveisDTO> listItens = new RepList<DadosVariaveisDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.* ";
            query += " FROM TB_PessoaDV A ";

            whereClause += " AND A.idPessoa = " + idPessoa.ToString();

            query += whereClause;

            return listItens.GetDataInDatabase(query);
        }

        public int UpdateData(List<DadosVariaveisDTO> listObj, int idPessoa)
        {
            RepList<PessoaDTO> listProjeto = new RepList<PessoaDTO>();
            RepGen<PessoaDTO> sqlCommand = new RepGen<PessoaDTO>();

            // ************************
            // DELETE
            // ************************
            var param = new DynamicParameters();
            param.Add("@idPessoa", idPessoa, DbType.String);

            var result = sqlCommand.ExecuteSQLCommand("delete TB_PessoaDV where idPessoa = @idPessoa", param);

            // ************************
            // INSERT 
            // ************************

            foreach (var item in listObj)
            {
                var param2 = new DynamicParameters();
                param2.Add("@idPessoa", idPessoa, DbType.String);
                param2.Add("@idDadoVariavel", item.idDadoVariavel, DbType.Int32);

                result = sqlCommand.ExecuteSQLCommand("INSERT INTO TB_PessoaDV (idPessoa, idDadoVariavel) VALUES (@idPessoa, @idDadoVariavel)", param2);
            }

            return result;
        }
    }
}
