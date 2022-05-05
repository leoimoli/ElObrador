namespace ElObrador
{
    partial class LibreDeudaWF
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImagenPagina = new System.Windows.Forms.PictureBox();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chcRegistrarDeuda = new System.Windows.Forms.CheckBox();
            this.chcPagarDeuda = new System.Windows.Forms.CheckBox();
            this.grbGrilla = new System.Windows.Forms.GroupBox();
            this.grbRegistrarDeuda = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbGrilla.SuspendLayout();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 35);
            this.panel1.TabIndex = 9;
            // 
            // ImagenPagina
            // 
            this.ImagenPagina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.ImagenPagina.Image = global::ElObrador.Properties.Resources.icons8_gestión_de_clientes_30__1_;
            this.ImagenPagina.Location = new System.Drawing.Point(10, 1);
            this.ImagenPagina.Name = "ImagenPagina";
            this.ImagenPagina.Size = new System.Drawing.Size(32, 32);
            this.ImagenPagina.TabIndex = 3;
            this.ImagenPagina.TabStop = false;
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.ForeColor = System.Drawing.Color.White;
            this.lblHistorial.Location = new System.Drawing.Point(48, 8);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(103, 19);
            this.lblHistorial.TabIndex = 4;
            this.lblHistorial.Text = "Libre Deuda";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::ElObrador.Properties.Resources.cancelar2;
            this.btnCerrar.Location = new System.Drawing.Point(620, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chcRegistrarDeuda);
            this.groupBox1.Controls.Add(this.chcPagarDeuda);
            this.groupBox1.Location = new System.Drawing.Point(115, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 80);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // chcRegistrarDeuda
            // 
            this.chcRegistrarDeuda.AutoSize = true;
            this.chcRegistrarDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcRegistrarDeuda.Location = new System.Drawing.Point(30, 33);
            this.chcRegistrarDeuda.Name = "chcRegistrarDeuda";
            this.chcRegistrarDeuda.Size = new System.Drawing.Size(145, 24);
            this.chcRegistrarDeuda.TabIndex = 11;
            this.chcRegistrarDeuda.Text = "Registrar Deuda";
            this.chcRegistrarDeuda.UseVisualStyleBackColor = true;
            // 
            // chcPagarDeuda
            // 
            this.chcPagarDeuda.AutoSize = true;
            this.chcPagarDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcPagarDeuda.Location = new System.Drawing.Point(252, 33);
            this.chcPagarDeuda.Name = "chcPagarDeuda";
            this.chcPagarDeuda.Size = new System.Drawing.Size(122, 24);
            this.chcPagarDeuda.TabIndex = 12;
            this.chcPagarDeuda.Text = "Pagar Deuda";
            this.chcPagarDeuda.UseVisualStyleBackColor = true;
            // 
            // grbGrilla
            // 
            this.grbGrilla.Controls.Add(this.grbRegistrarDeuda);
            this.grbGrilla.Location = new System.Drawing.Point(0, 191);
            this.grbGrilla.Name = "grbGrilla";
            this.grbGrilla.Size = new System.Drawing.Size(645, 293);
            this.grbGrilla.TabIndex = 13;
            this.grbGrilla.TabStop = false;
            this.grbGrilla.Text = "Listado Libre Deuda";
            // 
            // grbRegistrarDeuda
            // 
            this.grbRegistrarDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbRegistrarDeuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.grbRegistrarDeuda.Location = new System.Drawing.Point(6, 0);
            this.grbRegistrarDeuda.Name = "grbRegistrarDeuda";
            this.grbRegistrarDeuda.Size = new System.Drawing.Size(629, 262);
            this.grbRegistrarDeuda.TabIndex = 0;
            this.grbRegistrarDeuda.TabStop = false;
            this.grbRegistrarDeuda.Text = "Registar Deuda";
            // 
            // LibreDeudaWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 527);
            this.Controls.Add(this.grbGrilla);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LibreDeudaWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LibreDeudaWF";
            this.Load += new System.EventHandler(this.LibreDeudaWF_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbGrilla.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ImagenPagina;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chcRegistrarDeuda;
        private System.Windows.Forms.CheckBox chcPagarDeuda;
        private System.Windows.Forms.GroupBox grbGrilla;
        private System.Windows.Forms.GroupBox grbRegistrarDeuda;
    }
}