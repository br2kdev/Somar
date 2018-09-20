using Somar.DAL.Repository;
using Somar.DTO;
using System.Collections.Generic;

namespace Somar.DAL
{
    public class DashboardDAL
    {

        public List<DashboardDTO> GetAlunosPorEscola()
        {
            RepList<DashboardDTO> resultList = new RepList<DashboardDTO>();

            string query = string.Empty;
            string whereClause = "";

            query += " SELECT id = A.idEscola, displayName = A.nomeEscola, displayCount = COUNT(1)";
            query += " FROM TB_Escolas       A";
            query += " INNER JOIN TB_Pessoas B ON A.idEscola = B.idEscola";
            query += " GROUP BY A.idEscola, A.nomeEscola";

            /*
            if (objectDTO.idPessoa != 0)
                whereClause += " AND A.idPessoa = " + objectDTO.idPessoa.ToString();

            if (!string.IsNullOrEmpty(objectDTO.nomePessoa))
                whereClause += " AND A.nomePessoa like '%" + objectDTO.nomePessoa + "%'";
            */

            return resultList.GetDataInDatabase(query);
        }

        public List<DashboardDTO> GetAlunosPorProjeto()
        {
            RepList<DashboardDTO> resultList = new RepList<DashboardDTO>();

            string query = string.Empty;
            string whereClause = "";

            query += " SELECT id = C.idProjeto, displayName = C.nomeProjeto, displayCount = COUNT(1)";
            query += " FROM TB_Matricula      A";
            query += " INNER JOIN TB_Turmas   B ON A.idTurma = B.idTurma";
            query += " INNER JOIN TB_Projetos C ON B.idProjeto = C.idProjeto";
            query += " WHERE A.dtCancelamento IS NOT NULL";
            query += " GROUP BY C.idProjeto, C.nomeProjeto";

            /*
            if (objectDTO.idPessoa != 0)
                whereClause += " AND A.idPessoa = " + objectDTO.idPessoa.ToString();

            if (!string.IsNullOrEmpty(objectDTO.nomePessoa))
                whereClause += " AND A.nomePessoa like '%" + objectDTO.nomePessoa + "%'";
            */

            return resultList.GetDataInDatabase(query);
        }

        public List<DashboardDTO> GetAlunosPorBairro()
        {
            RepList<DashboardDTO> resultList = new RepList<DashboardDTO>();

            string query = string.Empty;
            string whereClause = "";

            query += " SELECT id = B.idBairro, displayName = C.bai_no, displayCount = COUNT(1)";
            query += " FROM TB_Pessoas           A";
            query += " INNER JOIN TB_Enderecos   B ON A.idEndereco = B.idEndereco";
            query += " INNER JOIN TB_CEP_Bairro  C ON B.idBairro = C.bai_nu_sequencial";
            query += " GROUP BY B.idBairro, C.bai_no";

            /*
            if (objectDTO.idPessoa != 0)
                whereClause += " AND A.idPessoa = " + objectDTO.idPessoa.ToString();

            if (!string.IsNullOrEmpty(objectDTO.nomePessoa))
                whereClause += " AND A.nomePessoa like '%" + objectDTO.nomePessoa + "%'";
            */

            //query += whereClause;

            return resultList.GetDataInDatabase(query);
        }

    }
}
