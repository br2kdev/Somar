using Somar.DAL.Repository;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.DAL
{
    public class MatriculaDAL
    {
        public List<MatriculaDTO> GetDataInDataBase(MatriculaDTO objectDTO)
        {
            RepList<MatriculaDTO> listPessoa = new RepList<MatriculaDTO>();

            string query = string.Empty;
            string whereClause = " WHERE 1 = 1 ";

            query += " SELECT A.*, B.nomePessoa, C.nomeTurma, D.nomeProjeto, ";
            query += " descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END ";
            query += " FROM TB_Matricula        A ";
            query += " LEFT JOIN TB_Pessoas     B ON A.idPessoa   = B.idPessoa";
            query += " LEFT JOIN TB_Turmas      C ON A.idTurma    = C.idTurma";
            query += " LEFT JOIN TB_Projetos    D ON C.idProjeto  = D.idProjeto";

            if (objectDTO.idPessoa != 0)
                whereClause += " AND A.idPessoa = " + objectDTO.idPessoa.ToString();

            //if (objectDTO.flagAtivo != null)
            //    whereClause += " AND flagAtivo like '%" + objectDTO.nomeProjeto + "%'";

            query += whereClause;

            return listPessoa.GetDataInDatabase(query);
        }
    }
}
