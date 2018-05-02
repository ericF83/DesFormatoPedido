namespace DesFormatoPedido
{
    partial class FRMloginCte
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
            this.txtNombreCte = new System.Windows.Forms.TextBox();
            this.lblNombreCte = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNombreCte
            // 
            this.txtNombreCte.BackColor = System.Drawing.Color.LightBlue;
            this.txtNombreCte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreCte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreCte.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombreCte.Location = new System.Drawing.Point(73, 71);
            this.txtNombreCte.MaxLength = 5;
            this.txtNombreCte.Name = "txtNombreCte";
            this.txtNombreCte.Size = new System.Drawing.Size(153, 19);
            this.txtNombreCte.TabIndex = 15;
            this.txtNombreCte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombreCte_KeyDown);
            // 
            // lblNombreCte
            // 
            this.lblNombreCte.AutoSize = true;
            this.lblNombreCte.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCte.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNombreCte.Location = new System.Drawing.Point(70, 53);
            this.lblNombreCte.Name = "lblNombreCte";
            this.lblNombreCte.Size = new System.Drawing.Size(98, 15);
            this.lblNombreCte.TabIndex = 14;
            this.lblNombreCte.Text = "CLAVE CLIENTE";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(164, 137);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(116, 34);
            this.btnAceptar.TabIndex = 30;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FRMloginCte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 183);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNombreCte);
            this.Controls.Add(this.lblNombreCte);
            this.Name = "FRMloginCte";
            this.Text = "CLIENTE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtNombreCte;
        private System.Windows.Forms.Label lblNombreCte;
        private System.Windows.Forms.Button btnAceptar;
    }
}