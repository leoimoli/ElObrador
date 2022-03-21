namespace ElObrador
{
    partial class HistorialPrecioWF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialPrecioWF));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImagenPagina = new System.Windows.Forms.PictureBox();
            this.lblPantalla = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblidMaterial = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.ImagenPagina);
            this.panel1.Controls.Add(this.lblPantalla);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 43);
            this.panel1.TabIndex = 6;
            // 
            // ImagenPagina
            // 
            this.ImagenPagina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.ImagenPagina.Image = global::ElObrador.Properties.Resources.icons8_precio_bajo_301;
            this.ImagenPagina.Location = new System.Drawing.Point(13, 1);
            this.ImagenPagina.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ImagenPagina.Name = "ImagenPagina";
            this.ImagenPagina.Size = new System.Drawing.Size(43, 39);
            this.ImagenPagina.TabIndex = 3;
            this.ImagenPagina.TabStop = false;
            // 
            // lblPantalla
            // 
            this.lblPantalla.AutoSize = true;
            this.lblPantalla.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPantalla.ForeColor = System.Drawing.Color.White;
            this.lblPantalla.Location = new System.Drawing.Point(64, 10);
            this.lblPantalla.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPantalla.Name = "lblPantalla";
            this.lblPantalla.Size = new System.Drawing.Size(265, 23);
            this.lblPantalla.TabIndex = 4;
            this.lblPantalla.Text = "Historial Precio de Alquiler";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::ElObrador.Properties.Resources.cancelar2;
            this.btnCerrar.Location = new System.Drawing.Point(641, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(33, 31);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMaterial,
            this.Mat,
            this.Codigo,
            this.Modelo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(16, 100);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(660, 310);
            this.dataGridView1.TabIndex = 170;
            // 
            // idMaterial
            // 
            this.idMaterial.HeaderText = "idHistorial";
            this.idMaterial.MinimumWidth = 6;
            this.idMaterial.Name = "idMaterial";
            this.idMaterial.Visible = false;
            this.idMaterial.Width = 125;
            // 
            // Mat
            // 
            this.Mat.HeaderText = "Monto";
            this.Mat.MinimumWidth = 6;
            this.Mat.Name = "Mat";
            this.Mat.Width = 170;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Fecha";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 150;
            // 
            // Modelo
            // 
            this.Modelo.HeaderText = "Usuario";
            this.Modelo.MinimumWidth = 6;
            this.Modelo.Name = "Modelo";
            this.Modelo.Width = 170;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(148, 469);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(385, 47);
            this.btnVolver.TabIndex = 207;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblidMaterial
            // 
            this.lblidMaterial.AutoSize = true;
            this.lblidMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidMaterial.ForeColor = System.Drawing.Color.Black;
            this.lblidMaterial.Location = new System.Drawing.Point(39, 64);
            this.lblidMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidMaterial.Name = "lblidMaterial";
            this.lblidMaterial.Size = new System.Drawing.Size(27, 20);
            this.lblidMaterial.TabIndex = 208;
            this.lblidMaterial.Text = "@";
            this.lblidMaterial.Visible = false;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblMaterial.Location = new System.Drawing.Point(216, 64);
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(27, 20);
            this.lblMaterial.TabIndex = 209;
            this.lblMaterial.Text = "@";
            // 
            // HistorialPrecioWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 554);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.lblidMaterial);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HistorialPrecioWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HistorialPrecioWF";
            this.Load += new System.EventHandler(this.HistorialPrecioWF_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ImagenPagina;
        private System.Windows.Forms.Label lblPantalla;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.Label lblidMaterial;
        private System.Windows.Forms.Label lblMaterial;
    }
}