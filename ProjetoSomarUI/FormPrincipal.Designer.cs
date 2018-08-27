namespace ProjetoSomarUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projetosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turmasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pessoasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alunoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.diarioToolStripMenuItem,
            this.sairToolStripMenuItem,
            this.testeToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1314, 24);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuPrincipal";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projetosToolStripMenuItem,
            this.turmasToolStripMenuItem,
            this.pessoasToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // projetosToolStripMenuItem
            // 
            this.projetosToolStripMenuItem.Name = "projetosToolStripMenuItem";
            this.projetosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.projetosToolStripMenuItem.Text = "Projetos";
            this.projetosToolStripMenuItem.Click += new System.EventHandler(this.projetosToolStripMenuItem_Click);
            // 
            // turmasToolStripMenuItem
            // 
            this.turmasToolStripMenuItem.Name = "turmasToolStripMenuItem";
            this.turmasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.turmasToolStripMenuItem.Text = "Turmas";
            this.turmasToolStripMenuItem.Click += new System.EventHandler(this.turmasToolStripMenuItem_Click);
            // 
            // pessoasToolStripMenuItem
            // 
            this.pessoasToolStripMenuItem.Name = "pessoasToolStripMenuItem";
            this.pessoasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pessoasToolStripMenuItem.Text = "Pessoas";
            this.pessoasToolStripMenuItem.Click += new System.EventHandler(this.pessoasToolStripMenuItem_Click);
            // 
            // diarioToolStripMenuItem
            // 
            this.diarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alunoToolStripMenuItem,
            this.frequenciaToolStripMenuItem});
            this.diarioToolStripMenuItem.Name = "diarioToolStripMenuItem";
            this.diarioToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.diarioToolStripMenuItem.Text = "Diario";
            // 
            // alunoToolStripMenuItem
            // 
            this.alunoToolStripMenuItem.Name = "alunoToolStripMenuItem";
            this.alunoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.alunoToolStripMenuItem.Text = "Consultar Aluno";
            // 
            // frequenciaToolStripMenuItem
            // 
            this.frequenciaToolStripMenuItem.Name = "frequenciaToolStripMenuItem";
            this.frequenciaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.frequenciaToolStripMenuItem.Text = "Frequencia";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairMenuItem_Click);
            // 
            // testeToolStripMenuItem
            // 
            this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            this.testeToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.testeToolStripMenuItem.Text = "Teste";
            this.testeToolStripMenuItem.Click += new System.EventHandler(this.testeToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1314, 580);
            this.Controls.Add(this.menuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FormPrincipal";
            this.Text = "Somar - Solidariedade em Marcha";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projetosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turmasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pessoasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alunoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
    }
}

