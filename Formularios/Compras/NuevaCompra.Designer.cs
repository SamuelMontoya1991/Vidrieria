namespace Vidrieria.Formularios.Compras
{
    partial class NuevaCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaCompra));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblMateriales = new System.Windows.Forms.DataGridView();
            this.id_material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tblProveedor = new System.Windows.Forms.DataGridView();
            this.nombreproveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalCantidad = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMateriales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.txtTotalCantidad);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tblMateriales);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.tblProveedor);
            this.panel1.Controls.Add(this.txtNombreProveedor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigoProveedor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 447);
            this.panel1.TabIndex = 0;
            // 
            // tblMateriales
            // 
            this.tblMateriales.AllowUserToAddRows = false;
            this.tblMateriales.AllowUserToDeleteRows = false;
            this.tblMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblMateriales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_material,
            this.descripcion,
            this.cantidad,
            this.precioU,
            this.subtotal});
            this.tblMateriales.Location = new System.Drawing.Point(12, 93);
            this.tblMateriales.Name = "tblMateriales";
            this.tblMateriales.RowHeadersVisible = false;
            this.tblMateriales.Size = new System.Drawing.Size(654, 281);
            this.tblMateriales.TabIndex = 13;
            this.tblMateriales.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblMateriales_CellEndEdit);
            this.tblMateriales.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.tblMateriales_EditingControlShowing);
            this.tblMateriales.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tblMateriales_KeyDown);
            // 
            // id_material
            // 
            this.id_material.DataPropertyName = "id_accesorio";
            this.id_material.HeaderText = "Codigo";
            this.id_material.Name = "id_material";
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.Width = 250;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            // 
            // precioU
            // 
            this.precioU.DataPropertyName = "preciou";
            this.precioU.HeaderText = "PrecioU";
            this.precioU.Name = "precioU";
            // 
            // subtotal
            // 
            this.subtotal.DataPropertyName = "subtotal";
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(590, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(108, 43);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(216, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 46);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tblProveedor
            // 
            this.tblProveedor.AllowUserToAddRows = false;
            this.tblProveedor.AllowUserToDeleteRows = false;
            this.tblProveedor.AllowUserToResizeColumns = false;
            this.tblProveedor.AllowUserToResizeRows = false;
            this.tblProveedor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tblProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreproveedor});
            this.tblProveedor.Location = new System.Drawing.Point(316, 3);
            this.tblProveedor.Name = "tblProveedor";
            this.tblProveedor.ReadOnly = true;
            this.tblProveedor.RowHeadersVisible = false;
            this.tblProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblProveedor.Size = new System.Drawing.Size(268, 71);
            this.tblProveedor.TabIndex = 10;
            this.tblProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblProveedor_CellDoubleClick);
            // 
            // nombreproveedor
            // 
            this.nombreproveedor.DataPropertyName = "nombreproveedor";
            this.nombreproveedor.Frozen = true;
            this.nombreproveedor.HeaderText = "Nombre";
            this.nombreproveedor.Name = "nombreproveedor";
            this.nombreproveedor.ReadOnly = true;
            this.nombreproveedor.Width = 350;
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Location = new System.Drawing.Point(126, 54);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(184, 20);
            this.txtNombreProveedor.TabIndex = 9;
            this.txtNombreProveedor.TextChanged += new System.EventHandler(this.txtNombreProveedor_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre Proveedor";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Location = new System.Drawing.Point(126, 20);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(82, 20);
            this.txtCodigoProveedor.TabIndex = 7;
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Codigo Proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Totales......";
            // 
            // txtTotalCantidad
            // 
            this.txtTotalCantidad.Location = new System.Drawing.Point(371, 377);
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.Size = new System.Drawing.Size(82, 20);
            this.txtTotalCantidad.TabIndex = 15;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(566, 377);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(322, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Objetos";
            // 
            // NuevaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(714, 447);
            this.Controls.Add(this.panel1);
            this.Name = "NuevaCompra";
            this.Text = "NuevaCompra";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMateriales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProveedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView tblProveedor;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreproveedor;
        private System.Windows.Forms.DataGridView tblMateriales;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_material;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioU;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.TextBox txtTotalCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
    }
}