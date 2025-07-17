using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vidrieria.Formularios.Factura
{
    partial class InformacionFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformacionFactura));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnActualilzar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tblCai = new System.Windows.Forms.DataGridView();
            this.id_cai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rango_inicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rango_final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRangoFinal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRangoInicial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblCai)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.btnActualilzar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.tblCai);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.txtFecha);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtRangoFinal);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtRangoInicial);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 397);
            this.panel1.TabIndex = 0;
            // 
            // btnActualilzar
            // 
            this.btnActualilzar.BackColor = System.Drawing.Color.Turquoise;
            this.btnActualilzar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualilzar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualilzar.Image")));
            this.btnActualilzar.Location = new System.Drawing.Point(199, 309);
            this.btnActualilzar.Name = "btnActualilzar";
            this.btnActualilzar.Size = new System.Drawing.Size(105, 44);
            this.btnActualilzar.TabIndex = 11;
            this.btnActualilzar.Text = "Actualizar";
            this.btnActualilzar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualilzar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(22, 309);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(108, 44);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // tblCai
            // 
            this.tblCai.AllowUserToAddRows = false;
            this.tblCai.AllowUserToDeleteRows = false;
            this.tblCai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_cai,
            this.cai,
            this.rango_inicial,
            this.rango_final,
            this.fecha_limite,
            this.estado});
            this.tblCai.Location = new System.Drawing.Point(0, 159);
            this.tblCai.Name = "tblCai";
            this.tblCai.ReadOnly = true;
            this.tblCai.RowHeadersWidth = 30;
            this.tblCai.Size = new System.Drawing.Size(620, 130);
            this.tblCai.TabIndex = 9;
            // 
            // id_cai
            // 
            this.id_cai.DataPropertyName = "id_cai";
            this.id_cai.Frozen = true;
            this.id_cai.HeaderText = "ID";
            this.id_cai.Name = "id_cai";
            this.id_cai.ReadOnly = true;
            this.id_cai.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.id_cai.Width = 40;
            // 
            // cai
            // 
            this.cai.DataPropertyName = "cai";
            this.cai.Frozen = true;
            this.cai.HeaderText = "C.A.I";
            this.cai.Name = "cai";
            this.cai.ReadOnly = true;
            this.cai.Width = 240;
            // 
            // rango_inicial
            // 
            this.rango_inicial.DataPropertyName = "rango_inicial";
            this.rango_inicial.Frozen = true;
            this.rango_inicial.HeaderText = "Rango Inicial";
            this.rango_inicial.Name = "rango_inicial";
            this.rango_inicial.ReadOnly = true;
            this.rango_inicial.Width = 130;
            // 
            // rango_final
            // 
            this.rango_final.DataPropertyName = "rango_final";
            this.rango_final.Frozen = true;
            this.rango_final.HeaderText = "Rango Final";
            this.rango_final.Name = "rango_final";
            this.rango_final.ReadOnly = true;
            this.rango_final.Width = 130;
            // 
            // fecha_limite
            // 
            this.fecha_limite.DataPropertyName = "fecha_limite";
            this.fecha_limite.Frozen = true;
            this.fecha_limite.HeaderText = "Fecha Limite";
            this.fecha_limite.Name = "fecha_limite";
            this.fecha_limite.ReadOnly = true;
            this.fecha_limite.Width = 80;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.Frozen = true;
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 60;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.Turquoise;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(518, 119);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(102, 35);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            // 
            // txtFecha
            // 
            this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha.Location = new System.Drawing.Point(359, 64);
            this.txtFecha.MaxDate = new System.DateTime(2070, 12, 31, 0, 0, 0, 0);
            this.txtFecha.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(92, 20);
            this.txtFecha.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha Limite";
            // 
            // txtRangoFinal
            // 
            this.txtRangoFinal.Location = new System.Drawing.Point(85, 103);
            this.txtRangoFinal.Name = "txtRangoFinal";
            this.txtRangoFinal.Size = new System.Drawing.Size(192, 20);
            this.txtRangoFinal.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rango Final";
            // 
            // txtRangoInicial
            // 
            this.txtRangoInicial.Location = new System.Drawing.Point(85, 64);
            this.txtRangoInicial.Name = "txtRangoInicial";
            this.txtRangoInicial.Size = new System.Drawing.Size(192, 20);
            this.txtRangoInicial.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rango Inicial";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(85, 20);
            this.txtCodigo.MaxLength = 37;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(286, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo CAI";
            // 
            // InformacionFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 397);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(638, 436);
            this.MinimumSize = new System.Drawing.Size(638, 436);
            this.Name = "InformacionFactura";
            this.Text = "InformacionFactura";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblCai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private TextBox txtCodigo;
        private Label label1;
        private Label label2;
        private Button btnNuevo;
        private DateTimePicker txtFecha;
        private Label label4;
        private TextBox txtRangoFinal;
        private Label label3;
        private TextBox txtRangoInicial;
        private DataGridView tblCai;
        private Button btnActualilzar;
        private Button btnGuardar;
        private DataGridViewTextBoxColumn id_cai;
        private DataGridViewTextBoxColumn cai;
        private DataGridViewTextBoxColumn rango_inicial;
        private DataGridViewTextBoxColumn rango_final;
        private DataGridViewTextBoxColumn fecha_limite;
        private DataGridViewTextBoxColumn estado;
    }
}