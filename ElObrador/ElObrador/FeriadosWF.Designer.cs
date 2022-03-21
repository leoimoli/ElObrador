namespace ElObrador
{
    partial class FeriadosWF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeriadosWF));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImagenPagina = new System.Windows.Forms.PictureBox();
            this.lblPantalla = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.idprod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelFeriados = new System.Windows.Forms.Panel();
            this.btnNuevoFeriado = new System.Windows.Forms.Button();
            this.btnCrearGrupo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelNuevo = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.panelFeriados.SuspendLayout();
            this.panelNuevo.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(780, 43);
            this.panel1.TabIndex = 6;
            // 
            // ImagenPagina
            // 
            this.ImagenPagina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.ImagenPagina.Image = global::ElObrador.Properties.Resources.icons8_mantenimiento_30__1_;
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
            this.lblPantalla.Size = new System.Drawing.Size(284, 23);
            this.lblPantalla.TabIndex = 4;
            this.lblPantalla.Text = "Feriados y Días no laborales";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::ElObrador.Properties.Resources.cancelar2;
            this.btnCerrar.Location = new System.Drawing.Point(731, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(33, 31);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.BackgroundColor = System.Drawing.Color.White;
            this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idprod,
            this.dataGridViewTextBoxColumn2,
            this.Codigo,
            this.Quitar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLista.EnableHeadersVisualStyles = false;
            this.dgvLista.Location = new System.Drawing.Point(19, 66);
            this.dgvLista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvLista.Name = "dgvLista";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.RowHeadersWidth = 51;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvLista.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLista.Size = new System.Drawing.Size(635, 311);
            this.dgvLista.TabIndex = 180;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            this.dgvLista.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvLista_CellPainting);
            // 
            // idprod
            // 
            this.idprod.HeaderText = "Id";
            this.idprod.MinimumWidth = 6;
            this.idprod.Name = "idprod";
            this.idprod.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Motivo";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 230;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Fecha";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 125;
            // 
            // Quitar
            // 
            this.Quitar.HeaderText = "Quitar";
            this.Quitar.MinimumWidth = 6;
            this.Quitar.Name = "Quitar";
            this.Quitar.Width = 125;
            // 
            // panelFeriados
            // 
            this.panelFeriados.Controls.Add(this.btnNuevoFeriado);
            this.panelFeriados.Controls.Add(this.btnCrearGrupo);
            this.panelFeriados.Controls.Add(this.label1);
            this.panelFeriados.Controls.Add(this.txtAño);
            this.panelFeriados.Controls.Add(this.dgvLista);
            this.panelFeriados.Location = new System.Drawing.Point(51, 60);
            this.panelFeriados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelFeriados.Name = "panelFeriados";
            this.panelFeriados.Size = new System.Drawing.Size(657, 436);
            this.panelFeriados.TabIndex = 181;
            // 
            // btnNuevoFeriado
            // 
            this.btnNuevoFeriado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnNuevoFeriado.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnNuevoFeriado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoFeriado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoFeriado.ForeColor = System.Drawing.Color.White;
            this.btnNuevoFeriado.Image = global::ElObrador.Properties.Resources.mas__2_;
            this.btnNuevoFeriado.Location = new System.Drawing.Point(477, 31);
            this.btnNuevoFeriado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevoFeriado.Name = "btnNuevoFeriado";
            this.btnNuevoFeriado.Size = new System.Drawing.Size(33, 31);
            this.btnNuevoFeriado.TabIndex = 189;
            this.toolTip1.SetToolTip(this.btnNuevoFeriado, "Nuevo Feriado");
            this.btnNuevoFeriado.UseVisualStyleBackColor = false;
            this.btnNuevoFeriado.Click += new System.EventHandler(this.btnNuevoFeriado_Click);
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnCrearGrupo.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCrearGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearGrupo.ForeColor = System.Drawing.Color.White;
            this.btnCrearGrupo.Image = global::ElObrador.Properties.Resources.play;
            this.btnCrearGrupo.Location = new System.Drawing.Point(436, 31);
            this.btnCrearGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(33, 31);
            this.btnCrearGrupo.TabIndex = 188;
            this.toolTip1.SetToolTip(this.btnCrearGrupo, "Buscar Feriados");
            this.btnCrearGrupo.UseVisualStyleBackColor = false;
            this.btnCrearGrupo.Click += new System.EventHandler(this.btnCrearGrupo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(181, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 182;
            this.label1.Text = "Año";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(244, 34);
            this.txtAño.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(183, 22);
            this.txtAño.TabIndex = 181;
            this.txtAño.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAño_KeyDown);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(180, 503);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(385, 47);
            this.btnVolver.TabIndex = 207;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // panelNuevo
            // 
            this.panelNuevo.Controls.Add(this.label5);
            this.panelNuevo.Controls.Add(this.progressBar1);
            this.panelNuevo.Controls.Add(this.label4);
            this.panelNuevo.Controls.Add(this.btnCancelar);
            this.panelNuevo.Controls.Add(this.btnGuardar);
            this.panelNuevo.Controls.Add(this.dtFecha);
            this.panelNuevo.Controls.Add(this.txtMotivo);
            this.panelNuevo.Controls.Add(this.label2);
            this.panelNuevo.Controls.Add(this.label3);
            this.panelNuevo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelNuevo.Location = new System.Drawing.Point(35, 60);
            this.panelNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelNuevo.Name = "panelNuevo";
            this.panelNuevo.Size = new System.Drawing.Size(689, 288);
            this.panelNuevo.TabIndex = 190;
            this.panelNuevo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(80, 190);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(550, 18);
            this.label5.TabIndex = 208;
            this.label5.Text = "Atención: El sistema ya contabiliza los dias domingo como No Laborables";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(96, 154);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(529, 28);
            this.progressBar1.Step = 50;
            this.progressBar1.TabIndex = 202;
            this.progressBar1.Value = 10;
            this.progressBar1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(131, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(399, 23);
            this.label4.TabIndex = 201;
            this.label4.Text = "Ingresar nuevo Feriado o Día No laboral";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(147, 230);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(179, 47);
            this.btnCancelar.TabIndex = 200;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(372, 230);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(179, 47);
            this.btnGuardar.TabIndex = 199;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(259, 66);
            this.dtFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(265, 22);
            this.dtFecha.TabIndex = 182;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(259, 117);
            this.txtMotivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(265, 22);
            this.txtMotivo.TabIndex = 181;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(151, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 180;
            this.label2.Text = "Fecha(*):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(147, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 179;
            this.label3.Text = "Motivo(*):";
            // 
            // FeriadosWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 554);
            this.Controls.Add(this.panelNuevo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.panelFeriados);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FeriadosWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeriadosWF";
            this.Load += new System.EventHandler(this.FeriadosWF_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.panelFeriados.ResumeLayout(false);
            this.panelFeriados.PerformLayout();
            this.panelNuevo.ResumeLayout(false);
            this.panelNuevo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ImagenPagina;
        private System.Windows.Forms.Label lblPantalla;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Panel panelFeriados;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.Button btnNuevoFeriado;
        private System.Windows.Forms.Button btnCrearGrupo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panelNuevo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprod;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewButtonColumn Quitar;
    }
}