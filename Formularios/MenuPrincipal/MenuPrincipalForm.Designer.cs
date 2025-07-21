using System.Drawing;
using System.Windows.Forms;

namespace Vidrieria.Formularios.MenuPrincipal
{
    partial class MenuPrincipalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipalForm));
            this.opcionesPrincipales = new System.Windows.Forms.MenuStrip();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trabajosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trabajosPersonalizadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gastosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoGastoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accesoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteCotizacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temaClaro = new System.Windows.Forms.ToolStripMenuItem();
            this.temaOscuro = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasPorPagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasPorCobrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesPrincipales.SuspendLayout();
            this.SuspendLayout();
            // 
            // opcionesPrincipales
            // 
            this.opcionesPrincipales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionesPrincipales.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem,
            this.gastosToolStripMenuItem,
            this.inventarioToolStripMenuItem,
            this.cuentasToolStripMenuItem,
            this.empresaToolStripMenuItem,
            this.materialesToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.empleadosToolStripMenuItem,
            this.temaToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.opcionesPrincipales.Location = new System.Drawing.Point(0, 0);
            this.opcionesPrincipales.Name = "opcionesPrincipales";
            this.opcionesPrincipales.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.opcionesPrincipales.Size = new System.Drawing.Size(1902, 25);
            this.opcionesPrincipales.TabIndex = 0;
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trabajosToolStripMenuItem,
            this.trabajosPersonalizadosToolStripMenuItem});
            this.ventasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ventasToolStripMenuItem.Image")));
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // trabajosToolStripMenuItem
            // 
            this.trabajosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("trabajosToolStripMenuItem.Image")));
            this.trabajosToolStripMenuItem.Name = "trabajosToolStripMenuItem";
            this.trabajosToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.trabajosToolStripMenuItem.Text = "Nuevo Trabajo";
            this.trabajosToolStripMenuItem.Click += new System.EventHandler(this.trabajosToolStripMenuItem_Click);
            // 
            // trabajosPersonalizadosToolStripMenuItem
            // 
            this.trabajosPersonalizadosToolStripMenuItem.Name = "trabajosPersonalizadosToolStripMenuItem";
            this.trabajosPersonalizadosToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.trabajosPersonalizadosToolStripMenuItem.Text = "Trabajos Personalizados";
            this.trabajosPersonalizadosToolStripMenuItem.Click += new System.EventHandler(this.trabajosPersonalizadosToolStripMenuItem_Click);
            // 
            // gastosToolStripMenuItem
            // 
            this.gastosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoGastoToolStripMenuItem,
            this.reporteGToolStripMenuItem});
            this.gastosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gastosToolStripMenuItem.Image")));
            this.gastosToolStripMenuItem.Name = "gastosToolStripMenuItem";
            this.gastosToolStripMenuItem.Size = new System.Drawing.Size(76, 21);
            this.gastosToolStripMenuItem.Text = "Gastos";
            // 
            // nuevoGastoToolStripMenuItem
            // 
            this.nuevoGastoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoGastoToolStripMenuItem.Image")));
            this.nuevoGastoToolStripMenuItem.Name = "nuevoGastoToolStripMenuItem";
            this.nuevoGastoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoGastoToolStripMenuItem.Text = "Nuevo Gasto";
            this.nuevoGastoToolStripMenuItem.Click += new System.EventHandler(this.nuevoGastoToolStripMenuItem_Click);
            // 
            // reporteGToolStripMenuItem
            // 
            this.reporteGToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reporteGToolStripMenuItem.Image")));
            this.reporteGToolStripMenuItem.Name = "reporteGToolStripMenuItem";
            this.reporteGToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reporteGToolStripMenuItem.Text = "Reporte";
            this.reporteGToolStripMenuItem.Click += new System.EventHandler(this.reporteGToolStripMenuItem_Click);
            // 
            // cuentasToolStripMenuItem
            // 
            this.cuentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentasPorPagarToolStripMenuItem,
            this.cuentasPorCobrarToolStripMenuItem});
            this.cuentasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cuentasToolStripMenuItem.Image")));
            this.cuentasToolStripMenuItem.Name = "cuentasToolStripMenuItem";
            this.cuentasToolStripMenuItem.Size = new System.Drawing.Size(82, 21);
            this.cuentasToolStripMenuItem.Text = "Cuentas";
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // empresaToolStripMenuItem
            // 
            this.empresaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacionEmpresaToolStripMenuItem,
            this.informaciónFacturaToolStripMenuItem});
            this.empresaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("empresaToolStripMenuItem.Image")));
            this.empresaToolStripMenuItem.Name = "empresaToolStripMenuItem";
            this.empresaToolStripMenuItem.Size = new System.Drawing.Size(87, 21);
            this.empresaToolStripMenuItem.Text = "Empresa";
            // 
            // informacionEmpresaToolStripMenuItem
            // 
            this.informacionEmpresaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("informacionEmpresaToolStripMenuItem.Image")));
            this.informacionEmpresaToolStripMenuItem.Name = "informacionEmpresaToolStripMenuItem";
            this.informacionEmpresaToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.informacionEmpresaToolStripMenuItem.Text = "Información Empresa";
            this.informacionEmpresaToolStripMenuItem.Click += new System.EventHandler(this.informacionEmpresaToolStripMenuItem_Click);
            // 
            // informaciónFacturaToolStripMenuItem
            // 
            this.informaciónFacturaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("informaciónFacturaToolStripMenuItem.Image")));
            this.informaciónFacturaToolStripMenuItem.Name = "informaciónFacturaToolStripMenuItem";
            this.informaciónFacturaToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.informaciónFacturaToolStripMenuItem.Text = "Información Factura";
            this.informaciónFacturaToolStripMenuItem.Click += new System.EventHandler(this.informaciónFacturaToolStripMenuItem_Click);
            // 
            // materialesToolStripMenuItem
            // 
            this.materialesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accesoriosToolStripMenuItem});
            this.materialesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("materialesToolStripMenuItem.Image")));
            this.materialesToolStripMenuItem.Name = "materialesToolStripMenuItem";
            this.materialesToolStripMenuItem.Size = new System.Drawing.Size(97, 21);
            this.materialesToolStripMenuItem.Text = "Materiales";
            // 
            // accesoriosToolStripMenuItem
            // 
            this.accesoriosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accesoriosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("accesoriosToolStripMenuItem.Image")));
            this.accesoriosToolStripMenuItem.Name = "accesoriosToolStripMenuItem";
            this.accesoriosToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.accesoriosToolStripMenuItem.Text = "Control Materiales";
            this.accesoriosToolStripMenuItem.Click += new System.EventHandler(this.accesoriosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clientesToolStripMenuItem.Image")));
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // administrarClientesToolStripMenuItem
            // 
            this.administrarClientesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("administrarClientesToolStripMenuItem.Image")));
            this.administrarClientesToolStripMenuItem.Name = "administrarClientesToolStripMenuItem";
            this.administrarClientesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.administrarClientesToolStripMenuItem.Text = "Administrar Clientes";
            this.administrarClientesToolStripMenuItem.Click += new System.EventHandler(this.administrarClientesToolStripMenuItem_Click);
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarUsuariosToolStripMenuItem,
            this.empleadosToolStripMenuItem1});
            this.empleadosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("empleadosToolStripMenuItem.Image")));
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(101, 21);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            // 
            // administrarUsuariosToolStripMenuItem
            // 
            this.administrarUsuariosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("administrarUsuariosToolStripMenuItem.Image")));
            this.administrarUsuariosToolStripMenuItem.Name = "administrarUsuariosToolStripMenuItem";
            this.administrarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.administrarUsuariosToolStripMenuItem.Text = "Administrar Usuarios";
            this.administrarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administrarUsuariosToolStripMenuItem_Click);
            // 
            // empleadosToolStripMenuItem1
            // 
            this.empleadosToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("empleadosToolStripMenuItem1.Image")));
            this.empleadosToolStripMenuItem1.Name = "empleadosToolStripMenuItem1";
            this.empleadosToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.empleadosToolStripMenuItem1.Text = "Administrar Empleados";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteCotizacionesToolStripMenuItem});
            this.reportesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportesToolStripMenuItem.Image")));
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(89, 21);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporteCotizacionesToolStripMenuItem
            // 
            this.reporteCotizacionesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reporteCotizacionesToolStripMenuItem.Image")));
            this.reporteCotizacionesToolStripMenuItem.Name = "reporteCotizacionesToolStripMenuItem";
            this.reporteCotizacionesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.reporteCotizacionesToolStripMenuItem.Text = "Reporte cotizaciones";
            this.reporteCotizacionesToolStripMenuItem.Click += new System.EventHandler(this.reporteCotizacionesToolStripMenuItem_Click);
            // 
            // temaToolStripMenuItem
            // 
            this.temaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temaClaro,
            this.temaOscuro});
            this.temaToolStripMenuItem.Name = "temaToolStripMenuItem";
            this.temaToolStripMenuItem.Size = new System.Drawing.Size(51, 21);
            this.temaToolStripMenuItem.Text = "Tema";
            // 
            // temaClaro
            // 
            this.temaClaro.CheckOnClick = true;
            this.temaClaro.Name = "temaClaro";
            this.temaClaro.Size = new System.Drawing.Size(118, 22);
            this.temaClaro.Text = "Claro";
            this.temaClaro.Click += new System.EventHandler(this.claroToolStripMenuItem_Click);
            // 
            // temaOscuro
            // 
            this.temaOscuro.CheckOnClick = true;
            this.temaOscuro.Name = "temaOscuro";
            this.temaOscuro.Size = new System.Drawing.Size(118, 22);
            this.temaOscuro.Text = "Oscuro";
            this.temaOscuro.Click += new System.EventHandler(this.oscuroToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem,
            this.salirDelSistemaToolStripMenuItem});
            this.salirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salirToolStripMenuItem.Image")));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarSesiónToolStripMenuItem.Image")));
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // salirDelSistemaToolStripMenuItem
            // 
            this.salirDelSistemaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salirDelSistemaToolStripMenuItem.Image")));
            this.salirDelSistemaToolStripMenuItem.Name = "salirDelSistemaToolStripMenuItem";
            this.salirDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.salirDelSistemaToolStripMenuItem.Text = "Salir del Sistema";
            this.salirDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.salirDelSistemaToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarProveedoresToolStripMenuItem,
            this.nuevaCompraToolStripMenuItem});
            this.proveedoresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("proveedoresToolStripMenuItem.Image")));
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(110, 21);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            // 
            // administrarProveedoresToolStripMenuItem
            // 
            this.administrarProveedoresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("administrarProveedoresToolStripMenuItem.Image")));
            this.administrarProveedoresToolStripMenuItem.Name = "administrarProveedoresToolStripMenuItem";
            this.administrarProveedoresToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.administrarProveedoresToolStripMenuItem.Text = "Administrar Proveedores";
            this.administrarProveedoresToolStripMenuItem.Click += new System.EventHandler(this.administrarProveedoresToolStripMenuItem_Click);
            // 
            // cuentasPorPagarToolStripMenuItem
            // 
            this.cuentasPorPagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cuentasPorPagarToolStripMenuItem.Image")));
            this.cuentasPorPagarToolStripMenuItem.Name = "cuentasPorPagarToolStripMenuItem";
            this.cuentasPorPagarToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.cuentasPorPagarToolStripMenuItem.Text = "Cuentas por pagar";
            // 
            // cuentasPorCobrarToolStripMenuItem
            // 
            this.cuentasPorCobrarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cuentasPorCobrarToolStripMenuItem.Image")));
            this.cuentasPorCobrarToolStripMenuItem.Name = "cuentasPorCobrarToolStripMenuItem";
            this.cuentasPorCobrarToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.cuentasPorCobrarToolStripMenuItem.Text = "Cuentas por cobrar";
            // 
            // nuevaCompraToolStripMenuItem
            // 
            this.nuevaCompraToolStripMenuItem.Name = "nuevaCompraToolStripMenuItem";
            this.nuevaCompraToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.nuevaCompraToolStripMenuItem.Text = "Nueva Compra";
            this.nuevaCompraToolStripMenuItem.Click += new System.EventHandler(this.nuevaCompraToolStripMenuItem_Click);
            // 
            // MenuPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1902, 999);
            this.Controls.Add(this.opcionesPrincipales);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.opcionesPrincipales;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1058);
            this.MinimumSize = new System.Drawing.Size(1918, 1038);
            this.Name = "MenuPrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.opcionesPrincipales.ResumeLayout(false);
            this.opcionesPrincipales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip opcionesPrincipales;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem gastosToolStripMenuItem;
        private ToolStripMenuItem cuentasToolStripMenuItem;
        private ToolStripMenuItem inventarioToolStripMenuItem;
        private ToolStripMenuItem empresaToolStripMenuItem;
        private ToolStripMenuItem materialesToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem administrarClientesToolStripMenuItem;
        private ToolStripMenuItem empleadosToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem salirDelSistemaToolStripMenuItem;
        private ToolStripMenuItem informacionEmpresaToolStripMenuItem;
        private ToolStripMenuItem informaciónFacturaToolStripMenuItem;
        private ToolStripMenuItem nuevoGastoToolStripMenuItem;
        private ToolStripMenuItem reporteGToolStripMenuItem;
        private ToolStripMenuItem accesoriosToolStripMenuItem;
        private ToolStripMenuItem administrarUsuariosToolStripMenuItem;
        private ToolStripMenuItem empleadosToolStripMenuItem1;
        private ToolStripMenuItem trabajosToolStripMenuItem;
        private ToolStripMenuItem reporteCotizacionesToolStripMenuItem;
        private ToolStripMenuItem trabajosPersonalizadosToolStripMenuItem;
        private ToolStripMenuItem temaToolStripMenuItem;
        private ToolStripMenuItem temaClaro;
        private ToolStripMenuItem temaOscuro;
        private ToolStripMenuItem proveedoresToolStripMenuItem;
        private ToolStripMenuItem administrarProveedoresToolStripMenuItem;
        private ToolStripMenuItem cuentasPorPagarToolStripMenuItem;
        private ToolStripMenuItem cuentasPorCobrarToolStripMenuItem;
        private ToolStripMenuItem nuevaCompraToolStripMenuItem;
    }
}