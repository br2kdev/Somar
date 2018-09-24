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

        private string msg { get; set; }

        private int _Width;
        private int _Height;

        private bool _EnableClickButton1 = true;
        private bool _EnableClickButton2;

        private Bitmap _ImgButton1;
        private Bitmap _ImgButton2;

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

        public Bitmap ImgButton1
        {
            get
            {
                return _ImgButton1;
            }
            set
            {
                _ImgButton1 = value;
            }
        }

        public Bitmap ImgButton2
        {
            get
            {
                return _ImgButton2;
            }
            set
            {
                _ImgButton2 = value;
            }
        }

        public bool EnableClickButton1
        {
            get
            {
                return _EnableClickButton1;
            }
            set
            {
                _EnableClickButton1 = value;
            }
        }

        public bool EnableClickButton2
        {
            get
            {
                return _EnableClickButton2;
            }
            set
            {
                _EnableClickButton2 = value;
            }
        }

        #endregion

        #region Member Delegates

        private Delegate _PageMethod1;
        private Delegate _PageMethod2;

        public Delegate CallingMethod1
        {
            set { _PageMethod1 = value; }
        }

        public Delegate CallingMethod2
        {
            set { _PageMethod2 = value; }
        }

        #endregion

        public GridViewControl()
        {
            InitializeComponent();
        }

        #region Gridview Controls

        public void InitializeGridView<T>(T modelItem)
        {
            // ***************************************************************** //
            //  SET CUSTOM STYLE IN GRIDVIEW
            // ***************************************************************** //
            this.dataGridView1.AutoSize = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            // ***************************************************************** //
            //  SET COLUMNS IN GRIDVIEW
            // ***************************************************************** //

            var fields = new GridViewControlUtils().GetFields(modelItem);

            if (_EnableClickButton1)
            {
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.SortMode = DataGridViewColumnSortMode.NotSortable;
                img.Name = "Image1";
                img.HeaderText = "";
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                img.Width = 45;
                this.dataGridView1.Columns.Add(img);
            }

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

            if (_EnableClickButton2)
            {
                // Select Image
                DataGridViewImageColumn img2 = new DataGridViewImageColumn();
                img2.SortMode = DataGridViewColumnSortMode.NotSortable;
                img2.Name = "Image2";
                img2.HeaderText = "";
                img2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                img2.Width = 45;
                this.dataGridView1.Columns.Add(img2);
            }

            // -------------------------------------------------------------
            this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            this.dataGridView1.CellMouseLeave += new DataGridViewCellEventHandler(dataGridView1_CellMouseLeave);
            this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(dataGridView1_CellMouseEnter);

            // ***************************************************************** //
        }

        public void GridViewDataBind(DataTable result, string msg)
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
            if (e.RowIndex > -1)
            {
                int columnIndex1 = (this.dataGridView1.Columns["Image1"] != null) ? this.dataGridView1.Columns["Image1"].Index : -1;
                int columnIndex2 = (this.dataGridView1.Columns["Image2"] != null) ? this.dataGridView1.Columns["Image2"].Index : -1;

                if (e.ColumnIndex == columnIndex1)
                {
                    e.Value = (ImgButton1) ?? ProjetoSomarUI.Properties.Resources.icon_search24x24;
                }
                else if (e.ColumnIndex == columnIndex2)
                {
                    e.Value = (ImgButton2); //?? ProjetoSomarUI.Properties.Resources.icon;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int btn1Index = (this.dataGridView1.Columns["Image1"] != null) ? this.dataGridView1.Columns["Image1"].Index : -1;
                int btn2Index = (this.dataGridView1.Columns["Image2"] != null) ? this.dataGridView1.Columns["Image2"].Index : -1;

                if (e.ColumnIndex == btn1Index)
                {
                    int idClicked = Convert.ToInt32(this.dataGridView1[e.ColumnIndex+1, e.RowIndex].Value);

                    if (_PageMethod1 != null)
                    {
                        _PageMethod1.DynamicInvoke(idClicked);
                    }
                }
                else if (e.ColumnIndex == btn2Index)
                {
                    int idClicked = Convert.ToInt32(this.dataGridView1[e.ColumnIndex+1, e.RowIndex].Value);

                    if (_PageMethod2 != null)
                    {
                        _PageMethod2.DynamicInvoke(idClicked);
                    }
                }

                if (_EnableClickButton1  || _EnableClickButton2)
                {
                    
                }
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                Bitmap isImage = (Bitmap)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                dataGridView1.Cursor = Cursors.Hand;
            }
            catch(Exception exc)
            {
                dataGridView1.Cursor = Cursors.Default;
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Bitmap isImage = (Bitmap)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                dataGridView1.Cursor = Cursors.Hand;
            }
            catch (Exception exc)
            {
                dataGridView1.Cursor = Cursors.Default;
            }
        }

        #endregion

        public void btnExport(Relatorio _relatorio)
        {
            var _dataTable = (DataTable)dataGridView1.DataSource;

            Relatorios.FormReport frm = new Relatorios.FormReport(_relatorio, _dataTable);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
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
