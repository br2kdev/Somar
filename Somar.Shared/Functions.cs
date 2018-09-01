using System;
using System.Collections.Generic;
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
    }
}
