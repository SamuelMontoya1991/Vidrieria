using System.Drawing;
using System.Windows.Forms;

namespace Vidrieria.Formularios.ReportesEnSistema
{
    partial class ReporteCotizaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteCotizaciones));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblTotales = new System.Windows.Forms.DataGridView();
            this.totalobjetos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalcotizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCotizaciones = new System.Windows.Forms.DataGridView();
            this.id_cotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrevendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objetos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblClientes = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFecha2 = new System.Windows.Forms.DateTimePicker();
            this.txtFecha1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuDerecho = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verCotizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verMaterialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vistaPreviaDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirCotizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirHojaDeMaterialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTotales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCotizaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblClientes)).BeginInit();
            this.menuDerecho.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.tblTotales);
            this.panel1.Controls.Add(this.tblCotizaciones);
            this.panel1.Controls.Add(this.tblClientes);
            this.panel1.Controls.Add(this.txtNombreCliente);
            this.panel1.Controls.Add(this.btnGenerar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFecha2);
            this.panel1.Controls.Add(this.txtFecha1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 551);
            this.panel1.TabIndex = 0;
            // 
            // tblTotales
            // 
            this.tblTotales.AllowUserToAddRows = false;
            this.tblTotales.AllowUserToDeleteRows = false;
            this.tblTotales.BackgroundColor = System.Drawing.Color.Thistle;
            this.tblTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTotales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.totalobjetos,
            this.totalcotizado});
            this.tblTotales.Location = new System.Drawing.Point(537, 494);
            this.tblTotales.Name = "tblTotales";
            this.tblTotales.ReadOnly = true;
            this.tblTotales.RowHeadersVisible = false;
            this.tblTotales.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tblTotales.Size = new System.Drawing.Size(175, 46);
            this.tblTotales.TabIndex = 13;
            // 
            // totalobjetos
            // 
            this.totalobjetos.DataPropertyName = "totalobjetos";
            this.totalobjetos.HeaderText = "TotalObjetos";
            this.totalobjetos.Name = "totalobjetos";
            this.totalobjetos.ReadOnly = true;
            // 
            // totalcotizado
            // 
            this.totalcotizado.DataPropertyName = "totalcotizado";
            this.totalcotizado.HeaderText = "TotalCotizado";
            this.totalcotizado.Name = "totalcotizado";
            this.totalcotizado.ReadOnly = true;
            // 
            // tblCotizaciones
            // 
            this.tblCotizaciones.AllowUserToAddRows = false;
            this.tblCotizaciones.AllowUserToDeleteRows = false;
            this.tblCotizaciones.BackgroundColor = System.Drawing.Color.Thistle;
            this.tblCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCotizaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_cotizacion,
            this.nombrecliente,
            this.fecha,
            this.nombrevendedor,
            this.objetos,
            this.total});
            this.tblCotizaciones.Location = new System.Drawing.Point(10, 107);
            this.tblCotizaciones.Name = "tblCotizaciones";
            this.tblCotizaciones.ReadOnly = true;
            this.tblCotizaciones.RowHeadersVisible = false;
            this.tblCotizaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblCotizaciones.Size = new System.Drawing.Size(702, 386);
            this.tblCotizaciones.TabIndex = 12;
            this.tblCotizaciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblCotizaciones_CellDoubleClick);
            this.tblCotizaciones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tblCotizaciones_MouseDown);
            // 
            // id_cotizacion
            // 
            this.id_cotizacion.DataPropertyName = "id_cotizacion";
            this.id_cotizacion.Frozen = true;
            this.id_cotizacion.HeaderText = "ID";
            this.id_cotizacion.Name = "id_cotizacion";
            this.id_cotizacion.ReadOnly = true;
            this.id_cotizacion.Width = 80;
            // 
            // nombrecliente
            // 
            this.nombrecliente.DataPropertyName = "nombrecliente";
            this.nombrecliente.Frozen = true;
            this.nombrecliente.HeaderText = "Cliente";
            this.nombrecliente.Name = "nombrecliente";
            this.nombrecliente.ReadOnly = true;
            this.nombrecliente.Width = 250;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.Frozen = true;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 120;
            // 
            // nombrevendedor
            // 
            this.nombrevendedor.DataPropertyName = "nombrevendedor";
            this.nombrevendedor.Frozen = true;
            this.nombrevendedor.HeaderText = "Vendedor";
            this.nombrevendedor.Name = "nombrevendedor";
            this.nombrevendedor.ReadOnly = true;
            this.nombrevendedor.Width = 180;
            // 
            // objetos
            // 
            this.objetos.DataPropertyName = "objetos";
            this.objetos.Frozen = true;
            this.objetos.HeaderText = "Objetos";
            this.objetos.Name = "objetos";
            this.objetos.ReadOnly = true;
            this.objetos.Width = 80;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            this.total.Frozen = true;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // tblClientes
            // 
            this.tblClientes.AllowUserToAddRows = false;
            this.tblClientes.AllowUserToDeleteRows = false;
            this.tblClientes.BackgroundColor = System.Drawing.Color.Thistle;
            this.tblClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre});
            this.tblClientes.Location = new System.Drawing.Point(475, 3);
            this.tblClientes.Name = "tblClientes";
            this.tblClientes.ReadOnly = true;
            this.tblClientes.RowHeadersVisible = false;
            this.tblClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblClientes.Size = new System.Drawing.Size(230, 71);
            this.tblClientes.TabIndex = 11;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.Frozen = true;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 300;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(308, 40);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(151, 20);
            this.txtNombreCliente.TabIndex = 10;
            this.txtNombreCliente.TextChanged += new System.EventHandler(this.txtNombreCliente_TextChanged);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.GhostWhite;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.Location = new System.Drawing.Point(191, 18);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(95, 47);
            this.btnGenerar.TabIndex = 9;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre Cliente";
            // 
            // txtFecha2
            // 
            this.txtFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha2.Location = new System.Drawing.Point(54, 45);
            this.txtFecha2.Name = "txtFecha2";
            this.txtFecha2.Size = new System.Drawing.Size(121, 20);
            this.txtFecha2.TabIndex = 7;
            this.txtFecha2.ValueChanged += new System.EventHandler(this.txtFecha2_ValueChanged);
            this.txtFecha2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFecha2_KeyDown);
            // 
            // txtFecha1
            // 
            this.txtFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha1.Location = new System.Drawing.Point(54, 18);
            this.txtFecha1.Name = "txtFecha1";
            this.txtFecha1.Size = new System.Drawing.Size(121, 20);
            this.txtFecha1.TabIndex = 6;
            this.txtFecha1.ValueChanged += new System.EventHandler(this.txtFecha1_ValueChanged);
            this.txtFecha1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFecha1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(18, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Desde";
            // 
            // menuDerecho
            // 
            this.menuDerecho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verCotizacionToolStripMenuItem,
            this.verMaterialesToolStripMenuItem,
            this.vistaPreviaDocumentoToolStripMenuItem,
            this.imprimirCotizacionToolStripMenuItem,
            this.imprimirHojaDeMaterialesToolStripMenuItem});
            this.menuDerecho.Name = "menuDerecho";
            this.menuDerecho.Size = new System.Drawing.Size(222, 114);
            // 
            // verCotizacionToolStripMenuItem
            // 
            this.verCotizacionToolStripMenuItem.Name = "verCotizacionToolStripMenuItem";
            this.verCotizacionToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.verCotizacionToolStripMenuItem.Text = "Ver Cotizacion";
            this.verCotizacionToolStripMenuItem.Click += new System.EventHandler(this.verCotizacionToolStripMenuItem_Click);
            // 
            // verMaterialesToolStripMenuItem
            // 
            this.verMaterialesToolStripMenuItem.Name = "verMaterialesToolStripMenuItem";
            this.verMaterialesToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.verMaterialesToolStripMenuItem.Text = "Ver Materiales";
            this.verMaterialesToolStripMenuItem.Click += new System.EventHandler(this.verMaterialesToolStripMenuItem_Click);
            // 
            // vistaPreviaDocumentoToolStripMenuItem
            // 
            this.vistaPreviaDocumentoToolStripMenuItem.Name = "vistaPreviaDocumentoToolStripMenuItem";
            this.vistaPreviaDocumentoToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.vistaPreviaDocumentoToolStripMenuItem.Text = "Vista previa Documento";
            // 
            // imprimirCotizacionToolStripMenuItem
            // 
            this.imprimirCotizacionToolStripMenuItem.Name = "imprimirCotizacionToolStripMenuItem";
            this.imprimirCotizacionToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.imprimirCotizacionToolStripMenuItem.Text = "Imprimir Cotizacion";
            // 
            // imprimirHojaDeMaterialesToolStripMenuItem
            // 
            this.imprimirHojaDeMaterialesToolStripMenuItem.Name = "imprimirHojaDeMaterialesToolStripMenuItem";
            this.imprimirHojaDeMaterialesToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.imprimirHojaDeMaterialesToolStripMenuItem.Text = "Imprimir Hoja de materiales";
            // 
            // ReporteCotizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 551);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteCotizaciones";
            this.Text = "ReporteCotizaciones";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTotales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCotizaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblClientes)).EndInit();
            this.menuDerecho.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnGenerar;
        private Label label3;
        private DateTimePicker txtFecha2;
        private DateTimePicker txtFecha1;
        private Label label2;
        private Label label1;
        private TextBox txtNombreCliente;
        private DataGridView tblCotizaciones;
        private DataGridView tblClientes;
        private DataGridViewTextBoxColumn id_cotizacion;
        private DataGridViewTextBoxColumn nombrecliente;
        private DataGridViewTextBoxColumn fecha;
        private DataGridViewTextBoxColumn nombrevendedor;
        private DataGridViewTextBoxColumn objetos;
        private DataGridViewTextBoxColumn total;
        private DataGridViewTextBoxColumn nombre;
        private DataGridView tblTotales;
        private DataGridViewTextBoxColumn totalobjetos;
        private DataGridViewTextBoxColumn totalcotizado;
        private ContextMenuStrip menuDerecho;
        private ToolStripMenuItem verCotizacionToolStripMenuItem;
        private ToolStripMenuItem imprimirCotizacionToolStripMenuItem;
        private ToolStripMenuItem imprimirHojaDeMaterialesToolStripMenuItem;
        private ToolStripMenuItem vistaPreviaDocumentoToolStripMenuItem;
        private ToolStripMenuItem verMaterialesToolStripMenuItem;
    }
}