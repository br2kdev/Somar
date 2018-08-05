using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.Shared
{
    public class GridViewControl
    {
        public Dictionary<string, string> GetFields<T>(T className)
        {
            Dictionary<String, String> fieldList = new Dictionary<String, String>();

            Type typeName = className.GetType();

            var properties = typeName.GetProperties();

            foreach (var item in properties)
            {
                var listCustom = item.CustomAttributes;

                if (listCustom.Count() > 0)
                {
                    var prop = listCustom.SingleOrDefault();
                    var DisplayName = prop.ConstructorArguments.SingleOrDefault().Value.ToString();
                    fieldList.Add(item.Name, DisplayName);
                }
            }

            return fieldList;
        }

        public static bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            if (columnIndex == 0)
                return true;
            else
                return false;
        }
    }
}
