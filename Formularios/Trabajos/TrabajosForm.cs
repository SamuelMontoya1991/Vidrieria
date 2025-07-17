using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Clases.ClasesTrabajos;
using Vidrieria.Formularios.Cotizaciones;
using Vidrieria.Formularios.Factura;
using Vidrieria.Formularios.MenuPrincipal;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;


namespace Vidrieria.Formularios.Trabajos
{
    public partial class TrabajosForm : Form, IFormularioConUsuario, IFormularioConTema
    {
        Tema temaActual;
        Usuario? usuario;
        List<NuevoTrabajo> trabajos = new List<NuevoTrabajo>();
        ConexionDB BD = new ConexionDB();
        int tipoTrabajo = 0;
        int colorSeleccionado = 0;
        

        private void quitarSeleccion() { 
            tblAluminios.ClearSelection();
            tblHojas.ClearSelection();
            tblMolduras.ClearSelection();
            tblAccesorios.ClearSelection();
        }
        private void cargarLivianaCorrediza()
        {
            tipoTrabajo = 1;
            txtAlto.Text = "1";
            txtAncho.Text = "1";
            txtCantidad.Text = "1";
            txtAncho.Focus();
            cambiarColores(true, 1);
            reordenarColumnas();
            resetearCheckbox();
            string aluminios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=2 and vlivianacorr=1";
            string hojas = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=3 and vlivianacorr=1";
            string accesorios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=1 and vlivianacorr=1";
            string molduras = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=4 and vlivianacorr=1";
            tblAluminios.AutoGenerateColumns = false;
            tblAluminios.DataSource = BD.LlenarTabla(aluminios);
            tblHojas.DataSource = BD.LlenarTabla(hojas);
            tblMolduras.DataSource = BD.LlenarTabla(molduras);
            tblAccesorios.DataSource = BD.LlenarTabla(accesorios);
            quitarSeleccion();
            calcularLivianaCorrediza();
        }
        public void calcularLivianaCorrediza()
        {
            //empieza el aluminio
            int pies = 12;
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            double ancho = Convert.ToDouble(txtAncho.Text);
            double alto = Convert.ToDouble(txtAlto.Text);

            double medida = Convert.ToDouble(tblAluminios.Rows[0].Cells[0].Value);
            double total = (((ancho + (alto * 2)) / pies) / medida) * cantidad;

            tblAluminios.Rows[0].Cells[6].Value = total.ToString("0.00");
            double medida1 = Convert.ToDouble(tblAluminios.Rows[1].Cells[0].Value);
            double total1 = (((ancho) / pies) / medida1) * cantidad;

            tblAluminios.Rows[1].Cells[6].Value = total1.ToString("0.00");

            double area = (ancho * alto) / 144;
            txtPies.Text = (area).ToString("0.00");

            for (int i = 0; i < tblAluminios.RowCount; i++)
            {
                double precioN = Convert.ToDouble((tblAluminios.Rows[i].Cells[2].Value));
                double precioBR = Convert.ToDouble((tblAluminios.Rows[i].Cells[3].Value));
                double precioM = Convert.ToDouble((tblAluminios.Rows[i].Cells[4].Value));
                double usado = Convert.ToDouble((tblAluminios.Rows[i].Cells[6].Value));

                tblAluminios.Rows[i].Cells[7].Value = ((precioN * usado)).ToString("0.00");
                tblAluminios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[9].Value = ((precioM * usado)).ToString("0.00");
            }

            //empieza la hoja
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);
            medida = Convert.ToDouble("" + tblHojas.Rows[0].Cells[0].Value);
            medida1 = Convert.ToDouble("" + tblHojas.Rows[1].Cells[0].Value);
            double medida2 = Convert.ToDouble("" + tblHojas.Rows[2].Cells[0].Value);
            double medida3 = Convert.ToDouble("" + tblHojas.Rows[3].Cells[0].Value);
            double medida4 = 12;
            double medida5 = Convert.ToDouble("" + tblHojas.Rows[5].Cells[0].Value);


            tblHojas.Rows[0].Cells[6].Value = (((((ancho * 2) / 12) / medida) * cantidad)).ToString("0.00");
            tblHojas.Rows[1].Cells[6].Value = (((((ancho * 3) / 12) / medida1) * cantidad)).ToString("0.00");
            tblHojas.Rows[2].Cells[6].Value = (((((alto) / 12) / medida2) * cantidad)).ToString("0.00");
            tblHojas.Rows[3].Cells[6].Value = (((((area)) / medida3) * cantidad)).ToString("0.00");
            tblHojas.Rows[4].Cells[6].Value = (((((ancho * 2) + (alto * 4)) / medida4) * cantidad)).ToString("0.00");
            tblHojas.Rows[5].Cells[6].Value = (((((((ancho * 2) + (alto * 2)) / 12) / medida5) * 2) * cantidad)).ToString("0.00");
            tblHojas.Rows[6].Cells[6].Value = ((cantidad * 2)).ToString("0.00");
            tblHojas.Rows[7].Cells[6].Value = (((((alto * 3)) / 12) * cantidad)).ToString("0.00");

            for (int i = 0; i < tblHojas.RowCount; i++)
            {
                double precioN = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[2].Value));
                double precioBR = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[3].Value));
                double precioM = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[4].Value));
                double usado = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[6].Value));

                tblHojas.Rows[i].Cells[7].Value = ((precioN * usado)).ToString("0.00");
                tblHojas.Rows[i].Cells[8].Value = ((precioBR * usado)).ToString("0.00");
                tblHojas.Rows[i].Cells[9].Value = ((precioM * usado)).ToString("0.00");
            }

            //empieza molduras
            tblMolduras.Rows[0].Cells[6].Value = (((((ancho + (alto)) / medida) * cantidad))).ToString("0.00");
            tblMolduras.Rows[1].Cells[6].Value = ((cantidad)).ToString("0.00");
            tblMolduras.Rows[2].Cells[6].Value = ((cantidad) * 4).ToString("0.00");
            tblMolduras.Rows[3].Cells[6].Value = (((alto / 12) * cantidad)).ToString("0.00");


            for (int i = 0; i < tblMolduras.RowCount; i++)
            {
                double precioN = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[2].Value));
                double precioBR = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[3].Value));
                double precioM = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[4].Value));
                double usado = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[6].Value));

                tblMolduras.Rows[i].Cells[7].Value = ((precioN * usado)).ToString("0.00");
                tblMolduras.Rows[i].Cells[8].Value = ((precioBR * usado)).ToString("0.00");
                tblMolduras.Rows[i].Cells[9].Value = ((precioM * usado)).ToString("0.00");
            }
            //empieza accesorios
            tblAccesorios.Rows[0].Cells[6].Value = (((cantidad / 2))).ToString("0.00");

            for (int i = 0; i < tblAccesorios.RowCount; i++)
            {
                double precioN = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[2].Value));
                double precioBR = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[3].Value));
                double precioM = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[4].Value));
                double usado = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[6].Value));

                tblAccesorios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //calcular precios totales
            calcularPrecios();
        }
        private void cargarSemiPesada()
        {
            tipoTrabajo = 7;
            txtAlto.Text = "1";
            txtAncho.Text = "1";
            txtCantidad.Text = "1";
            txtAncho.Focus();
            cambiarColores(true, 7);
            reordenarColumnas();
            resetearCheckbox();
            string aluminios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=2 and vsemipesada=1";
            string hojas = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=3 and vsemipesada=1";
            string accesorios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=1 and vsemipesada=1";
            string molduras = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=4 and vsemipesada=1";
            tblAluminios.AutoGenerateColumns = false;
            tblAluminios.DataSource = BD.LlenarTabla(aluminios);
            tblHojas.DataSource = BD.LlenarTabla(hojas);
            tblMolduras.DataSource = BD.LlenarTabla(molduras);
            tblAccesorios.DataSource = BD.LlenarTabla(accesorios);
            quitarSeleccion();
            calcularSemiPesada();
        }
        public void calcularSemiPesada()
        {
            //empieza el aluminio
            int pies = 12;
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            double ancho = Convert.ToDouble(txtAncho.Text);
            double alto = Convert.ToDouble(txtAlto.Text);

            double medida = Convert.ToDouble(tblAluminios.Rows[0].Cells[0].Value);
            double total = (((ancho + (alto * 2)) / pies) / medida) * cantidad;
            tblAluminios.Rows[0].Cells[6].Value = total.ToString("0.00");

            double medida1 = Convert.ToDouble(tblAluminios.Rows[1].Cells[0].Value);
            double total1 = (((ancho) / pies) / medida1) * cantidad;
            tblAluminios.Rows[1].Cells[6].Value = total1.ToString("0.00");

            double medida2 = Convert.ToDouble(tblAluminios.Rows[2].Cells[0].Value);
            double total2 = (((ancho + (alto * 2)) / pies) / medida2) * cantidad;
            tblAluminios.Rows[2].Cells[6].Value = total1.ToString("0.00");



            double area = (ancho * alto) / 144;
            txtPies.Text = (area).ToString("0.00");

            for (int i = 0; i < tblAluminios.RowCount; i++)
            {
                double precioN = Convert.ToDouble((tblAluminios.Rows[i].Cells[2].Value));
                double precioBR = Convert.ToDouble((tblAluminios.Rows[i].Cells[3].Value));
                double precioM = Convert.ToDouble((tblAluminios.Rows[i].Cells[4].Value));
                double usado = Convert.ToDouble((tblAluminios.Rows[i].Cells[6].Value));

                tblAluminios.Rows[i].Cells[7].Value = ((precioN * usado)).ToString("0.00");
                tblAluminios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[9].Value = ((precioM * usado)).ToString("0.00");
            }

            //empieza la hoja
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);
            medida = Convert.ToDouble("" + tblHojas.Rows[0].Cells[0].Value);
            medida1 = Convert.ToDouble("" + tblHojas.Rows[1].Cells[0].Value);
            medida2 = Convert.ToDouble("" + tblHojas.Rows[2].Cells[0].Value);
            double medida3 = Convert.ToDouble("" + tblHojas.Rows[3].Cells[0].Value);
            double medida4 = Convert.ToDouble("" + tblHojas.Rows[4].Cells[0].Value);
            double medida5 = Convert.ToDouble("" + tblHojas.Rows[5].Cells[0].Value);
            double medida6 = Convert.ToDouble("" + tblHojas.Rows[6].Cells[0].Value);


            tblHojas.Rows[0].Cells[6].Value = ((((alto * 2) / 12) / medida) * cantidad).ToString("0.00");
            tblHojas.Rows[1].Cells[6].Value = (((((ancho * 2) + (alto * 2)) / 12) / medida1) * 2 * cantidad).ToString("0.00");
            tblHojas.Rows[2].Cells[6].Value = (((ancho / 12) / medida2) * cantidad).ToString("0.00");
            tblHojas.Rows[3].Cells[6].Value = (((ancho / 12) / medida3) * cantidad).ToString("0.00");
            tblHojas.Rows[4].Cells[6].Value = (((alto * 2 / 12) / medida4) * cantidad).ToString("0.00");
            tblHojas.Rows[5].Cells[6].Value = (((ancho * 2) / medida5) * cantidad).ToString("0.00");
            tblHojas.Rows[6].Cells[6].Value = ((area / medida6) * cantidad).ToString("0.00");
            tblHojas.Rows[7].Cells[6].Value = (cantidad * 2).ToString("0.00");
            tblHojas.Rows[8].Cells[6].Value = (cantidad * 4).ToString("0.00");
            tblHojas.Rows[9].Cells[6].Value = (cantidad * 4).ToString("0.00");
            tblHojas.Rows[10].Cells[6].Value = ((((alto * 2) + (ancho * 2)) / 12) * cantidad).ToString("0.00");
            tblHojas.Rows[11].Cells[6].Value = ((alto * 6) * cantidad).ToString("0.00");


            for (int i = 0; i < tblHojas.RowCount; i++)
            {
                double precioN = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[2].Value));
                double precioBR = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[3].Value));
                double precioM = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[4].Value));
                double usado = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[6].Value));

                tblHojas.Rows[i].Cells[7].Value = ((precioN * usado)).ToString("0.00");
                tblHojas.Rows[i].Cells[8].Value = ((precioBR * usado)).ToString("0.00");
                tblHojas.Rows[i].Cells[9].Value = ((precioM * usado)).ToString("0.00");
            }

            //empieza molduras
            tblMolduras.Rows[0].Cells[6].Value = ((((ancho + alto) / pies) / medida) * cantidad).ToString("0.00");
            tblMolduras.Rows[1].Cells[6].Value = ((cantidad)).ToString("0.00");
            tblMolduras.Rows[2].Cells[6].Value = ((cantidad * 4)).ToString("0.00");
            tblMolduras.Rows[3].Cells[6].Value = (((alto / 12) * cantidad)).ToString("0.00");


            for (int i = 0; i < tblMolduras.RowCount; i++)
            {
                double precioN = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[2].Value));
                double precioBR = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[3].Value));
                double precioM = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[4].Value));
                double usado = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[6].Value));

                tblMolduras.Rows[i].Cells[7].Value = ((precioN * usado)).ToString("0.00");
                tblMolduras.Rows[i].Cells[8].Value = ((precioBR * usado)).ToString("0.00");
                tblMolduras.Rows[i].Cells[9].Value = ((precioM * usado)).ToString("0.00");
            }
            //empieza accesorios
            tblAccesorios.Rows[0].Cells[6].Value = (((cantidad / 2))).ToString("0.00");

            for (int i = 0; i < tblAccesorios.RowCount; i++)
            {
                double precioN = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[2].Value));
                double precioBR = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[3].Value));
                double precioM = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[4].Value));
                double usado = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[6].Value));

                tblAccesorios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //calcular precios totales
            calcularPrecios();
        }
        private void cargarFijaLiviana()
        {
            tipoTrabajo = 2;
            txtAlto.Text = "1";
            txtAncho.Text = "1";
            txtCantidad.Text = "1";
            txtAncho.Focus();
            cambiarColores(true, 2);
            reordenarColumnas();
            resetearCheckbox();
            string aluminios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=2 and vfijaliviana=1";
            string hojas = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=3 and vfijaliviana=1";
            string accesorios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=1 and vfijaliviana=1";
            string molduras = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=4 and vfijaliviana=1";
            tblAluminios.AutoGenerateColumns = false;
            tblAluminios.DataSource = BD.LlenarTabla(aluminios);
            tblHojas.DataSource = BD.LlenarTabla(hojas);
            tblMolduras.DataSource = BD.LlenarTabla(molduras);
            tblAccesorios.DataSource = BD.LlenarTabla(accesorios);
            quitarSeleccion();
            calcularFijaLiviana();
        }
        public void calcularFijaLiviana()
        {
            //empieza el aluminio
            int pies = 12;
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            double ancho = Convert.ToDouble(txtAncho.Text);
            double alto = Convert.ToDouble(txtAlto.Text);

            double medida = Convert.ToDouble(tblAluminios.Rows[0].Cells[0].Value);
            double total = (((ancho + (alto * 2)) / pies) / medida) * cantidad;
            tblAluminios.Rows[0].Cells[6].Value = total.ToString("0.00");

            double medida1 = Convert.ToDouble(tblAluminios.Rows[1].Cells[0].Value);
            double total1 = (((ancho) / pies) / medida1) * cantidad;
            tblAluminios.Rows[1].Cells[6].Value = total1.ToString("0.00");



            double area = (ancho * alto) / 144;
            txtPies.Text = (area).ToString("0.00");

            for (int i = 0; i < tblAluminios.RowCount; i++)
            {
                double precioN = Convert.ToDouble((tblAluminios.Rows[i].Cells[2].Value));
                double precioBR = Convert.ToDouble((tblAluminios.Rows[i].Cells[3].Value));
                double precioM = Convert.ToDouble((tblAluminios.Rows[i].Cells[4].Value));
                double usado = Convert.ToDouble((tblAluminios.Rows[i].Cells[6].Value));

                tblAluminios.Rows[i].Cells[7].Value = ((precioN * usado)).ToString("0.00");
                tblAluminios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[9].Value = ((precioM * usado)).ToString("0.00");
            }

            //empieza la hoja
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);
            medida = Convert.ToDouble("" + tblHojas.Rows[0].Cells[0].Value);
            medida1 = Convert.ToDouble("" + tblHojas.Rows[1].Cells[0].Value);
            double medida2 = Convert.ToDouble("" + tblHojas.Rows[2].Cells[0].Value);



            tblHojas.Rows[0].Cells[6].Value = ((((alto * 2) / 12) / medida) * cantidad).ToString("0.00");
            tblHojas.Rows[1].Cells[6].Value = (((((ancho * 2) + (alto * 2)) / 12) / medida1) * 2 * cantidad).ToString("0.00");
            tblHojas.Rows[2].Cells[6].Value = (((ancho / 12) / medida2) * cantidad).ToString("0.00");

            for (int i = 0; i < tblHojas.RowCount; i++)
            {
                double precioN = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[2].Value));
                double precioBR = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[3].Value));
                double precioM = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[4].Value));
                double usado = Convert.ToDouble(("" + tblHojas.Rows[i].Cells[6].Value));

                tblHojas.Rows[i].Cells[7].Value = ((precioN * usado)).ToString("0.00");
                tblHojas.Rows[i].Cells[8].Value = ((precioBR * usado)).ToString("0.00");
                tblHojas.Rows[i].Cells[9].Value = ((precioM * usado)).ToString("0.00");
            }

            //empieza molduras
            //tblMolduras.Rows[0].Cells[6].Value = ((((ancho + alto) / pies) / medida) * cantidad).ToString("0.00");
            //tblMolduras.Rows[1].Cells[6].Value = ((cantidad)).ToString("0.00");
            //tblMolduras.Rows[2].Cells[6].Value = ((cantidad * 4)).ToString("0.00");
            //tblMolduras.Rows[3].Cells[6].Value = (((alto / 12) * cantidad)).ToString("0.00");


            //for (int i = 0; i < 4; i++)
            //{
            //    double precioN = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[2].Value));
            //    double precioBR = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[3].Value));
            //    double precioM = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[4].Value));
            //    double usado = Convert.ToDouble(("" + tblMolduras.Rows[i].Cells[6].Value));

            //    tblMolduras.Rows[i].Cells[7].Value = ((precioN * usado)).ToString("0.00");
            //    tblMolduras.Rows[i].Cells[8].Value = ((precioBR * usado)).ToString("0.00");
            //    tblMolduras.Rows[i].Cells[9].Value = ((precioM * usado)).ToString("0.00");
            //}
            //empieza accesorios
            tblAccesorios.Rows[0].Cells[6].Value = (((cantidad / 2))).ToString("0.00");

            for (int i = 0; i < tblAccesorios.RowCount; i++)
            {
                double precioN = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[2].Value));
                double precioBR = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[3].Value));
                double precioM = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[4].Value));
                double usado = Convert.ToDouble(("" + tblAccesorios.Rows[i].Cells[6].Value));

                tblAccesorios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //calcular precios totales
            calcularPrecios();
        }
        private void cargarFijaPesada()
        {
            tipoTrabajo = 3;
            txtAlto.Text = "1";
            txtAncho.Text = "1";
            txtCantidad.Text = "1";
            txtAncho.Focus();
            cambiarColores(true, 3);
            reordenarColumnas();
            resetearCheckbox();
            string aluminios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=2 and vfijapesada=1";
            string hojas = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=3 and vfijapesada=1";
            string accesorios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=1 and vfijapesada=1";
            string molduras = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=4 and vfijapesada=1";
            tblAluminios.AutoGenerateColumns = false;
            tblAluminios.DataSource = BD.LlenarTabla(aluminios);
            tblHojas.DataSource = BD.LlenarTabla(hojas);
            tblMolduras.DataSource = BD.LlenarTabla(molduras);
            tblAccesorios.DataSource = BD.LlenarTabla(accesorios);
            quitarSeleccion();
            calcularFijaPesada();
        }
        public void calcularFijaPesada()
        {
            //empieza el aluminio
            double cantidad = double.Parse(txtCantidad.Text);
            double ancho = double.Parse(txtAncho.Text);
            double alto = double.Parse(txtAlto.Text);
            double medida = double.Parse(tblAluminios.Rows[0].Cells[0].Value.ToString());
            double total = ((((ancho * 2) + (alto * 2)) / 12) / medida) * cantidad;
            tblAluminios.Rows[0].Cells[6].Value = total.ToString("0.00");

            double area = (ancho * alto) / 144;
            txtPies.Text = area.ToString("0.00");

            for (int i = 0; i < tblAluminios.RowCount; i++)
            {
                double precioN = double.Parse(tblAluminios.Rows[i].Cells[2].Value.ToString());
                double precioBR = double.Parse(tblAluminios.Rows[i].Cells[3].Value.ToString());
                double precioM = double.Parse(tblAluminios.Rows[i].Cells[4].Value.ToString());
                double usado = double.Parse(tblAluminios.Rows[i].Cells[6].Value.ToString());

                tblAluminios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }

            //empieza la hoja
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);
            medida = Convert.ToDouble("" + tblHojas.Rows[0].Cells[0].Value);
            double medida1 = Convert.ToDouble(tblHojas.Rows[1].Cells[0].Value.ToString());
            double medida2 = Convert.ToDouble(tblHojas.Rows[2].Cells[0].Value.ToString());
            double medida3 = Convert.ToDouble(tblHojas.Rows[3].Cells[0].Value.ToString());

            tblHojas.Rows[0].Cells[6].Value = (((((alto * 2) + (ancho * 2)) / 12) / medida) * cantidad).ToString("0.00");
            tblHojas.Rows[1].Cells[6].Value = (((((alto * 2) + (ancho * 2)) / 12) / medida1) * cantidad).ToString("0.00");
            tblHojas.Rows[2].Cells[6].Value = ((area / medida2) * cantidad).ToString("0.00");
            tblHojas.Rows[3].Cells[6].Value = (((ancho * 2) + (alto * 2) / 12) * cantidad).ToString("0.00");

            for (int i = 0; i < tblHojas.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblHojas.Rows[i].Cells[2].Value.ToString());
                double precioBR = Convert.ToDouble(tblHojas.Rows[i].Cells[3].Value.ToString());
                double precioM = Convert.ToDouble(tblHojas.Rows[i].Cells[4].Value.ToString());
                double usado = Convert.ToDouble(tblHojas.Rows[i].Cells[6].Value.ToString());

                tblHojas.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }

            //empieza molduras

            //empieza accesorios
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToDouble(txtCantidad.Text);

            tblAccesorios.Rows[0].Cells[6].Value = (cantidad / 2).ToString("0.00");

            for (int i = 0; i < 1; i++)
            {
                double precioN = Convert.ToDouble(tblAccesorios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblAccesorios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblAccesorios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblAccesorios.Rows[i].Cells[6].Value);

                tblAccesorios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }

            //calcular precios totales
            calcularPrecios();
        }
        private void cargarGuillotina()
        {
            tipoTrabajo = 5;
            txtAlto.Text = "1";
            txtAncho.Text = "1";
            txtCantidad.Text = "1";
            txtAncho.Focus();
            cambiarColores(true, 5);
            reordenarColumnas();
            resetearCheckbox();
            string aluminios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=2 and guillotina=1";
            string hojas = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=3 and guillotina=1";
            string accesorios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=1 and guillotina=1";
            string molduras = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=4 and guillotina=1";
            tblAluminios.AutoGenerateColumns = false;
            tblAluminios.DataSource = BD.LlenarTabla(aluminios);
            tblHojas.DataSource = BD.LlenarTabla(hojas);
            tblMolduras.DataSource = BD.LlenarTabla(molduras);
            tblAccesorios.DataSource = BD.LlenarTabla(accesorios);
            quitarSeleccion();
            calcularGuillotina();
        }
        private void calcularGuillotina()
        {
            //empieza el aluminio

            double cantidad = Convert.ToDouble(txtCantidad.Text);
            double ancho = Convert.ToDouble(txtAncho.Text);
            double alto = Convert.ToDouble(txtAlto.Text);
            double medida = Convert.ToDouble(tblAluminios.Rows[0].Cells[0].Value);
            double total = ((((ancho * 2) + (alto * 2)) / 12) / medida) * cantidad;
            tblAluminios.Rows[0].Cells[6].Value = total.ToString("0.00");

            double area = (ancho * alto) / 144;
            txtPies.Text = area.ToString("0.00");

            for (int i = 0; i < tblAluminios.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblAluminios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblAluminios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblAluminios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblAluminios.Rows[i].Cells[6].Value);

                tblAluminios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //empieza la hoja
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            medida = Convert.ToDouble(tblHojas.Rows[0].Cells[0].Value);
            double medida1 = Convert.ToDouble(tblHojas.Rows[1].Cells[0].Value);
            double medida2 = Convert.ToDouble(tblHojas.Rows[2].Cells[0].Value);
            double medida3 = Convert.ToDouble(tblHojas.Rows[3].Cells[0].Value);
            double medida4 = 12;
            double medida5 = Convert.ToDouble(tblHojas.Rows[5].Cells[0].Value);

            tblHojas.Rows[0].Cells[6].Value = (((ancho * 2) / 12) / medida * cantidad).ToString("0.00");
            tblHojas.Rows[1].Cells[6].Value = ((((alto * 2) / 12) / 2) / medida1 * cantidad).ToString("0.00");
            tblHojas.Rows[2].Cells[6].Value = ((((alto * 2) + (ancho * 4)) / 12) * cantidad).ToString("0.00");
            tblHojas.Rows[3].Cells[6].Value = (((((alto * 2) + (ancho * 2)) / 12) / medida3) * 2 * cantidad).ToString("0.00");
            tblHojas.Rows[4].Cells[6].Value = (((ancho * 2) / medida4) * cantidad).ToString("0.00");
            tblHojas.Rows[5].Cells[6].Value = ((area / medida5) * cantidad).ToString("0.00");

            tblHojas.Rows[6].Cells[6].Value = (cantidad * 2).ToString("0.00");

            for (int i = 0; i < tblHojas.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblHojas.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblHojas.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblHojas.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblHojas.Rows[i].Cells[6].Value);

                tblHojas.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //empieza molduras
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            medida = Convert.ToDouble(tblMolduras.Rows[0].Cells[0].Value);

            tblMolduras.Rows[0].Cells[6].Value = ((alto / 12) * cantidad).ToString("0.00");
            tblMolduras.Rows[1].Cells[6].Value = cantidad.ToString("0.00");

            for (int i = 0; i < tblMolduras.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblMolduras.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblMolduras.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblMolduras.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblMolduras.Rows[i].Cells[6].Value);

                tblMolduras.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblMolduras.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblMolduras.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //empieza accesorios
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToDouble(txtCantidad.Text);

            tblAccesorios.Rows[0].Cells[6].Value = (cantidad / 2).ToString("0.00");

            for (int i = 0; i < 1; i++)
            {
                double precioN = Convert.ToDouble(tblAccesorios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblAccesorios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblAccesorios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblAccesorios.Rows[i].Cells[6].Value);

                tblAccesorios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //calcular precios totales
            calcularPrecios();
        }
        private void cargarPesada()
        {
            tipoTrabajo = 4;
            txtAlto.Text = "1";
            txtAncho.Text = "1";
            txtCantidad.Text = "1";
            txtAncho.Focus();
            cambiarColores(true, 4);
            reordenarColumnas();
            resetearCheckbox();
            string aluminios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=2 and pvpesada=1";
            string hojas = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=3 and pvpesada=1";
            string accesorios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=1 and pvpesada=1";
            string molduras = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=4 and pvpesada=1";
            tblAluminios.AutoGenerateColumns = false;
            tblAluminios.DataSource = BD.LlenarTabla(aluminios);
            tblHojas.DataSource = BD.LlenarTabla(hojas);
            tblMolduras.DataSource = BD.LlenarTabla(molduras);
            tblAccesorios.DataSource = BD.LlenarTabla(accesorios);
            quitarSeleccion();
            calcularPesada();
        }
        private void calcularPesada()
        {
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double ancho = Convert.ToDouble(txtAncho.Text);
            double alto = Convert.ToDouble(txtAlto.Text);

            double medida = Convert.ToDouble(tblAluminios.Rows[0].Cells[0].Value);
            double total = ((ancho / 12) / medida) * cantidad;
            tblAluminios.Rows[0].Cells[6].Value = total.ToString("0.00");

            double medida1 = Convert.ToDouble(tblAluminios.Rows[1].Cells[0].Value);
            double total1 = ((ancho / 12) / medida1) * cantidad;
            tblAluminios.Rows[1].Cells[6].Value = total1.ToString("0.00");

            double medida2 = Convert.ToDouble(tblAluminios.Rows[2].Cells[0].Value);
            double total2 = ((alto * 2 / 12) / medida1) * cantidad;
            tblAluminios.Rows[2].Cells[6].Value = total2.ToString("0.00");

            double area = (ancho * alto) / 144;
            txtPies.Text = area.ToString("0.00");

            for (int i = 0; i < tblAluminios.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblAluminios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblAluminios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblAluminios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblAluminios.Rows[i].Cells[6].Value);

                tblAluminios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //empieza la hoja
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            medida = Convert.ToDouble(tblHojas.Rows[0].Cells[0].Value);
            medida1 = Convert.ToDouble(tblHojas.Rows[1].Cells[0].Value);
            medida2 = Convert.ToDouble(tblHojas.Rows[2].Cells[0].Value);
            double medida3 = Convert.ToDouble(tblHojas.Rows[3].Cells[0].Value);
            double medida4 = Convert.ToDouble(tblHojas.Rows[4].Cells[0].Value);
            double medida5 = Convert.ToDouble(tblHojas.Rows[5].Cells[0].Value);
            double medida6 = Convert.ToDouble(tblHojas.Rows[6].Cells[0].Value);
            double medida7 = Convert.ToDouble(tblHojas.Rows[7].Cells[0].Value);
            double medida8 = Convert.ToDouble(tblHojas.Rows[8].Cells[0].Value);
            double medida9 = Convert.ToDouble(tblHojas.Rows[9].Cells[0].Value);
            double medida10 = Convert.ToDouble(tblHojas.Rows[10].Cells[0].Value);
            double medida11 = Convert.ToDouble(tblHojas.Rows[11].Cells[0].Value);

            tblHojas.Rows[0].Cells[6].Value = (((alto * 2) / 12) / medida * cantidad).ToString("0.00");
            tblHojas.Rows[1].Cells[6].Value = ((area / medida1) * cantidad).ToString("0.00");
            tblHojas.Rows[2].Cells[6].Value = ((((ancho * 2) + (alto * 2)) / 12) * cantidad).ToString("0.00");
            tblHojas.Rows[3].Cells[6].Value = (((((ancho * 4) + (alto * 2)) / 12) / medida3) * 2 * cantidad).ToString("0.00");
            tblHojas.Rows[4].Cells[6].Value = (((ancho / 12) / medida4) * cantidad).ToString("0.00");
            tblHojas.Rows[5].Cells[6].Value = (((ancho / 12) / medida5) * cantidad).ToString("0.00");
            tblHojas.Rows[6].Cells[6].Value = (((alto * 2 / 12) / medida6) * cantidad).ToString("0.00");
            tblHojas.Rows[7].Cells[6].Value = ((ancho * 2) / 236).ToString("0.00");
            tblHojas.Rows[8].Cells[6].Value = (cantidad * 2).ToString("0.00");
            tblHojas.Rows[9].Cells[6].Value = (cantidad * 4).ToString("0.00");
            tblHojas.Rows[10].Cells[6].Value = (cantidad * 4).ToString("0.00");
            tblHojas.Rows[11].Cells[6].Value = (((ancho * 6) / 12) * cantidad).ToString("0.00");


            for (int i = 0; i < tblHojas.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblHojas.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblHojas.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblHojas.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblHojas.Rows[i].Cells[6].Value);

                tblHojas.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //empieza molduras
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            medida = Convert.ToDouble(tblMolduras[0, 0].Value);

            tblMolduras.Rows[0].Cells[6].Value = (((((ancho + (alto * 2)) / 12) / medida) * cantidad)).ToString("0.00");
            tblMolduras.Rows[1].Cells[6].Value = cantidad;
            tblMolduras.Rows[2].Cells[6].Value = cantidad * 4;
            tblMolduras.Rows[3].Cells[6].Value = ((alto / 12) * cantidad).ToString("0.00");

            for (int i = 0; i < 4; i++)
            {
                double precioN = Convert.ToDouble(tblMolduras.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblMolduras.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblMolduras.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblMolduras.Rows[i].Cells[6].Value);

                tblMolduras.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblMolduras.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblMolduras.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //empieza accesorios
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            tblAccesorios.Rows[0].Cells[6].Value = (cantidad / 2).ToString("0.00");

            for (int i = 0; i < 1; i++)
            {
                double precioN = Convert.ToDouble(tblAccesorios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblAccesorios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblAccesorios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblAccesorios.Rows[i].Cells[6].Value);

                tblAccesorios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //calcular precios totales
            calcularPrecios();
        }
        private void cargarPesadaDoble()
        {
            tipoTrabajo = 6;
            txtAlto.Text = "1";
            txtAncho.Text = "1";
            txtCantidad.Text = "1";
            txtAncho.Focus();
            cambiarColores(true, 6);
            reordenarColumnas();
            resetearCheckbox();
            string aluminios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=2 and PVpesadadoble=1";
            string hojas = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=3 and PVpesadadoble=1";
            string accesorios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=1 and PVpesadadoble=1";
            string molduras = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=4 and PVpesadadoble=1";
            tblAluminios.AutoGenerateColumns = false;
            tblAluminios.DataSource = BD.LlenarTabla(aluminios);
            tblHojas.DataSource = BD.LlenarTabla(hojas);
            tblMolduras.DataSource = BD.LlenarTabla(molduras);
            tblAccesorios.DataSource = BD.LlenarTabla(accesorios);
            quitarSeleccion();
            calcularPesadaDoble();
        }
        private void calcularPesadaDoble()
        {
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double ancho = Convert.ToDouble(txtAncho.Text);
            double alto = Convert.ToDouble(txtAlto.Text);
            double medida = Convert.ToDouble(tblAluminios.Rows[0].Cells[0].Value);
            double total = ((ancho / 12) / medida) * cantidad;
            tblAluminios.Rows[0].Cells[6].Value = total.ToString("0.00");

            double medida1 = Convert.ToDouble(tblAluminios.Rows[1].Cells[0].Value);
            double total1 = ((ancho / 12) / medida1) * cantidad;
            tblAluminios.Rows[1].Cells[6].Value = total1.ToString("0.00");

            double medida2 = Convert.ToDouble(tblAluminios.Rows[2].Cells[0].Value);
            double total2 = ((alto * 2 / 12) / medida1) * cantidad;
            tblAluminios.Rows[2].Cells[6].Value = total2.ToString("0.00");

            double area = (ancho * alto) / 144;
            txtPies.Text = area.ToString("0.00");

            for (int i = 0; i < tblAluminios.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblAluminios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblAluminios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblAluminios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblAluminios.Rows[i].Cells[6].Value);

                tblAluminios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //empieza la hoja
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            medida = Convert.ToDouble(tblHojas.Rows[0].Cells[0].Value);
            medida1 = Convert.ToDouble(tblHojas.Rows[1].Cells[0].Value);
            medida2 = Convert.ToDouble(tblHojas.Rows[2].Cells[0].Value);
            double medida3 = Convert.ToDouble(tblHojas.Rows[3].Cells[0].Value);
            double medida4 = Convert.ToDouble(tblHojas.Rows[4].Cells[0].Value);
            double medida5 = Convert.ToDouble(tblHojas.Rows[5].Cells[0].Value);
            double medida6 = Convert.ToDouble(tblHojas.Rows[6].Cells[0].Value);
            double medida7 = Convert.ToDouble(tblHojas.Rows[7].Cells[0].Value);
            double medida8 = Convert.ToDouble(tblHojas.Rows[8].Cells[0].Value);
            double medida9 = Convert.ToDouble(tblHojas.Rows[9].Cells[0].Value);
            double medida10 = Convert.ToDouble(tblHojas.Rows[10].Cells[0].Value);
            double medida11 = Convert.ToDouble(tblHojas.Rows[11].Cells[0].Value);
            double medida12 = Convert.ToDouble(tblHojas.Rows[12].Cells[0].Value);

            tblHojas.Rows[0].Cells[6].Value = (((alto * 2) / 12) / medida * cantidad).ToString("0.00");
            tblHojas.Rows[1].Cells[6].Value = ((area / medida1) * cantidad).ToString("0.00");
            tblHojas.Rows[2].Cells[6].Value = ((((ancho * 2) + (alto * 2)) / 12) * cantidad).ToString("0.00");
            tblHojas.Rows[3].Cells[6].Value = (((((ancho * 4) + (alto * 2)) / 12) / medida3) * 2 * cantidad).ToString("0.00");
            tblHojas.Rows[4].Cells[6].Value = (((ancho / 12) / medida4) * cantidad).ToString("0.00");
            tblHojas.Rows[5].Cells[6].Value = (((ancho / 12) / medida5) * cantidad).ToString("0.00");
            tblHojas.Rows[6].Cells[6].Value = (((alto * 2 / 12) / medida6) * cantidad).ToString("0.00");
            tblHojas.Rows[7].Cells[6].Value = ((ancho * 2) / 236).ToString("0.00");
            tblHojas.Rows[8].Cells[6].Value = (cantidad * 2).ToString("0.00");
            tblHojas.Rows[9].Cells[6].Value = (cantidad * 4).ToString("0.00");
            tblHojas.Rows[10].Cells[6].Value = (cantidad * 4).ToString("0.00");
            tblHojas.Rows[11].Cells[6].Value = (((ancho * 6) / 12) * cantidad).ToString("0.00");
            tblHojas.Rows[12].Cells[6].Value = (((alto * 2) / 12) / medida12 * cantidad).ToString("0.00");

            for (int i = 0; i < tblHojas.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblHojas.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblHojas.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblHojas.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblHojas.Rows[i].Cells[6].Value);

                tblHojas.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //empieza moldura
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            medida = Convert.ToDouble(tblMolduras.Rows[0].Cells[0].Value);

            tblMolduras.Rows[0].Cells[6].Value = ((((ancho + (alto * 2)) / 12) / medida) * cantidad).ToString("0.00");
            tblMolduras.Rows[1].Cells[6].Value = cantidad.ToString();
            tblMolduras.Rows[2].Cells[6].Value = (cantidad * 4).ToString();
            tblMolduras.Rows[3].Cells[6].Value = ((alto / 12) * cantidad).ToString("0.00");

            for (int i = 0; i < tblMolduras.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblMolduras.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblMolduras.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblMolduras.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblMolduras.Rows[i].Cells[6].Value);

                tblMolduras.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblMolduras.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblMolduras.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //empieza accesorio
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            tblAccesorios.Rows[0].Cells[6].Value = (cantidad / 2).ToString("0.00");

            for (int i = 0; i < 1; i++)
            {
                double precioN = Convert.ToDouble(tblAccesorios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblAccesorios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblAccesorios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblAccesorios.Rows[i].Cells[6].Value);

                tblAccesorios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //calcular precios
            calcularPrecios();
        }
        private void cargarAbatible()
        {
            tipoTrabajo = 11;
            txtAlto.Text = "1";
            txtAncho.Text = "1";
            txtCantidad.Text = "1";
            txtAncho.Focus();
            cambiarColores(true, 11);
            reordenarColumnas();
            resetearCheckbox();
            string aluminios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=2 and pabatible=1";
            string hojas = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=3 and pabatible=1";
            string accesorios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=1 and pabatible=1";
            string molduras = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=4 and pabatible=1";
            tblAluminios.AutoGenerateColumns = false;
            tblAluminios.DataSource = BD.LlenarTabla(aluminios);
            tblHojas.DataSource = BD.LlenarTabla(hojas);
            tblMolduras.DataSource = BD.LlenarTabla(molduras);
            tblAccesorios.DataSource = BD.LlenarTabla(accesorios);
            quitarSeleccion();
            calcularAbatible();
        }
        private void calcularAbatible()
        {
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double ancho = Convert.ToDouble(txtAncho.Text);
            double alto = Convert.ToDouble(txtAlto.Text);
            double medida = Convert.ToDouble(tblAluminios.Rows[0].Cells[0].Value);
            double total = (((ancho + (alto * 2)) / 12) / medida) * cantidad;
            tblAluminios.Rows[0].Cells[6].Value = total.ToString("0.00");

            double medida1 = Convert.ToDouble(tblAluminios.Rows[1].Cells[0].Value);
            double total1 = ((ancho / 12) / medida1) * cantidad;
            tblAluminios.Rows[1].Cells[6].Value = total1.ToString("0.00");

            double area = (ancho * alto) / 144;
            txtPies.Text = area.ToString("0.00");

            for (int i = 0; i < tblAluminios.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblAluminios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblAluminios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblAluminios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblAluminios.Rows[i].Cells[6].Value);

                tblAluminios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //empieza Hojas
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            medida = Convert.ToDouble(tblHojas.Rows[0].Cells[0].Value);
            medida1 = Convert.ToDouble(tblHojas.Rows[1].Cells[0].Value);
            double medida2 = Convert.ToDouble(tblHojas.Rows[2].Cells[0].Value);
            double medida3 = Convert.ToDouble(tblHojas.Rows[3].Cells[0].Value);
            double medida4 = Convert.ToDouble(tblHojas.Rows[4].Cells[0].Value);
            double medida5 = Convert.ToDouble(tblHojas.Rows[5].Cells[0].Value);
            double medida6 = Convert.ToDouble(tblHojas.Rows[6].Cells[0].Value);
            double medida7 = Convert.ToDouble(tblHojas.Rows[7].Cells[0].Value);
            double medida8 = Convert.ToDouble(tblHojas.Rows[8].Cells[0].Value);
            double medida9 = Convert.ToDouble(tblHojas.Rows[9].Cells[0].Value);
            double medida10 = Convert.ToDouble(tblHojas.Rows[10].Cells[0].Value);
            // double medida11 = Convert.ToDouble(tblHojas.Rows[11].Cells[0].Value);
            // double medida12 = Convert.ToDouble(tblHojas.Rows[12].Cells[0].Value);

            tblHojas.Rows[0].Cells[6].Value = (((alto * 2) / 12) / medida * cantidad).ToString("0.00");
            tblHojas.Rows[1].Cells[6].Value = ((area / medida1) * cantidad).ToString("0.00");
            tblHojas.Rows[2].Cells[6].Value = ((((ancho * 2) + (alto * 4)) / 12) * cantidad).ToString("0.00");
            tblHojas.Rows[3].Cells[6].Value = (((ancho / 12) / medida3) * cantidad).ToString("0.00");
            tblHojas.Rows[4].Cells[6].Value = (((ancho / 12) / medida4) * cantidad).ToString("0.00");
            tblHojas.Rows[5].Cells[6].Value = (((alto * 6) / 12) * cantidad).ToString("0.00");
            tblHojas.Rows[6].Cells[6].Value = cantidad.ToString("0.00");
            tblHojas.Rows[7].Cells[6].Value = cantidad.ToString("0.00");
            tblHojas.Rows[8].Cells[6].Value = cantidad.ToString("0.00");
            tblHojas.Rows[9].Cells[6].Value = (((ancho * 2) + (alto * 2)) / 12 / medida9).ToString("0.00");
            tblHojas.Rows[10].Cells[6].Value = cantidad.ToString("0.00");
            // tblHojas.Rows[11].Cells[6].Value = (((ancho * 6) / 12) * cantidad).ToString("0.00");
            // tblHojas.Rows[12].Cells[6].Value = (((alto * 2) / 12) / medida12 * cantidad).ToString("0.00");

            for (int i = 0; i < tblHojas.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblHojas.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblHojas.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblHojas.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblHojas.Rows[i].Cells[6].Value);

                tblHojas.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //empieza accesorios
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);
            medida = Convert.ToDouble(tblAccesorios.Rows[2].Cells[0].Value);

            tblAccesorios.Rows[0].Cells[6].Value = cantidad.ToString("0.00");
            tblAccesorios.Rows[1].Cells[6].Value = cantidad.ToString("0.00");
            tblAccesorios.Rows[2].Cells[6].Value = ((ancho / 12) / medida).ToString("0.00");
            tblAccesorios.Rows[3].Cells[6].Value = cantidad.ToString("0.00");
            tblAccesorios.Rows[4].Cells[6].Value = cantidad.ToString("0.00");
            tblAccesorios.Rows[5].Cells[6].Value = cantidad.ToString("0.00");

            for (int i = 0; i < tblAccesorios.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblAccesorios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblAccesorios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblAccesorios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblAccesorios.Rows[i].Cells[6].Value);

                tblAccesorios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //calcular precios
            calcularPrecios();
        }
        private void cargarPbanioUsa()
        {
            tipoTrabajo = 8;
            txtAlto.Text = "1";
            txtAncho.Text = "1";
            txtCantidad.Text = "1";
            txtAncho.Focus();
            cambiarColores(true, 8);
            reordenarColumnas();
            resetearCheckbox();
            string aluminios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=2 and pbaniousa=1";
            string hojas = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=3 and pbaniousa=1";
            string accesorios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=1 and pbaniousa=1";
            string molduras = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=4 and pbaniousa=1";
            tblAluminios.AutoGenerateColumns = false;
            tblAluminios.DataSource = BD.LlenarTabla(aluminios);
            tblHojas.DataSource = BD.LlenarTabla(hojas);
            tblMolduras.DataSource = BD.LlenarTabla(molduras);
            tblAccesorios.DataSource = BD.LlenarTabla(accesorios);
            quitarSeleccion();
            calcularPbanioUsa();
        }
        private void calcularPbanioUsa()
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            double ancho = Convert.ToDouble(txtAncho.Text);
            double alto = Convert.ToDouble(txtAlto.Text);

            double medida0 = Convert.ToDouble(tblAluminios.Rows[0].Cells[0].Value);
            double total0 = (ancho / medida0) * cantidad;
            tblAluminios.Rows[0].Cells[6].Value = total0.ToString("0.00");

            double medida1 = Convert.ToDouble(tblAluminios.Rows[1].Cells[0].Value);
            double total1 = (ancho / medida1) * cantidad;
            tblAluminios.Rows[1].Cells[6].Value = total1.ToString("0.00");

            double medida2 = Convert.ToDouble(tblAluminios.Rows[2].Cells[0].Value);
            double total2 = ((alto * 2) / medida2) * cantidad;
            tblAluminios.Rows[2].Cells[6].Value = total2.ToString("0.00");

            double area = (ancho * alto) / 144;
            txtPies.Text = area.ToString("0.00");

            for (int i = 0; i < tblAluminios.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblAluminios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblAluminios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblAluminios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblAluminios.Rows[i].Cells[6].Value);

                tblAluminios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //comienza Hojas
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            double medida = Convert.ToDouble(tblHojas.Rows[0].Cells[0].Value);

            tblHojas.Rows[0].Cells[6].Value = (((alto * 4 + ancho * 2) / medida) * cantidad).ToString("0.00");
            tblHojas.Rows[1].Cells[6].Value = (2 * cantidad).ToString("0.00");
            tblHojas.Rows[2].Cells[6].Value = (4 * cantidad).ToString("0.00");
            tblHojas.Rows[3].Cells[6].Value = (((ancho * 2 + alto * 4) / 12) * cantidad).ToString("0.00");

            for (int i = 0; i < tblHojas.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblHojas.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblHojas.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblHojas.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblHojas.Rows[i].Cells[6].Value);

                tblHojas.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //comienza moldura
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            medida = Convert.ToDouble(tblMolduras.Rows[0].Cells[0].Value);

            tblMolduras.Rows[0].Cells[6].Value = cantidad.ToString("0.00");
            tblMolduras.Rows[1].Cells[6].Value = (cantidad * 4).ToString("0.00");
            // tblMolduras.Rows[2].Cells[6].Value = (cantidad * 4).ToString("0.00");
            // tblMolduras.Rows[3].Cells[6].Value = ((alto / 12) * cantidad).ToString("0.00");

            for (int i = 0; i < tblMolduras.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblMolduras.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblMolduras.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblMolduras.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblMolduras.Rows[i].Cells[6].Value);

                tblMolduras.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblMolduras.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblMolduras.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //comienza accesorio
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToDouble(txtCantidad.Text);
            medida = Convert.ToDouble(tblAccesorios.Rows[2].Cells[0].Value);

            tblAccesorios.Rows[0].Cells[6].Value = cantidad.ToString("0.00");
            tblAccesorios.Rows[1].Cells[6].Value = (cantidad * 4).ToString("0.00");
            tblAccesorios.Rows[2].Cells[6].Value = (cantidad * 4).ToString("0.00");

            for (int i = 0; i < tblAccesorios.RowCount; i++)
            {
                double precioN = Convert.ToDouble(tblAccesorios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble(tblAccesorios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble(tblAccesorios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble(tblAccesorios.Rows[i].Cells[6].Value);

                tblAccesorios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //calcular precios
            calcularPrecios();

        }
        private void cargarPbanio()
        {
            tipoTrabajo = 9;
            txtAlto.Text = "1";
            txtAncho.Text = "1";
            txtCantidad.Text = "1";
            txtAncho.Focus();
            cambiarColores(true, 9);
            reordenarColumnas();
            resetearCheckbox();
            string aluminios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=2 and pbanio=1";
            string hojas = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=3 and pbanio=1";
            string accesorios = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=1 and pbanio=1";
            string molduras = "select medida,tipo_presentacion,costonatural,costobronce,costomadera,descripcion, 0.00 as utilizado, 0.00 precion, 0.00 preciobr, 0.00 preciom from vwMaterialesCompleto where tipo=4 and pbanio=1";
            tblAluminios.AutoGenerateColumns = false;
            tblAluminios.DataSource = BD.LlenarTabla(aluminios);
            tblHojas.DataSource = BD.LlenarTabla(hojas);
            tblMolduras.DataSource = BD.LlenarTabla(molduras);
            tblAccesorios.DataSource = BD.LlenarTabla(accesorios);
            quitarSeleccion();
            calcularPbanio();
        }
        private void calcularPbanio()
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            double ancho = Convert.ToDouble(txtAncho.Text);
            double alto = Convert.ToDouble(txtAlto.Text);
            double medida = Convert.ToDouble("" + tblAluminios.Rows[0].Cells[0].Value);
            double total = ((ancho / 12) / medida) * cantidad;
            tblAluminios.Rows[0].Cells[6].Value = total.ToString("0.00");

            double medida1 = Convert.ToDouble("" + tblAluminios.Rows[1].Cells[0].Value);
            double total1 = ((ancho / 12) / medida1) * cantidad;
            tblAluminios.Rows[1].Cells[6].Value = total1.ToString("0.00");

            double medida2 = Convert.ToDouble("" + tblAluminios.Rows[2].Cells[0].Value);
            double total2 = (((alto * 2) / 12) / medida2) * cantidad;
            tblAluminios.Rows[2].Cells[6].Value = total2.ToString("0.00");

            double area = (ancho * alto) / 144;
            txtPies.Text = area.ToString("0.00");

            for (int i = 0; i < tblAluminios.Rows.Count; i++)
            {
                double precioN = Convert.ToDouble("" + tblAluminios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble("" + tblAluminios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble("" + tblAluminios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble("" + tblAluminios.Rows[i].Cells[6].Value);

                tblAluminios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAluminios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //comienza Hojas
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            medida = Convert.ToDouble("" + tblHojas.Rows[0].Cells[0].Value);
            medida1 = Convert.ToDouble("" + tblHojas.Rows[1].Cells[0].Value);
            medida2 = Convert.ToDouble("" + tblHojas.Rows[2].Cells[0].Value);

            double medida5 = Convert.ToDouble("" + tblHojas.Rows[5].Cells[0].Value);


            tblHojas.Rows[0].Cells[6].Value = ((((ancho * 2) + (alto * 4)) / 12) * cantidad).ToString("0.00");
            tblHojas.Rows[1].Cells[6].Value = (((ancho / 12) / medida1) * cantidad).ToString("0.00");
            tblHojas.Rows[2].Cells[6].Value = (((ancho / 12) / medida2) * cantidad).ToString("0.00");
            tblHojas.Rows[3].Cells[6].Value = (4 * cantidad).ToString("0.00");
            tblHojas.Rows[4].Cells[6].Value = (2 * cantidad).ToString("0.00");
            tblHojas.Rows[5].Cells[6].Value = ((((alto * 4) / 12) / medida5) * cantidad).ToString("0.00");


            for (int i = 0; i < tblHojas.Rows.Count; i++)
            {
                double precioN = Convert.ToDouble("" + tblHojas.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble("" + tblHojas.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble("" + tblHojas.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble("" + tblHojas.Rows[i].Cells[6].Value);

                tblHojas.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblHojas.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //comienza moldura
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            medida = Convert.ToDouble("" + tblMolduras.Rows[0].Cells[0].Value);

            tblMolduras.Rows[0].Cells[6].Value = (((ancho * 2) / 12) / medida).ToString("0.00");
            tblMolduras.Rows[1].Cells[6].Value = (cantidad * 4).ToString("0.00");

            for (int i = 0; i < tblMolduras.Rows.Count; i++)
            {
                double precioN = Convert.ToDouble("" + tblMolduras.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble("" + tblMolduras.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble("" + tblMolduras.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble("" + tblMolduras.Rows[i].Cells[6].Value);

                tblMolduras.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblMolduras.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblMolduras.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //comienza accesorio
            ancho = Convert.ToDouble(txtAncho.Text);
            alto = Convert.ToDouble(txtAlto.Text);
            area = Convert.ToDouble(txtPies.Text);
            cantidad = Convert.ToDouble(txtCantidad.Text);
            medida = Convert.ToDouble("" + tblAccesorios.Rows[2].Cells[0].Value);

            tblAccesorios.Rows[0].Cells[6].Value = cantidad.ToString("0.00");
            tblAccesorios.Rows[1].Cells[6].Value = (cantidad * 4).ToString("0.00");
            tblAccesorios.Rows[2].Cells[6].Value = (cantidad * 4).ToString("0.00");


            for (int i = 0; i < tblAccesorios.Rows.Count; i++)
            {
                double precioN = Convert.ToDouble("" + tblAccesorios.Rows[i].Cells[2].Value);
                double precioBR = Convert.ToDouble("" + tblAccesorios.Rows[i].Cells[3].Value);
                double precioM = Convert.ToDouble("" + tblAccesorios.Rows[i].Cells[4].Value);
                double usado = Convert.ToDouble("" + tblAccesorios.Rows[i].Cells[6].Value);

                tblAccesorios.Rows[i].Cells[7].Value = (precioN * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[8].Value = (precioBR * usado).ToString("0.00");
                tblAccesorios.Rows[i].Cells[9].Value = (precioM * usado).ToString("0.00");
            }
            //calcular precios
            calcularPrecios();
        }


        private void cambiarColores(bool activo, int tipo)
        {
            switch (tipo)
            {
                case 1: // Liviana Corrediza
                    btnLivianaCorrediza.BackColor = activo ?  TemaDeApp.BotonActivo: TemaDeApp.BotonInactivo;
                    btnFijaLiviana.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnGuillotina.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesadaDoble.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnSemiPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanioUsa.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanio.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnExtras.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnAbatible.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    break;
                case 2: // Fija Liviana
                    btnLivianaCorrediza.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaLiviana.BackColor = activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnGuillotina.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesadaDoble.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnSemiPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanioUsa.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanio.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnExtras.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnAbatible.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;

                    break;
                case 3: // Fija Pesada
                    btnLivianaCorrediza.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaLiviana.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaPesada.BackColor = activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnGuillotina.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesadaDoble.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnSemiPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanioUsa.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanio.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnExtras.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnAbatible.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    break;
                case 4: // Pesada
                    btnLivianaCorrediza.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaLiviana.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesada.BackColor = activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnGuillotina.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesadaDoble.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnSemiPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanioUsa.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanio.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnExtras.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnAbatible.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo; ;
                    break;
                case 5: // Guillotina
                    btnLivianaCorrediza.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaLiviana.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnGuillotina.BackColor = activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesadaDoble.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnSemiPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanioUsa.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanio.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnExtras.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnAbatible.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    break;
                case 6: // Pesada Doble
                    btnLivianaCorrediza.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaLiviana.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnGuillotina.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesadaDoble.BackColor = activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnSemiPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanioUsa.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanio.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnExtras.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnAbatible.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;

                    break;
                case 7: // Semi Pesada
                    btnLivianaCorrediza.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaLiviana.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnGuillotina.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesadaDoble.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnSemiPesada.BackColor = activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanioUsa.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanio.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnExtras.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnAbatible.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    break;
                case 8: // Baño Usa
                    btnLivianaCorrediza.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaLiviana.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnGuillotina.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesadaDoble.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnSemiPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanioUsa.BackColor = activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanio.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnExtras.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnAbatible.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    break;
                case 9: // Baño
                    btnLivianaCorrediza.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaLiviana.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnGuillotina.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesadaDoble.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnSemiPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanioUsa.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanio.BackColor = activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnExtras.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnAbatible.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    break;
                case 10:
                    // Extras
                    btnLivianaCorrediza.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaLiviana.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnGuillotina.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesadaDoble.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnSemiPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanioUsa.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanio.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnExtras.BackColor = activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnAbatible.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    break;
                case 11: // Abatible
                    btnLivianaCorrediza.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaLiviana.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnFijaPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnGuillotina.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnPesadaDoble.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnSemiPesada.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanioUsa.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnBanio.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnExtras.BackColor = !activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    btnAbatible.BackColor = activo ? TemaDeApp.BotonActivo : TemaDeApp.BotonInactivo;
                    break;
                case 12:

                default:
                    break;
            }

        }
        private void reordenarColumnas()
        {
            tblAluminios.Columns["medidaA"].DisplayIndex = 0;
            tblAluminios.Columns["tipo_presentacionA"].DisplayIndex = 1;
            tblAluminios.Columns["costonaturalA"].DisplayIndex = 2;
            tblAluminios.Columns["costobronceA"].DisplayIndex = 3;
            tblAluminios.Columns["costomaderaA"].DisplayIndex = 4;
            tblAluminios.Columns["descripcionA"].DisplayIndex = 5;
            tblAluminios.Columns["utilizadoA"].DisplayIndex = 6;
            tblAluminios.Columns["precionA"].DisplayIndex = 7;
            tblAluminios.Columns["preciobrA"].DisplayIndex = 8;
            tblAluminios.Columns["preciomA"].DisplayIndex = 9;

            tblHojas.Columns["medidaH"].DisplayIndex = 0;
            tblHojas.Columns["tipo_presentacionH"].DisplayIndex = 1;
            tblHojas.Columns["costonaturalH"].DisplayIndex = 2;
            tblHojas.Columns["costobronceH"].DisplayIndex = 3;
            tblHojas.Columns["costomaderaH"].DisplayIndex = 4;
            tblHojas.Columns["descripcionH"].DisplayIndex = 5;
            tblHojas.Columns["utilizadoH"].DisplayIndex = 6;
            tblHojas.Columns["precionH"].DisplayIndex = 7;
            tblHojas.Columns["preciobrH"].DisplayIndex = 8;
            tblHojas.Columns["preciomH"].DisplayIndex = 9;

            tblMolduras.Columns["medidaM"].DisplayIndex = 0;
            tblMolduras.Columns["tipo_presentacionM"].DisplayIndex = 1;
            tblMolduras.Columns["costonaturalM"].DisplayIndex = 2;
            tblMolduras.Columns["costobronceM"].DisplayIndex = 3;
            tblMolduras.Columns["costomaderaM"].DisplayIndex = 4;
            tblMolduras.Columns["descripcionM"].DisplayIndex = 5;
            tblMolduras.Columns["utilizadoM"].DisplayIndex = 6;
            tblMolduras.Columns["precionM"].DisplayIndex = 7;
            tblMolduras.Columns["preciobrM"].DisplayIndex = 8;
            tblMolduras.Columns["preciomM"].DisplayIndex = 9;

            tblAccesorios.Columns["medidaAc"].DisplayIndex = 0;
            tblAccesorios.Columns["tipo_presentacionAc"].DisplayIndex = 1;
            tblAccesorios.Columns["costonaturalAc"].DisplayIndex = 2;
            tblAccesorios.Columns["costobronceAc"].DisplayIndex = 3;
            tblAccesorios.Columns["costomaderaAc"].DisplayIndex = 4;
            tblAccesorios.Columns["descripcionAc"].DisplayIndex = 5;
            tblAccesorios.Columns["utilizadoAc"].DisplayIndex = 6;
            tblAccesorios.Columns["precionAc"].DisplayIndex = 7;
            tblAccesorios.Columns["preciobrAc"].DisplayIndex = 8;
            tblAccesorios.Columns["preciomAc"].DisplayIndex = 9;
        }
        private void calcularPrecios()
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            int filasaluminios = tblAluminios.RowCount;
            int filashojas = tblHojas.RowCount;
            int filasmolduras = tblMolduras.RowCount;
            int filasaccesorios = tblAccesorios.RowCount;
            double PN = 0, PBR = 0, PM = 0;
            for (int i = 0; i < filasaluminios; i++)
            {
                PN = PN + Convert.ToDouble("" + tblAluminios.Rows[i].Cells[7].Value);
                PBR = PBR + Convert.ToDouble("" + tblAluminios.Rows[i].Cells[8].Value);
                PM = PM + Convert.ToDouble("" + tblAluminios.Rows[i].Cells[9].Value);
            }
            for (int i = 0; i < filashojas; i++)
            {
                PN = PN + Convert.ToDouble("" + tblHojas.Rows[i].Cells[7].Value);
                PBR = PBR + Convert.ToDouble("" + tblHojas.Rows[i].Cells[8].Value);
                PM = PM + Convert.ToDouble("" + tblHojas.Rows[i].Cells[9].Value);
            }
            for (int i = 0; i < filasmolduras; i++)
            {
                PN = PN + Convert.ToDouble("" + tblMolduras.Rows[i].Cells[7].Value);
                PBR = PBR + Convert.ToDouble("" + tblMolduras.Rows[i].Cells[8].Value);
                PM = PM + Convert.ToDouble("" + tblMolduras.Rows[i].Cells[9].Value);
            }
            for (int i = 0; i < filasaccesorios; i++)
            {
                PN = PN + Convert.ToDouble("" + tblAccesorios.Rows[i].Cells[7].Value);
                PBR = PBR + Convert.ToDouble("" + tblAccesorios.Rows[i].Cells[8].Value);
                PM = PM + Convert.ToDouble("" + tblAccesorios.Rows[i].Cells[9].Value);
            }



            tblCostos.Rows[0].Cells[0].Value = ("Costo Natural");
            tblCostos.Rows[1].Cells[0].Value = ("Costo Bronce");
            tblCostos.Rows[2].Cells[0].Value = ("Costo Madera");
            tblCostos.Rows[0].Cells[1].Value = (PN).ToString("0.00");
            tblCostos.Rows[1].Cells[1].Value = (PBR).ToString("0.00");
            tblCostos.Rows[2].Cells[1].Value = (PM).ToString("0.00");


            tblVentas.Rows[0].Cells[0].Value = ("Venta Natural");
            tblVentas.Rows[1].Cells[0].Value = ("Venta Bronce");
            tblVentas.Rows[2].Cells[0].Value = ("Venta Madera");

            tblVentas.Rows[0].Cells[1].Value = (((PN) * 1.65)).ToString("0.00");
            tblVentas.Rows[1].Cells[1].Value = (((PBR) * 1.65)).ToString("0.00");
            tblVentas.Rows[2].Cells[1].Value = (((PM) * 1.65)).ToString("0.00");


            string porcen = "1." + txtPorcentaje.Text;
            double porcentaje = Convert.ToDouble(porcen);


            if (porcentaje != 0.00)
            {
                tblVentas.Rows[0].Cells[2].Value = (((PN) * porcentaje)).ToString("0.00");
                tblVentas.Rows[1].Cells[2].Value = (((PBR) * porcentaje)).ToString("0.00");
                tblVentas.Rows[2].Cells[2].Value = (((PM) * porcentaje)).ToString("0.00");
            }
            else
            {
                tblVentas.Rows[0].Cells[2].Value = (((PN) * 1.75)).ToString("0.00");
                tblVentas.Rows[1].Cells[2].Value = (((PBR) * 1.75)).ToString("0.00");
                tblVentas.Rows[2].Cells[2].Value = (((PM) * 1.75)).ToString("0.00");
            }
        }
        private string obtenerNombreTrabajo(int tipo)
        {
            string nombre = "";
            switch (tipo)
            {
                case 1:
                    nombre = "Ventana Liviana Corrediza";
                    break;
                case 2:
                    nombre = "Ventana Fija Liviana";
                    break;
                case 3:
                    nombre = "Ventana Fija Pesada";
                    break;
                case 4:
                    nombre = "Ventana Pesada";
                    break;
                case 5:
                    nombre = "Ventana Guillotina";
                    break;
                case 6:
                    nombre = "Puerta y Ventana Pesada Doble";
                    break;
                case 7:
                    nombre = "Puerta y Ventana Semi Pesada";
                    break;
                case 8:
                    nombre = "Puerta Baño Usa";
                    break;
                case 9:
                    nombre = "Puerta Baño";
                    break;
                case 10:
                    nombre = "Extras";
                    break;
                case 11:
                    nombre = "Puerta Abatible";
                    break;
                default:
                    nombre = "Trabajo Desconocido";
                    break;
            }
            return nombre;
        }
        private string obtenerColor(int color)
        {
            switch (color)
            {
                case 1:
                    return "Natural";
                case 2:
                    return "Bronce";
                case 3:
                    return "Madera";
                default:
                    return "No hay color";
            }
        }
        private double obtenerCosto(int color)
        {
            switch (color)
            {
                case 1:
                    return Convert.ToDouble(tblCostos.Rows[0].Cells[1].Value);
                case 2:
                    return Convert.ToDouble(tblCostos.Rows[1].Cells[1].Value);
                case 3:
                    return Convert.ToDouble(tblCostos.Rows[2].Cells[1].Value);
                default:
                    return 0.00;
            }
        }
        private void resetearCheckbox()
        {
            cbNatural165.Checked = false;
            cbBronce165.Checked = false;
            cbMadera165.Checked = false;
            cbNaturalP.Checked = false;
            cbBronceP.Checked = false;
            cbMaderaP.Checked = false;
            txtPrecio.Text = "0.00";

        }
        private DataGridView ClonarDataGridView(DataGridView original)
        {
            DataGridView copia = new DataGridView();
            copia.AllowUserToAddRows = false;

            foreach (DataGridViewColumn col in original.Columns)
            {
                copia.Columns.Add((DataGridViewColumn)col.Clone());
            }

            foreach (DataGridViewRow row in original.Rows)
            {
                if (!row.IsNewRow)
                {
                    int index = copia.Rows.Add();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        copia.Rows[index].Cells[i].Value = row.Cells[i].Value;
                    }
                }
            }

            return copia;
        }


        public TrabajosForm()
        {
            InitializeComponent();

            btnLivianaCorrediza.BackColor = Color.FromArgb(255, 255, 192);
            String[] fila1 = { "", "" };
            tblCostos.Rows.Add(fila1);
            tblCostos.Rows.Add(fila1);
            tblCostos.Rows.Add(fila1);
            tblVentas.Rows.Add(fila1);
            tblVentas.Rows.Add(fila1);
            tblVentas.Rows.Add(fila1);
            cargarLivianaCorrediza();
            btnLivianaCorrediza.Focus();
            txtAncho.Focus();
        }

        private void btnLivianaCorrediza_Click(object sender, EventArgs e)
        {
            try
            {
                cargarLivianaCorrediza();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSemiPesada_Click(object sender, EventArgs e)
        {
            try
            {
                cargarSemiPesada();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFijaLiviana_Click(object sender, EventArgs e)
        {
            try
            {
                cargarFijaLiviana();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnFijaPesada_Click(object sender, EventArgs e)
        {
            try
            {
                cargarFijaPesada();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuillotina_Click(object sender, EventArgs e)
        {
            try
            {
                cargarGuillotina();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPesada_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPesada();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPesadaDoble_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPesadaDoble();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAbatible_Click(object sender, EventArgs e)
        {
            try
            {
                cargarAbatible();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBanioUsa_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPbanioUsa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBanio_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPbanio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExtras_Click(object sender, EventArgs e)
        {
            try
            {
                cambiarColores(true, 10);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void txtAncho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtAlto.Focus();
            }
        }

        private void txtAlto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtCantidad.Focus();

            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtAncho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtAlto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAncho_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tipoTrabajo)
                {
                    case 1: // Liviana Corrediza
                        if (txtAncho.Text.Equals("")) { } else { calcularLivianaCorrediza(); }
                        break;
                    case 2: // Fija Liviana
                        if (txtAncho.Text.Equals("")) { } else { calcularFijaLiviana(); }
                        break;
                    case 3: // Fija Pesada
                        if (txtAncho.Text.Equals("")) { } else { calcularFijaPesada(); }
                        break;
                    case 4: // Pesada
                        if (txtAncho.Text.Equals("")) { } else { calcularPesada(); }
                        break;
                    case 5: // Guillotina
                        if (txtAncho.Text.Equals("")) { } else { calcularGuillotina(); }
                        break;
                    case 6: // Pesada Doble
                        if (txtAncho.Text.Equals("")) { } else { calcularPesadaDoble(); }
                        break;
                    case 7: // Semi Pesada
                        if (txtAncho.Text.Equals("")) { } else { calcularSemiPesada(); }
                        break;
                    case 8: // Baño Usa
                        if (txtAncho.Text.Equals("")) { } else { calcularPbanioUsa(); }
                        break;
                    case 9://banio
                        if (txtAncho.Text.Equals("")) { } else { calcularPbanio(); }
                        break;
                    case 10: // Extras
                        break;
                    case 11: // Abatible
                        if (txtAncho.Text.Equals("")) { } else { calcularAbatible(); }
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtAlto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tipoTrabajo)
                {
                    case 1: // Liviana Corrediza
                        if (txtAlto.Text.Equals("")) { } else { calcularLivianaCorrediza(); }
                        break;
                    case 2: // Fija Liviana
                        if (txtAlto.Text.Equals("")) { } else { calcularFijaLiviana(); }
                        break;
                    case 3: // Fija Pesada
                        if (txtAlto.Text.Equals("")) { } else { calcularFijaPesada(); }
                        break;
                    case 4: // Pesada
                        if (txtAlto.Text.Equals("")) { } else { calcularPesada(); }
                        break;
                    case 5: // Guillotina
                        if (txtAlto.Text.Equals("")) { } else { calcularGuillotina(); }
                        break;
                    case 6: // Pesada Doble
                        if (txtAlto.Text.Equals("")) { } else { calcularPesadaDoble(); }
                        break;
                    case 7: // Semi Pesada
                        if (txtAlto.Text.Equals("")) { } else { calcularSemiPesada(); }
                        break;
                    case 8: // Baño Usa
                        if (txtAlto.Text.Equals("")) { } else { calcularPbanioUsa(); }
                        break;
                    case 9://banio
                        if (txtAlto.Text.Equals("")) { } else { calcularPbanio(); }
                        break;
                    case 10: // Extras
                        break;
                    case 11: // Abatible
                        if (txtAlto.Text.Equals("")) { } else { calcularAbatible(); }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tipoTrabajo)
                {
                    case 1: // Liviana Corrediza
                        if (txtCantidad.Text.Equals("")) { } else { calcularLivianaCorrediza(); }
                        break;
                    case 2: // Fija Liviana
                        if (txtCantidad.Text.Equals("")) { } else { calcularFijaLiviana(); }
                        break;
                    case 3: // Fija Pesada
                        if (txtCantidad.Text.Equals("")) { } else { calcularFijaPesada(); }
                        break;
                    case 4: // Pesada
                        if (txtCantidad.Text.Equals("")) { } else { calcularPesada(); }
                        break;
                    case 5: // Guillotina
                        if (txtCantidad.Text.Equals("")) { } else { calcularGuillotina(); }
                        break;
                    case 6: // Pesada Doble
                        if (txtCantidad.Text.Equals("")) { } else { calcularPesadaDoble(); }
                        break;
                    case 7: // Semi Pesada
                        if (txtCantidad.Text.Equals("")) { } else { calcularSemiPesada(); }
                        break;
                    case 8: // Baño Usa
                        if (txtCantidad.Text.Equals("")) { } else { calcularPbanioUsa(); }
                        break;
                    case 9:// banio
                        if (txtCantidad.Text.Equals("")) { } else { calcularPbanio(); }
                        break;
                    case 10: // Extras
                        break;
                    case 11: // Abatible
                        if (txtCantidad.Text.Equals("")) { } else { calcularAbatible(); }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPorcentaje_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbNatural165_Click(object sender, EventArgs e)
        {
            colorSeleccionado = 1;
            cbNatural165.Checked = true;
            cbNaturalP.Checked = false;
            cbMaderaP.Checked = false;
            cbBronceP.Checked = false;
            cbBronce165.Checked = false;
            cbMadera165.Checked = false;
            txtPrecio.Text = Convert.ToDouble(tblVentas.Rows[0].Cells[1].Value).ToString("N2");
        }

        private void cbBronce165_Click(object sender, EventArgs e)
        {
            colorSeleccionado = 2;
            cbNatural165.Checked = false;
            cbBronce165.Checked = true;
            cbMadera165.Checked = false;
            cbNaturalP.Checked = false;
            cbMaderaP.Checked = false;
            cbBronceP.Checked = false;
            txtPrecio.Text = Convert.ToDouble(tblVentas.Rows[1].Cells[1].Value).ToString("N2");
        }

        private void cbMadera165_Click(object sender, EventArgs e)
        {
            colorSeleccionado = 3;
            cbNatural165.Checked = false;
            cbBronce165.Checked = false;
            cbMadera165.Checked = true;
            cbNaturalP.Checked = false;
            cbMaderaP.Checked = false;
            cbBronceP.Checked = false;
            txtPrecio.Text = Convert.ToDouble(tblVentas.Rows[2].Cells[1].Value).ToString("N2");
        }

        private void cbNaturalP_Click(object sender, EventArgs e)
        {
            colorSeleccionado = 1;
            cbNatural165.Checked = false;
            cbBronce165.Checked = false;
            cbMadera165.Checked = false;
            cbNaturalP.Checked = true;
            cbMaderaP.Checked = false;
            cbBronceP.Checked = false;
            txtPrecio.Text = Convert.ToDouble(tblVentas.Rows[0].Cells[2].Value).ToString("N2");
        }

        private void cbBronceP_Click(object sender, EventArgs e)
        {
            colorSeleccionado = 2;
            cbNatural165.Checked = false;
            cbBronce165.Checked = false;
            cbMadera165.Checked = false;
            cbNaturalP.Checked = false;
            cbMaderaP.Checked = false;
            cbBronceP.Checked = true;
            txtPrecio.Text = Convert.ToDouble(tblVentas.Rows[1].Cells[2].Value).ToString("N2");
        }

        private void cbMaderaP_Click(object sender, EventArgs e)
        {
            colorSeleccionado = 3;
            cbNatural165.Checked = false;
            cbBronce165.Checked = false;
            cbMadera165.Checked = false;
            cbNaturalP.Checked = false;
            cbMaderaP.Checked = true;
            cbBronceP.Checked = false;
            txtPrecio.Text = Convert.ToDouble(tblVentas.Rows[2].Cells[2].Value).ToString("N2");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NuevoTrabajo nuevoTrabajo = new NuevoTrabajo();
                nuevoTrabajo.Id = tipoTrabajo;
                nuevoTrabajo.Ancho = Convert.ToDouble(txtAncho.Text);
                nuevoTrabajo.Alto = Convert.ToDouble(txtAlto.Text);
                nuevoTrabajo.Cantidad = Convert.ToInt32(txtCantidad.Text);
                nuevoTrabajo.PrecioSeleccionado = Convert.ToDouble(txtPrecio.Text);
                nuevoTrabajo.Area = Convert.ToDouble(txtPies.Text);
                nuevoTrabajo.Nombre = obtenerNombreTrabajo(tipoTrabajo);
                nuevoTrabajo.ColorSeleccionado = obtenerColor(colorSeleccionado);
                nuevoTrabajo.Aluminio = ClonarDataGridView(tblAluminios);
                nuevoTrabajo.Hoja = ClonarDataGridView(tblHojas);
                nuevoTrabajo.Moldura = ClonarDataGridView(tblMolduras);
                nuevoTrabajo.Accesorio = ClonarDataGridView(tblAccesorios);
                nuevoTrabajo.CostoSeleccionado = obtenerCosto(colorSeleccionado);

                int contador = 0;
                foreach (var trabajo in trabajos)
                {
                    if (trabajo.Id == nuevoTrabajo.Id && trabajo.Ancho == nuevoTrabajo.Ancho && trabajo.Alto == nuevoTrabajo.Alto && trabajo.ColorSeleccionado == nuevoTrabajo.ColorSeleccionado)
                    {
                        contador = 1;
                        trabajo.agregarTrabajoExistente(nuevoTrabajo);
                        MessageBox.Show("Ya existe un trabajo de este tipo guardado, se cambiará la cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (contador == 0)
                {
                    trabajos.Add(nuevoTrabajo);
                    MessageBox.Show("Trabajo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                switch (tipoTrabajo)
                {
                    case 1: // Liviana Corrediza
                        cargarLivianaCorrediza();
                        break;
                    case 2: // Fija Liviana
                        cargarFijaLiviana();
                        break;
                    case 3: // Fija Pesada
                        cargarFijaPesada();
                        break;
                    case 4: // Pesada
                        cargarPesada();
                        break;
                    case 5: // Guillotina
                        cargarGuillotina();
                        break;
                    case 6: // Pesada Doble
                        cargarPesadaDoble();
                        break;
                    case 7: // Semi Pesada
                        cargarSemiPesada();
                        break;
                    case 8: // Baño Usa
                        cargarPbanioUsa();
                        break;
                    case 9://banio
                        cargarPbanio();
                        break;
                    case 10: // Extras
                        cambiarColores(true, 10);
                        break;
                    case 11: // Abatible
                        cargarAbatible();
                        break;
                    default:
                        MessageBox.Show("Tipo de trabajo desconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVerTrabajos_Click(object sender, EventArgs e)
        {
            var dialog = new ListaTrabajosDialog(trabajos);
            dialog.ShowDialog(this);
        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {
            var padre = this.MdiParent as MenuPrincipalForm;
            if (padre != null)
            {
                padre.AbrirFormularioCentrado<NuevaCotizacion>(this.usuario!, trabajos);
            }
        }

        public void InicializarUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        

    

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            var padre = this.MdiParent as MenuPrincipalForm;
            if (padre != null)
            {
                padre.AbrirFormularioCentrado<Facturar>(this.usuario!, trabajos);
            }
        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(temaActual);
            EstilosControles.AplicarEstiloFormulario(this);
        }

        private void cbNatural165_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcentaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                try
                {
                    switch (tipoTrabajo)
                    {
                        case 1: // Liviana Corrediza
                            if (txtPorcentaje.Text.Equals("")) { } else { calcularLivianaCorrediza(); }
                            break;
                        case 2: // Fija Liviana
                            if (txtPorcentaje.Text.Equals("")) { } else { calcularFijaLiviana(); }
                            break;
                        case 3: // Fija Pesada
                            if (txtPorcentaje.Text.Equals("")) { } else { calcularFijaPesada(); }
                            break;
                        case 4: // Pesada
                            if (txtPorcentaje.Text.Equals("")) { } else { calcularPesada(); }
                            break;
                        case 5: // Guillotina
                            if (txtPorcentaje.Text.Equals("")) { } else { calcularGuillotina(); }
                            break;
                        case 6: // Pesada Doble
                            if (txtPorcentaje.Text.Equals("")) { } else { calcularPesadaDoble(); }
                            break;
                        case 7: // Semi Pesada
                            if (txtPorcentaje.Text.Equals("")) { } else { calcularSemiPesada(); }
                            break;
                        case 8: // Baño Usa
                            if (txtPorcentaje.Text.Equals("")) { } else { calcularPbanioUsa(); }
                            break;
                        case 9://banio
                            if (txtPorcentaje.Text.Equals("")) { } else { calcularPbanio(); }
                            break;
                        case 10: // Extras
                            break;
                        case 11: // Abatible
                            if (txtPorcentaje.Text.Equals("")) { } else { calcularAbatible(); }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
