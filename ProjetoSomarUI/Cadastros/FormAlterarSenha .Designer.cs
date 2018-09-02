namespace ProjetoSomarUI.Cadastros
{
    partial class FormAlterarSenha
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.hdnIdEndereco = new System.Windows.Forms.TextBox();
            this.btnVoltar1 = new System.Windows.Forms.Button();
            this.txtEditMode = new System.Windows.Forms.TextBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.txtDataAlteracao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNomeAlteracao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfirmarSenha = new System.Windows.Forms.TextBox();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.hdnIdEndereco);
            this.panel2.Controls.Add(this.btnVoltar1);
            this.panel2.Controls.Add(this.txtEditMode);
            this.panel2.Controls.Add(this.btnGravar);
            this.panel2.Location = new System.Drawing.Point(0, 327);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 64);
            this.panel2.TabIndex = 65;
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
            // btnVoltar1
            // 
            this.btnVoltar1.Location = new System.Drawing.Point(365, 16);
            this.btnVoltar1.Name = "btnVoltar1";
            this.btnVoltar1.Size = new System.Drawing.Size(110, 34);
            this.btnVoltar1.TabIndex = 69;
            this.btnVoltar1.Text = "Voltar";
            this.btnVoltar1.UseVisualStyleBackColor = true;
            this.btnVoltar1.Click += new System.EventHandler(this.btnVoltar1_Click);
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
            this.btnGravar.Location = new System.Drawing.Point(569, 16);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(121, 34);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "Alterar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Visible = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.SystemColors.Window;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtSenha.Location = new System.Drawing.Point(134, 80);
            this.txtSenha.MaxLength = 100;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(159, 27);
            this.txtSenha.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Controls.Add(this.txtDataCadastro);
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
            // txtDataCadastro
            // 
            this.txtDataCadastro.Enabled = false;
            this.txtDataCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtDataCadastro.Location = new System.Drawing.Point(118, 18);
            this.txtDataCadastro.MaxLength = 10;
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.Size = new System.Drawing.Size(124, 27);
            this.txtDataCadastro.TabIndex = 94;
            this.txtDataCadastro.TabStop = false;
            this.txtDataCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(17, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 85;
            this.label5.Text = "Confirmar Senha:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label10.Location = new System.Drawing.Point(17, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 77;
            this.label10.Text = "Senha:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(15, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 51);
            this.panel1.TabIndex = 64;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjetoSomarUI.Properties.Resources.icon_projeto32x32;
            this.pictureBox1.InitialImage = global::ProjetoSomarUI.Properties.Resources.icon_projeto32x32;
            this.pictureBox1.Location = new System.Drawing.Point(17, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 35);
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.lblTitle.Location = new System.Drawing.Point(64, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(196, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ALTERAR SENHA";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtUsuario);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtConfirmarSenha);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtSenha);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panel3.Location = new System.Drawing.Point(14, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(973, 536);
            this.panel3.TabIndex = 66;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtUsuario.Location = new System.Drawing.Point(134, 27);
            this.txtUsuario.MaxLength = 100;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(159, 27);
            this.txtUsuario.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(17, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 88;
            this.label2.Text = "Usuario:";
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.BackColor = System.Drawing.SystemColors.Window;
            this.txtConfirmarSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtConfirmarSenha.Location = new System.Drawing.Point(134, 124);
            this.txtConfirmarSenha.MaxLength = 100;
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            this.txtConfirmarSenha.Size = new System.Drawing.Size(159, 27);
            this.txtConfirmarSenha.TabIndex = 86;
            // 
            // panelEdit
            // 
            this.panelEdit.BackColor = System.Drawing.SystemColors.Control;
            this.panelEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEdit.Controls.Add(this.panel3);
            this.panelEdit.Controls.Add(this.panel1);
            this.panelEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdit.Location = new System.Drawing.Point(0, 0);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(1009, 641);
            this.panelEdit.TabIndex = 42;
            this.panelEdit.Visible = false;
            // 
            // FormAlterarSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 641);
            this.Controls.Add(this.panelEdit);
            this.Name = "FormAlterarSenha";
            this.Text = "FormEscolas";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVoltar1;
        private System.Windows.Forms.TextBox txtEditMode;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.TextBox txtDataAlteracao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNomeAlteracao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.TextBox hdnIdEndereco;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConfirmarSenha;
    }
}