using Somar.DTO;
using Somar.DAL;
using System.Collections.Generic;

namespace Somar.BLL
{
    public class MatriculaBLL
    {
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
    }
}
