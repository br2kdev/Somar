using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Somar.Shared;
using Somar.DTO;
using System.Drawing.Printing;
using System.Collections;
using ProjetoSomarUI.Modules;
using DGVPrinterHelper;
using ProjetoSomarUI.Relatorios;

namespace ProjetoSomarUI.Controls
{
    public partial class GridViewControl : UserControl
    {
        #region Member Variables

        ArrayList arrColumnLefts = new ArrayList();     // Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();    // Used to save column widths

        private string msg { get; set; }

        #region variables

        private DataTable _DataSource;
        private int _Width;
        private int _Height;

        public int ControlWidth
        {
            get
            {
                if (_Width == 0)
                    return dataGridView1.Width;
                else
                    return _Width;
            }
            set
            {
                _Width = value;
                dataGridView1.Width = _Width;
            }
        }

        public int ControlHeight
        {
            get
            {
                if (_Height == 0)
                    return dataGridView1.Height;
                else
                    return _Height;
            }
            set
            {
                _Height = value;
                dataGridView1.Height = _Height;
            }
        }

        #endregion

        #endregion

        #region Member Delegates

        private Delegate _PageMethod;

        public Delegate CallingPageMethod
        {
            set { _PageMethod = value; }
        }

        #endregion

        public GridViewControl()
        {
            InitializeComponent();

            //this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
            //this.printDocument1.BeginPrint += new PrintEventHandler(this.printDocument1_BeginPrint);
        }

        #region Gridview Controls

        public void InitializeGridView<T>(T modelItem, string msg)
        {

            msg = "Nenhum projeto encontrado";

            // ***************************************************************** //
            //  SET CUSTOM STYLE IN GRIDVIEW
            // ***************************************************************** //
            this.dataGridView1.AutoSize = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            // ***************************************************************** //
            /*
            this.dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            */

            /*            
            // Configure the DataGridView so that users can manually change 
            // only the column widths, which are set to fill mode. 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            */

            // ***************************************************************** //
            //  SET COLUMNS IN GRIDVIEW
            // ***************************************************************** //

            var fields = new GridViewControlUtils().GetFields(modelItem);

            // Edit Image
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.SortMode = DataGridViewColumnSortMode.NotSortable;
            img.Name = "Image";
            img.HeaderText = "";
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            img.Width = 45;
            this.dataGridView1.Columns.Add(img);

            // -------------------------------------------------------------

            // All Fields
            foreach (var item in fields)
            {
                DataGridViewTextBoxColumn dt = new DataGridViewTextBoxColumn();
                dt.DataPropertyName = item.Key;
                dt.HeaderText = item.Value;

                if (item.Key.Contains("nome"))
                    dt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                this.dataGridView1.Columns.Add(dt);
            }

            // -------------------------------------------------------------

            this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            this.dataGridView1.CellMouseLeave += new DataGridViewCellEventHandler(dataGridView1_CellMouseLeave);
            this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(dataGridView1_CellMouseEnter);

            // ***************************************************************** //
        }

        /*
        public void DataBind(DataTable dataTable)
        {
            DataSource = dataTable;
            dataGridView1.DataSource = ShowData(1);
        }
        */

        public void GridViewDataBind(DataTable result)
        {
            if (result.Rows.Count == 0)
            {
                dataGridView1.Visible = false;
                panelMessage.Visible = true;
                lblMessage.Text = msg;
            }
            else
            {
                dataGridView1.Visible = true;
                panelMessage.Visible = false;
                lblMessage.Text = "";
                dataGridView1.DataSource = result;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridView1.Columns["Image"].Index)
            {
                e.Value = ProjetoSomarUI.Properties.Resources.icon_search24x24;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if(e.RowIndex > -1)
                { 
                    int idClicked = Convert.ToInt32(this.dataGridView1[1, e.RowIndex].Value);

                    if (_PageMethod != null)
                    {
                        _PageMethod.DynamicInvoke(idClicked);
                    }

                    //MessageBox.Show("OK");
                    //userFunctionPointer.DynamicInvoke(idProjeto);

                    // CarregaDetalhes(idProjeto);

                    // MessageBox.Show("You have selected in image in " + e.RowIndex + " row.");
                    // MessageBox.Show("You have selected in image in " + this.dataGridView1[1, e.RowIndex].Value.ToString() + " row.");
                }
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (GridViewControlUtils.IsValidCellAddress(e.RowIndex, e.ColumnIndex))
                dataGridView1.Cursor = Cursors.Hand;
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (GridViewControlUtils.IsValidCellAddress(e.RowIndex, e.ColumnIndex))
                dataGridView1.Cursor = Cursors.Default;
        }

        #endregion

        public void btnExport(Relatorio _relatorio)
        {
            var _dataTable = (DataTable)dataGridView1.DataSource;

            Relatorios.FormReport frm = new Relatorios.FormReport(_relatorio, _dataTable);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();           

            //printDGVPrinter();
            //printWithResize();
            //Print.ShowPrintPreview(printDocument1);

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

            /*
            //Open the print preview dialog
            PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            objPPdialog.Document = printDocument1;
            objPPdialog.ShowDialog();
            */
        }

        public void printDGVPrinter()
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "Projetos";
            printer.SubTitle = " " + DateTime.Now.ToShortDateString();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;
            //printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.DataWidth;
            printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;

            //Hide Columns
            printer.HideColumns.Add("Image");

            printer.HeaderCellAlignment = StringAlignment.Center;
            printer.Footer = "Somar - ";
            printer.FooterSpacing = 15;

            printer.HideColumns.Add(" ");

            printer.CellFormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoWrap;
            printer.PrintSettings.DefaultPageSettings.PaperSize = new PaperSize("210 x 297 mm", 800, 800);
            printer.PrintSettings.DefaultPageSettings.Landscape = true;
            //printer.PrintSettings.DefaultPageSettings. = true;
            printer.PrintSettings.DefaultPageSettings.Margins = new Margins(3, 3, 3, 3);

            //printer.PrintDataGridView(dataGridView1);
            printer.PrintPreviewDataGridView(dataGridView1);

        }

    }
}
