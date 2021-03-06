﻿namespace ProjetoSomarUI
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.administrativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escolasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projetosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turmasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alunoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelAniversario = new System.Windows.Forms.Panel();
            this.pnlAniversariantes = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.ListViewAniversariantes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnKey = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblHora = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblDataAtual = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuPrincipal.SuspendLayout();
            this.panelAniversario.SuspendLayout();
            this.pnlAniversariantes.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrativoToolStripMenuItem,
            this.cadastrosToolStripMenuItem,
            this.diarioToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1072, 28);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuPrincipal";
            // 
            // administrativoToolStripMenuItem
            // 
            this.administrativoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsuarioToolStripMenuItem});
            this.administrativoToolStripMenuItem.Name = "administrativoToolStripMenuItem";
            this.administrativoToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.administrativoToolStripMenuItem.Text = "Administrativo";
            // 
            // UsuarioToolStripMenuItem
            // 
            this.UsuarioToolStripMenuItem.Name = "UsuarioToolStripMenuItem";
            this.UsuarioToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.UsuarioToolStripMenuItem.Text = "Usuários do Sistema";
            this.UsuarioToolStripMenuItem.Click += new System.EventHandler(this.UsuarioToolStripMenuItem_Click);
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escolasToolStripMenuItem,
            this.projetosToolStripMenuItem,
            this.turmasToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // escolasToolStripMenuItem
            // 
            this.escolasToolStripMenuItem.Name = "escolasToolStripMenuItem";
            this.escolasToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.escolasToolStripMenuItem.Text = "Escolas";
            this.escolasToolStripMenuItem.Click += new System.EventHandler(this.escolasToolStripMenuItem_Click);
            // 
            // projetosToolStripMenuItem
            // 
            this.projetosToolStripMenuItem.Name = "projetosToolStripMenuItem";
            this.projetosToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.projetosToolStripMenuItem.Text = "Projetos";
            this.projetosToolStripMenuItem.Click += new System.EventHandler(this.projetosToolStripMenuItem_Click);
            // 
            // turmasToolStripMenuItem
            // 
            this.turmasToolStripMenuItem.Name = "turmasToolStripMenuItem";
            this.turmasToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.turmasToolStripMenuItem.Text = "Turmas";
            this.turmasToolStripMenuItem.Click += new System.EventHandler(this.turmasToolStripMenuItem_Click);
            // 
            // diarioToolStripMenuItem
            // 
            this.diarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alunoToolStripMenuItem,
            this.frequenciaToolStripMenuItem});
            this.diarioToolStripMenuItem.Name = "diarioToolStripMenuItem";
            this.diarioToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.diarioToolStripMenuItem.Text = "Aluno";
            // 
            // alunoToolStripMenuItem
            // 
            this.alunoToolStripMenuItem.Name = "alunoToolStripMenuItem";
            this.alunoToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.alunoToolStripMenuItem.Text = "Matricula";
            this.alunoToolStripMenuItem.Click += new System.EventHandler(this.alunoToolStripMenuItem_Click);
            // 
            // frequenciaToolStripMenuItem
            // 
            this.frequenciaToolStripMenuItem.Name = "frequenciaToolStripMenuItem";
            this.frequenciaToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.frequenciaToolStripMenuItem.Text = "Frequencia";
            this.frequenciaToolStripMenuItem.Click += new System.EventHandler(this.frequenciaToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelAniversario
            // 
            this.panelAniversario.BackColor = System.Drawing.SystemColors.Control;
            this.panelAniversario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAniversario.Controls.Add(this.pnlAniversariantes);
            this.panelAniversario.Controls.Add(this.ListViewAniversariantes);
            this.panelAniversario.Controls.Add(this.panel5);
            this.panelAniversario.Controls.Add(this.panel4);
            this.panelAniversario.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAniversario.Location = new System.Drawing.Point(682, 28);
            this.panelAniversario.Name = "panelAniversario";
            this.panelAniversario.Size = new System.Drawing.Size(390, 552);
            this.panelAniversario.TabIndex = 82;
            this.panelAniversario.Visible = false;
            // 
            // pnlAniversariantes
            // 
            this.pnlAniversariantes.Controls.Add(this.label5);
            this.pnlAniversariantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAniversariantes.Location = new System.Drawing.Point(0, 120);
            this.pnlAniversariantes.Name = "pnlAniversariantes";
            this.pnlAniversariantes.Size = new System.Drawing.Size(386, 428);
            this.pnlAniversariantes.TabIndex = 84;
            this.pnlAniversariantes.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(68, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 16);
            this.label5.TabIndex = 80;
            this.label5.Text = "nenhum aniversariante este mês!";
            // 
            // ListViewAniversariantes
            // 
            this.ListViewAniversariantes.BackColor = System.Drawing.Color.White;
            this.ListViewAniversariantes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ListViewAniversariantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewAniversariantes.Enabled = false;
            this.ListViewAniversariantes.GridLines = true;
            this.ListViewAniversariantes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewAniversariantes.Location = new System.Drawing.Point(0, 120);
            this.ListViewAniversariantes.MultiSelect = false;
            this.ListViewAniversariantes.Name = "ListViewAniversariantes";
            this.ListViewAniversariantes.Size = new System.Drawing.Size(386, 428);
            this.ListViewAniversariantes.TabIndex = 81;
            this.ListViewAniversariantes.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundTitle;
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 60);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(386, 60);
            this.panel5.TabIndex = 81;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::ProjetoSomarUI.Properties.Resources.birthday_icon;
            this.pictureBox3.InitialImage = global::ProjetoSomarUI.Properties.Resources.icon_user32x32;
            this.pictureBox3.Location = new System.Drawing.Point(14, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 35);
            this.pictureBox3.TabIndex = 82;
            this.pictureBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 16);
            this.label6.TabIndex = 81;
            this.label6.Text = "Aniversariantes do Mês";
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundTitle;
            this.panel4.Controls.Add(this.btnReport);
            this.panel4.Controls.Add(this.btnAddStudent);
            this.panel4.Controls.Add(this.btnKey);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(386, 60);
            this.panel4.TabIndex = 80;
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundTitle;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Image = global::ProjetoSomarUI.Properties.Resources.icon_report48x48;
            this.btnReport.Location = new System.Drawing.Point(135, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(61, 53);
            this.btnReport.TabIndex = 85;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundTitle;
            this.btnAddStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddStudent.Image = global::ProjetoSomarUI.Properties.Resources.icon_addUser48x48;
            this.btnAddStudent.Location = new System.Drawing.Point(69, 3);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(60, 53);
            this.btnAddStudent.TabIndex = 84;
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnKey
            // 
            this.btnKey.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundTitle;
            this.btnKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKey.Image = global::ProjetoSomarUI.Properties.Resources.icon_key48x48;
            this.btnKey.Location = new System.Drawing.Point(314, 3);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(62, 53);
            this.btnKey.TabIndex = 4;
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 83;
            this.label7.Text = "Atalhos";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundTitle;
            this.panel3.Controls.Add(this.lblHora);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.lblDataAtual);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(392, 60);
            this.panel3.TabIndex = 8;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.BackColor = System.Drawing.Color.Transparent;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(106, 33);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(11, 16);
            this.lblHora.TabIndex = 82;
            this.lblHora.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 81;
            this.label3.Text = "Hora:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::ProjetoSomarUI.Properties.Resources.calendar_icon32x32;
            this.pictureBox2.InitialImage = global::ProjetoSomarUI.Properties.Resources.icon_user32x32;
            this.pictureBox2.Location = new System.Drawing.Point(15, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 35);
            this.pictureBox2.TabIndex = 80;
            this.pictureBox2.TabStop = false;
            // 
            // lblDataAtual
            // 
            this.lblDataAtual.AutoSize = true;
            this.lblDataAtual.BackColor = System.Drawing.Color.Transparent;
            this.lblDataAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataAtual.Location = new System.Drawing.Point(106, 11);
            this.lblDataAtual.Name = "lblDataAtual";
            this.lblDataAtual.Size = new System.Drawing.Size(11, 16);
            this.lblDataAtual.TabIndex = 4;
            this.lblDataAtual.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data:";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ProjetoSomarUI.Properties.Resources.backgroundTitle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblPerfil);
            this.panel1.Controls.Add(this.lblNome);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 60);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ProjetoSomarUI.Properties.Resources.icon_user32x32;
            this.pictureBox1.InitialImage = global::ProjetoSomarUI.Properties.Resources.icon_user32x32;
            this.pictureBox1.Location = new System.Drawing.Point(15, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 35);
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.BackColor = System.Drawing.Color.Transparent;
            this.lblPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfil.Location = new System.Drawing.Point(109, 34);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(52, 16);
            this.lblPerfil.TabIndex = 3;
            this.lblPerfil.Text = "lblPerfil";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.BackColor = System.Drawing.Color.Transparent;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(109, 9);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(59, 16);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "lblNome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Perfil:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1072, 580);
            this.Controls.Add(this.panelAniversario);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FormPrincipal";
            this.Text = "Somar - Solidariedade em Marcha";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.panelAniversario.ResumeLayout(false);
            this.pnlAniversariantes.ResumeLayout(false);
            this.pnlAniversariantes.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projetosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turmasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alunoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequenciaToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDataAtual;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem escolasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrativoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UsuarioToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelAniversario;
        private System.Windows.Forms.ListView ListViewAniversariantes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel pnlAniversariantes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnReport;
    }
}

