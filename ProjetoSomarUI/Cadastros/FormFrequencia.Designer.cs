namespace ProjetoSomarUI.Cadastros
{
    partial class FormFrequencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFrequencia));
            this.label12 = new System.Windows.Forms.Label();
            this.lblProjeto = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelMessage2 = new System.Windows.Forms.Panel();
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.txtdtFrequencia = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTurmaEdit = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbProjetoEdit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnGravar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnVoltar1 = new System.Windows.Forms.Button();
            this.txtEditMode = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtdtCadastro = new System.Windows.Forms.TextBox();
            this.txtDataAlteracao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNomeAlteracao = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.cmbTurma = new System.Windows.Forms.ComboBox();
            this.cmbProjeto = new System.Windows.Forms.ComboBox();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.panelConsulta = new System.Windows.Forms.Panel();
            this.Grid = new ProjetoSomarUI.Controls.GridViewControl();
            this.btnGerarLista = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelMessage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelEdit.SuspendLayout();
            this.panelConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(322, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 111;
            this.label12.Text = "Turma:";
            // 
            // lblProjeto
            // 
            this.lblProjeto.AutoSize = true;
            this.lblProjeto.BackColor = System.Drawing.Color.Transparent;
            this.lblProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjeto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblProjeto.Location = new System.Drawing.Point(21, 17);
            this.lblProjeto.Name = "lblProjeto";
            this.lblProjeto.Size = new System.Drawing.Size(62, 16);
            this.lblProjeto.TabIndex = 31;
            this.lblProjeto.Text = "Projeto:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundTitle;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 51);
            this.panel1.TabIndex = 64;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.lblTitle.Location = new System.Drawing.Point(59, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(385, 26);
            this.lblTitle.TabIndex = 79;
            this.lblTitle.Text = "FREQUENCIA (Lançamento de faltas)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ProjetoSomarUI.Properties.Resources.icon_projeto32x32;
            this.pictureBox1.InitialImage = global::ProjetoSomarUI.Properties.Resources.icon_projeto32x32;
            this.pictureBox1.Location = new System.Drawing.Point(17, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 35);
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(768, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 77;
            this.label8.Text = "Código:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.lblCodigo.Location = new System.Drawing.Point(859, 6);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(124, 38);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panelMessage2);
            this.panel3.Controls.Add(this.txtdtFrequencia);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cmbTurmaEdit);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.cmbProjetoEdit);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Controls.Add(this.btnGravar);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panel3.Location = new System.Drawing.Point(4, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(997, 581);
            this.panel3.TabIndex = 66;
            // 
            // panelMessage2
            // 
            this.panelMessage2.Controls.Add(this.lblMessage2);
            this.panelMessage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.panelMessage2.Location = new System.Drawing.Point(3, 70);
            this.panelMessage2.Name = "panelMessage2";
            this.panelMessage2.Size = new System.Drawing.Size(987, 63);
            this.panelMessage2.TabIndex = 47;
            this.panelMessage2.Visible = false;
            // 
            // lblMessage2
            // 
            this.lblMessage2.AutoSize = true;
            this.lblMessage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblMessage2.Location = new System.Drawing.Point(9, 23);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(41, 20);
            this.lblMessage2.TabIndex = 1;
            this.lblMessage2.Text = "Text";
            // 
            // txtdtFrequencia
            // 
            this.txtdtFrequencia.AllowDrop = true;
            this.txtdtFrequencia.Enabled = false;
            this.txtdtFrequencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtdtFrequencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdtFrequencia.Location = new System.Drawing.Point(55, 13);
            this.txtdtFrequencia.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.txtdtFrequencia.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.txtdtFrequencia.Name = "txtdtFrequencia";
            this.txtdtFrequencia.Size = new System.Drawing.Size(128, 26);
            this.txtdtFrequencia.TabIndex = 123;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 122;
            this.label1.Text = "Data:";
            // 
            // cmbTurmaEdit
            // 
            this.cmbTurmaEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurmaEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cmbTurmaEdit.FormattingEnabled = true;
            this.cmbTurmaEdit.Location = new System.Drawing.Point(622, 12);
            this.cmbTurmaEdit.Name = "cmbTurmaEdit";
            this.cmbTurmaEdit.Size = new System.Drawing.Size(286, 28);
            this.cmbTurmaEdit.TabIndex = 121;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label13.Location = new System.Drawing.Point(204, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 17);
            this.label13.TabIndex = 120;
            this.label13.Text = "Projeto:";
            // 
            // cmbProjetoEdit
            // 
            this.cmbProjetoEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjetoEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cmbProjetoEdit.FormattingEnabled = true;
            this.cmbProjetoEdit.Location = new System.Drawing.Point(264, 12);
            this.cmbProjetoEdit.Name = "cmbProjetoEdit";
            this.cmbProjetoEdit.Size = new System.Drawing.Size(286, 28);
            this.cmbProjetoEdit.TabIndex = 119;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(566, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 118;
            this.label5.Text = "Turma:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView2.ColumnHeadersHeight = 30;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(3, 52);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.RowTemplate.Height = 30;
            this.dataGridView2.RowTemplate.ReadOnly = true;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView2.Size = new System.Drawing.Size(987, 397);
            this.dataGridView2.TabIndex = 117;
            this.dataGridView2.Visible = false;
            // 
            // btnGravar
            // 
            this.btnGravar.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.icon_add32x32;
            this.btnGravar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGravar.Location = new System.Drawing.Point(918, 9);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(33, 33);
            this.btnGravar.TabIndex = 116;
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.btnGerarLista);
            this.panel2.Controls.Add(this.btnVoltar1);
            this.panel2.Controls.Add(this.txtEditMode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 455);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(995, 64);
            this.panel2.TabIndex = 65;
            // 
            // btnVoltar1
            // 
            this.btnVoltar1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnVoltar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVoltar1.Image = global::ProjetoSomarUI.Properties.Resources.icon_back32x32;
            this.btnVoltar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar1.Location = new System.Drawing.Point(451, 12);
            this.btnVoltar1.Name = "btnVoltar1";
            this.btnVoltar1.Size = new System.Drawing.Size(92, 40);
            this.btnVoltar1.TabIndex = 70;
            this.btnVoltar1.Text = "VOLTAR";
            this.btnVoltar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar1.UseVisualStyleBackColor = true;
            // 
            // txtEditMode
            // 
            this.txtEditMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtEditMode.Location = new System.Drawing.Point(848, 19);
            this.txtEditMode.Name = "txtEditMode";
            this.txtEditMode.Size = new System.Drawing.Size(100, 26);
            this.txtEditMode.TabIndex = 68;
            this.txtEditMode.Visible = false;
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
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 519);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(995, 60);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundFilter;
            this.groupBox1.Controls.Add(this.btnAll);
            this.groupBox1.Controls.Add(this.btnNovo);
            this.groupBox1.Controls.Add(this.cmbTurma);
            this.groupBox1.Controls.Add(this.cmbProjeto);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblProjeto);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(998, 79);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAll.BackgroundImage")));
            this.btnAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAll.Location = new System.Drawing.Point(628, 21);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(58, 46);
            this.btnAll.TabIndex = 119;
            this.btnAll.UseVisualStyleBackColor = false;
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNovo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNovo.BackgroundImage")));
            this.btnNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNovo.FlatAppearance.BorderSize = 2;
            this.btnNovo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnNovo.Location = new System.Drawing.Point(919, 13);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 60);
            this.btnNovo.TabIndex = 45;
            this.btnNovo.UseVisualStyleBackColor = false;
            // 
            // cmbTurma
            // 
            this.cmbTurma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cmbTurma.FormattingEnabled = true;
            this.cmbTurma.Location = new System.Drawing.Point(327, 36);
            this.cmbTurma.Name = "cmbTurma";
            this.cmbTurma.Size = new System.Drawing.Size(286, 28);
            this.cmbTurma.TabIndex = 118;
            // 
            // cmbProjeto
            // 
            this.cmbProjeto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cmbProjeto.FormattingEnabled = true;
            this.cmbProjeto.Location = new System.Drawing.Point(24, 36);
            this.cmbProjeto.Name = "cmbProjeto";
            this.cmbProjeto.Size = new System.Drawing.Size(286, 28);
            this.cmbProjeto.TabIndex = 116;
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
            this.panelEdit.Size = new System.Drawing.Size(998, 641);
            this.panelEdit.TabIndex = 44;
            this.panelEdit.Visible = false;
            // 
            // panelConsulta
            // 
            this.panelConsulta.Controls.Add(this.Grid);
            this.panelConsulta.Controls.Add(this.groupBox1);
            this.panelConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConsulta.Location = new System.Drawing.Point(0, 0);
            this.panelConsulta.Name = "panelConsulta";
            this.panelConsulta.Size = new System.Drawing.Size(998, 641);
            this.panelConsulta.TabIndex = 43;
            // 
            // Grid
            // 
            this.Grid.AutoSize = true;
            this.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Grid.ControlHeight = 547;
            this.Grid.ControlWidth = 982;
            this.Grid.EnableClickButton1 = true;
            this.Grid.EnableClickButton2 = false;
            this.Grid.ImgButton1 = null;
            this.Grid.ImgButton2 = null;
            this.Grid.Location = new System.Drawing.Point(9, 83);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(985, 550);
            this.Grid.TabIndex = 39;
            // 
            // btnGerarLista
            // 
            this.btnGerarLista.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnGerarLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGerarLista.Image = global::ProjetoSomarUI.Properties.Resources.icon_edit2_32x32;
            this.btnGerarLista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarLista.Location = new System.Drawing.Point(679, 9);
            this.btnGerarLista.Name = "btnGerarLista";
            this.btnGerarLista.Size = new System.Drawing.Size(118, 43);
            this.btnGerarLista.TabIndex = 81;
            this.btnGerarLista.Text = "GERAR LISTA";
            this.btnGerarLista.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGerarLista.UseVisualStyleBackColor = true;
            // 
            // FormFrequencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 641);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.panelConsulta);
            this.Name = "FormFrequencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FREQUENCIA (lista de presenca)";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelMessage2.ResumeLayout(false);
            this.panelMessage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.panelConsulta.ResumeLayout(false);
            this.panelConsulta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblProjeto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lblCodigo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtEditMode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtdtCadastro;
        private System.Windows.Forms.TextBox txtDataAlteracao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNomeAlteracao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Panel panelConsulta;
        private System.Windows.Forms.ComboBox cmbTurma;
        private System.Windows.Forms.ComboBox cmbProjeto;
        private System.Windows.Forms.ComboBox cmbTurmaEdit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbProjetoEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtdtFrequencia;
        private System.Windows.Forms.Panel panelMessage2;
        private System.Windows.Forms.Label lblMessage2;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnVoltar1;
        private Controls.GridViewControl Grid;
        private System.Windows.Forms.Button btnGerarLista;
    }
}