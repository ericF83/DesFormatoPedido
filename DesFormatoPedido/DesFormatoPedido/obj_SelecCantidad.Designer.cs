namespace DesFormatoPedido
{
    partial class obj_SelecCantidad
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbltalla = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.toolTipObj = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lbltalla
            // 
            this.lbltalla.AutoSize = true;
            this.lbltalla.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltalla.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbltalla.Location = new System.Drawing.Point(4, 3);
            this.lbltalla.Name = "lbltalla";
            this.lbltalla.Size = new System.Drawing.Size(15, 16);
            this.lbltalla.TabIndex = 15;
            this.lbltalla.Text = "T";
            // 
            // txtNo
            // 
            this.txtNo.BackColor = System.Drawing.Color.LightBlue;
            this.txtNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNo.Location = new System.Drawing.Point(7, 22);
            this.txtNo.Multiline = true;
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(32, 20);
            this.txtNo.TabIndex = 16;
            this.toolTipObj.SetToolTip(this.txtNo, "capturar cantidad");
            this.txtNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNo_KeyPress);
            // 
            // obj_SelecCantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.lbltalla);
            this.Name = "obj_SelecCantidad";
            this.Size = new System.Drawing.Size(46, 51);
            this.Load += new System.EventHandler(this.SelecCantidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbltalla;
        public System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.ToolTip toolTipObj;
    }
}
