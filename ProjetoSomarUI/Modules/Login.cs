using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Somar.BLL;

namespace ProjetoSomarUI
{

    public class Login
    {
        //decalre properties 
        public string Username { get; set; }
        public string Userpassword { get; set; }

        public Login()
        {

        }

        internal bool SignIn(string user, string pass)
        {
            UsuarioBLL usuario = new UsuarioBLL();
            var result = usuario.GetUserByLogin(user, pass);

            if(result != null)
                return true;
            else
                return false;
        }

        internal bool IsLoggedIn(string user, string pass)
        {
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Informe o login");
                return false;

            }
            else if (StringValidator(user) == true)
            {
                MessageBox.Show("Enter only text here");
                ClearTexts(user, pass);
                return false;
            }
            else
            {
                if (Username != user)
                {
                    MessageBox.Show("Nome de Usuário inválido");
                    ClearTexts(user, pass);
                    return false;
                }
                else
                {
                    if (string.IsNullOrEmpty(pass))
                    {
                        MessageBox.Show("Enter the passowrd!");
                        return false;
                    }
                    else if (IntegerValidator(pass) == true)
                    {
                        MessageBox.Show("Enter only integer here");
                        return false;
                    }
                    else if (Userpassword != pass)
                    {
                        MessageBox.Show("Password is incorrect");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private bool StringValidator(string input)
        {
            string pattern = "[^a-zA-Z]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IntegerValidator(string input)
        {
            string pattern = "[^0-9]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ClearTexts(string user, string pass)
        {
            user = String.Empty;
            pass = String.Empty;
        }

    }
}
