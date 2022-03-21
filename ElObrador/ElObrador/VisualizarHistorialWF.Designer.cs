namespace ElObrador
{
    partial class VisualizarHistorialWF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizarHistorialWF));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImagenPagina = new System.Windows.Forms.PictureBox();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.lblidTaller = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.ImagenPagina);
            this.panel1.Controls.Add(this.lblHistorial);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 43);
            this.panel1.TabIndex = 7;
            // 
            // ImagenPagina
            // 
            this.ImagenPagina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.ImagenPagina.Image = global::ElObrador.Properties.Resources.icons8_historial_de_pedidos_30;
            this.ImagenPagina.Location = new System.Drawing.Point(13, 1);
            this.ImagenPagina.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ImagenPagina.Name = "ImagenPagina";
            this.ImagenPagina.Size = new System.Drawing.Size(43, 39);
            this.ImagenPagina.TabIndex = 3;
            this.ImagenPagina.TabStop = false;
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.ForeColor = System.Drawing.Color.White;
            this.lblHistorial.Location = new System.Drawing.Point(64, 10);
            this.lblHistorial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(142, 23);
            this.lblHistorial.TabIndex = 4;
            this.lblHistorial.Text = "Historial Taller";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::ElObrador.Properties.Resources.cancelar2;
            this.btnCerrar.Location = new System.Drawing.Point(617, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(33, 31);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblidTaller
            // 
            this.lblidTaller.AutoSize = true;
            this.lblidTaller.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidTaller.ForeColor = System.Drawing.Color.Black;
            this.lblidTaller.Location = new System.Drawing.Point(13, 69);
            this.lblidTaller.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidTaller.Name = "lblidTaller";
            this.lblidTaller.Size = new System.Drawing.Size(27, 20);
            this.lblidTaller.TabIndex = 207;
            this.lblidTaller.Text = "@";
            this.lblidTaller.Visible = false;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(164, 439);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(385, 47);
            this.btnVolver.TabIndex = 206;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(40, 170);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 20);
            this.label8.TabIndex = 205;
            this.label8.Text = "Descripción(*):";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(44, 194);
            this.txtDiagnostico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiagnostico.MaxLength = 400;
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(608, 155);
            this.txtDiagnostico.TabIndex = 204;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(203, 91);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 203;
            this.label7.Text = "Fecha:";
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(207, 116);
            this.dtFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(292, 22);
            this.dtFecha.TabIndex = 202;
            // 
            // VisualizarHistorialWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 554);
            this.Controls.Add(this.lblidTaller);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDiagnostico);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VisualizarHistorialWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisualizarHistorialWF";
            this.Load += new System.EventHandler(this.VisualizarHistorialWF_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ImagenPagina;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Label lblidTaller;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtFecha;
    }
}