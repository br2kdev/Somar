namespace ProjetoSomarUI.Relatorios
{
    partial class FormPainel
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
            this.btnProjetos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTurmas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProjetos
            // 
            this.btnProjetos.Location = new System.Drawing.Point(12, 69);
            this.btnProjetos.Name = "btnProjetos";
            this.btnProjetos.Size = new System.Drawing.Size(101, 50);
            this.btnProjetos.TabIndex = 3;
            this.btnProjetos.Text = "Projetos";
            this.btnProjetos.UseVisualStyleBackColor = true;
            this.btnProjetos.Click += new System.EventHandler(this.btnProjetos_Click);
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
            this.lblTitle.Size = new System.Drawing.Size(153, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "RELATÓRIOS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 51);
            this.panel1.TabIndex = 65;
            // 
            // btnTurmas
            // 
            this.btnTurmas.Location = new System.Drawing.Point(119, 69);
            this.btnTurmas.Name = "btnTurmas";
            this.btnTurmas.Size = new System.Drawing.Size(101, 50);
            this.btnTurmas.TabIndex = 66;
            this.btnTurmas.Text = "Turmas";
            this.btnTurmas.UseVisualStyleBackColor = true;
            this.btnTurmas.Click += new System.EventHandler(this.btnTurmas_Click);
            // 
            // FormPainel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 450);
            this.Controls.Add(this.btnTurmas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnProjetos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPainel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormPainel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProjetos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTurmas;
    }
}