using System.Drawing;
using System.Windows.Forms;

namespace Vidrieria.Formularios.Trabajos
{
    partial class TrabajosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrabajosForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnCotizar = new System.Windows.Forms.Button();
            this.btnVerTrabajos = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbMaderaP = new System.Windows.Forms.CheckBox();
            this.cbMadera165 = new System.Windows.Forms.CheckBox();
            this.cbBronceP = new System.Windows.Forms.CheckBox();
            this.cbBronce165 = new System.Windows.Forms.CheckBox();
            this.cbNaturalP = new System.Windows.Forms.CheckBox();
            this.cbNatural165 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tblVentas = new System.Windows.Forms.DataGridView();
            this.descripcionventa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalventa165 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalpersonal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.tblCostos = new System.Windows.Forms.DataGridView();
            this.descripcioncosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalcosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblAccesorios = new System.Windows.Forms.DataGridView();
            this.medidaAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_presentacionAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costonaturalAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costobronceAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costomaderaAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilizadoAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precionAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciobrAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciomAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblMolduras = new System.Windows.Forms.DataGridView();
            this.medidaM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_presentacionM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costonaturalM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costobronceM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costomaderaM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilizadoM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precionM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciobrM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciomM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblHojas = new System.Windows.Forms.DataGridView();
            this.medidaH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_presentacionH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costonaturalH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costobronceH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costomaderaH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilizadoH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precionH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciobrH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciomH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblAluminios = new System.Windows.Forms.DataGridView();
            this.medidaA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_presentacionA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costonaturalA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costobronceA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costomaderaA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilizadoA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precionA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciobrA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciomA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPies = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtAlto = new System.Windows.Forms.TextBox();
            this.txtAncho = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExtras = new System.Windows.Forms.Button();
            this.btnBanio = new System.Windows.Forms.Button();
            this.btnBanioUsa = new System.Windows.Forms.Button();
            this.btnAbatible = new System.Windows.Forms.Button();
            this.btnPesadaDoble = new System.Windows.Forms.Button();
            this.btnPesada = new System.Windows.Forms.Button();
            this.btnGuillotina = new System.Windows.Forms.Button();
            this.btnFijaPesada = new System.Windows.Forms.Button();
            this.btnFijaLiviana = new System.Windows.Forms.Button();
            this.btnSemiPesada = new System.Windows.Forms.Button();
            this.btnLivianaCorrediza = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCostos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccesorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMolduras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHojas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAluminios)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btnFacturar);
            this.panel1.Controls.Add(this.btnCotizar);
            this.panel1.Controls.Add(this.btnVerTrabajos);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.txtPrecio);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbMaderaP);
            this.panel1.Controls.Add(this.cbMadera165);
            this.panel1.Controls.Add(this.cbBronceP);
            this.panel1.Controls.Add(this.cbBronce165);
            this.panel1.Controls.Add(this.cbNaturalP);
            this.panel1.Controls.Add(this.cbNatural165);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtPorcentaje);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tblVentas);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tblCostos);
            this.panel1.Controls.Add(this.tblAccesorios);
            this.panel1.Controls.Add(this.tblMolduras);
            this.panel1.Controls.Add(this.tblHojas);
            this.panel1.Controls.Add(this.tblAluminios);
            this.panel1.Controls.Add(this.txtPies);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.txtAlto);
            this.panel1.Controls.Add(this.txtAncho);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(170, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 556);
            this.panel1.TabIndex = 0;
            // 
            // btnFacturar
            // 
            this.btnFacturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFacturar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturar.Image")));
            this.btnFacturar.Location = new System.Drawing.Point(900, 464);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(145, 49);
            this.btnFacturar.TabIndex = 30;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnCotizar
            // 
            this.btnCotizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCotizar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCotizar.Image = ((System.Drawing.Image)(resources.GetObject("btnCotizar.Image")));
            this.btnCotizar.Location = new System.Drawing.Point(764, 464);
            this.btnCotizar.Name = "btnCotizar";
            this.btnCotizar.Size = new System.Drawing.Size(130, 49);
            this.btnCotizar.TabIndex = 29;
            this.btnCotizar.Text = "Cotizar";
            this.btnCotizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCotizar.UseVisualStyleBackColor = false;
            this.btnCotizar.Click += new System.EventHandler(this.btnCotizar_Click);
            // 
            // btnVerTrabajos
            // 
            this.btnVerTrabajos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnVerTrabajos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerTrabajos.Image = ((System.Drawing.Image)(resources.GetObject("btnVerTrabajos.Image")));
            this.btnVerTrabajos.Location = new System.Drawing.Point(900, 394);
            this.btnVerTrabajos.Name = "btnVerTrabajos";
            this.btnVerTrabajos.Size = new System.Drawing.Size(145, 49);
            this.btnVerTrabajos.TabIndex = 28;
            this.btnVerTrabajos.Text = "Ver Trabajos";
            this.btnVerTrabajos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerTrabajos.UseVisualStyleBackColor = false;
            this.btnVerTrabajos.Click += new System.EventHandler(this.btnVerTrabajos_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(764, 394);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 49);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(814, 349);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(169, 33);
            this.txtPrecio.TabIndex = 26;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(840, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Precio Seleccionado";
            // 
            // cbMaderaP
            // 
            this.cbMaderaP.AutoSize = true;
            this.cbMaderaP.Location = new System.Drawing.Point(1046, 272);
            this.cbMaderaP.Name = "cbMaderaP";
            this.cbMaderaP.Size = new System.Drawing.Size(15, 14);
            this.cbMaderaP.TabIndex = 24;
            this.cbMaderaP.UseVisualStyleBackColor = true;
            this.cbMaderaP.Click += new System.EventHandler(this.cbMaderaP_Click);
            // 
            // cbMadera165
            // 
            this.cbMadera165.AutoSize = true;
            this.cbMadera165.Location = new System.Drawing.Point(1028, 272);
            this.cbMadera165.Name = "cbMadera165";
            this.cbMadera165.Size = new System.Drawing.Size(15, 14);
            this.cbMadera165.TabIndex = 23;
            this.cbMadera165.UseVisualStyleBackColor = true;
            this.cbMadera165.Click += new System.EventHandler(this.cbMadera165_Click);
            // 
            // cbBronceP
            // 
            this.cbBronceP.AutoSize = true;
            this.cbBronceP.Location = new System.Drawing.Point(1046, 254);
            this.cbBronceP.Name = "cbBronceP";
            this.cbBronceP.Size = new System.Drawing.Size(15, 14);
            this.cbBronceP.TabIndex = 22;
            this.cbBronceP.UseVisualStyleBackColor = true;
            this.cbBronceP.Click += new System.EventHandler(this.cbBronceP_Click);
            // 
            // cbBronce165
            // 
            this.cbBronce165.AutoSize = true;
            this.cbBronce165.Location = new System.Drawing.Point(1028, 254);
            this.cbBronce165.Name = "cbBronce165";
            this.cbBronce165.Size = new System.Drawing.Size(15, 14);
            this.cbBronce165.TabIndex = 21;
            this.cbBronce165.UseVisualStyleBackColor = true;
            this.cbBronce165.Click += new System.EventHandler(this.cbBronce165_Click);
            // 
            // cbNaturalP
            // 
            this.cbNaturalP.AutoSize = true;
            this.cbNaturalP.Location = new System.Drawing.Point(1046, 235);
            this.cbNaturalP.Name = "cbNaturalP";
            this.cbNaturalP.Size = new System.Drawing.Size(15, 14);
            this.cbNaturalP.TabIndex = 20;
            this.cbNaturalP.UseVisualStyleBackColor = true;
            this.cbNaturalP.Click += new System.EventHandler(this.cbNaturalP_Click);
            // 
            // cbNatural165
            // 
            this.cbNatural165.AutoSize = true;
            this.cbNatural165.Location = new System.Drawing.Point(1028, 235);
            this.cbNatural165.Name = "cbNatural165";
            this.cbNatural165.Size = new System.Drawing.Size(15, 14);
            this.cbNatural165.TabIndex = 19;
            this.cbNatural165.UseVisualStyleBackColor = true;
            this.cbNatural165.CheckedChanged += new System.EventHandler(this.cbNatural165_CheckedChanged);
            this.cbNatural165.Click += new System.EventHandler(this.cbNatural165_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(986, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "%";
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(934, 185);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(49, 20);
            this.txtPorcentaje.TabIndex = 17;
            this.txtPorcentaje.TextChanged += new System.EventHandler(this.txtPorcentaje_TextChanged);
            this.txtPorcentaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPorcentaje_KeyDown);
            this.txtPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentaje_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(728, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Venta";
            // 
            // tblVentas
            // 
            this.tblVentas.AllowUserToAddRows = false;
            this.tblVentas.AllowUserToDeleteRows = false;
            this.tblVentas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descripcionventa,
            this.totalventa165,
            this.totalpersonal});
            this.tblVentas.Location = new System.Drawing.Point(728, 211);
            this.tblVentas.Name = "tblVentas";
            this.tblVentas.ReadOnly = true;
            this.tblVentas.RowHeadersVisible = false;
            this.tblVentas.RowTemplate.Height = 20;
            this.tblVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblVentas.Size = new System.Drawing.Size(294, 97);
            this.tblVentas.TabIndex = 15;
            // 
            // descripcionventa
            // 
            this.descripcionventa.DataPropertyName = "descripcionventa";
            this.descripcionventa.Frozen = true;
            this.descripcionventa.HeaderText = "Descripcion";
            this.descripcionventa.Name = "descripcionventa";
            this.descripcionventa.ReadOnly = true;
            this.descripcionventa.Width = 130;
            // 
            // totalventa165
            // 
            this.totalventa165.DataPropertyName = "totalventa165";
            this.totalventa165.Frozen = true;
            this.totalventa165.HeaderText = "Total 1.65";
            this.totalventa165.Name = "totalventa165";
            this.totalventa165.ReadOnly = true;
            this.totalventa165.Width = 80;
            // 
            // totalpersonal
            // 
            this.totalpersonal.DataPropertyName = "totalpersonal";
            this.totalpersonal.HeaderText = "Total %";
            this.totalpersonal.Name = "totalpersonal";
            this.totalpersonal.ReadOnly = true;
            this.totalpersonal.Width = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(725, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Costos";
            // 
            // tblCostos
            // 
            this.tblCostos.AllowUserToAddRows = false;
            this.tblCostos.AllowUserToDeleteRows = false;
            this.tblCostos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCostos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descripcioncosto,
            this.totalcosto});
            this.tblCostos.Location = new System.Drawing.Point(728, 49);
            this.tblCostos.Name = "tblCostos";
            this.tblCostos.ReadOnly = true;
            this.tblCostos.RowHeadersVisible = false;
            this.tblCostos.RowTemplate.Height = 20;
            this.tblCostos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblCostos.Size = new System.Drawing.Size(294, 94);
            this.tblCostos.TabIndex = 13;
            // 
            // descripcioncosto
            // 
            this.descripcioncosto.DataPropertyName = "descripcioncosto";
            this.descripcioncosto.Frozen = true;
            this.descripcioncosto.HeaderText = "Descripcion";
            this.descripcioncosto.Name = "descripcioncosto";
            this.descripcioncosto.ReadOnly = true;
            this.descripcioncosto.Width = 200;
            // 
            // totalcosto
            // 
            this.totalcosto.DataPropertyName = "totalcosto";
            this.totalcosto.Frozen = true;
            this.totalcosto.HeaderText = "Total";
            this.totalcosto.Name = "totalcosto";
            this.totalcosto.ReadOnly = true;
            this.totalcosto.Width = 90;
            // 
            // tblAccesorios
            // 
            this.tblAccesorios.AllowUserToAddRows = false;
            this.tblAccesorios.AllowUserToDeleteRows = false;
            this.tblAccesorios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblAccesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAccesorios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medidaAc,
            this.tipo_presentacionAc,
            this.costonaturalAc,
            this.costobronceAc,
            this.costomaderaAc,
            this.descripcionAc,
            this.utilizadoAc,
            this.precionAc,
            this.preciobrAc,
            this.preciomAc});
            this.tblAccesorios.Location = new System.Drawing.Point(5, 471);
            this.tblAccesorios.Name = "tblAccesorios";
            this.tblAccesorios.ReadOnly = true;
            this.tblAccesorios.RowHeadersVisible = false;
            this.tblAccesorios.RowTemplate.Height = 20;
            this.tblAccesorios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblAccesorios.Size = new System.Drawing.Size(717, 80);
            this.tblAccesorios.TabIndex = 12;
            // 
            // medidaAc
            // 
            this.medidaAc.DataPropertyName = "medida";
            this.medidaAc.Frozen = true;
            this.medidaAc.HeaderText = "Medidas";
            this.medidaAc.Name = "medidaAc";
            this.medidaAc.ReadOnly = true;
            this.medidaAc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.medidaAc.Width = 55;
            // 
            // tipo_presentacionAc
            // 
            this.tipo_presentacionAc.DataPropertyName = "tipo_presentacion";
            this.tipo_presentacionAc.Frozen = true;
            this.tipo_presentacionAc.HeaderText = "Presentación";
            this.tipo_presentacionAc.Name = "tipo_presentacionAc";
            this.tipo_presentacionAc.ReadOnly = true;
            this.tipo_presentacionAc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tipo_presentacionAc.Width = 80;
            // 
            // costonaturalAc
            // 
            this.costonaturalAc.DataPropertyName = "costonatural";
            this.costonaturalAc.Frozen = true;
            this.costonaturalAc.HeaderText = "Natural";
            this.costonaturalAc.Name = "costonaturalAc";
            this.costonaturalAc.ReadOnly = true;
            this.costonaturalAc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costonaturalAc.Width = 55;
            // 
            // costobronceAc
            // 
            this.costobronceAc.DataPropertyName = "costobronce";
            this.costobronceAc.Frozen = true;
            this.costobronceAc.HeaderText = "Bronce";
            this.costobronceAc.Name = "costobronceAc";
            this.costobronceAc.ReadOnly = true;
            this.costobronceAc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costobronceAc.Width = 55;
            // 
            // costomaderaAc
            // 
            this.costomaderaAc.DataPropertyName = "costomadera";
            this.costomaderaAc.Frozen = true;
            this.costomaderaAc.HeaderText = "Madera";
            this.costomaderaAc.Name = "costomaderaAc";
            this.costomaderaAc.ReadOnly = true;
            this.costomaderaAc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costomaderaAc.Width = 55;
            // 
            // descripcionAc
            // 
            this.descripcionAc.DataPropertyName = "descripcion";
            this.descripcionAc.Frozen = true;
            this.descripcionAc.HeaderText = "Descripción";
            this.descripcionAc.Name = "descripcionAc";
            this.descripcionAc.ReadOnly = true;
            this.descripcionAc.Width = 180;
            // 
            // utilizadoAc
            // 
            this.utilizadoAc.DataPropertyName = "utilizado";
            this.utilizadoAc.Frozen = true;
            this.utilizadoAc.HeaderText = "Utilizado";
            this.utilizadoAc.Name = "utilizadoAc";
            this.utilizadoAc.ReadOnly = true;
            this.utilizadoAc.Width = 60;
            // 
            // precionAc
            // 
            this.precionAc.DataPropertyName = "precion";
            this.precionAc.Frozen = true;
            this.precionAc.HeaderText = "PrecioN";
            this.precionAc.Name = "precionAc";
            this.precionAc.ReadOnly = true;
            this.precionAc.Width = 55;
            // 
            // preciobrAc
            // 
            this.preciobrAc.DataPropertyName = "preciobr";
            this.preciobrAc.Frozen = true;
            this.preciobrAc.HeaderText = "PrecioBR";
            this.preciobrAc.Name = "preciobrAc";
            this.preciobrAc.ReadOnly = true;
            this.preciobrAc.Width = 60;
            // 
            // preciomAc
            // 
            this.preciomAc.DataPropertyName = "preciom";
            this.preciomAc.Frozen = true;
            this.preciomAc.HeaderText = "PrecioM";
            this.preciomAc.Name = "preciomAc";
            this.preciomAc.ReadOnly = true;
            this.preciomAc.Width = 55;
            // 
            // tblMolduras
            // 
            this.tblMolduras.AllowUserToAddRows = false;
            this.tblMolduras.AllowUserToDeleteRows = false;
            this.tblMolduras.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblMolduras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblMolduras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medidaM,
            this.tipo_presentacionM,
            this.costonaturalM,
            this.costobronceM,
            this.costomaderaM,
            this.descripcionM,
            this.utilizadoM,
            this.precionM,
            this.preciobrM,
            this.preciomM});
            this.tblMolduras.Location = new System.Drawing.Point(5, 353);
            this.tblMolduras.Name = "tblMolduras";
            this.tblMolduras.ReadOnly = true;
            this.tblMolduras.RowHeadersVisible = false;
            this.tblMolduras.RowTemplate.Height = 20;
            this.tblMolduras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblMolduras.Size = new System.Drawing.Size(717, 119);
            this.tblMolduras.TabIndex = 11;
            // 
            // medidaM
            // 
            this.medidaM.DataPropertyName = "medida";
            this.medidaM.Frozen = true;
            this.medidaM.HeaderText = "Medidas";
            this.medidaM.Name = "medidaM";
            this.medidaM.ReadOnly = true;
            this.medidaM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.medidaM.Width = 55;
            // 
            // tipo_presentacionM
            // 
            this.tipo_presentacionM.DataPropertyName = "tipo_presentacion";
            this.tipo_presentacionM.Frozen = true;
            this.tipo_presentacionM.HeaderText = "Presentación";
            this.tipo_presentacionM.Name = "tipo_presentacionM";
            this.tipo_presentacionM.ReadOnly = true;
            this.tipo_presentacionM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tipo_presentacionM.Width = 80;
            // 
            // costonaturalM
            // 
            this.costonaturalM.DataPropertyName = "costonatural";
            this.costonaturalM.Frozen = true;
            this.costonaturalM.HeaderText = "Natural";
            this.costonaturalM.Name = "costonaturalM";
            this.costonaturalM.ReadOnly = true;
            this.costonaturalM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costonaturalM.Width = 55;
            // 
            // costobronceM
            // 
            this.costobronceM.DataPropertyName = "costobronce";
            this.costobronceM.Frozen = true;
            this.costobronceM.HeaderText = "Bronce";
            this.costobronceM.Name = "costobronceM";
            this.costobronceM.ReadOnly = true;
            this.costobronceM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costobronceM.Width = 55;
            // 
            // costomaderaM
            // 
            this.costomaderaM.DataPropertyName = "costomadera";
            this.costomaderaM.Frozen = true;
            this.costomaderaM.HeaderText = "Madera";
            this.costomaderaM.Name = "costomaderaM";
            this.costomaderaM.ReadOnly = true;
            this.costomaderaM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costomaderaM.Width = 55;
            // 
            // descripcionM
            // 
            this.descripcionM.DataPropertyName = "descripcion";
            this.descripcionM.Frozen = true;
            this.descripcionM.HeaderText = "Descripción";
            this.descripcionM.Name = "descripcionM";
            this.descripcionM.ReadOnly = true;
            this.descripcionM.Width = 180;
            // 
            // utilizadoM
            // 
            this.utilizadoM.DataPropertyName = "utilizado";
            this.utilizadoM.Frozen = true;
            this.utilizadoM.HeaderText = "Utilizado";
            this.utilizadoM.Name = "utilizadoM";
            this.utilizadoM.ReadOnly = true;
            this.utilizadoM.Width = 60;
            // 
            // precionM
            // 
            this.precionM.DataPropertyName = "precion";
            this.precionM.Frozen = true;
            this.precionM.HeaderText = "PrecioN";
            this.precionM.Name = "precionM";
            this.precionM.ReadOnly = true;
            this.precionM.Width = 55;
            // 
            // preciobrM
            // 
            this.preciobrM.DataPropertyName = "preciobr";
            this.preciobrM.Frozen = true;
            this.preciobrM.HeaderText = "PrecioBR";
            this.preciobrM.Name = "preciobrM";
            this.preciobrM.ReadOnly = true;
            this.preciobrM.Width = 60;
            // 
            // preciomM
            // 
            this.preciomM.DataPropertyName = "preciom";
            this.preciomM.Frozen = true;
            this.preciomM.HeaderText = "PrecioM";
            this.preciomM.Name = "preciomM";
            this.preciomM.ReadOnly = true;
            this.preciomM.Width = 55;
            // 
            // tblHojas
            // 
            this.tblHojas.AllowUserToAddRows = false;
            this.tblHojas.AllowUserToDeleteRows = false;
            this.tblHojas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblHojas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblHojas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medidaH,
            this.tipo_presentacionH,
            this.costonaturalH,
            this.costobronceH,
            this.costomaderaH,
            this.descripcionH,
            this.utilizadoH,
            this.precionH,
            this.preciobrH,
            this.preciomH});
            this.tblHojas.Location = new System.Drawing.Point(5, 138);
            this.tblHojas.Name = "tblHojas";
            this.tblHojas.ReadOnly = true;
            this.tblHojas.RowHeadersVisible = false;
            this.tblHojas.RowTemplate.Height = 20;
            this.tblHojas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblHojas.Size = new System.Drawing.Size(717, 215);
            this.tblHojas.TabIndex = 10;
            // 
            // medidaH
            // 
            this.medidaH.DataPropertyName = "medida";
            this.medidaH.Frozen = true;
            this.medidaH.HeaderText = "Medidas";
            this.medidaH.Name = "medidaH";
            this.medidaH.ReadOnly = true;
            this.medidaH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.medidaH.Width = 55;
            // 
            // tipo_presentacionH
            // 
            this.tipo_presentacionH.DataPropertyName = "tipo_presentacion";
            this.tipo_presentacionH.Frozen = true;
            this.tipo_presentacionH.HeaderText = "Presentación";
            this.tipo_presentacionH.Name = "tipo_presentacionH";
            this.tipo_presentacionH.ReadOnly = true;
            this.tipo_presentacionH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tipo_presentacionH.Width = 80;
            // 
            // costonaturalH
            // 
            this.costonaturalH.DataPropertyName = "costonatural";
            this.costonaturalH.Frozen = true;
            this.costonaturalH.HeaderText = "Natural";
            this.costonaturalH.Name = "costonaturalH";
            this.costonaturalH.ReadOnly = true;
            this.costonaturalH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costonaturalH.Width = 55;
            // 
            // costobronceH
            // 
            this.costobronceH.DataPropertyName = "costobronce";
            this.costobronceH.Frozen = true;
            this.costobronceH.HeaderText = "Bronce";
            this.costobronceH.Name = "costobronceH";
            this.costobronceH.ReadOnly = true;
            this.costobronceH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costobronceH.Width = 55;
            // 
            // costomaderaH
            // 
            this.costomaderaH.DataPropertyName = "costomadera";
            this.costomaderaH.Frozen = true;
            this.costomaderaH.HeaderText = "Madera";
            this.costomaderaH.Name = "costomaderaH";
            this.costomaderaH.ReadOnly = true;
            this.costomaderaH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costomaderaH.Width = 55;
            // 
            // descripcionH
            // 
            this.descripcionH.DataPropertyName = "descripcion";
            this.descripcionH.Frozen = true;
            this.descripcionH.HeaderText = "Descripción";
            this.descripcionH.Name = "descripcionH";
            this.descripcionH.ReadOnly = true;
            this.descripcionH.Width = 180;
            // 
            // utilizadoH
            // 
            this.utilizadoH.DataPropertyName = "utilizado";
            this.utilizadoH.Frozen = true;
            this.utilizadoH.HeaderText = "Utilizado";
            this.utilizadoH.Name = "utilizadoH";
            this.utilizadoH.ReadOnly = true;
            this.utilizadoH.Width = 60;
            // 
            // precionH
            // 
            this.precionH.DataPropertyName = "precion";
            this.precionH.Frozen = true;
            this.precionH.HeaderText = "PrecioN";
            this.precionH.Name = "precionH";
            this.precionH.ReadOnly = true;
            this.precionH.Width = 55;
            // 
            // preciobrH
            // 
            this.preciobrH.DataPropertyName = "preciobr";
            this.preciobrH.Frozen = true;
            this.preciobrH.HeaderText = "PrecioBR";
            this.preciobrH.Name = "preciobrH";
            this.preciobrH.ReadOnly = true;
            this.preciobrH.Width = 60;
            // 
            // preciomH
            // 
            this.preciomH.DataPropertyName = "preciom";
            this.preciomH.Frozen = true;
            this.preciomH.HeaderText = "PrecioM";
            this.preciomH.Name = "preciomH";
            this.preciomH.ReadOnly = true;
            this.preciomH.Width = 55;
            // 
            // tblAluminios
            // 
            this.tblAluminios.AllowUserToAddRows = false;
            this.tblAluminios.AllowUserToDeleteRows = false;
            this.tblAluminios.AllowUserToResizeColumns = false;
            this.tblAluminios.AllowUserToResizeRows = false;
            this.tblAluminios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblAluminios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAluminios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medidaA,
            this.tipo_presentacionA,
            this.costonaturalA,
            this.costobronceA,
            this.costomaderaA,
            this.descripcionA,
            this.utilizadoA,
            this.precionA,
            this.preciobrA,
            this.preciomA});
            this.tblAluminios.Location = new System.Drawing.Point(5, 58);
            this.tblAluminios.Name = "tblAluminios";
            this.tblAluminios.ReadOnly = true;
            this.tblAluminios.RowHeadersVisible = false;
            this.tblAluminios.RowTemplate.Height = 20;
            this.tblAluminios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblAluminios.Size = new System.Drawing.Size(717, 80);
            this.tblAluminios.TabIndex = 9;
            // 
            // medidaA
            // 
            this.medidaA.DataPropertyName = "medida";
            this.medidaA.Frozen = true;
            this.medidaA.HeaderText = "Medidas";
            this.medidaA.Name = "medidaA";
            this.medidaA.ReadOnly = true;
            this.medidaA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.medidaA.Width = 55;
            // 
            // tipo_presentacionA
            // 
            this.tipo_presentacionA.DataPropertyName = "tipo_presentacion";
            this.tipo_presentacionA.Frozen = true;
            this.tipo_presentacionA.HeaderText = "Presentación";
            this.tipo_presentacionA.Name = "tipo_presentacionA";
            this.tipo_presentacionA.ReadOnly = true;
            this.tipo_presentacionA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tipo_presentacionA.Width = 80;
            // 
            // costonaturalA
            // 
            this.costonaturalA.DataPropertyName = "costonatural";
            this.costonaturalA.Frozen = true;
            this.costonaturalA.HeaderText = "Natural";
            this.costonaturalA.Name = "costonaturalA";
            this.costonaturalA.ReadOnly = true;
            this.costonaturalA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costonaturalA.Width = 55;
            // 
            // costobronceA
            // 
            this.costobronceA.DataPropertyName = "costobronce";
            this.costobronceA.Frozen = true;
            this.costobronceA.HeaderText = "Bronce";
            this.costobronceA.Name = "costobronceA";
            this.costobronceA.ReadOnly = true;
            this.costobronceA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costobronceA.Width = 55;
            // 
            // costomaderaA
            // 
            this.costomaderaA.DataPropertyName = "costomadera";
            this.costomaderaA.Frozen = true;
            this.costomaderaA.HeaderText = "Madera";
            this.costomaderaA.Name = "costomaderaA";
            this.costomaderaA.ReadOnly = true;
            this.costomaderaA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costomaderaA.Width = 55;
            // 
            // descripcionA
            // 
            this.descripcionA.DataPropertyName = "descripcion";
            this.descripcionA.Frozen = true;
            this.descripcionA.HeaderText = "Descripción";
            this.descripcionA.Name = "descripcionA";
            this.descripcionA.ReadOnly = true;
            this.descripcionA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.descripcionA.Width = 180;
            // 
            // utilizadoA
            // 
            this.utilizadoA.DataPropertyName = "utilizado";
            this.utilizadoA.Frozen = true;
            this.utilizadoA.HeaderText = "Utilizado";
            this.utilizadoA.Name = "utilizadoA";
            this.utilizadoA.ReadOnly = true;
            this.utilizadoA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.utilizadoA.Width = 60;
            // 
            // precionA
            // 
            this.precionA.DataPropertyName = "precion";
            this.precionA.Frozen = true;
            this.precionA.HeaderText = "PrecioN";
            this.precionA.Name = "precionA";
            this.precionA.ReadOnly = true;
            this.precionA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.precionA.Width = 55;
            // 
            // preciobrA
            // 
            this.preciobrA.DataPropertyName = "preciobr";
            this.preciobrA.Frozen = true;
            this.preciobrA.HeaderText = "PrecioBR";
            this.preciobrA.Name = "preciobrA";
            this.preciobrA.ReadOnly = true;
            this.preciobrA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.preciobrA.Width = 60;
            // 
            // preciomA
            // 
            this.preciomA.DataPropertyName = "preciom";
            this.preciomA.Frozen = true;
            this.preciomA.HeaderText = "PrecioM";
            this.preciomA.Name = "preciomA";
            this.preciomA.ReadOnly = true;
            this.preciomA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.preciomA.Width = 55;
            // 
            // txtPies
            // 
            this.txtPies.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPies.Location = new System.Drawing.Point(360, 10);
            this.txtPies.Name = "txtPies";
            this.txtPies.ReadOnly = true;
            this.txtPies.Size = new System.Drawing.Size(47, 25);
            this.txtPies.TabIndex = 8;
            this.txtPies.Text = "1";
            this.txtPies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtCantidad.Location = new System.Drawing.Point(228, 10);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(47, 25);
            this.txtCantidad.TabIndex = 7;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtAlto
            // 
            this.txtAlto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtAlto.Location = new System.Drawing.Point(124, 10);
            this.txtAlto.Name = "txtAlto";
            this.txtAlto.Size = new System.Drawing.Size(47, 25);
            this.txtAlto.TabIndex = 6;
            this.txtAlto.Text = "1";
            this.txtAlto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAlto.TextChanged += new System.EventHandler(this.txtAlto_TextChanged);
            this.txtAlto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAlto_KeyDown);
            this.txtAlto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlto_KeyPress);
            // 
            // txtAncho
            // 
            this.txtAncho.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtAncho.Location = new System.Drawing.Point(43, 10);
            this.txtAncho.Name = "txtAncho";
            this.txtAncho.Size = new System.Drawing.Size(47, 25);
            this.txtAncho.TabIndex = 5;
            this.txtAncho.Text = "1";
            this.txtAncho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAncho.TextChanged += new System.EventHandler(this.txtAncho_TextChanged);
            this.txtAncho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAncho_KeyDown);
            this.txtAncho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAncho_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pies Cuadrados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cantidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ancho";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.btnExtras);
            this.panel2.Controls.Add(this.btnBanio);
            this.panel2.Controls.Add(this.btnBanioUsa);
            this.panel2.Controls.Add(this.btnAbatible);
            this.panel2.Controls.Add(this.btnPesadaDoble);
            this.panel2.Controls.Add(this.btnPesada);
            this.panel2.Controls.Add(this.btnGuillotina);
            this.panel2.Controls.Add(this.btnFijaPesada);
            this.panel2.Controls.Add(this.btnFijaLiviana);
            this.panel2.Controls.Add(this.btnSemiPesada);
            this.panel2.Controls.Add(this.btnLivianaCorrediza);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 556);
            this.panel2.TabIndex = 0;
            // 
            // btnExtras
            // 
            this.btnExtras.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExtras.FlatAppearance.BorderSize = 0;
            this.btnExtras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.btnExtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtras.Image = ((System.Drawing.Image)(resources.GetObject("btnExtras.Image")));
            this.btnExtras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExtras.Location = new System.Drawing.Point(0, 490);
            this.btnExtras.Name = "btnExtras";
            this.btnExtras.Size = new System.Drawing.Size(170, 49);
            this.btnExtras.TabIndex = 10;
            this.btnExtras.Text = "Extras";
            this.btnExtras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExtras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExtras.UseVisualStyleBackColor = true;
            // 
            // btnBanio
            // 
            this.btnBanio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanio.FlatAppearance.BorderSize = 0;
            this.btnBanio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.btnBanio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanio.Image = ((System.Drawing.Image)(resources.GetObject("btnBanio.Image")));
            this.btnBanio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanio.Location = new System.Drawing.Point(0, 441);
            this.btnBanio.Name = "btnBanio";
            this.btnBanio.Size = new System.Drawing.Size(170, 49);
            this.btnBanio.TabIndex = 9;
            this.btnBanio.Text = "Puerta Baño";
            this.btnBanio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBanio.UseVisualStyleBackColor = true;
            this.btnBanio.Click += new System.EventHandler(this.btnBanio_Click);
            // 
            // btnBanioUsa
            // 
            this.btnBanioUsa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanioUsa.FlatAppearance.BorderSize = 0;
            this.btnBanioUsa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.btnBanioUsa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanioUsa.Image = ((System.Drawing.Image)(resources.GetObject("btnBanioUsa.Image")));
            this.btnBanioUsa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanioUsa.Location = new System.Drawing.Point(0, 392);
            this.btnBanioUsa.Name = "btnBanioUsa";
            this.btnBanioUsa.Size = new System.Drawing.Size(170, 49);
            this.btnBanioUsa.TabIndex = 8;
            this.btnBanioUsa.Text = "Puerta Baño USA";
            this.btnBanioUsa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanioUsa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBanioUsa.UseVisualStyleBackColor = true;
            this.btnBanioUsa.Click += new System.EventHandler(this.btnBanioUsa_Click);
            // 
            // btnAbatible
            // 
            this.btnAbatible.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbatible.FlatAppearance.BorderSize = 0;
            this.btnAbatible.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.btnAbatible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbatible.Image = ((System.Drawing.Image)(resources.GetObject("btnAbatible.Image")));
            this.btnAbatible.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbatible.Location = new System.Drawing.Point(0, 343);
            this.btnAbatible.Name = "btnAbatible";
            this.btnAbatible.Size = new System.Drawing.Size(170, 49);
            this.btnAbatible.TabIndex = 7;
            this.btnAbatible.Text = "Puerta Abatible";
            this.btnAbatible.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbatible.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbatible.UseVisualStyleBackColor = true;
            this.btnAbatible.Click += new System.EventHandler(this.btnAbatible_Click);
            // 
            // btnPesadaDoble
            // 
            this.btnPesadaDoble.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPesadaDoble.FlatAppearance.BorderSize = 0;
            this.btnPesadaDoble.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.btnPesadaDoble.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesadaDoble.Image = ((System.Drawing.Image)(resources.GetObject("btnPesadaDoble.Image")));
            this.btnPesadaDoble.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesadaDoble.Location = new System.Drawing.Point(0, 294);
            this.btnPesadaDoble.Name = "btnPesadaDoble";
            this.btnPesadaDoble.Size = new System.Drawing.Size(170, 49);
            this.btnPesadaDoble.TabIndex = 6;
            this.btnPesadaDoble.Text = "P y V Pesada Doble";
            this.btnPesadaDoble.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesadaDoble.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesadaDoble.UseVisualStyleBackColor = true;
            this.btnPesadaDoble.Click += new System.EventHandler(this.btnPesadaDoble_Click);
            // 
            // btnPesada
            // 
            this.btnPesada.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPesada.FlatAppearance.BorderSize = 0;
            this.btnPesada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.btnPesada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesada.Image = ((System.Drawing.Image)(resources.GetObject("btnPesada.Image")));
            this.btnPesada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesada.Location = new System.Drawing.Point(0, 245);
            this.btnPesada.Name = "btnPesada";
            this.btnPesada.Size = new System.Drawing.Size(170, 49);
            this.btnPesada.TabIndex = 5;
            this.btnPesada.Text = "P y V Pesada";
            this.btnPesada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesada.UseVisualStyleBackColor = true;
            this.btnPesada.Click += new System.EventHandler(this.btnPesada_Click);
            // 
            // btnGuillotina
            // 
            this.btnGuillotina.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGuillotina.FlatAppearance.BorderSize = 0;
            this.btnGuillotina.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.btnGuillotina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuillotina.Image = ((System.Drawing.Image)(resources.GetObject("btnGuillotina.Image")));
            this.btnGuillotina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuillotina.Location = new System.Drawing.Point(0, 196);
            this.btnGuillotina.Name = "btnGuillotina";
            this.btnGuillotina.Size = new System.Drawing.Size(170, 49);
            this.btnGuillotina.TabIndex = 4;
            this.btnGuillotina.Text = "Ventana Guillotina";
            this.btnGuillotina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuillotina.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuillotina.UseVisualStyleBackColor = true;
            this.btnGuillotina.Click += new System.EventHandler(this.btnGuillotina_Click);
            // 
            // btnFijaPesada
            // 
            this.btnFijaPesada.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFijaPesada.FlatAppearance.BorderSize = 0;
            this.btnFijaPesada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.btnFijaPesada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFijaPesada.Image = ((System.Drawing.Image)(resources.GetObject("btnFijaPesada.Image")));
            this.btnFijaPesada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFijaPesada.Location = new System.Drawing.Point(0, 147);
            this.btnFijaPesada.Name = "btnFijaPesada";
            this.btnFijaPesada.Size = new System.Drawing.Size(170, 49);
            this.btnFijaPesada.TabIndex = 3;
            this.btnFijaPesada.Text = "Ventana Fija Pesada";
            this.btnFijaPesada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFijaPesada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFijaPesada.UseVisualStyleBackColor = true;
            this.btnFijaPesada.Click += new System.EventHandler(this.btnFijaPesada_Click);
            // 
            // btnFijaLiviana
            // 
            this.btnFijaLiviana.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFijaLiviana.FlatAppearance.BorderSize = 0;
            this.btnFijaLiviana.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.btnFijaLiviana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFijaLiviana.Image = ((System.Drawing.Image)(resources.GetObject("btnFijaLiviana.Image")));
            this.btnFijaLiviana.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFijaLiviana.Location = new System.Drawing.Point(0, 98);
            this.btnFijaLiviana.Name = "btnFijaLiviana";
            this.btnFijaLiviana.Size = new System.Drawing.Size(170, 49);
            this.btnFijaLiviana.TabIndex = 2;
            this.btnFijaLiviana.Text = "Ventana Fija Liviana";
            this.btnFijaLiviana.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFijaLiviana.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFijaLiviana.UseVisualStyleBackColor = true;
            this.btnFijaLiviana.Click += new System.EventHandler(this.btnFijaLiviana_Click);
            // 
            // btnSemiPesada
            // 
            this.btnSemiPesada.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSemiPesada.FlatAppearance.BorderSize = 0;
            this.btnSemiPesada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.btnSemiPesada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemiPesada.Image = ((System.Drawing.Image)(resources.GetObject("btnSemiPesada.Image")));
            this.btnSemiPesada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSemiPesada.Location = new System.Drawing.Point(0, 49);
            this.btnSemiPesada.Name = "btnSemiPesada";
            this.btnSemiPesada.Size = new System.Drawing.Size(170, 49);
            this.btnSemiPesada.TabIndex = 1;
            this.btnSemiPesada.Text = "Semi Pesada Corrediza";
            this.btnSemiPesada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSemiPesada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSemiPesada.UseVisualStyleBackColor = true;
            this.btnSemiPesada.Click += new System.EventHandler(this.btnSemiPesada_Click);
            // 
            // btnLivianaCorrediza
            // 
            this.btnLivianaCorrediza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLivianaCorrediza.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLivianaCorrediza.FlatAppearance.BorderSize = 0;
            this.btnLivianaCorrediza.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.btnLivianaCorrediza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLivianaCorrediza.Image = ((System.Drawing.Image)(resources.GetObject("btnLivianaCorrediza.Image")));
            this.btnLivianaCorrediza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLivianaCorrediza.Location = new System.Drawing.Point(0, 0);
            this.btnLivianaCorrediza.Name = "btnLivianaCorrediza";
            this.btnLivianaCorrediza.Size = new System.Drawing.Size(170, 49);
            this.btnLivianaCorrediza.TabIndex = 0;
            this.btnLivianaCorrediza.Text = "Ventana Liviana Corrediza";
            this.btnLivianaCorrediza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLivianaCorrediza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLivianaCorrediza.UseVisualStyleBackColor = false;
            this.btnLivianaCorrediza.Click += new System.EventHandler(this.btnLivianaCorrediza_Click);
            // 
            // TrabajosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 556);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1257, 595);
            this.MinimumSize = new System.Drawing.Size(1257, 595);
            this.Name = "TrabajosForm";
            this.Text = "TrabajosForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCostos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccesorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMolduras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHojas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAluminios)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnLivianaCorrediza;
        private Button btnExtras;
        private Button btnBanio;
        private Button btnBanioUsa;
        private Button btnAbatible;
        private Button btnPesadaDoble;
        private Button btnPesada;
        private Button btnGuillotina;
        private Button btnFijaPesada;
        private Button btnFijaLiviana;
        private Button btnSemiPesada;
        private TextBox txtPies;
        private TextBox txtCantidad;
        private TextBox txtAlto;
        private TextBox txtAncho;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView tblAluminios;
        private DataGridView tblAccesorios;
        private DataGridView tblMolduras;
        private DataGridView tblHojas;
        private DataGridViewTextBoxColumn medidaH;
        private DataGridViewTextBoxColumn tipo_presentacionH;
        private DataGridViewTextBoxColumn costonaturalH;
        private DataGridViewTextBoxColumn costobronceH;
        private DataGridViewTextBoxColumn costomaderaH;
        private DataGridViewTextBoxColumn descripcionH;
        private DataGridViewTextBoxColumn utilizadoH;
        private DataGridViewTextBoxColumn precionH;
        private DataGridViewTextBoxColumn preciobrH;
        private DataGridViewTextBoxColumn preciomH;
        private DataGridViewTextBoxColumn medidaAc;
        private DataGridViewTextBoxColumn tipo_presentacionAc;
        private DataGridViewTextBoxColumn costonaturalAc;
        private DataGridViewTextBoxColumn costobronceAc;
        private DataGridViewTextBoxColumn costomaderaAc;
        private DataGridViewTextBoxColumn descripcionAc;
        private DataGridViewTextBoxColumn utilizadoAc;
        private DataGridViewTextBoxColumn precionAc;
        private DataGridViewTextBoxColumn preciobrAc;
        private DataGridViewTextBoxColumn preciomAc;
        private DataGridViewTextBoxColumn medidaM;
        private DataGridViewTextBoxColumn tipo_presentacionM;
        private DataGridViewTextBoxColumn costonaturalM;
        private DataGridViewTextBoxColumn costobronceM;
        private DataGridViewTextBoxColumn costomaderaM;
        private DataGridViewTextBoxColumn descripcionM;
        private DataGridViewTextBoxColumn utilizadoM;
        private DataGridViewTextBoxColumn precionM;
        private DataGridViewTextBoxColumn preciobrM;
        private DataGridViewTextBoxColumn preciomM;
        private DataGridViewTextBoxColumn medidaA;
        private DataGridViewTextBoxColumn tipo_presentacionA;
        private DataGridViewTextBoxColumn costonaturalA;
        private DataGridViewTextBoxColumn costobronceA;
        private DataGridViewTextBoxColumn costomaderaA;
        private DataGridViewTextBoxColumn descripcionA;
        private DataGridViewTextBoxColumn utilizadoA;
        private DataGridViewTextBoxColumn precionA;
        private DataGridViewTextBoxColumn preciobrA;
        private DataGridViewTextBoxColumn preciomA;
        private Label label5;
        private DataGridView tblCostos;
        private DataGridViewTextBoxColumn descripcioncosto;
        private DataGridViewTextBoxColumn totalcosto;
        private Label label6;
        private DataGridView dataGridView1;
        private DataGridView tblVentas;
        private TextBox txtPorcentaje;
        private Label label7;
        private DataGridViewTextBoxColumn descripcionventa;
        private DataGridViewTextBoxColumn totalventa165;
        private DataGridViewTextBoxColumn totalpersonal;
        private CheckBox cbMaderaP;
        private CheckBox cbMadera165;
        private CheckBox cbBronceP;
        private CheckBox cbBronce165;
        private CheckBox cbNaturalP;
        private CheckBox cbNatural165;
        private Button btnGuardar;
        private TextBox txtPrecio;
        private Label label8;
        private Button btnCotizar;
        private Button btnVerTrabajos;
        private Button btnFacturar;
    }
}