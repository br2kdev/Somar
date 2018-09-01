using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.Shared
{
    public static class Functions
    {
        public static int CalcularIdade(DateTime dtNascimento)
        {
            int idade = DateTime.Now.Year - dtNascimento.Year;
            if (DateTime.Now.Month < dtNascimento.Month || (DateTime.Now.Month == dtNascimento.Month && DateTime.Now.Day < dtNascimento.Day))
                idade--;

            return idade;
        }

        public static string FirstCharToUpper(string input)
        {
            string result = string.Empty;

            if (!String.IsNullOrEmpty(input))
                result = input.Length > 1 ? char.ToUpper(input[0]) + input.Substring(1) : input.ToUpper();

            return result;
        }

        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            var elementType = typeof(T);
            var ds = new DataSet("result");
            var t = new DataTable();
            ds.Tables.Add(t);

            if (elementType.IsValueType)
            {
                var colType = Nullable.GetUnderlyingType(elementType) ?? elementType;
                t.Columns.Add(elementType.Name, colType);

            }
            else
            {
                //add a column to table for each public property on T
                foreach (var propInfo in elementType.GetProperties())
                {
                    var colType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;
                    t.Columns.Add(propInfo.Name, colType);
                }
            }

            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                var row = t.NewRow();

                if (elementType.IsValueType)
                {
                    row[elementType.Name] = item;
                }
                else
                {
                    foreach (var propInfo in elementType.GetProperties())
                    {
                        row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                    }
                }
                t.Rows.Add(row);
            }

            return ds;
        }
    }
}
