namespace ElObrador
{
    partial class ConfiguracionesWF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguracionesWF));
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescipcionBus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PanelPrecios = new System.Windows.Forms.Panel();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnDestildar = new System.Windows.Forms.Button();
            this.btnTildar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnGuardarProducto = new System.Windows.Forms.Button();
            this.btnPrecios = new System.Windows.Forms.Button();
            this.btnFeriados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.PanelPrecios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(24, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 17);
            this.label5.TabIndex = 77;
            this.label5.Text = "Buscar Categoria";
            // 
            // txtDescipcionBus
            // 
            this.txtDescipcionBus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescipcionBus.Location = new System.Drawing.Point(171, 111);
            this.txtDescipcionBus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescipcionBus.Name = "txtDescipcionBus";
            this.txtDescipcionBus.Size = new System.Drawing.Size(480, 22);
            this.txtDescipcionBus.TabIndex = 76;
            this.txtDescipcionBus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescipcionBus_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(23, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 29);
            this.label1.TabIndex = 75;
            this.label1.Text = "Listado de Materiales";
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStock.ColumnHeadersHeight = 30;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProducto,
            this.Material,
            this.Stock,
            this.Ver});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStock.EnableHeadersVisualStyles = false;
            this.dgvStock.Location = new System.Drawing.Point(16, 144);
            this.dgvStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvStock.Name = "dgvStock";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStock.RowHeadersVisible = false;
            this.dgvStock.RowHeadersWidth = 51;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvStock.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStock.Size = new System.Drawing.Size(667, 505);
            this.dgvStock.TabIndex = 74;
            this.dgvStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
            this.dgvStock.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvStock_CellPainting);
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
            this.Material.HeaderText = "Categoria";
            this.Material.MinimumWidth = 6;
            this.Material.Name = "Material";
            this.Material.Width = 205;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.Width = 190;
            // 
            // Ver
            // 
            this.Ver.HeaderText = "Ver";
            this.Ver.MinimumWidth = 6;
            this.Ver.Name = "Ver";
            this.Ver.Width = 125;
            // 
            // PanelPrecios
            // 
            this.PanelPrecios.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelPrecios.Controls.Add(this.btnHistorial);
            this.PanelPrecios.Controls.Add(this.btnDestildar);
            this.PanelPrecios.Controls.Add(this.btnTildar);
            this.PanelPrecios.Controls.Add(this.label8);
            this.PanelPrecios.Controls.Add(this.txtMonto);
            this.PanelPrecios.Controls.Add(this.lblCategoria);
            this.PanelPrecios.Controls.Add(this.label2);
            this.PanelPrecios.Controls.Add(this.dataGridView1);
            this.PanelPrecios.Controls.Add(this.progressBar1);
            this.PanelPrecios.Controls.Add(this.btnGuardarProducto);
            this.PanelPrecios.Enabled = false;
            this.PanelPrecios.Location = new System.Drawing.Point(753, 103);
            this.PanelPrecios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelPrecios.Name = "PanelPrecios";
            this.PanelPrecios.Size = new System.Drawing.Size(668, 545);
            this.PanelPrecios.TabIndex = 167;
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnHistorial.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.Color.White;
            this.btnHistorial.Location = new System.Drawing.Point(281, 226);
            this.btnHistorial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(116, 41);
            this.btnHistorial.TabIndex = 187;
            this.btnHistorial.Text = "Ver Historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnDestildar
            // 
            this.btnDestildar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnDestildar.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnDestildar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDestildar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDestildar.ForeColor = System.Drawing.Color.White;
            this.btnDestildar.Location = new System.Drawing.Point(145, 226);
            this.btnDestildar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDestildar.Name = "btnDestildar";
            this.btnDestildar.Size = new System.Drawing.Size(116, 41);
            this.btnDestildar.TabIndex = 186;
            this.btnDestildar.Text = "Destildar";
            this.btnDestildar.UseVisualStyleBackColor = false;
            this.btnDestildar.Click += new System.EventHandler(this.btnDestildar_Click);
            // 
            // btnTildar
            // 
            this.btnTildar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnTildar.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnTildar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTildar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTildar.ForeColor = System.Drawing.Color.White;
            this.btnTildar.Location = new System.Drawing.Point(7, 226);
            this.btnTildar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTildar.Name = "btnTildar";
            this.btnTildar.Size = new System.Drawing.Size(116, 41);
            this.btnTildar.TabIndex = 185;
            this.btnTildar.Text = "Tildar Todos";
            this.btnTildar.UseVisualStyleBackColor = false;
            this.btnTildar.Click += new System.EventHandler(this.btnTildar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(71, 311);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 20);
            this.label8.TabIndex = 184;
            this.label8.Text = "Valor de Alquiler(*):";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(281, 310);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(292, 22);
            this.txtMonto.TabIndex = 183;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblCategoria.Location = new System.Drawing.Point(260, 11);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(27, 20);
            this.lblCategoria.TabIndex = 171;
            this.lblCategoria.Text = "@";
            this.lblCategoria.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 25);
            this.label2.TabIndex = 170;
            this.label2.Text = "Categoria Seleccionada: ";
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
            this.dataGridView1.Location = new System.Drawing.Point(4, 38);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Size = new System.Drawing.Size(660, 185);
            this.dataGridView1.TabIndex = 169;
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
            this.progressBar1.Location = new System.Drawing.Point(81, 378);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(529, 28);
            this.progressBar1.Step = 50;
            this.progressBar1.TabIndex = 168;
            this.progressBar1.Value = 10;
            this.progressBar1.Visible = false;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // btnGuardarProducto
            // 
            this.btnGuardarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnGuardarProducto.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnGuardarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarProducto.ForeColor = System.Drawing.Color.White;
            this.btnGuardarProducto.Location = new System.Drawing.Point(161, 414);
            this.btnGuardarProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardarProducto.Name = "btnGuardarProducto";
            this.btnGuardarProducto.Size = new System.Drawing.Size(385, 47);
            this.btnGuardarProducto.TabIndex = 166;
            this.btnGuardarProducto.Text = "Guardar";
            this.btnGuardarProducto.UseVisualStyleBackColor = false;
            this.btnGuardarProducto.Click += new System.EventHandler(this.btnGuardarProducto_Click);
            // 
            // btnPrecios
            // 
            this.btnPrecios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnPrecios.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnPrecios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrecios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrecios.ForeColor = System.Drawing.Color.White;
            this.btnPrecios.Location = new System.Drawing.Point(16, 656);
            this.btnPrecios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrecios.Name = "btnPrecios";
            this.btnPrecios.Size = new System.Drawing.Size(181, 34);
            this.btnPrecios.TabIndex = 168;
            this.btnPrecios.Text = "Precios Alquiler";
            this.btnPrecios.UseVisualStyleBackColor = false;
            // 
            // btnFeriados
            // 
            this.btnFeriados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnFeriados.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnFeriados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeriados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeriados.ForeColor = System.Drawing.Color.White;
            this.btnFeriados.Location = new System.Drawing.Point(205, 656);
            this.btnFeriados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFeriados.Name = "btnFeriados";
            this.btnFeriados.Size = new System.Drawing.Size(181, 34);
            this.btnFeriados.TabIndex = 169;
            this.btnFeriados.Text = "Feriados";
            this.btnFeriados.UseVisualStyleBackColor = false;
            this.btnFeriados.Click += new System.EventHandler(this.btnFeriados_Click);
            // 
            // ConfiguracionesWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 694);
            this.Controls.Add(this.btnFeriados);
            this.Controls.Add(this.btnPrecios);
            this.Controls.Add(this.PanelPrecios);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescipcionBus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConfiguracionesWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuraciones";
            this.Load += new System.EventHandler(this.ConfiguracionesWF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.PanelPrecios.ResumeLayout(false);
            this.PanelPrecios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescipcionBus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewButtonColumn Ver;
        private System.Windows.Forms.Panel PanelPrecios;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnGuardarProducto;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Button btnDestildar;
        private System.Windows.Forms.Button btnTildar;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnPrecios;
        private System.Windows.Forms.Button btnFeriados;
    }
}