namespace ProjetoSomarUI.Cadastros
{
    partial class FormEscolas
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnVoltar1 = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.hdnIdEndereco = new System.Windows.Forms.TextBox();
            this.txtEditMode = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtdtCadastro = new System.Windows.Forms.TextBox();
            this.txtDataAlteracao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNomeAlteracao = new System.Windows.Forms.TextBox();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelConsulta = new System.Windows.Forms.Panel();
            this.Grid = new ProjetoSomarUI.Controls.GridViewControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtIdEndereco = new System.Windows.Forms.TextBox();
            this.txtIdCidade = new System.Windows.Forms.TextBox();
            this.txtIdBairro = new System.Windows.Forms.TextBox();
            this.btnSearchCEP = new System.Windows.Forms.PictureBox();
            this.txtCEP = new System.Windows.Forms.MaskedTextBox();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelConsulta.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchCEP)).BeginInit();
            this.panelEdit.SuspendLayout();
            this.SuspendLayout();
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
            this.cmbStatus.Location = new System.Drawing.Point(831, 18);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(124, 28);
            this.cmbStatus.TabIndex = 92;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.btnVoltar1);
            this.panel2.Controls.Add(this.btnGravar);
            this.panel2.Controls.Add(this.hdnIdEndereco);
            this.panel2.Controls.Add(this.txtEditMode);
            this.panel2.Location = new System.Drawing.Point(0, 327);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(979, 64);
            this.panel2.TabIndex = 65;
            // 
            // btnVoltar1
            // 
            this.btnVoltar1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnVoltar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVoltar1.Image = global::ProjetoSomarUI.Properties.Resources.icon_back32x32;
            this.btnVoltar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar1.Location = new System.Drawing.Point(374, 12);
            this.btnVoltar1.Name = "btnVoltar1";
            this.btnVoltar1.Size = new System.Drawing.Size(92, 40);
            this.btnVoltar1.TabIndex = 72;
            this.btnVoltar1.Text = "VOLTAR";
            this.btnVoltar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar1.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGravar.Enabled = false;
            this.btnGravar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnGravar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGravar.Image = global::ProjetoSomarUI.Properties.Resources.icon_saveColor32x32;
            this.btnGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGravar.Location = new System.Drawing.Point(501, 12);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(98, 40);
            this.btnGravar.TabIndex = 71;
            this.btnGravar.Text = "SALVAR";
            this.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // hdnIdEndereco
            // 
            this.hdnIdEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.hdnIdEndereco.Location = new System.Drawing.Point(749, 17);
            this.hdnIdEndereco.Name = "hdnIdEndereco";
            this.hdnIdEndereco.Size = new System.Drawing.Size(100, 26);
            this.hdnIdEndereco.TabIndex = 70;
            this.hdnIdEndereco.Visible = false;
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
            this.groupBox3.Location = new System.Drawing.Point(0, 474);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(978, 60);
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
            // txtObservacoes
            // 
            this.txtObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtObservacoes.Location = new System.Drawing.Point(134, 58);
            this.txtObservacoes.MaxLength = 400;
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(821, 81);
            this.txtObservacoes.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(17, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 85;
            this.label5.Text = "Observação:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label10.Location = new System.Drawing.Point(17, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 77;
            this.label10.Text = "Escola:";
            // 
            // panelConsulta
            // 
            this.panelConsulta.Controls.Add(this.Grid);
            this.panelConsulta.Controls.Add(this.groupBox1);
            this.panelConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConsulta.Location = new System.Drawing.Point(0, 0);
            this.panelConsulta.Name = "panelConsulta";
            this.panelConsulta.Size = new System.Drawing.Size(991, 641);
            this.panelConsulta.TabIndex = 41;
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
            this.Grid.Location = new System.Drawing.Point(6, 84);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(982, 550);
            this.Grid.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundFilter;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnNovo);
            this.groupBox1.Controls.Add(this.btnAll);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cmbSearchType);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(991, 79);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "Consultar por:";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrint.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.icon_printer32x32;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.Location = new System.Drawing.Point(796, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(58, 46);
            this.btnPrint.TabIndex = 40;
            this.btnPrint.UseVisualStyleBackColor = false;
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
            this.btnNovo.Location = new System.Drawing.Point(902, 13);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 60);
            this.btnNovo.TabIndex = 37;
            this.btnNovo.UseVisualStyleBackColor = false;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAll.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.icon_reload232x32;
            this.btnAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAll.Location = new System.Drawing.Point(698, 20);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(58, 46);
            this.btnAll.TabIndex = 39;
            this.btnAll.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.icon_search32x32;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(632, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 48);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.15F);
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Location = new System.Drawing.Point(113, 31);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(157, 26);
            this.cmbSearchType.TabIndex = 35;
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtSearch.Location = new System.Drawing.Point(276, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(351, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundTitle;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 60);
            this.panel1.TabIndex = 64;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditar.Image = global::ProjetoSomarUI.Properties.Resources.icon_edit2_32x32;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(639, 8);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 43);
            this.btnEditar.TabIndex = 79;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjetoSomarUI.Properties.Resources.icon_projeto32x32;
            this.pictureBox1.InitialImage = global::ProjetoSomarUI.Properties.Resources.icon_projeto32x32;
            this.pictureBox1.Location = new System.Drawing.Point(17, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 35);
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(768, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 77;
            this.label8.Text = "Código:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.lblCodigo.Location = new System.Drawing.Point(836, 11);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(124, 38);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.lblTitle.Location = new System.Drawing.Point(64, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(261, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DETALHES DA ESCOLA";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtIdEndereco);
            this.panel3.Controls.Add(this.txtIdCidade);
            this.panel3.Controls.Add(this.txtIdBairro);
            this.panel3.Controls.Add(this.btnSearchCEP);
            this.panel3.Controls.Add(this.txtCEP);
            this.panel3.Controls.Add(this.txtUF);
            this.panel3.Controls.Add(this.label27);
            this.panel3.Controls.Add(this.txtCidade);
            this.panel3.Controls.Add(this.txtBairro);
            this.panel3.Controls.Add(this.txtComplemento);
            this.panel3.Controls.Add(this.txtNumero);
            this.panel3.Controls.Add(this.txtLogradouro);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.cmbStatus);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.txtObservacoes);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtNome);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panel3.Location = new System.Drawing.Point(4, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(980, 536);
            this.panel3.TabIndex = 66;
            // 
            // txtIdEndereco
            // 
            this.txtIdEndereco.Location = new System.Drawing.Point(347, 153);
            this.txtIdEndereco.Name = "txtIdEndereco";
            this.txtIdEndereco.Size = new System.Drawing.Size(20, 20);
            this.txtIdEndereco.TabIndex = 144;
            this.txtIdEndereco.Visible = false;
            // 
            // txtIdCidade
            // 
            this.txtIdCidade.Location = new System.Drawing.Point(621, 298);
            this.txtIdCidade.Name = "txtIdCidade";
            this.txtIdCidade.Size = new System.Drawing.Size(20, 20);
            this.txtIdCidade.TabIndex = 143;
            this.txtIdCidade.Visible = false;
            // 
            // txtIdBairro
            // 
            this.txtIdBairro.Location = new System.Drawing.Point(134, 298);
            this.txtIdBairro.Name = "txtIdBairro";
            this.txtIdBairro.Size = new System.Drawing.Size(20, 20);
            this.txtIdBairro.TabIndex = 142;
            this.txtIdBairro.Visible = false;
            // 
            // btnSearchCEP
            // 
            this.btnSearchCEP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchCEP.Image = global::ProjetoSomarUI.Properties.Resources.icon_search24x24;
            this.btnSearchCEP.Location = new System.Drawing.Point(240, 151);
            this.btnSearchCEP.Name = "btnSearchCEP";
            this.btnSearchCEP.Size = new System.Drawing.Size(40, 26);
            this.btnSearchCEP.TabIndex = 141;
            this.btnSearchCEP.TabStop = false;
            this.btnSearchCEP.Click += new System.EventHandler(this.btnSearchCEP_Click);
            // 
            // txtCEP
            // 
            this.txtCEP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtCEP.Location = new System.Drawing.Point(134, 150);
            this.txtCEP.Mask = "00000-999";
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(100, 27);
            this.txtCEP.TabIndex = 140;
            // 
            // txtUF
            // 
            this.txtUF.BackColor = System.Drawing.SystemColors.Window;
            this.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUF.Enabled = false;
            this.txtUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtUF.Location = new System.Drawing.Point(870, 265);
            this.txtUF.MaxLength = 100;
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(30, 27);
            this.txtUF.TabIndex = 139;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label27.Location = new System.Drawing.Point(859, 270);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(13, 17);
            this.label27.TabIndex = 138;
            this.label27.Text = "-";
            // 
            // txtCidade
            // 
            this.txtCidade.BackColor = System.Drawing.SystemColors.Window;
            this.txtCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCidade.Enabled = false;
            this.txtCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtCidade.Location = new System.Drawing.Point(621, 265);
            this.txtCidade.MaxLength = 100;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(238, 27);
            this.txtCidade.TabIndex = 136;
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.SystemColors.Window;
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Enabled = false;
            this.txtBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtBairro.Location = new System.Drawing.Point(134, 265);
            this.txtBairro.MaxLength = 100;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(366, 27);
            this.txtBairro.TabIndex = 134;
            // 
            // txtComplemento
            // 
            this.txtComplemento.BackColor = System.Drawing.SystemColors.Window;
            this.txtComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComplemento.Enabled = false;
            this.txtComplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtComplemento.Location = new System.Drawing.Point(134, 226);
            this.txtComplemento.MaxLength = 100;
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(366, 27);
            this.txtComplemento.TabIndex = 132;
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Enabled = false;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtNumero.Location = new System.Drawing.Point(621, 188);
            this.txtNumero.MaxLength = 100;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(83, 27);
            this.txtNumero.TabIndex = 130;
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.BackColor = System.Drawing.SystemColors.Window;
            this.txtLogradouro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLogradouro.Enabled = false;
            this.txtLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtLogradouro.Location = new System.Drawing.Point(134, 188);
            this.txtLogradouro.MaxLength = 100;
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(366, 27);
            this.txtLogradouro.TabIndex = 128;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label21.Location = new System.Drawing.Point(562, 270);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 17);
            this.label21.TabIndex = 137;
            this.label21.Text = "Cidade:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label20.Location = new System.Drawing.Point(17, 272);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 17);
            this.label20.TabIndex = 135;
            this.label20.Text = "Bairro:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label19.Location = new System.Drawing.Point(17, 233);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 17);
            this.label19.TabIndex = 133;
            this.label19.Text = "Complemento:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label18.Location = new System.Drawing.Point(590, 193);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 17);
            this.label18.TabIndex = 131;
            this.label18.Text = "Nº:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label17.Location = new System.Drawing.Point(17, 195);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 17);
            this.label17.TabIndex = 129;
            this.label17.Text = "Logradouro:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label16.Location = new System.Drawing.Point(17, 158);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 17);
            this.label16.TabIndex = 127;
            this.label16.Text = "CEP:";
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
            this.panelEdit.Size = new System.Drawing.Size(991, 641);
            this.panelEdit.TabIndex = 42;
            this.panelEdit.Visible = false;
            // 
            // FormEscolas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 641);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.panelConsulta);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEscolas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ESCOLAS";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelConsulta.ResumeLayout(false);
            this.panelConsulta.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchCEP)).EndInit();
            this.panelEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtEditMode;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtdtCadastro;
        private System.Windows.Forms.TextBox txtDataAlteracao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNomeAlteracao;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelConsulta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lblCodigo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.TextBox txtIdEndereco;
        private System.Windows.Forms.TextBox txtIdCidade;
        private System.Windows.Forms.TextBox txtIdBairro;
        private System.Windows.Forms.PictureBox btnSearchCEP;
        private System.Windows.Forms.MaskedTextBox txtCEP;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox hdnIdEndereco;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private Controls.GridViewControl Grid;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnVoltar1;
        private System.Windows.Forms.Button btnGravar;
    }
}