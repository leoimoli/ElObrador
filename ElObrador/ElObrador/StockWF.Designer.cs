namespace ElObrador
{
    partial class StockWF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockWF));
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescipcionBus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistroStock = new System.Windows.Forms.Button();
            this.PanelDerecho = new System.Windows.Forms.Panel();
            this.PanelNuevoMaterial = new System.Windows.Forms.Panel();
            this.btnCrearCodigo = new System.Windows.Forms.Button();
            this.btnCrerarProveedor = new System.Windows.Forms.Button();
            this.btnCrearCategoria = new System.Windows.Forms.Button();
            this.btnCrearGrupo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFacturaRemito = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGrupo = new System.Windows.Forms.ComboBox();
            this.lblContador = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
            this.btnGuardarProducto = new System.Windows.Forms.Button();
            this.lblNuevoProducto = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.PanelDerecho.SuspendLayout();
            this.PanelNuevoMaterial.SuspendLayout();
            this.SuspendLayout();
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
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStock.EnableHeadersVisualStyles = false;
            this.dgvStock.Location = new System.Drawing.Point(16, 130);
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
            this.dgvStock.Size = new System.Drawing.Size(667, 514);
            this.dgvStock.TabIndex = 70;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(24, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 17);
            this.label5.TabIndex = 73;
            this.label5.Text = "Buscar por Categoría";
            // 
            // txtDescipcionBus
            // 
            this.txtDescipcionBus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescipcionBus.Location = new System.Drawing.Point(217, 87);
            this.txtDescipcionBus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescipcionBus.Name = "txtDescipcionBus";
            this.txtDescipcionBus.Size = new System.Drawing.Size(433, 22);
            this.txtDescipcionBus.TabIndex = 72;
            this.txtDescipcionBus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescipcionBus_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(23, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 29);
            this.label1.TabIndex = 71;
            this.label1.Text = "Stock de Materiales";
            // 
            // btnRegistroStock
            // 
            this.btnRegistroStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnRegistroStock.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnRegistroStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistroStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistroStock.ForeColor = System.Drawing.Color.White;
            this.btnRegistroStock.Location = new System.Drawing.Point(16, 657);
            this.btnRegistroStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegistroStock.Name = "btnRegistroStock";
            this.btnRegistroStock.Size = new System.Drawing.Size(181, 34);
            this.btnRegistroStock.TabIndex = 75;
            this.btnRegistroStock.Text = "Registrar Stock";
            this.btnRegistroStock.UseVisualStyleBackColor = false;
            this.btnRegistroStock.Click += new System.EventHandler(this.btnRegistroStock_Click);
            // 
            // PanelDerecho
            // 
            this.PanelDerecho.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelDerecho.Controls.Add(this.PanelNuevoMaterial);
            this.PanelDerecho.Controls.Add(this.lblNuevoProducto);
            this.PanelDerecho.Location = new System.Drawing.Point(743, 58);
            this.PanelDerecho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelDerecho.Name = "PanelDerecho";
            this.PanelDerecho.Size = new System.Drawing.Size(676, 634);
            this.PanelDerecho.TabIndex = 77;
            // 
            // PanelNuevoMaterial
            // 
            this.PanelNuevoMaterial.Controls.Add(this.btnCrearCodigo);
            this.PanelNuevoMaterial.Controls.Add(this.btnCrerarProveedor);
            this.PanelNuevoMaterial.Controls.Add(this.btnCrearCategoria);
            this.PanelNuevoMaterial.Controls.Add(this.btnCrearGrupo);
            this.PanelNuevoMaterial.Controls.Add(this.label10);
            this.PanelNuevoMaterial.Controls.Add(this.txtProveedor);
            this.PanelNuevoMaterial.Controls.Add(this.label9);
            this.PanelNuevoMaterial.Controls.Add(this.txtFacturaRemito);
            this.PanelNuevoMaterial.Controls.Add(this.label8);
            this.PanelNuevoMaterial.Controls.Add(this.txtMonto);
            this.PanelNuevoMaterial.Controls.Add(this.label7);
            this.PanelNuevoMaterial.Controls.Add(this.dtFechaCompra);
            this.PanelNuevoMaterial.Controls.Add(this.label6);
            this.PanelNuevoMaterial.Controls.Add(this.txtModelo);
            this.PanelNuevoMaterial.Controls.Add(this.label4);
            this.PanelNuevoMaterial.Controls.Add(this.txtCodigo);
            this.PanelNuevoMaterial.Controls.Add(this.label3);
            this.PanelNuevoMaterial.Controls.Add(this.cmbCategoria);
            this.PanelNuevoMaterial.Controls.Add(this.label2);
            this.PanelNuevoMaterial.Controls.Add(this.cmbGrupo);
            this.PanelNuevoMaterial.Controls.Add(this.lblContador);
            this.PanelNuevoMaterial.Controls.Add(this.lblTotal);
            this.PanelNuevoMaterial.Controls.Add(this.txtDescripcion);
            this.PanelNuevoMaterial.Controls.Add(this.progressBar1);
            this.PanelNuevoMaterial.Controls.Add(this.txtDescripcionProducto);
            this.PanelNuevoMaterial.Controls.Add(this.btnGuardarProducto);
            this.PanelNuevoMaterial.Enabled = false;
            this.PanelNuevoMaterial.Location = new System.Drawing.Point(4, 38);
            this.PanelNuevoMaterial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelNuevoMaterial.Name = "PanelNuevoMaterial";
            this.PanelNuevoMaterial.Size = new System.Drawing.Size(668, 592);
            this.PanelNuevoMaterial.TabIndex = 166;
            // 
            // btnCrearCodigo
            // 
            this.btnCrearCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnCrearCodigo.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCrearCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearCodigo.ForeColor = System.Drawing.Color.White;
            this.btnCrearCodigo.Image = global::ElObrador.Properties.Resources.mas__2_;
            this.btnCrearCodigo.Location = new System.Drawing.Point(517, 159);
            this.btnCrearCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCrearCodigo.Name = "btnCrearCodigo";
            this.btnCrearCodigo.Size = new System.Drawing.Size(36, 36);
            this.btnCrearCodigo.TabIndex = 190;
            this.toolTip1.SetToolTip(this.btnCrearCodigo, "Generar Código");
            this.btnCrearCodigo.UseVisualStyleBackColor = false;
            this.btnCrearCodigo.Click += new System.EventHandler(this.btnCrearCodigo_Click);
            // 
            // btnCrerarProveedor
            // 
            this.btnCrerarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnCrerarProveedor.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCrerarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrerarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrerarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnCrerarProveedor.Image = global::ElObrador.Properties.Resources.mas__2_;
            this.btnCrerarProveedor.Location = new System.Drawing.Point(517, 426);
            this.btnCrerarProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCrerarProveedor.Name = "btnCrerarProveedor";
            this.btnCrerarProveedor.Size = new System.Drawing.Size(36, 36);
            this.btnCrerarProveedor.TabIndex = 189;
            this.toolTip1.SetToolTip(this.btnCrerarProveedor, "Nuevo Proveedor");
            this.btnCrerarProveedor.UseVisualStyleBackColor = false;
            this.btnCrerarProveedor.Visible = false;
            this.btnCrerarProveedor.Click += new System.EventHandler(this.btnCrerarProveedor_Click);
            // 
            // btnCrearCategoria
            // 
            this.btnCrearCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnCrearCategoria.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCrearCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearCategoria.ForeColor = System.Drawing.Color.White;
            this.btnCrearCategoria.Image = global::ElObrador.Properties.Resources.mas__2_;
            this.btnCrearCategoria.Location = new System.Drawing.Point(517, 52);
            this.btnCrearCategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCrearCategoria.Name = "btnCrearCategoria";
            this.btnCrearCategoria.Size = new System.Drawing.Size(36, 36);
            this.btnCrearCategoria.TabIndex = 188;
            this.toolTip1.SetToolTip(this.btnCrearCategoria, "Crear Cátegoria");
            this.btnCrearCategoria.UseVisualStyleBackColor = false;
            this.btnCrearCategoria.Click += new System.EventHandler(this.btnCrearCategoria_Click);
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnCrearGrupo.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCrearGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearGrupo.ForeColor = System.Drawing.Color.White;
            this.btnCrearGrupo.Image = global::ElObrador.Properties.Resources.mas__2_;
            this.btnCrearGrupo.Location = new System.Drawing.Point(517, 5);
            this.btnCrearGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(36, 36);
            this.btnCrearGrupo.TabIndex = 187;
            this.toolTip1.SetToolTip(this.btnCrearGrupo, "Crear Grupo");
            this.btnCrearGrupo.UseVisualStyleBackColor = false;
            this.btnCrearGrupo.Click += new System.EventHandler(this.btnCrearGrupo_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(93, 432);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 20);
            this.label10.TabIndex = 186;
            this.label10.Text = "Proveedor:";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(215, 431);
            this.txtProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(292, 22);
            this.txtProveedor.TabIndex = 185;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(28, 379);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 20);
            this.label9.TabIndex = 184;
            this.label9.Text = "Factura o Remito:";
            // 
            // txtFacturaRemito
            // 
            this.txtFacturaRemito.Location = new System.Drawing.Point(215, 378);
            this.txtFacturaRemito.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFacturaRemito.Name = "txtFacturaRemito";
            this.txtFacturaRemito.Size = new System.Drawing.Size(292, 22);
            this.txtFacturaRemito.TabIndex = 183;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(27, 325);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 20);
            this.label8.TabIndex = 182;
            this.label8.Text = "Monto de compra:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(215, 324);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(292, 22);
            this.txtMonto.TabIndex = 181;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosyDecimales);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(24, 277);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 20);
            this.label7.TabIndex = 180;
            this.label7.Text = "Fecha de Compra:";
            // 
            // dtFechaCompra
            // 
            this.dtFechaCompra.Location = new System.Drawing.Point(215, 272);
            this.dtFechaCompra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFechaCompra.Name = "dtFechaCompra";
            this.dtFechaCompra.Size = new System.Drawing.Size(292, 22);
            this.dtFechaCompra.TabIndex = 179;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(124, 219);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 178;
            this.label6.Text = "Modelo:";
            // 
            // txtModelo
            // 
            this.txtModelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtModelo.Location = new System.Drawing.Point(215, 218);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(292, 22);
            this.txtModelo.TabIndex = 177;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(103, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 176;
            this.label4.Text = "Código(*):";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(215, 165);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(292, 22);
            this.txtCodigo.TabIndex = 175;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(76, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 174;
            this.label3.Text = "Categoria(*):";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(215, 57);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(292, 24);
            this.cmbCategoria.TabIndex = 173;
            this.cmbCategoria.Click += new System.EventHandler(this.cmbCategoria_Click);
            this.cmbCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCategoria_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(109, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 172;
            this.label2.Text = "Grupo(*):";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Location = new System.Drawing.Point(215, 9);
            this.cmbGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(292, 24);
            this.cmbGrupo.TabIndex = 167;
            this.cmbGrupo.SelectedIndexChanged += new System.EventHandler(this.cmbGrupo_SelectedIndexChanged);
            this.cmbGrupo.Click += new System.EventHandler(this.cmbGrupo_Click);
            this.cmbGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGrupo_KeyPress);
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblContador.Location = new System.Drawing.Point(513, 113);
            this.lblContador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(32, 23);
            this.lblContador.TabIndex = 171;
            this.lblContador.Text = "50";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblTotal.Location = new System.Drawing.Point(543, 113);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 23);
            this.lblTotal.TabIndex = 170;
            this.lblTotal.Text = "/50";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AutoSize = true;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(56, 116);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(137, 20);
            this.txtDescripcion.TabIndex = 169;
            this.txtDescripcion.Text = "Descripción(*):";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(83, 463);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(529, 28);
            this.progressBar1.Step = 50;
            this.progressBar1.TabIndex = 168;
            this.progressBar1.Value = 10;
            this.progressBar1.Visible = false;
            // 
            // txtDescripcionProducto
            // 
            this.txtDescripcionProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionProducto.Location = new System.Drawing.Point(215, 98);
            this.txtDescripcionProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescripcionProducto.MaxLength = 50;
            this.txtDescripcionProducto.Multiline = true;
            this.txtDescripcionProducto.Name = "txtDescripcionProducto";
            this.txtDescripcionProducto.Size = new System.Drawing.Size(292, 51);
            this.txtDescripcionProducto.TabIndex = 167;
            this.txtDescripcionProducto.TextChanged += new System.EventHandler(this.txtDescripcionProducto_TextChanged);
            // 
            // btnGuardarProducto
            // 
            this.btnGuardarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.btnGuardarProducto.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnGuardarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarProducto.ForeColor = System.Drawing.Color.White;
            this.btnGuardarProducto.Location = new System.Drawing.Point(159, 502);
            this.btnGuardarProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardarProducto.Name = "btnGuardarProducto";
            this.btnGuardarProducto.Size = new System.Drawing.Size(385, 47);
            this.btnGuardarProducto.TabIndex = 166;
            this.btnGuardarProducto.Text = "Guardar";
            this.btnGuardarProducto.UseVisualStyleBackColor = false;
            this.btnGuardarProducto.Click += new System.EventHandler(this.btnGuardarProducto_Click);
            // 
            // lblNuevoProducto
            // 
            this.lblNuevoProducto.AutoSize = true;
            this.lblNuevoProducto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(45)))));
            this.lblNuevoProducto.Location = new System.Drawing.Point(11, 12);
            this.lblNuevoProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNuevoProducto.Name = "lblNuevoProducto";
            this.lblNuevoProducto.Size = new System.Drawing.Size(152, 23);
            this.lblNuevoProducto.TabIndex = 42;
            this.lblNuevoProducto.Text = "Nuevo Material";
            // 
            // StockWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 694);
            this.Controls.Add(this.PanelDerecho);
            this.Controls.Add(this.btnRegistroStock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescipcionBus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StockWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.StockWF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.PanelDerecho.ResumeLayout(false);
            this.PanelDerecho.PerformLayout();
            this.PanelNuevoMaterial.ResumeLayout(false);
            this.PanelNuevoMaterial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescipcionBus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistroStock;
        private System.Windows.Forms.Panel PanelDerecho;
        private System.Windows.Forms.Panel PanelNuevoMaterial;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label txtDescripcion;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtDescripcionProducto;
        private System.Windows.Forms.Button btnGuardarProducto;
        private System.Windows.Forms.Label lblNuevoProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGrupo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtFechaCompra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFacturaRemito;
        private System.Windows.Forms.Button btnCrearCategoria;
        private System.Windows.Forms.Button btnCrearGrupo;
        private System.Windows.Forms.Button btnCrerarProveedor;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCrearCodigo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewButtonColumn Ver;
    }
}