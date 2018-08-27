using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoSomarUI
{
    public partial class FormLogin : Form
    {
        private SplashScreen splashScreen;

        private bool done = false;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtLogin.Text;
            string pass = txtSenha.Text;

            Login login = new Login();

            if (login.SignIn(user, pass))
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Login e senha incorreto!");
                this.DialogResult = DialogResult.None;
            }
        }

        /*
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //enter your code for forget password case 
            MessageBox.Show("Under development");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Enter your code for registration form of your choice 
            MessageBox.Show("Under development");
        }
        */
    }
}
