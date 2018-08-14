using Somar.DAL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Somar.BLL
{
    public class PessoaBLL
    {
        public List<PessoaDTO> GetAllData()
        {
            PessoaDAL cmd = new PessoaDAL();
            return cmd.GetDataInDataBase(new PessoaDTO());
        }

        public List<PessoaDTO> GetDataWithParam(PessoaDTO _projeto)
        {
            PessoaDAL cmd = new PessoaDAL();
            return cmd.GetDataInDataBase(_projeto);
        }

        public PessoaDTO GetByID(PessoaDTO _projeto)
        {
            PessoaDAL cmd = new PessoaDAL();

            var result = cmd.GetDataInDataBase(_projeto);

            if (result.Count == 1)
                return result.SingleOrDefault();
            else
                throw new Exception("Erro de Gravação do Projeto");
        }

        public int SaveProject(PessoaDTO _projeto)
        {
            PessoaDAL cmd = new PessoaDAL();

            int result = 0;

            if (_projeto.idPessoa == 0)
                result = cmd.InsertData(_projeto);
            else
            {
                result = cmd.UpdateData(_projeto);

                if (result != 0)
                {
                    return _projeto.idPessoa;
                }
            }

            return result;
        }

        public int RemoveProject(PessoaDTO _projeto)
        {
            PessoaDAL cmd = new PessoaDAL();

            return cmd.UpdateData(_projeto);
        }
    }
}
