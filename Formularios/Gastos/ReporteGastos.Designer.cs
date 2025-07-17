using System.Drawing;
using System.Windows.Forms;

namespace Vidrieria.Formularios.Gastos
{
    partial class ReporteGastos
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
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteGastos));
            this.panel1 = new Panel();
            this.txtTotal = new TextBox();
            this.label3 = new Label();
            this.tblGastos = new DataGridView();
            this.tipo_gasto = new DataGridViewTextBoxColumn();
            this.descripcion = new DataGridViewTextBoxColumn();
            this.total = new DataGridViewTextBoxColumn();
            this.fechaCompra = new DataGridViewTextBoxColumn();
            this.btnDesglosar = new Button();
            this.btnGenerar = new Button();
            this.txtFecha2 = new DateTimePicker();
            this.txtFecha1 = new DateTimePicker();
            this.label2 = new Label();
            this.label1 = new Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tblGastos).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = SystemColors.ActiveCaption;
            this.panel1.Controls.Add(txtTotal);
            this.panel1.Controls.Add(label3);
            this.panel1.Controls.Add(tblGastos);
            this.panel1.Controls.Add(btnDesglosar);
            this.panel1.Controls.Add(btnGenerar);
            this.panel1.Controls.Add(txtFecha2);
            this.panel1.Controls.Add(txtFecha1);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(label1);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(728, 474);
            this.panel1.TabIndex = 0;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtTotal.Location = new Point(92, 435);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new Size(162, 27);
            this.txtTotal.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.label3.Location = new Point(12, 442);
            this.label3.Name = "label3";
            this.label3.Size = new Size(74, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total Gastos:";
            // 
            // tblGastos
            // 
            this.tblGastos.AllowUserToAddRows = false;
            this.tblGastos.AllowUserToDeleteRows = false;
            this.tblGastos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblGastos.Columns.AddRange(new DataGridViewColumn[] { tipo_gasto, descripcion, total, fechaCompra });
            this.tblGastos.Location = new Point(12, 44);
            this.tblGastos.Name = "tblGastos";
            this.tblGastos.ReadOnly = true;
            this.tblGastos.Size = new Size(703, 377);
            this.tblGastos.TabIndex = 7;
            // 
            // tipo_gasto
            // 
            this.tipo_gasto.DataPropertyName = "tipo_gasto";
            this.tipo_gasto.HeaderText = "Codigo";
            this.tipo_gasto.Name = "tipo_gasto";
            this.tipo_gasto.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 370;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            this.total.HeaderText = "Valor";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // fechaCompra
            // 
            this.fechaCompra.DataPropertyName = "fechacompra";
            this.fechaCompra.HeaderText = "Fecha";
            this.fechaCompra.Name = "fechaCompra";
            this.fechaCompra.ReadOnly = true;
            // 
            // btnDesglosar
            // 
            this.btnDesglosar.BackColor = Color.FromArgb(192, 255, 255);
            this.btnDesglosar.Image = (Image)resources.GetObject("btnDesglosar.Image");
            this.btnDesglosar.Location = new Point(588, 0);
            this.btnDesglosar.Name = "btnDesglosar";
            this.btnDesglosar.Size = new Size(127, 41);
            this.btnDesglosar.TabIndex = 5;
            this.btnDesglosar.Text = "Desglosar";
            this.btnDesglosar.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnDesglosar.UseVisualStyleBackColor = false;
            this.btnDesglosar.Click += btnDesglosar_Click;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = Color.FromArgb(192, 255, 192);
            this.btnGenerar.Image = (Image)resources.GetObject("btnGenerar.Image");
            this.btnGenerar.Location = new Point(462, 0);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new Size(101, 41);
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += btnGenerar_Click;
            // 
            // txtFecha2
            // 
            this.txtFecha2.Format = DateTimePickerFormat.Short;
            this.txtFecha2.Location = new Point(294, 15);
            this.txtFecha2.Name = "txtFecha2";
            this.txtFecha2.Size = new Size(140, 23);
            this.txtFecha2.TabIndex = 3;
            // 
            // txtFecha1
            // 
            this.txtFecha1.Format = DateTimePickerFormat.Short;
            this.txtFecha1.Location = new Point(82, 15);
            this.txtFecha1.Name = "txtFecha1";
            this.txtFecha1.Size = new Size(140, 23);
            this.txtFecha1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.label2.Location = new Point(251, 21);
            this.label2.Name = "label2";
            this.label2.Size = new Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.label1.Location = new Point(37, 21);
            this.label1.Name = "label1";
            this.label1.Size = new Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde";
            // 
            // ReporteGastos
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(728, 474);
            this.Controls.Add(panel1);
            this.MaximumSize = new Size(744, 513);
            this.MinimumSize = new Size(744, 513);
            this.Name = "ReporteGastos";
            this.Text = "ReporteGastos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tblGastos).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DateTimePicker txtFecha2;
        private DateTimePicker txtFecha1;
        private Label label2;
        private Label label1;
        private Button btnDesglosar;
        private Button btnGenerar;
        private DataGridView tblGastos;
        private TextBox txtTotal;
        private Label label3;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewTextBoxColumn tipo_gasto;
        private DataGridViewTextBoxColumn descripcion;
        private DataGridViewTextBoxColumn total;
        private DataGridViewTextBoxColumn fechaCompra;
    }
}