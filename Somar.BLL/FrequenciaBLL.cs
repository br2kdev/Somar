using Somar.DAL;
using Somar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Somar.BLL
{
    public class FrequenciaBLL
    {
        public List<FrequenciaDTO> GetAllData(FrequenciaDTO item)
        {
            FrequenciaDAL cmd = new FrequenciaDAL();
            return cmd.GetDataInDataBase(item);
        }

        public List<FrequenciaDTO> GetDetalhesFrequencia(FrequenciaDTO item)
        {
            FrequenciaDAL cmd = new FrequenciaDAL();
            return cmd.GetDetalhesFrequencia(item);
        }

        public FrequenciaDTO GetByID(FrequenciaDTO item)
        {
            FrequenciaDAL cmd = new FrequenciaDAL();

            var result = cmd.GetDataInDataBase(item);

            if (result.Count == 1)
                return result.SingleOrDefault();
            else
                throw new Exception("Erro de Gravação do Projeto");
        }

        public int SalvarFrequencia(FrequenciaDTO _item)
        {
            FrequenciaDAL cmd = new FrequenciaDAL();

            int result = 0;

            if (_item.idFrequencia == 0)
            { 
                result = cmd.InsertData(_item);

                if(result != 0)
                {
                    cmd.GerarFrequencia(new FrequenciaDTO() { idFrequencia = result, dataFrequencia = _item.dataFrequencia });
                }
            }
            else
            {
                result = cmd.UpdateData(_item);

                if (result != 0)
                {
                    return _item.idFrequencia;
                }
            }

            return result;
        }
    }
}
