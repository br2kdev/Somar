namespace ProjetoSomarUI.Relatorios
{
    partial class FormVisualizador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.GenerateReport = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.somarDatabaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.somarDatabaseDataSet = new ProjetoSomarUI.SomarDatabaseDataSet();
            this.projetosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projetosTableAdapter = new ProjetoSomarUI.SomarDatabaseDataSetTableAdapters.ProjetosTableAdapter();
            this.projetosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.somarDatabaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.somarDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetosBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // GenerateReport
            // 
            this.GenerateReport.Location = new System.Drawing.Point(663, 13);
            this.GenerateReport.Name = "GenerateReport";
            this.GenerateReport.Size = new System.Drawing.Size(75, 23);
            this.GenerateReport.TabIndex = 0;
            this.GenerateReport.Text = "button1";
            this.GenerateReport.UseVisualStyleBackColor = true;
            this.GenerateReport.Click += new System.EventHandler(this.GenerateReport_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetProjetos";
            reportDataSource1.Value = this.projetosBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProjetoSomarUI.Relatorios.RelProjetos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(995, 513);
            this.reportViewer1.TabIndex = 1;
            // 
            // somarDatabaseDataSetBindingSource
            // 
            this.somarDatabaseDataSetBindingSource.DataSource = this.somarDatabaseDataSet;
            this.somarDatabaseDataSetBindingSource.Position = 0;
            // 
            // somarDatabaseDataSet
            // 
            this.somarDatabaseDataSet.DataSetName = "SomarDatabaseDataSet";
            this.somarDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // projetosBindingSource
            // 
            this.projetosBindingSource.DataMember = "Projetos";
            this.projetosBindingSource.DataSource = this.somarDatabaseDataSetBindingSource;
            // 
            // projetosTableAdapter
            // 
            this.projetosTableAdapter.ClearBeforeFill = true;
            // 
            // projetosBindingSource1
            // 
            this.projetosBindingSource1.DataMember = "Projetos";
            this.projetosBindingSource1.DataSource = this.somarDatabaseDataSetBindingSource;
            // 
            // FormVisualizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 513);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.GenerateReport);
            this.Name = "FormVisualizador";
            this.Text = "FormVisualizador";
            this.Load += new System.EventHandler(this.FormVisualizador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.somarDatabaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.somarDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetosBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button GenerateReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource somarDatabaseDataSetBindingSource;
        private SomarDatabaseDataSet somarDatabaseDataSet;
        private System.Windows.Forms.BindingSource projetosBindingSource;
        private SomarDatabaseDataSetTableAdapters.ProjetosTableAdapter projetosTableAdapter;
        private System.Windows.Forms.BindingSource projetosBindingSource1;
    }
}