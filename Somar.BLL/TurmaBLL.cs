using Somar.DAL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Somar.BLL
{
    public class TurmaBLL
    {
        public List<TurmaDTO> GetAllData()
        {
            TurmaDAL cmd = new TurmaDAL();
            return cmd.GetDataInDataBase(new TurmaDTO());
        }

        public List<TurmaDTO> GetDataWithParam(TurmaDTO _projeto)
        {
            TurmaDAL cmd = new TurmaDAL();
            return cmd.GetDataInDataBase(_projeto);
        }

        public List<TurmaDTO> GetTurmasPorProjeto(int _idProjeto)
        {
            TurmaDAL cmd = new TurmaDAL();
            return cmd.GetTurmasPorProjeto(_idProjeto);
        }

        public TurmaDTO GetByID(TurmaDTO _projeto)
        {
            TurmaDAL cmd = new TurmaDAL();

            var result = cmd.GetDataInDataBase(_projeto);

            if (result.Count == 1)
                return result.SingleOrDefault();
            else
                throw new Exception("Erro de Gravação do Projeto");
        }

        public int SaveProject(TurmaDTO _projeto)
        {
            TurmaDAL cmd = new TurmaDAL();

            int result = 0;

            if (_projeto.idTurma == 0)
                result = cmd.InsertData(_projeto);
            else
            {
                result = cmd.UpdateData(_projeto);

                if (result != 0)
                {
                    return _projeto.idTurma;
                }
            }

            return result;
        }

        public int RemoveProject(TurmaDTO _projeto)
        {
            TurmaDAL cmd = new TurmaDAL();

            return cmd.UpdateData(_projeto);
        }
    }
}
