using System.Drawing;
using System.Windows.Forms;

namespace Vidrieria.Formularios.Materiales
{
    partial class ControlMateriales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlMateriales));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPresentacion = new System.Windows.Forms.ComboBox();
            this.tblMateriales = new System.Windows.Forms.DataGridView();
            this.txtMadera = new System.Windows.Forms.TextBox();
            this.txtBronce = new System.Windows.Forms.TextBox();
            this.txtNatural = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbMateriales = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbVitrina = new System.Windows.Forms.CheckBox();
            this.cbPuertaUSA = new System.Windows.Forms.CheckBox();
            this.cbPuertabanio = new System.Windows.Forms.CheckBox();
            this.cbGuillotina = new System.Windows.Forms.CheckBox();
            this.cbPabatible = new System.Windows.Forms.CheckBox();
            this.cbPVPdoble = new System.Windows.Forms.CheckBox();
            this.cbVentanaSemi = new System.Windows.Forms.CheckBox();
            this.cbLivianaCorrediza = new System.Windows.Forms.CheckBox();
            this.cbPVPesada = new System.Windows.Forms.CheckBox();
            this.cbVentanaLiviana = new System.Windows.Forms.CheckBox();
            this.cbVentanaPesada = new System.Windows.Forms.CheckBox();
            this.cbArcos = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMateriales)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbPresentacion);
            this.panel1.Controls.Add(this.tblMateriales);
            this.panel1.Controls.Add(this.txtMadera);
            this.panel1.Controls.Add(this.txtBronce);
            this.panel1.Controls.Add(this.txtNatural);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.cmbMateriales);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 504);
            this.panel1.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(317, 9);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(106, 39);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Presentacion";
            // 
            // cmbPresentacion
            // 
            this.cmbPresentacion.FormattingEnabled = true;
            this.cmbPresentacion.Location = new System.Drawing.Point(285, 120);
            this.cmbPresentacion.Name = "cmbPresentacion";
            this.cmbPresentacion.Size = new System.Drawing.Size(130, 21);
            this.cmbPresentacion.TabIndex = 12;
            this.cmbPresentacion.SelectedIndexChanged += new System.EventHandler(this.cmbPresentacion_SelectedIndexChanged);
            // 
            // tblMateriales
            // 
            this.tblMateriales.AllowUserToAddRows = false;
            this.tblMateriales.AllowUserToDeleteRows = false;
            this.tblMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblMateriales.Location = new System.Drawing.Point(3, 158);
            this.tblMateriales.Name = "tblMateriales";
            this.tblMateriales.ReadOnly = true;
            this.tblMateriales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblMateriales.Size = new System.Drawing.Size(751, 301);
            this.tblMateriales.TabIndex = 11;
            // 
            // txtMadera
            // 
            this.txtMadera.Location = new System.Drawing.Point(109, 120);
            this.txtMadera.Name = "txtMadera";
            this.txtMadera.Size = new System.Drawing.Size(97, 20);
            this.txtMadera.TabIndex = 10;
            // 
            // txtBronce
            // 
            this.txtBronce.Location = new System.Drawing.Point(285, 88);
            this.txtBronce.Name = "txtBronce";
            this.txtBronce.Size = new System.Drawing.Size(89, 20);
            this.txtBronce.TabIndex = 9;
            // 
            // txtNatural
            // 
            this.txtNatural.Location = new System.Drawing.Point(82, 88);
            this.txtNatural.Name = "txtNatural";
            this.txtNatural.Size = new System.Drawing.Size(89, 20);
            this.txtNatural.TabIndex = 8;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(82, 53);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(291, 20);
            this.txtDescripcion.TabIndex = 7;
            // 
            // cmbMateriales
            // 
            this.cmbMateriales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateriales.FormattingEnabled = true;
            this.cmbMateriales.Items.AddRange(new object[] {
            "--Seleccionar un material para ver--",
            "Accesorios",
            "Aluminios",
            "Hojas",
            "Molduras"});
            this.cmbMateriales.Location = new System.Drawing.Point(109, 19);
            this.cmbMateriales.Name = "cmbMateriales";
            this.cmbMateriales.Size = new System.Drawing.Size(192, 21);
            this.cmbMateriales.TabIndex = 6;
            this.cmbMateriales.SelectedIndexChanged += new System.EventHandler(this.cmbMateriales_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Seleccionar que ver";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Costo Bronce";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Costo Natural";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Costo Madera / Blanco";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.cbVitrina);
            this.panel2.Controls.Add(this.cbPuertaUSA);
            this.panel2.Controls.Add(this.cbPuertabanio);
            this.panel2.Controls.Add(this.cbGuillotina);
            this.panel2.Controls.Add(this.cbPabatible);
            this.panel2.Controls.Add(this.cbPVPdoble);
            this.panel2.Controls.Add(this.cbVentanaSemi);
            this.panel2.Controls.Add(this.cbLivianaCorrediza);
            this.panel2.Controls.Add(this.cbPVPesada);
            this.panel2.Controls.Add(this.cbVentanaLiviana);
            this.panel2.Controls.Add(this.cbVentanaPesada);
            this.panel2.Controls.Add(this.cbArcos);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(429, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 137);
            this.panel2.TabIndex = 0;
            // 
            // cbVitrina
            // 
            this.cbVitrina.AutoSize = true;
            this.cbVitrina.Location = new System.Drawing.Point(213, 109);
            this.cbVitrina.Name = "cbVitrina";
            this.cbVitrina.Size = new System.Drawing.Size(60, 17);
            this.cbVitrina.TabIndex = 12;
            this.cbVitrina.Text = "Vitrinas";
            this.cbVitrina.UseVisualStyleBackColor = true;
            this.cbVitrina.CheckedChanged += new System.EventHandler(this.cbVitrina_CheckedChanged);
            // 
            // cbPuertaUSA
            // 
            this.cbPuertaUSA.AutoSize = true;
            this.cbPuertaUSA.Location = new System.Drawing.Point(213, 88);
            this.cbPuertaUSA.Name = "cbPuertaUSA";
            this.cbPuertaUSA.Size = new System.Drawing.Size(110, 17);
            this.cbPuertaUSA.TabIndex = 11;
            this.cbPuertaUSA.Text = "Puerta Baño USA";
            this.cbPuertaUSA.UseVisualStyleBackColor = true;
            this.cbPuertaUSA.CheckedChanged += new System.EventHandler(this.cbPuertaUSA_CheckedChanged);
            // 
            // cbPuertabanio
            // 
            this.cbPuertabanio.AutoSize = true;
            this.cbPuertabanio.Location = new System.Drawing.Point(213, 66);
            this.cbPuertabanio.Name = "cbPuertabanio";
            this.cbPuertabanio.Size = new System.Drawing.Size(85, 17);
            this.cbPuertabanio.TabIndex = 10;
            this.cbPuertabanio.Text = "Puerta Baño";
            this.cbPuertabanio.UseVisualStyleBackColor = true;
            this.cbPuertabanio.CheckedChanged += new System.EventHandler(this.cbPuertabanio_CheckedChanged);
            // 
            // cbGuillotina
            // 
            this.cbGuillotina.AutoSize = true;
            this.cbGuillotina.Location = new System.Drawing.Point(213, 44);
            this.cbGuillotina.Name = "cbGuillotina";
            this.cbGuillotina.Size = new System.Drawing.Size(69, 17);
            this.cbGuillotina.TabIndex = 9;
            this.cbGuillotina.Text = "Guillotina";
            this.cbGuillotina.UseVisualStyleBackColor = true;
            this.cbGuillotina.CheckedChanged += new System.EventHandler(this.cbGuillotina_CheckedChanged);
            // 
            // cbPabatible
            // 
            this.cbPabatible.AutoSize = true;
            this.cbPabatible.Location = new System.Drawing.Point(100, 109);
            this.cbPabatible.Name = "cbPabatible";
            this.cbPabatible.Size = new System.Drawing.Size(98, 17);
            this.cbPabatible.TabIndex = 8;
            this.cbPabatible.Text = "Puerta Abatible";
            this.cbPabatible.UseVisualStyleBackColor = true;
            this.cbPabatible.CheckedChanged += new System.EventHandler(this.cbPabatible_CheckedChanged);
            // 
            // cbPVPdoble
            // 
            this.cbPVPdoble.AutoSize = true;
            this.cbPVPdoble.Location = new System.Drawing.Point(100, 88);
            this.cbPVPdoble.Name = "cbPVPdoble";
            this.cbPVPdoble.Size = new System.Drawing.Size(115, 17);
            this.cbPVPdoble.TabIndex = 7;
            this.cbPVPdoble.Text = "PyV Pesada Doble";
            this.cbPVPdoble.UseVisualStyleBackColor = true;
            this.cbPVPdoble.CheckedChanged += new System.EventHandler(this.cbPVPdoble_CheckedChanged);
            // 
            // cbVentanaSemi
            // 
            this.cbVentanaSemi.AutoSize = true;
            this.cbVentanaSemi.Location = new System.Drawing.Point(100, 66);
            this.cbVentanaSemi.Name = "cbVentanaSemi";
            this.cbVentanaSemi.Size = new System.Drawing.Size(98, 17);
            this.cbVentanaSemi.TabIndex = 6;
            this.cbVentanaSemi.Text = "V Semi-Pesada";
            this.cbVentanaSemi.UseVisualStyleBackColor = true;
            this.cbVentanaSemi.CheckedChanged += new System.EventHandler(this.cbVentanaSemi_CheckedChanged);
            // 
            // cbLivianaCorrediza
            // 
            this.cbLivianaCorrediza.AutoSize = true;
            this.cbLivianaCorrediza.Location = new System.Drawing.Point(100, 44);
            this.cbLivianaCorrediza.Name = "cbLivianaCorrediza";
            this.cbLivianaCorrediza.Size = new System.Drawing.Size(117, 17);
            this.cbLivianaCorrediza.TabIndex = 5;
            this.cbLivianaCorrediza.Text = "V Liviana Corrediza";
            this.cbLivianaCorrediza.UseVisualStyleBackColor = true;
            this.cbLivianaCorrediza.CheckedChanged += new System.EventHandler(this.cbLivianaCorrediza_CheckedChanged);
            // 
            // cbPVPesada
            // 
            this.cbPVPesada.AutoSize = true;
            this.cbPVPesada.Location = new System.Drawing.Point(15, 109);
            this.cbPVPesada.Name = "cbPVPesada";
            this.cbPVPesada.Size = new System.Drawing.Size(84, 17);
            this.cbPVPesada.TabIndex = 4;
            this.cbPVPesada.Text = "PyV Pesada";
            this.cbPVPesada.UseVisualStyleBackColor = true;
            this.cbPVPesada.CheckedChanged += new System.EventHandler(this.cbPVPesada_CheckedChanged);
            // 
            // cbVentanaLiviana
            // 
            this.cbVentanaLiviana.AutoSize = true;
            this.cbVentanaLiviana.Location = new System.Drawing.Point(15, 88);
            this.cbVentanaLiviana.Name = "cbVentanaLiviana";
            this.cbVentanaLiviana.Size = new System.Drawing.Size(89, 17);
            this.cbVentanaLiviana.TabIndex = 3;
            this.cbVentanaLiviana.Text = "V Fija Liviana";
            this.cbVentanaLiviana.UseVisualStyleBackColor = true;
            this.cbVentanaLiviana.CheckedChanged += new System.EventHandler(this.cbVentanaLiviana_CheckedChanged);
            // 
            // cbVentanaPesada
            // 
            this.cbVentanaPesada.AutoSize = true;
            this.cbVentanaPesada.Location = new System.Drawing.Point(15, 66);
            this.cbVentanaPesada.Name = "cbVentanaPesada";
            this.cbVentanaPesada.Size = new System.Drawing.Size(91, 17);
            this.cbVentanaPesada.TabIndex = 2;
            this.cbVentanaPesada.Text = "V Fija Pesada";
            this.cbVentanaPesada.UseVisualStyleBackColor = true;
            this.cbVentanaPesada.CheckedChanged += new System.EventHandler(this.cbVentanaPesada_CheckedChanged);
            // 
            // cbArcos
            // 
            this.cbArcos.AutoSize = true;
            this.cbArcos.Location = new System.Drawing.Point(15, 44);
            this.cbArcos.Name = "cbArcos";
            this.cbArcos.Size = new System.Drawing.Size(53, 17);
            this.cbArcos.TabIndex = 1;
            this.cbArcos.Text = "Arcos";
            this.cbArcos.UseVisualStyleBackColor = true;
            this.cbArcos.CheckedChanged += new System.EventHandler(this.cbArcos_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trabajos en los que se utiliza";
            // 
            // ControlMateriales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 504);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(777, 543);
            this.MinimumSize = new System.Drawing.Size(777, 543);
            this.Name = "ControlMateriales";
            this.Text = "Control de Materiales";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMateriales)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private CheckBox cbVitrina;
        private CheckBox cbPuertaUSA;
        private CheckBox cbPuertabanio;
        private CheckBox cbGuillotina;
        private CheckBox cbPabatible;
        private CheckBox cbPVPdoble;
        private CheckBox cbVentanaSemi;
        private CheckBox cbLivianaCorrediza;
        private CheckBox cbPVPesada;
        private CheckBox cbVentanaLiviana;
        private CheckBox cbVentanaPesada;
        private CheckBox cbArcos;
        private Label label1;
        private ComboBox cmbMateriales;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DataGridView tblMateriales;
        private TextBox txtMadera;
        private TextBox txtBronce;
        private TextBox txtNatural;
        private TextBox txtDescripcion;
        private Label label7;
        private ComboBox cmbPresentacion;
        private Button btnGuardar;
    }
}