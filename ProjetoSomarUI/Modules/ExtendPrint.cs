using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoSomarUI.Modules
{
    public static class ExtendPrint
    {
        public static void ShowPrintPreview(PrintDocument printDocument1)
        {
            /*
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }
            */

            //Open the print preview dialog
            PrintPreviewDialog objPPdialog = new PrintPreviewDialog();

            objPPdialog.Document = printDocument1;
            objPPdialog.ShowDialog();
        }
    }
}
