using Somar.DTO;
using Somar.DAL;
using System.Collections.Generic;

namespace Somar.BLL
{
    public class MatriculaBLL
    {
        public List<MatriculaDTO> GetSituacaoAluno(MatriculaDTO _item)
        {
            MatriculaDAL cmd = new MatriculaDAL();

            var listResult = cmd.GetSituacaoAluno(_item);

            foreach (var item in listResult)
            {
                item.descSituacao = (item.qtdeMatricula > 0) ? "Matriculado" : " - ";
            }

            return listResult;
        }

        public List<MatriculaDTO> GetAllData()
        {
            MatriculaDAL cmd = new MatriculaDAL();
            return cmd.GetDataInDataBase(new MatriculaDTO());
        }

        public List<MatriculaDTO> GetDataWithParam(MatriculaDTO _projeto)
        {
            MatriculaDAL cmd = new MatriculaDAL();
            return cmd.GetDataInDataBase(_projeto);
        }

        public int SaveMatricula(MatriculaDTO _item)
        {
            MatriculaDAL cmd = new MatriculaDAL();

            int result = 0;

            if (_item.idMatricula == 0)
                result = cmd.InsertData(_item);
            else
            {
                result = cmd.UpdateData(_item);

                if (result != 0)
                {
                    return _item.idMatricula;
                }
            }

            return result;
        }

        public int CancelarMatricula(MatriculaDTO _item)
        {
            MatriculaDAL cmd = new MatriculaDAL();

            return cmd.CancelarMatricula(_item);
        }

        public int ExcluirMatricula(MatriculaDTO _item)
        {
            MatriculaDAL cmd = new MatriculaDAL();

            return cmd.ExcluirMatricula(_item);
        }
    }
}
