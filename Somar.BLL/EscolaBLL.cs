using Somar.DAL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Somar.BLL
{
    public class EscolaBLL
    {
        public List<EscolaDTO> GetAllData()
        {
            EscolaDAL cmd = new EscolaDAL();
            return cmd.GetDataInDataBase(new EscolaDTO());
        }

        public List<EscolaDTO> GetDataWithParam(EscolaDTO _projeto)
        {
            EscolaDAL cmd = new EscolaDAL();
            return cmd.GetDataInDataBase(_projeto);
        }

        public EscolaDTO GetByID(EscolaDTO _escola)
        {
            EscolaDAL cmd = new EscolaDAL();

            var result = cmd.GetDataInDataBase(_escola);

            if (result.Count > 0)
            {
                if (result[0].idEndereco != 0)
                {
                    EnderecoDAL cmdEndereco = new EnderecoDAL();
                     result[0].endereco = cmdEndereco.GetEndereco(result[0].idEndereco);
                }
                
                return result.SingleOrDefault();
            }
            else
                throw new Exception("Ocorreu um erro!");
        }

        public int SaveEscola(EscolaDTO item)
        {
            EscolaDAL cmd = new EscolaDAL();
            EnderecoDAL cmdEndereco = new EnderecoDAL();
            ContatoDAL cmdContato = new ContatoDAL();

            int result = 0;

            if (item.idEscola == 0)
            {

                // *********************************************** //
                // ENDEREÇO
                // *********************************************** //
                if (item.idEndereco == 0)
                {
                    result = cmdEndereco.InsertData(item.endereco);

                    item.idEndereco = result;
                }
                else
                {
                    item.endereco.idEndereco = item.idEndereco;

                    result = cmdEndereco.UpdateData(item.endereco);
                }

                result = cmd.InsertData(item);
            }
            else
            {

                // *********************************************** //
                // ENDEREÇO
                // *********************************************** //
                if (item.idEndereco == 0)
                {
                    result = cmdEndereco.InsertData(item.endereco);

                    item.idEndereco = result;
                }
                else
                {
                    item.endereco.idEndereco = item.idEndereco;

                    result = cmdEndereco.UpdateData(item.endereco);
                }

                result = cmd.UpdateData(item);

                if (result != 0)
                {
                    return item.idEscola;
                }
            }

            return result;
        }

        public int RemoveProject(EscolaDTO _projeto)
        {
            EscolaDAL cmd = new EscolaDAL();

            return cmd.UpdateData(_projeto);
        }

    }
}
