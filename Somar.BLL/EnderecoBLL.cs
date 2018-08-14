using Somar.DAL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.BLL
{
    public class EnderecoBLL
    {
        public List<EnderecoDTO> GetAllData()
        {
            EnderecoDAL cmd = new EnderecoDAL();
            return cmd.GetDataInDataBase(new EnderecoDTO());
        }

        public List<EnderecoDTO> GetDataWithParam(EnderecoDTO _endereco)
        {
            EnderecoDAL cmd = new EnderecoDAL();
            return cmd.GetDataInDataBase(_endereco);
        }

        public List<EnderecoDTO> GetEndereco(EnderecoDTO _endereco)
        {
            EnderecoDAL cmd = new EnderecoDAL();
            return cmd.GetEndereco(_endereco);
        }

        public EnderecoDTO GetByID(EnderecoDTO _endereco)
        {
            EnderecoDAL cmd = new EnderecoDAL();

            var result = cmd.GetDataInDataBase(_endereco);

            if (result.Count == 1)
                return result.SingleOrDefault();
            else
                throw new Exception("Erro de Gravação do Projeto");
        }
    }
}
