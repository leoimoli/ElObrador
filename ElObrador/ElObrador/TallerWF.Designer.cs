﻿namespace ElObrador
{
    partial class TallerWF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TallerWF));
            this.dgvTaller = new System.Windows.Forms.DataGridView();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescipcionBus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblContador = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblidProducto = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoServicio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelVer = new System.Windows.Forms.Panel();
            this.btnSalidaTaller = new System.Windows.Forms.Button();
            this.lblidTaller = new System.Windows.Forms.Label();
            this.dgvHistorialTaller = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerHistorial = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label18 = new System.Windows.Forms.Label();
            this.btnNuevoHistorial = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaller)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelVer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialTaller)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTaller
            // 
            this.dgvTaller.AllowUserToAddRows = false;
            this.dgvTaller.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaller.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTaller.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaller.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaller.ColumnHeadersHeight = 30;
            this.dgvTaller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTaller.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProducto,
            this.RazonSocial,
            this.Domicilio,
            this.Telefono,
            this.Ver});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaller.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTaller.EnableHeadersVisualStyles = false;
            this.dgvTaller.Location = new System.Drawing.Point(15, 123);
            this.dgvTaller.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTaller.Name = "dgvTaller";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaller.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTaller.RowHeadersVisible = false;
            this.dgvTaller.RowHeadersWidth = 51;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvTaller.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTaller.Size = new System.Drawing.Size(763, 514);
            this.dgvTaller.TabIndex = 82;
            this.dgvTaller.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaller_CellClick);
            this.dgvTaller.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTaller_CellPainting);
            // 
            // idProducto
            // 
            this.idProducto.HeaderText = "id";
            this.idProducto.MinimumWidth = 6;
            this.idProducto.Name = "idProducto";
            this.idProducto.Visible = false;
            this.idProducto.Width = 50;
            // 
            // RazonSocial
            // 
            this.RazonSocial.HeaderText = "Material";
            this.RazonSocial.MinimumWidth = 6;
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.Width = 230;
            // 
            // Domicilio
            // 
            this.Domicilio.HeaderText = "Codigo";
            this.Domicilio.MinimumWidth = 6;
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.Width = 120;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Modelo";
            this.Telefono.MinimumWidth = 6;
            this.Telefono.Name = "Telefono";
            this.Telefono.Width = 140;
            // 
            // Ver
            // 
            this.Ver.HeaderText = "Seleccionar";
            this.Ver.MinimumWidth = 6;
            this.Ver.Name = "Ver";
            this.Ver.Width = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(23, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 81;
            this.label5.Text = "Buscar";
            // 
            // txtDescipcionBus
            // 
            this.txtDescipcionBus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescipcionBus.Location = new System.Drawing.Point(92, 95);
            this.txtDescipcionBus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescipcionBus.Name = "txtDescipcionBus";
            this.txtDescipcionBus.Size = new System.Drawing.Size(684, 22);
            this.txtDescipcionBus.TabIndex = 76;
            this.txtDescipcionBus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescipcionBus_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(20, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 29);
            this.label1.TabIndex = 79;
            this.label1.Text = "Materiales en Taller";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(25, 649);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(103, 34);
            this.btnNuevo.TabIndex = 77;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblContador);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.lblidProducto);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtDiagnostico);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dtFecha);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbTipoServicio);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.txtModelo);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.txtDescripcionProducto);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(787, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 592);
            this.panel1.TabIndex = 83;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblContador.Location = new System.Drawing.Point(529, 449);
            this.lblContador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(43, 23);
            this.lblContador.TabIndex = 192;
            this.lblContador.Text = "400";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblTotal.Location = new System.Drawing.Point(573, 449);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(52, 23);
            this.lblTotal.TabIndex = 191;
            this.lblTotal.Text = "/400";
            // 
            // lblidProducto
            // 
            this.lblidProducto.AutoSize = true;
            this.lblidProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidProducto.ForeColor = System.Drawing.Color.Black;
            this.lblidProducto.Location = new System.Drawing.Point(352, 74);
            this.lblidProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidProducto.Name = "lblidProducto";
            this.lblidProducto.Size = new System.Drawing.Size(27, 20);
            this.lblidProducto.TabIndex = 190;
            this.lblidProducto.Text = "@";
            this.lblidProducto.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(16, 265);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 20);
            this.label8.TabIndex = 189;
            this.label8.Text = "Diagnostico Inicial(*):";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(20, 289);
            this.txtDiagnostico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiagnostico.MaxLength = 400;
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(608, 155);
            this.txtDiagnostico.TabIndex = 188;
            this.txtDiagnostico.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(332, 183);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 20);
            this.label7.TabIndex = 187;
            this.label7.Text = "Fecha de de Ingreso:";
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(336, 209);
            this.dtFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(292, 22);
            this.dtFecha.TabIndex = 186;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 20);
            this.label3.TabIndex = 185;
            this.label3.Text = "Tipo de servicio(*):";
            // 
            // cmbTipoServicio
            // 
            this.cmbTipoServicio.FormattingEnabled = true;
            this.cmbTipoServicio.Location = new System.Drawing.Point(21, 208);
            this.cmbTipoServicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTipoServicio.Name = "cmbTipoServicio";
            this.cmbTipoServicio.Size = new System.Drawing.Size(292, 24);
            this.cmbTipoServicio.TabIndex = 184;
            this.cmbTipoServicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoServicio_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(332, 117);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 183;
            this.label6.Text = "Modelo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 182;
            this.label4.Text = "Código:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AutoSize = true;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(17, 37);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(116, 20);
            this.txtDescripcion.TabIndex = 181;
            this.txtDescripcion.Text = "Descripción:";
            // 
            // txtModelo
            // 
            this.txtModelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtModelo.Enabled = false;
            this.txtModelo.Location = new System.Drawing.Point(336, 142);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(292, 22);
            this.txtModelo.TabIndex = 180;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(21, 142);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(292, 22);
            this.txtCodigo.TabIndex = 179;
            // 
            // txtDescripcionProducto
            // 
            this.txtDescripcionProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionProducto.Enabled = false;
            this.txtDescripcionProducto.Location = new System.Drawing.Point(21, 62);
            this.txtDescripcionProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescripcionProducto.MaxLength = 50;
            this.txtDescripcionProducto.Multiline = true;
            this.txtDescripcionProducto.Name = "txtDescripcionProducto";
            this.txtDescripcionProducto.Size = new System.Drawing.Size(292, 51);
            this.txtDescripcionProducto.TabIndex = 178;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(83, 492);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(529, 28);
            this.progressBar1.Step = 50;
            this.progressBar1.TabIndex = 95;
            this.progressBar1.Value = 10;
            this.progressBar1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(16, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 23);
            this.label2.TabIndex = 42;
            this.label2.Text = "Nuevo Ingreso a Taller";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(147, 532);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(385, 47);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panelVer
            // 
            this.panelVer.BackColor = System.Drawing.Color.Gainsboro;
            this.panelVer.Controls.Add(this.btnSalidaTaller);
            this.panelVer.Controls.Add(this.lblidTaller);
            this.panelVer.Controls.Add(this.dgvHistorialTaller);
            this.panelVer.Controls.Add(this.label18);
            this.panelVer.Controls.Add(this.btnNuevoHistorial);
            this.panelVer.Location = new System.Drawing.Point(786, 82);
            this.panelVer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelVer.Name = "panelVer";
            this.panelVer.Size = new System.Drawing.Size(637, 592);
            this.panelVer.TabIndex = 84;
            this.panelVer.Visible = false;
            this.panelVer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelVer_Paint);
            // 
            // btnSalidaTaller
            // 
            this.btnSalidaTaller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnSalidaTaller.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnSalidaTaller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalidaTaller.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalidaTaller.ForeColor = System.Drawing.Color.White;
            this.btnSalidaTaller.Location = new System.Drawing.Point(84, 527);
            this.btnSalidaTaller.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalidaTaller.Name = "btnSalidaTaller";
            this.btnSalidaTaller.Size = new System.Drawing.Size(212, 47);
            this.btnSalidaTaller.TabIndex = 98;
            this.btnSalidaTaller.Text = "Salida de Taller";
            this.btnSalidaTaller.UseVisualStyleBackColor = false;
            this.btnSalidaTaller.Click += new System.EventHandler(this.btnSalidaTaller_Click);
            // 
            // lblidTaller
            // 
            this.lblidTaller.AutoSize = true;
            this.lblidTaller.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidTaller.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblidTaller.Location = new System.Drawing.Point(271, 9);
            this.lblidTaller.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidTaller.Name = "lblidTaller";
            this.lblidTaller.Size = new System.Drawing.Size(24, 23);
            this.lblidTaller.TabIndex = 97;
            this.lblidTaller.Text = "@";
            this.lblidTaller.Visible = false;
            // 
            // dgvHistorialTaller
            // 
            this.dgvHistorialTaller.AllowUserToAddRows = false;
            this.dgvHistorialTaller.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorialTaller.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorialTaller.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorialTaller.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHistorialTaller.ColumnHeadersHeight = 30;
            this.dgvHistorialTaller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistorialTaller.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Usuario,
            this.VerHistorial});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistorialTaller.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHistorialTaller.EnableHeadersVisualStyles = false;
            this.dgvHistorialTaller.Location = new System.Drawing.Point(5, 47);
            this.dgvHistorialTaller.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvHistorialTaller.Name = "dgvHistorialTaller";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorialTaller.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvHistorialTaller.RowHeadersVisible = false;
            this.dgvHistorialTaller.RowHeadersWidth = 51;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dgvHistorialTaller.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHistorialTaller.Size = new System.Drawing.Size(625, 420);
            this.dgvHistorialTaller.TabIndex = 96;
            this.dgvHistorialTaller.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorialTaller_CellClick);
            this.dgvHistorialTaller.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvHistorialTaller_CellPainting);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Nro.Historial";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.MinimumWidth = 6;
            this.Usuario.Name = "Usuario";
            this.Usuario.Width = 125;
            // 
            // VerHistorial
            // 
            this.VerHistorial.HeaderText = "Ver";
            this.VerHistorial.MinimumWidth = 6;
            this.VerHistorial.Name = "VerHistorial";
            this.VerHistorial.Width = 70;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label18.Location = new System.Drawing.Point(16, 9);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(167, 23);
            this.label18.TabIndex = 42;
            this.label18.Text = "Historial de Taller";
            // 
            // btnNuevoHistorial
            // 
            this.btnNuevoHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnNuevoHistorial.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnNuevoHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoHistorial.ForeColor = System.Drawing.Color.White;
            this.btnNuevoHistorial.Location = new System.Drawing.Point(377, 527);
            this.btnNuevoHistorial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevoHistorial.Name = "btnNuevoHistorial";
            this.btnNuevoHistorial.Size = new System.Drawing.Size(212, 47);
            this.btnNuevoHistorial.TabIndex = 13;
            this.btnNuevoHistorial.Text = "Nuevo Historial";
            this.btnNuevoHistorial.UseVisualStyleBackColor = false;
            this.btnNuevoHistorial.Click += new System.EventHandler(this.btnNuevoHistorial_Click);
            // 
            // TallerWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 694);
            this.Controls.Add(this.panelVer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvTaller);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescipcionBus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNuevo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TallerWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TallerWF";
            this.Load += new System.EventHandler(this.TallerWF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaller)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelVer.ResumeLayout(false);
            this.panelVer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialTaller)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTaller;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescipcionBus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoServicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiagnostico;
        public System.Windows.Forms.Label lblidProducto;
        public System.Windows.Forms.TextBox txtModelo;
        public System.Windows.Forms.TextBox txtCodigo;
        public System.Windows.Forms.TextBox txtDescripcionProducto;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panelVer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnNuevoHistorial;
        private System.Windows.Forms.DataGridView dgvHistorialTaller;
        private System.Windows.Forms.Label lblidTaller;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewButtonColumn VerHistorial;
        private System.Windows.Forms.Button btnSalidaTaller;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewButtonColumn Ver;
    }
}