using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoSomarUI.Relatorios
{
    public partial class FormPainel : Form
    {
        public FormPainel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Relatorios.FormReport frm = new Relatorios.FormReport();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Relatorios.FormReport frm = new Relatorios.FormReport();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }
    }
}
