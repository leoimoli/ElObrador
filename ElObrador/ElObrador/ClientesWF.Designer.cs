namespace ElObrador
{
    partial class ClientesWF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesWF));
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoBus = new System.Windows.Forms.TextBox();
            this.txtDescipcionBus = new System.Windows.Forms.TextBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFaltaDocumentacion = new System.Windows.Forms.Label();
            this.chcFacturas = new System.Windows.Forms.CheckBox();
            this.grbTipoFactura = new System.Windows.Forms.GroupBox();
            this.chcOtros = new System.Windows.Forms.CheckBox();
            this.chcTelefono = new System.Windows.Forms.CheckBox();
            this.chcGas = new System.Windows.Forms.CheckBox();
            this.chcAgua = new System.Windows.Forms.CheckBox();
            this.chcLuz = new System.Windows.Forms.CheckBox();
            this.chcFotocopiaDNI = new System.Windows.Forms.CheckBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCodArea = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnLibreDeuda = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.grbTipoFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnHistorial.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.Color.White;
            this.btnHistorial.Location = new System.Drawing.Point(280, 534);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(77, 28);
            this.btnHistorial.TabIndex = 68;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Visible = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(14, 534);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(77, 28);
            this.btnNuevo.TabIndex = 67;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label6.Location = new System.Drawing.Point(359, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Buscar por DNI";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(12, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Buscar por Apellido y Nombre";
            // 
            // txtCodigoBus
            // 
            this.txtCodigoBus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoBus.Location = new System.Drawing.Point(459, 81);
            this.txtCodigoBus.Name = "txtCodigoBus";
            this.txtCodigoBus.Size = new System.Drawing.Size(142, 20);
            this.txtCodigoBus.TabIndex = 64;
            this.txtCodigoBus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoBus_KeyDown);
            // 
            // txtDescipcionBus
            // 
            this.txtDescipcionBus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescipcionBus.Location = new System.Drawing.Point(191, 81);
            this.txtDescipcionBus.Name = "txtDescipcionBus";
            this.txtDescipcionBus.Size = new System.Drawing.Size(158, 20);
            this.txtDescipcionBus.TabIndex = 63;
            this.txtDescipcionBus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescipcionBus_KeyDown);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(97, 534);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(77, 28);
            this.btnEditar.TabIndex = 62;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblFaltaDocumentacion);
            this.panel1.Controls.Add(this.chcFacturas);
            this.panel1.Controls.Add(this.grbTipoFactura);
            this.panel1.Controls.Add(this.chcFotocopiaDNI);
            this.panel1.Controls.Add(this.txtLocalidad);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtProvincia);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbSexo);
            this.panel1.Controls.Add(this.txtAltura);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtTelefono);
            this.panel1.Controls.Add(this.txtCodArea);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtCalle);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtApellido);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtDni);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Location = new System.Drawing.Point(606, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 481);
            this.panel1.TabIndex = 61;
            // 
            // lblFaltaDocumentacion
            // 
            this.lblFaltaDocumentacion.AutoSize = true;
            this.lblFaltaDocumentacion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaltaDocumentacion.ForeColor = System.Drawing.Color.Red;
            this.lblFaltaDocumentacion.Location = new System.Drawing.Point(131, 7);
            this.lblFaltaDocumentacion.Name = "lblFaltaDocumentacion";
            this.lblFaltaDocumentacion.Size = new System.Drawing.Size(320, 18);
            this.lblFaltaDocumentacion.TabIndex = 125;
            this.lblFaltaDocumentacion.Text = "Atención: Debe presentar documentación";
            this.lblFaltaDocumentacion.Visible = false;
            // 
            // chcFacturas
            // 
            this.chcFacturas.AutoSize = true;
            this.chcFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcFacturas.ForeColor = System.Drawing.Color.Black;
            this.chcFacturas.Location = new System.Drawing.Point(244, 322);
            this.chcFacturas.Name = "chcFacturas";
            this.chcFacturas.Size = new System.Drawing.Size(209, 21);
            this.chcFacturas.TabIndex = 124;
            this.chcFacturas.Text = "Comprobante de Servicio";
            this.chcFacturas.UseVisualStyleBackColor = true;
            this.chcFacturas.CheckedChanged += new System.EventHandler(this.chcFacturas_CheckedChanged);
            // 
            // grbTipoFactura
            // 
            this.grbTipoFactura.Controls.Add(this.chcOtros);
            this.grbTipoFactura.Controls.Add(this.chcTelefono);
            this.grbTipoFactura.Controls.Add(this.chcGas);
            this.grbTipoFactura.Controls.Add(this.chcAgua);
            this.grbTipoFactura.Controls.Add(this.chcLuz);
            this.grbTipoFactura.Location = new System.Drawing.Point(16, 362);
            this.grbTipoFactura.Name = "grbTipoFactura";
            this.grbTipoFactura.Size = new System.Drawing.Size(406, 64);
            this.grbTipoFactura.TabIndex = 78;
            this.grbTipoFactura.TabStop = false;
            this.grbTipoFactura.Text = "Tipo de Comprobante";
            this.grbTipoFactura.Visible = false;
            // 
            // chcOtros
            // 
            this.chcOtros.AutoSize = true;
            this.chcOtros.ForeColor = System.Drawing.Color.Black;
            this.chcOtros.Location = new System.Drawing.Point(148, 47);
            this.chcOtros.Name = "chcOtros";
            this.chcOtros.Size = new System.Drawing.Size(51, 17);
            this.chcOtros.TabIndex = 124;
            this.chcOtros.Text = "Otros";
            this.chcOtros.UseVisualStyleBackColor = true;
            // 
            // chcTelefono
            // 
            this.chcTelefono.AutoSize = true;
            this.chcTelefono.ForeColor = System.Drawing.Color.Black;
            this.chcTelefono.Location = new System.Drawing.Point(10, 47);
            this.chcTelefono.Name = "chcTelefono";
            this.chcTelefono.Size = new System.Drawing.Size(122, 17);
            this.chcTelefono.TabIndex = 123;
            this.chcTelefono.Text = "Factura de Teléfono";
            this.chcTelefono.UseVisualStyleBackColor = true;
            // 
            // chcGas
            // 
            this.chcGas.AutoSize = true;
            this.chcGas.ForeColor = System.Drawing.Color.Black;
            this.chcGas.Location = new System.Drawing.Point(301, 19);
            this.chcGas.Name = "chcGas";
            this.chcGas.Size = new System.Drawing.Size(99, 17);
            this.chcGas.TabIndex = 122;
            this.chcGas.Text = "Factura de Gas";
            this.chcGas.UseVisualStyleBackColor = true;
            // 
            // chcAgua
            // 
            this.chcAgua.AutoSize = true;
            this.chcAgua.ForeColor = System.Drawing.Color.Black;
            this.chcAgua.Location = new System.Drawing.Point(148, 19);
            this.chcAgua.Name = "chcAgua";
            this.chcAgua.Size = new System.Drawing.Size(105, 17);
            this.chcAgua.TabIndex = 121;
            this.chcAgua.Text = "Factura de Agua";
            this.chcAgua.UseVisualStyleBackColor = true;
            // 
            // chcLuz
            // 
            this.chcLuz.AutoSize = true;
            this.chcLuz.ForeColor = System.Drawing.Color.Black;
            this.chcLuz.Location = new System.Drawing.Point(10, 19);
            this.chcLuz.Name = "chcLuz";
            this.chcLuz.Size = new System.Drawing.Size(97, 17);
            this.chcLuz.TabIndex = 120;
            this.chcLuz.Text = "Factura de Luz";
            this.chcLuz.UseVisualStyleBackColor = true;
            // 
            // chcFotocopiaDNI
            // 
            this.chcFotocopiaDNI.AutoSize = true;
            this.chcFotocopiaDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcFotocopiaDNI.ForeColor = System.Drawing.Color.Black;
            this.chcFotocopiaDNI.Location = new System.Drawing.Point(13, 322);
            this.chcFotocopiaDNI.Name = "chcFotocopiaDNI";
            this.chcFotocopiaDNI.Size = new System.Drawing.Size(177, 21);
            this.chcFotocopiaDNI.TabIndex = 117;
            this.chcFotocopiaDNI.Text = "Comprobante de DNI";
            this.chcFotocopiaDNI.UseVisualStyleBackColor = true;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocalidad.Enabled = false;
            this.txtLocalidad.Location = new System.Drawing.Point(244, 227);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(200, 20);
            this.txtLocalidad.TabIndex = 8;
            this.txtLocalidad.TextChanged += new System.EventHandler(this.txtLocalidad_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(242, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 116;
            this.label7.Text = "Localidad(*)";
            // 
            // txtProvincia
            // 
            this.txtProvincia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProvincia.Enabled = false;
            this.txtProvincia.Location = new System.Drawing.Point(13, 227);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(200, 20);
            this.txtProvincia.TabIndex = 7;
            this.txtProvincia.Click += new System.EventHandler(this.txtProvincia_Click);
            this.txtProvincia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProvincia_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(13, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 17);
            this.label10.TabIndex = 115;
            this.label10.Text = "Provincia(*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(242, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 112;
            this.label3.Text = "Sexo(*)";
            // 
            // cmbSexo
            // 
            this.cmbSexo.Enabled = false;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Location = new System.Drawing.Point(245, 58);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(200, 21);
            this.cmbSexo.TabIndex = 1;
            this.cmbSexo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSexo_KeyPress);
            // 
            // txtAltura
            // 
            this.txtAltura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAltura.Enabled = false;
            this.txtAltura.Location = new System.Drawing.Point(244, 285);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(200, 20);
            this.txtAltura.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(242, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 111;
            this.label4.Text = "Altura";
            // 
            // txtTelefono
            // 
            this.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(300, 169);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(145, 20);
            this.txtTelefono.TabIndex = 6;
            // 
            // txtCodArea
            // 
            this.txtCodArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodArea.Enabled = false;
            this.txtCodArea.Location = new System.Drawing.Point(244, 169);
            this.txtCodArea.Name = "txtCodArea";
            this.txtCodArea.Size = new System.Drawing.Size(50, 20);
            this.txtCodArea.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(242, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 110;
            this.label8.Text = "Teléfono";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(245, 116);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(242, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 17);
            this.label13.TabIndex = 109;
            this.label13.Text = "Nombre(*)";
            // 
            // txtCalle
            // 
            this.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalle.Enabled = false;
            this.txtCalle.Location = new System.Drawing.Point(13, 285);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(200, 20);
            this.txtCalle.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(13, 265);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 17);
            this.label14.TabIndex = 103;
            this.label14.Text = "Calle";
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(13, 169);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(10, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 102;
            this.label9.Text = "Email";
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(13, 116);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(10, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 17);
            this.label11.TabIndex = 101;
            this.label11.Text = "Apellido(*)";
            // 
            // txtDni
            // 
            this.txtDni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDni.Enabled = false;
            this.txtDni.Location = new System.Drawing.Point(13, 58);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(200, 20);
            this.txtDni.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(10, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(168, 17);
            this.label12.TabIndex = 100;
            this.label12.Text = "Número Documento(*)";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(56, 253);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(397, 23);
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
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 18);
            this.label2.TabIndex = 42;
            this.label2.Text = "Nuevo Cliente";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(110, 432);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(289, 38);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 24);
            this.label1.TabIndex = 60;
            this.label1.Text = "Listado de Clientes";
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientes.ColumnHeadersHeight = 30;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProducto,
            this.RazonSocial,
            this.Domicilio,
            this.Email,
            this.Telefono});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClientes.EnableHeadersVisualStyles = false;
            this.dgvClientes.Location = new System.Drawing.Point(5, 107);
            this.dgvClientes.Name = "dgvClientes";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowHeadersWidth = 51;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvClientes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvClientes.Size = new System.Drawing.Size(596, 421);
            this.dgvClientes.TabIndex = 76;
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
            this.RazonSocial.HeaderText = "Apellido y Nombre";
            this.RazonSocial.MinimumWidth = 6;
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.Width = 200;
            // 
            // Domicilio
            // 
            this.Domicilio.HeaderText = "Domicilio";
            this.Domicilio.MinimumWidth = 6;
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.Width = 190;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.MinimumWidth = 6;
            this.Telefono.Name = "Telefono";
            this.Telefono.Width = 150;
            // 
            // btnLibreDeuda
            // 
            this.btnLibreDeuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnLibreDeuda.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnLibreDeuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibreDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibreDeuda.ForeColor = System.Drawing.Color.White;
            this.btnLibreDeuda.Location = new System.Drawing.Point(181, 534);
            this.btnLibreDeuda.Name = "btnLibreDeuda";
            this.btnLibreDeuda.Size = new System.Drawing.Size(93, 28);
            this.btnLibreDeuda.TabIndex = 77;
            this.btnLibreDeuda.Text = "Libre Deuda";
            this.btnLibreDeuda.UseVisualStyleBackColor = false;
            this.btnLibreDeuda.Click += new System.EventHandler(this.btnLibreDeuda_Click);
            // 
            // ClientesWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 564);
            this.Controls.Add(this.btnLibreDeuda);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodigoBus);
            this.Controls.Add(this.txtDescipcionBus);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientesWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientesWF";
            this.Load += new System.EventHandler(this.ClientesWF_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbTipoFactura.ResumeLayout(false);
            this.grbTipoFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoBus;
        private System.Windows.Forms.TextBox txtDescipcionBus;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCodArea;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.Button btnLibreDeuda;
        private System.Windows.Forms.GroupBox grbTipoFactura;
        private System.Windows.Forms.CheckBox chcTelefono;
        private System.Windows.Forms.CheckBox chcGas;
        private System.Windows.Forms.CheckBox chcAgua;
        private System.Windows.Forms.CheckBox chcLuz;
        private System.Windows.Forms.CheckBox chcFotocopiaDNI;
        private System.Windows.Forms.CheckBox chcFacturas;
        private System.Windows.Forms.CheckBox chcOtros;
        private System.Windows.Forms.Label lblFaltaDocumentacion;
    }
}