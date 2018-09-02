using Somar.DAL;
using Somar.DTO;
using System.Collections.Generic;

namespace Somar.BLL
{
    public class FrequenciaBLL
    {
        public List<FrequenciaDTO> GetAllData(FrequenciaDTO item)
        {
            FrequenciaDAL cmd = new FrequenciaDAL();
            return cmd.GetDataInDataBase(item);
        }

        public int SalvarFrequencia(FrequenciaDTO _item)
        {
            FrequenciaDAL cmd = new FrequenciaDAL();

            int result = 0;

            if (_item.idFrequencia == 0)
                result = cmd.InsertData(_item);
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
