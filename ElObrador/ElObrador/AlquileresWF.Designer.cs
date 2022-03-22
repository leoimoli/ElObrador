namespace ElObrador
{
    partial class AlquileresWF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlquileresWF));
            this.dgvAlquiler = new System.Windows.Forms.DataGridView();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorAlquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelPrecios = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescipcionBus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGrupo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTotalPagarReal = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblidCliente = new System.Windows.Forms.Label();
            this.lblDniCliente = new System.Windows.Forms.Label();
            this.lblApeNom = new System.Windows.Forms.Label();
            this.lblClienteFijo = new System.Windows.Forms.Label();
            this.lblDniFijo = new System.Windows.Forms.Label();
            this.btnCliente = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnDevoluciones = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquiler)).BeginInit();
            this.PanelPrecios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlquiler
            // 
            this.dgvAlquiler.AllowUserToAddRows = false;
            this.dgvAlquiler.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlquiler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlquiler.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlquiler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlquiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlquiler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProducto,
            this.Material,
            this.Dias,
            this.FechaInicio,
            this.FechaFin,
            this.ValorAlquiler,
            this.Cod,
            this.Mod});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlquiler.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAlquiler.EnableHeadersVisualStyles = false;
            this.dgvAlquiler.Location = new System.Drawing.Point(12, 85);
            this.dgvAlquiler.Name = "dgvAlquiler";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlquiler.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAlquiler.RowHeadersVisible = false;
            this.dgvAlquiler.RowHeadersWidth = 51;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvAlquiler.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAlquiler.Size = new System.Drawing.Size(546, 382);
            this.dgvAlquiler.TabIndex = 75;
            this.dgvAlquiler.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAlquiler_KeyDown);
            // 
            // idProducto
            // 
            this.idProducto.HeaderText = "id";
            this.idProducto.MinimumWidth = 6;
            this.idProducto.Name = "idProducto";
            this.idProducto.Visible = false;
            this.idProducto.Width = 50;
            // 
            // Material
            // 
            this.Material.HeaderText = "Material";
            this.Material.MinimumWidth = 6;
            this.Material.Name = "Material";
            this.Material.Width = 195;
            // 
            // Dias
            // 
            this.Dias.HeaderText = "Días";
            this.Dias.MinimumWidth = 6;
            this.Dias.Name = "Dias";
            this.Dias.Width = 70;
            // 
            // FechaInicio
            // 
            this.FechaInicio.HeaderText = "Fecha Inicio";
            this.FechaInicio.MinimumWidth = 6;
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Width = 95;
            // 
            // FechaFin
            // 
            this.FechaFin.HeaderText = "Fecha Devolución";
            this.FechaFin.MinimumWidth = 6;
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Width = 95;
            // 
            // ValorAlquiler
            // 
            this.ValorAlquiler.HeaderText = "Total";
            this.ValorAlquiler.MinimumWidth = 6;
            this.ValorAlquiler.Name = "ValorAlquiler";
            this.ValorAlquiler.Width = 90;
            // 
            // Cod
            // 
            this.Cod.HeaderText = "Codigo";
            this.Cod.MinimumWidth = 6;
            this.Cod.Name = "Cod";
            this.Cod.Visible = false;
            this.Cod.Width = 125;
            // 
            // Mod
            // 
            this.Mod.HeaderText = "Modelo";
            this.Mod.MinimumWidth = 6;
            this.Mod.Name = "Mod";
            this.Mod.Visible = false;
            this.Mod.Width = 125;
            // 
            // PanelPrecios
            // 
            this.PanelPrecios.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelPrecios.Controls.Add(this.label5);
            this.PanelPrecios.Controls.Add(this.txtDescipcionBus);
            this.PanelPrecios.Controls.Add(this.label3);
            this.PanelPrecios.Controls.Add(this.cmbCategoria);
            this.PanelPrecios.Controls.Add(this.label2);
            this.PanelPrecios.Controls.Add(this.cmbGrupo);
            this.PanelPrecios.Controls.Add(this.label1);
            this.PanelPrecios.Controls.Add(this.dtFechaHasta);
            this.PanelPrecios.Controls.Add(this.label7);
            this.PanelPrecios.Controls.Add(this.dtFechaDesde);
            this.PanelPrecios.Controls.Add(this.dataGridView1);
            this.PanelPrecios.Controls.Add(this.progressBar1);
            this.PanelPrecios.Controls.Add(this.btnCargar);
            this.PanelPrecios.Location = new System.Drawing.Point(564, 85);
            this.PanelPrecios.Name = "PanelPrecios";
            this.PanelPrecios.Size = new System.Drawing.Size(501, 408);
            this.PanelPrecios.TabIndex = 168;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(8, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 190;
            this.label5.Text = "Buscar por Material";
            // 
            // txtDescipcionBus
            // 
            this.txtDescipcionBus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescipcionBus.Location = new System.Drawing.Point(132, 82);
            this.txtDescipcionBus.Name = "txtDescipcionBus";
            this.txtDescipcionBus.Size = new System.Drawing.Size(361, 20);
            this.txtDescipcionBus.TabIndex = 189;
            this.txtDescipcionBus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescipcionBus_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(270, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 188;
            this.label3.Text = "Categoria(*):";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(273, 39);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(220, 21);
            this.cmbCategoria.TabIndex = 187;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(27, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 186;
            this.label2.Text = "Grupo(*):";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Location = new System.Drawing.Point(30, 39);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(220, 21);
            this.cmbGrupo.TabIndex = 185;
            this.cmbGrupo.SelectedIndexChanged += new System.EventHandler(this.cmbGrupo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(270, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 184;
            this.label1.Text = "Fecha Fin:";
            // 
            // dtFechaHasta
            // 
            this.dtFechaHasta.Location = new System.Drawing.Point(273, 287);
            this.dtFechaHasta.Name = "dtFechaHasta";
            this.dtFechaHasta.Size = new System.Drawing.Size(220, 20);
            this.dtFechaHasta.TabIndex = 183;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 182;
            this.label7.Text = "Fecha Inicio:";
            // 
            // dtFechaDesde
            // 
            this.dtFechaDesde.Location = new System.Drawing.Point(15, 287);
            this.dtFechaDesde.Name = "dtFechaDesde";
            this.dtFechaDesde.Size = new System.Drawing.Size(220, 20);
            this.dtFechaDesde.TabIndex = 181;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.idMaterial,
            this.Mat,
            this.Codigo,
            this.Modelo,
            this.Precio});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Size = new System.Drawing.Size(495, 150);
            this.dataGridView1.TabIndex = 170;
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.MinimumWidth = 6;
            this.Check.Name = "Check";
            this.Check.Width = 20;
            // 
            // idMaterial
            // 
            this.idMaterial.HeaderText = "idMaterial";
            this.idMaterial.MinimumWidth = 6;
            this.idMaterial.Name = "idMaterial";
            this.idMaterial.Visible = false;
            this.idMaterial.Width = 125;
            // 
            // Mat
            // 
            this.Mat.HeaderText = "Material";
            this.Mat.MinimumWidth = 6;
            this.Mat.Name = "Mat";
            this.Mat.Width = 170;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 110;
            // 
            // Modelo
            // 
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.MinimumWidth = 6;
            this.Modelo.Name = "Modelo";
            this.Modelo.Width = 110;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio Actual";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.Width = 80;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(71, 322);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(397, 23);
            this.progressBar1.Step = 50;
            this.progressBar1.TabIndex = 168;
            this.progressBar1.Value = 10;
            this.progressBar1.Visible = false;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(391, 351);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(107, 38);
            this.btnCargar.TabIndex = 166;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(351, 522);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(107, 38);
            this.btnGuardar.TabIndex = 169;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(125, 523);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 38);
            this.btnCancelar.TabIndex = 170;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTotalPagarReal
            // 
            this.lblTotalPagarReal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblTotalPagarReal.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.lblTotalPagarReal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalPagarReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagarReal.ForeColor = System.Drawing.Color.White;
            this.lblTotalPagarReal.Location = new System.Drawing.Point(437, 473);
            this.lblTotalPagarReal.Name = "lblTotalPagarReal";
            this.lblTotalPagarReal.Size = new System.Drawing.Size(121, 43);
            this.lblTotalPagarReal.TabIndex = 172;
            this.lblTotalPagarReal.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label8.Location = new System.Drawing.Point(333, 473);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 39);
            this.label8.TabIndex = 171;
            this.label8.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(12, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 24);
            this.label4.TabIndex = 173;
            this.label4.Text = "Registro de Alquiler";
            // 
            // lblidCliente
            // 
            this.lblidCliente.AutoSize = true;
            this.lblidCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblidCliente.Location = new System.Drawing.Point(13, 523);
            this.lblidCliente.Name = "lblidCliente";
            this.lblidCliente.Size = new System.Drawing.Size(19, 13);
            this.lblidCliente.TabIndex = 174;
            this.lblidCliente.Text = "@";
            this.lblidCliente.Visible = false;
            // 
            // lblDniCliente
            // 
            this.lblDniCliente.AutoSize = true;
            this.lblDniCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDniCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblDniCliente.Location = new System.Drawing.Point(69, 491);
            this.lblDniCliente.Name = "lblDniCliente";
            this.lblDniCliente.Size = new System.Drawing.Size(20, 15);
            this.lblDniCliente.TabIndex = 175;
            this.lblDniCliente.Text = "@";
            this.lblDniCliente.Visible = false;
            // 
            // lblApeNom
            // 
            this.lblApeNom.AutoSize = true;
            this.lblApeNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApeNom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblApeNom.Location = new System.Drawing.Point(69, 472);
            this.lblApeNom.Name = "lblApeNom";
            this.lblApeNom.Size = new System.Drawing.Size(20, 15);
            this.lblApeNom.TabIndex = 176;
            this.lblApeNom.Text = "@";
            this.lblApeNom.Visible = false;
            // 
            // lblClienteFijo
            // 
            this.lblClienteFijo.AutoSize = true;
            this.lblClienteFijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteFijo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblClienteFijo.Location = new System.Drawing.Point(13, 472);
            this.lblClienteFijo.Name = "lblClienteFijo";
            this.lblClienteFijo.Size = new System.Drawing.Size(56, 15);
            this.lblClienteFijo.TabIndex = 177;
            this.lblClienteFijo.Text = "Cliente:";
            this.lblClienteFijo.Visible = false;
            // 
            // lblDniFijo
            // 
            this.lblDniFijo.AutoSize = true;
            this.lblDniFijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDniFijo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblDniFijo.Location = new System.Drawing.Point(33, 491);
            this.lblDniFijo.Name = "lblDniFijo";
            this.lblDniFijo.Size = new System.Drawing.Size(33, 15);
            this.lblDniFijo.TabIndex = 178;
            this.lblDniFijo.Text = "Dni:";
            this.lblDniFijo.Visible = false;
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnCliente.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.ForeColor = System.Drawing.Color.White;
            this.btnCliente.Location = new System.Drawing.Point(238, 523);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(107, 38);
            this.btnCliente.TabIndex = 179;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnDevoluciones
            // 
            this.btnDevoluciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnDevoluciones.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnDevoluciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevoluciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevoluciones.ForeColor = System.Drawing.Color.White;
            this.btnDevoluciones.Location = new System.Drawing.Point(921, 523);
            this.btnDevoluciones.Name = "btnDevoluciones";
            this.btnDevoluciones.Size = new System.Drawing.Size(107, 38);
            this.btnDevoluciones.TabIndex = 180;
            this.btnDevoluciones.Text = "Devoluciones";
            this.btnDevoluciones.UseVisualStyleBackColor = false;
            this.btnDevoluciones.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // AlquileresWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 564);
            this.Controls.Add(this.btnDevoluciones);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.lblDniFijo);
            this.Controls.Add(this.lblClienteFijo);
            this.Controls.Add(this.lblApeNom);
            this.Controls.Add(this.lblDniCliente);
            this.Controls.Add(this.lblidCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalPagarReal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.PanelPrecios);
            this.Controls.Add(this.dgvAlquiler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlquileresWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlquileresWF";
            this.Load += new System.EventHandler(this.AlquileresWF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquiler)).EndInit();
            this.PanelPrecios.ResumeLayout(false);
            this.PanelPrecios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlquiler;
        private System.Windows.Forms.Panel PanelPrecios;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFechaHasta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtFechaDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGrupo;
        private System.Windows.Forms.TextBox txtDescipcionBus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button lblTotalPagarReal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblidCliente;
        public System.Windows.Forms.Label lblDniCliente;
        public System.Windows.Forms.Label lblApeNom;
        public System.Windows.Forms.Label lblClienteFijo;
        public System.Windows.Forms.Label lblDniFijo;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnDevoluciones;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorAlquiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mod;
    }
}