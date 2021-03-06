﻿namespace ProjetoSomarUI.Cadastros
{
    partial class FormProjetos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProjetos));
            this.panelEdit = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtResponsavel = new System.Windows.Forms.TextBox();
            this.txtDataInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTempoProjeto = new System.Windows.Forms.Panel();
            this.txtdtTermino = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTempoProjeto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDuracao = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnVoltar1 = new System.Windows.Forms.Button();
            this.txtEditMode = new System.Windows.Forms.TextBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtdtCadastro = new System.Windows.Forms.TextBox();
            this.txtDataAlteracao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNomeAlteracao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panelConsulta = new System.Windows.Forms.Panel();
            this.Grid = new ProjetoSomarUI.Controls.GridViewControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint2 = new System.Windows.Forms.Button();
            this.panelEdit.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlTempoProjeto.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelConsulta.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEdit
            // 
            this.panelEdit.BackColor = System.Drawing.SystemColors.Control;
            this.panelEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEdit.Controls.Add(this.panel1);
            this.panelEdit.Controls.Add(this.panel3);
            this.panelEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdit.Location = new System.Drawing.Point(0, 0);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(1005, 641);
            this.panelEdit.TabIndex = 40;
            this.panelEdit.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundTitle;
            this.panel1.Controls.Add(this.btnPrint2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 60);
            this.panel1.TabIndex = 64;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ProjetoSomarUI.Properties.Resources.icon_projeto32x32;
            this.pictureBox1.InitialImage = global::ProjetoSomarUI.Properties.Resources.icon_projeto32x32;
            this.pictureBox1.Location = new System.Drawing.Point(17, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 35);
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditar.Image = global::ProjetoSomarUI.Properties.Resources.icon_edit2_32x32;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(643, 9);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 43);
            this.btnEditar.TabIndex = 68;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(768, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 77;
            this.label8.Text = "Código:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.lblCodigo.Location = new System.Drawing.Point(836, 12);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(124, 38);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(64, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(276, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DETALHES DO PROJETO";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtResponsavel);
            this.panel3.Controls.Add(this.txtDataInicio);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pnlTempoProjeto);
            this.panel3.Controls.Add(this.cmbTempoProjeto);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtDuracao);
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.cmbStatus);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtDescricao);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtNome);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panel3.Location = new System.Drawing.Point(14, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(973, 546);
            this.panel3.TabIndex = 66;
            // 
            // txtResponsavel
            // 
            this.txtResponsavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtResponsavel.Location = new System.Drawing.Point(644, 284);
            this.txtResponsavel.MaxLength = 100;
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(311, 27);
            this.txtResponsavel.TabIndex = 102;
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.AllowDrop = true;
            this.txtDataInicio.Enabled = false;
            this.txtDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataInicio.Location = new System.Drawing.Point(133, 321);
            this.txtDataInicio.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.txtDataInicio.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(128, 26);
            this.txtDataInicio.TabIndex = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(32, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 101;
            this.label3.Text = "Data de Inicio:";
            // 
            // pnlTempoProjeto
            // 
            this.pnlTempoProjeto.Controls.Add(this.txtdtTermino);
            this.pnlTempoProjeto.Controls.Add(this.label2);
            this.pnlTempoProjeto.Location = new System.Drawing.Point(263, 313);
            this.pnlTempoProjeto.Name = "pnlTempoProjeto";
            this.pnlTempoProjeto.Size = new System.Drawing.Size(274, 49);
            this.pnlTempoProjeto.TabIndex = 97;
            // 
            // txtdtTermino
            // 
            this.txtdtTermino.AllowDrop = true;
            this.txtdtTermino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtdtTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdtTermino.Location = new System.Drawing.Point(130, 8);
            this.txtdtTermino.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.txtdtTermino.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.txtdtTermino.Name = "txtdtTermino";
            this.txtdtTermino.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtdtTermino.Size = new System.Drawing.Size(128, 26);
            this.txtdtTermino.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 85;
            this.label2.Text = "Data de Termino:";
            // 
            // cmbTempoProjeto
            // 
            this.cmbTempoProjeto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTempoProjeto.Enabled = false;
            this.cmbTempoProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cmbTempoProjeto.FormattingEnabled = true;
            this.cmbTempoProjeto.Items.AddRange(new object[] {
            "Definido",
            "Indeterminado"});
            this.cmbTempoProjeto.Location = new System.Drawing.Point(134, 283);
            this.cmbTempoProjeto.Name = "cmbTempoProjeto";
            this.cmbTempoProjeto.Size = new System.Drawing.Size(128, 28);
            this.cmbTempoProjeto.TabIndex = 96;
            this.cmbTempoProjeto.SelectedIndexChanged += new System.EventHandler(this.cmbTempoProjeto_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(5, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 95;
            this.label4.Text = "Tempo de Projeto:";
            // 
            // txtDuracao
            // 
            this.txtDuracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtDuracao.Location = new System.Drawing.Point(644, 326);
            this.txtDuracao.MaxLength = 100;
            this.txtDuracao.Name = "txtDuracao";
            this.txtDuracao.Size = new System.Drawing.Size(259, 27);
            this.txtDuracao.TabIndex = 94;
            this.txtDuracao.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblStatus.Location = new System.Drawing.Point(762, 26);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.TabIndex = 93;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Enabled = false;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Desativado",
            "Ativo"});
            this.cmbStatus.Location = new System.Drawing.Point(831, 18);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(124, 28);
            this.cmbStatus.TabIndex = 92;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btnVoltar1);
            this.panel2.Controls.Add(this.txtEditMode);
            this.panel2.Controls.Add(this.btnGravar);
            this.panel2.Location = new System.Drawing.Point(0, 387);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 51);
            this.panel2.TabIndex = 65;
            // 
            // btnVoltar1
            // 
            this.btnVoltar1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnVoltar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVoltar1.Image = global::ProjetoSomarUI.Properties.Resources.icon_back32x32;
            this.btnVoltar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar1.Location = new System.Drawing.Point(386, 6);
            this.btnVoltar1.Name = "btnVoltar1";
            this.btnVoltar1.Size = new System.Drawing.Size(92, 40);
            this.btnVoltar1.TabIndex = 69;
            this.btnVoltar1.Text = "VOLTAR";
            this.btnVoltar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar1.UseVisualStyleBackColor = true;
            this.btnVoltar1.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // txtEditMode
            // 
            this.txtEditMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtEditMode.Location = new System.Drawing.Point(855, 19);
            this.txtEditMode.Name = "txtEditMode";
            this.txtEditMode.Size = new System.Drawing.Size(100, 26);
            this.txtEditMode.TabIndex = 68;
            this.txtEditMode.Visible = false;
            // 
            // btnGravar
            // 
            this.btnGravar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGravar.Enabled = false;
            this.btnGravar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnGravar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGravar.Image = global::ProjetoSomarUI.Properties.Resources.icon_saveColor32x32;
            this.btnGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGravar.Location = new System.Drawing.Point(513, 6);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(98, 40);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "SALVAR";
            this.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Controls.Add(this.txtdtCadastro);
            this.groupBox3.Controls.Add(this.txtDataAlteracao);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtNomeAlteracao);
            this.groupBox3.Location = new System.Drawing.Point(0, 475);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(972, 60);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            // 
            // txtdtCadastro
            // 
            this.txtdtCadastro.Enabled = false;
            this.txtdtCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtdtCadastro.Location = new System.Drawing.Point(118, 18);
            this.txtdtCadastro.MaxLength = 10;
            this.txtdtCadastro.Name = "txtdtCadastro";
            this.txtdtCadastro.Size = new System.Drawing.Size(124, 27);
            this.txtdtCadastro.TabIndex = 94;
            this.txtdtCadastro.TabStop = false;
            this.txtdtCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDataAlteracao
            // 
            this.txtDataAlteracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtDataAlteracao.Location = new System.Drawing.Point(837, 18);
            this.txtDataAlteracao.MaxLength = 100;
            this.txtDataAlteracao.Name = "txtDataAlteracao";
            this.txtDataAlteracao.Size = new System.Drawing.Size(118, 27);
            this.txtDataAlteracao.TabIndex = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label6.Location = new System.Drawing.Point(12, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 17);
            this.label6.TabIndex = 95;
            this.label6.Text = "Data Cadastro:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label11.Location = new System.Drawing.Point(271, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 17);
            this.label11.TabIndex = 77;
            this.label11.Text = "Última Alteração:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label9.Location = new System.Drawing.Point(729, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 17);
            this.label9.TabIndex = 79;
            this.label9.Text = "Data Alteração:";
            // 
            // txtNomeAlteracao
            // 
            this.txtNomeAlteracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtNomeAlteracao.Location = new System.Drawing.Point(386, 18);
            this.txtNomeAlteracao.MaxLength = 100;
            this.txtNomeAlteracao.Name = "txtNomeAlteracao";
            this.txtNomeAlteracao.Size = new System.Drawing.Size(329, 27);
            this.txtNomeAlteracao.TabIndex = 78;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label7.Location = new System.Drawing.Point(546, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 89;
            this.label7.Text = "Responsável:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtDescricao.Location = new System.Drawing.Point(134, 56);
            this.txtDescricao.MaxLength = 400;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(821, 219);
            this.txtDescricao.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(17, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 85;
            this.label5.Text = "Descrição:";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.SystemColors.Window;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtNome.Location = new System.Drawing.Point(134, 19);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(571, 27);
            this.txtNome.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label10.Location = new System.Drawing.Point(17, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 17);
            this.label10.TabIndex = 77;
            this.label10.Text = "Projeto:";
            // 
            // panelConsulta
            // 
            this.panelConsulta.Controls.Add(this.Grid);
            this.panelConsulta.Controls.Add(this.groupBox1);
            this.panelConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConsulta.Location = new System.Drawing.Point(0, 0);
            this.panelConsulta.Name = "panelConsulta";
            this.panelConsulta.Size = new System.Drawing.Size(1005, 641);
            this.panelConsulta.TabIndex = 39;
            // 
            // Grid
            // 
            this.Grid.AutoSize = true;
            this.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Grid.ControlHeight = 547;
            this.Grid.ControlWidth = 979;
            this.Grid.EnableClickButton1 = true;
            this.Grid.EnableClickButton2 = false;
            this.Grid.ImgButton1 = null;
            this.Grid.ImgButton2 = null;
            this.Grid.Location = new System.Drawing.Point(14, 87);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(982, 550);
            this.Grid.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundFilter;
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.cmbSearchType);
            this.groupBox1.Controls.Add(this.btnNovo);
            this.groupBox1.Controls.Add(this.btnAll);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1005, 79);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrint.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.icon_printer32x32;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.Location = new System.Drawing.Point(796, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(58, 46);
            this.btnPrint.TabIndex = 36;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.15F);
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "Nome do Projeto",
            "Código do Projeto"});
            this.cmbSearchType.Location = new System.Drawing.Point(112, 30);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(157, 26);
            this.cmbSearchType.TabIndex = 35;
            this.cmbSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSearchType_SelectedIndexChanged);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNovo.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.icon_add48x48;
            this.btnNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNovo.FlatAppearance.BorderSize = 2;
            this.btnNovo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnNovo.Location = new System.Drawing.Point(923, 12);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 60);
            this.btnNovo.TabIndex = 28;
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAll.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.icon_reload232x32;
            this.btnAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAll.Location = new System.Drawing.Point(698, 19);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(58, 46);
            this.btnAll.TabIndex = 34;
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.icon_search32x32;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(632, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 48);
            this.btnSearch.TabIndex = 33;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtSearch.Location = new System.Drawing.Point(275, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(350, 26);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Consultar por:";
            // 
            // btnPrint2
            // 
            this.btnPrint2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrint2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint2.BackgroundImage")));
            this.btnPrint2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint2.Location = new System.Drawing.Point(566, 8);
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.Size = new System.Drawing.Size(58, 46);
            this.btnPrint2.TabIndex = 81;
            this.btnPrint2.UseVisualStyleBackColor = false;
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // FormProjetos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1005, 641);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.panelConsulta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProjetos";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROJETOS";
            this.Load += new System.EventHandler(this.FormProjetos_Load);
            this.panelEdit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlTempoProjeto.ResumeLayout(false);
            this.pnlTempoProjeto.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelConsulta.ResumeLayout(false);
            this.panelConsulta.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelConsulta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lblCodigo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtEditMode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDataAlteracao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNomeAlteracao;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnVoltar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtdtCadastro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDuracao;
        private System.Windows.Forms.Panel pnlTempoProjeto;
        private System.Windows.Forms.DateTimePicker txtdtTermino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTempoProjeto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtDataInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResponsavel;
        private System.Windows.Forms.Button btnPrint;
        private Controls.GridViewControl Grid;
        private System.Windows.Forms.Button btnPrint2;
    }
}