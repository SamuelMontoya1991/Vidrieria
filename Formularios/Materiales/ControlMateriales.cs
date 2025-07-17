using System;
using System.Data;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Materiales
{
    public partial class ControlMateriales : Form, IFormularioConTema
    {
        ConexionDB BD = new ConexionDB();
        ModeloMaterial Material = new ModeloMaterial();
        Tema temaActual;


        private void llenarTablaMateriales(int index)
        {
            DataTable table = new DataTable();
            switch (index)
            {
                case 1:
                    table = BD.LlenarTabla("SELECT id_accesorio,Descripcion,costonatural,costobronce,costomadera,estado,medida,tipo_presentacion,Arcos,VLivianaCorr,Vsemipesada,Vfijapesada,Vfijaliviana,guillotina,PVpesada,PVpesadadoble,Pabatible,PbanioUSA,Pbanio,Vitrina,extras FROM Sis_Accesorios");
                    break;
                case 2:
                    table = BD.LlenarTabla("SELECT * FROM Sis_aluminios");
                    break;
                case 3:
                    table = BD.LlenarTabla("SELECT * FROM sis_hojas");
                    break;
                case 4:
                    table = BD.LlenarTabla("SELECT * FROM sis_molduras");
                    break;
                default:
                    break;
            }
            tblMateriales.DataSource = table;

        }
        public void recibirProducto(ModeloMaterial material)
        {
            txtDescripcion.Text = material.descripcion;
            txtNatural.Text = material.natural.ToString();
            txtBronce.Text = material.bronce.ToString();
            txtMadera.Text = material.madera.ToString();
            //txtMedida.Text=("" + medida);
            cmbPresentacion.SelectedIndex = material.tipo;
            this.Material = material;

            if (material.arco == 1)
            {
                cbArcos.Checked = true;
            }
            if (material.livianacorrediza == 1)
            {
                cbLivianaCorrediza.Checked = true;
            }
            if (material.semipesada == 1)
            {
                cbVentanaSemi.Checked = true;
            }
            if (material.fijapesada == 1)
            {
                cbVentanaPesada.Checked = (true);
            }
            if (material.fijaliviana == 1)
            {
                cbVentanaLiviana.Checked = (true);
            }
            if (material.guillotina == 1)
            {
                cbGuillotina.Checked = (true);
            }
            if (material.pvpesada == 1)
            {
                cbPVPesada.Checked = (true);
            }
            if (material.pvpesadadoble == 1)
            {
                cbPVPdoble.Checked = (true);
            }
            if (material.pabatible == 1)
            {
                cbPabatible.Checked = (true);
            }
            if (material.pbaniousa == 1)
            {
                cbPuertaUSA.Checked = (true);
            }
            if (material.pbanio == 1)
            {
                cbPuertabanio.Checked = (true);
            }
            if (material.vitrina == 1)
            {
                cbVitrina.Checked = (true);
            }
        }

        private bool validarCampos()
        {
            return !string.IsNullOrEmpty(txtDescripcion.Text) ||
                !string.IsNullOrEmpty(txtNatural.Text) ||
                !string.IsNullOrEmpty(txtBronce.Text) ||
                !string.IsNullOrEmpty(txtMadera.Text);
        }
        private void obtenerValoresCampos()
        {
            this.Material.descripcion = txtDescripcion.Text;
            this.Material.natural = Convert.ToDouble(txtNatural.Text);
            this.Material.bronce = Convert.ToDouble(txtBronce.Text);
            this.Material.madera = Convert.ToDouble(txtMadera.Text);
            this.Material.tipo = cmbPresentacion.SelectedIndex + 1;

            //this.Material.medida = txtMedida.Text;
        }
        private void limpiarCampos()
        {
            txtDescripcion.Clear();
            txtNatural.Clear();
            txtBronce.Clear();
            txtMadera.Clear();
            if (cmbPresentacion.Items.Count > 0)
            {
                cmbPresentacion.SelectedIndex = 0;
            }
            cbArcos.Checked = (false);
            cbGuillotina.Checked = (false);
            cbPVPdoble.Checked = (false);
            cbPVPesada.Checked = (false);
            cbPabatible.Checked = (false);
            cbPuertaUSA.Checked = (false);
            cbPuertabanio.Checked = (false);
            cbVentanaLiviana.Checked = (false);
            cbLivianaCorrediza.Checked = (false);
            cbVentanaPesada.Checked = (false);
            cbVentanaSemi.Checked = (false);
            cbVitrina.Checked = (false);
        }
        private void Guardar()
        {
            string tabla = string.Empty;
            string id = string.Empty;
            switch (cmbMateriales.SelectedIndex)
            {
                case 1:
                    tabla = "sis_accesorios";
                    id = "id_accesorio";
                    break;
                case 2:
                    tabla = "sis_aluminios";
                    id = "id_aluminio";
                    break;
                case 3:
                    tabla = "sis_hojas";
                    id = "id_hoja";
                    break;
                case 4:
                    tabla = "sis_molduras";
                    id = "id_moldura";
                    break;
            }
            if (validarCampos())
            {
                obtenerValoresCampos();
                bool exito = BD.ActualizarMaterial(Material, tabla, id);
                MessageBox.Show(exito ? "Material actualizado correctamente." : "Error al actualizar el material.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (exito)
                {
                    limpiarCampos();
                    llenarTablaMateriales(cmbMateriales.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }





        public ControlMateriales()
        {
            InitializeComponent();
            cmbMateriales.SelectedIndex = 0;
            cmbPresentacion.DataSource = BD.llenarCombobox("select descripcion from sis_presentacion", "-Seleccione una presentacion-");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMateriales_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarCampos();
            llenarTablaMateriales(cmbMateriales.SelectedIndex);
            this.Material.tipo = cmbMateriales.SelectedIndex + 1;
        }

        private void tblMateriales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = tblMateriales.CurrentRow.Cells[20].Value != DBNull.Value
                ? Convert.ToInt32(tblMateriales.CurrentRow.Cells[20].Value.ToString())
                : 2;

            ModeloMaterial material = new ModeloMaterial(
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[0].Value),
            tblMateriales.CurrentRow.Cells[1].Value.ToString(),
            Convert.ToDouble(tblMateriales.CurrentRow.Cells[2].Value.ToString()),
            Convert.ToDouble(tblMateriales.CurrentRow.Cells[3].Value.ToString()),
            Convert.ToDouble(tblMateriales.CurrentRow.Cells[4].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[8].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[9].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[10].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[11].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[12].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[13].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[14].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[15].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[16].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[17].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[18].Value.ToString()),
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[19].Value.ToString()),
            valor,
            Convert.ToInt32(tblMateriales.CurrentRow.Cells[7].Value)
            );

            recibirProducto(material);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void cbArcos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbArcos.Checked)
            {
                this.Material.arco = 1;
            }
            else
            {
                this.Material.arco = 0;
            }
        }

        private void cbLivianaCorrediza_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLivianaCorrediza.Checked)
            {
                this.Material.livianacorrediza = 1;
            }
            else
            {
                this.Material.livianacorrediza = 0;
            }
        }

        private void cbGuillotina_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGuillotina.Checked)
            {
                this.Material.guillotina = 1;
            }
            else
            {
                this.Material.guillotina = 0;
            }
        }

        private void cbVentanaPesada_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVentanaPesada.Checked)
            {
                this.Material.fijapesada = 1;
            }
            else
            {
                this.Material.fijapesada = 0;
            }
        }

        private void cbVentanaSemi_CheckedChanged(object sender, EventArgs e)
        {

            if (cbVentanaSemi.Checked)
            {
                this.Material.semipesada = 1;
            }
            else
            {
                this.Material.semipesada = 0;
            }
        }

        private void cbPuertabanio_CheckedChanged(object sender, EventArgs e)
        {

            if (cbPuertabanio.Checked)
            {
                this.Material.pbanio = 1;
            }
            else
            {
                this.Material.pbanio = 0;
            }
        }

        private void cbVentanaLiviana_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVentanaLiviana.Checked)
            {
                this.Material.fijaliviana = 1;
            }
            else
            {
                this.Material.fijaliviana = 0;
            }
        }

        private void cbPVPdoble_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPVPdoble.Checked)
            {
                this.Material.pvpesadadoble = 1;
            }
            else
            {
                this.Material.pvpesadadoble = 0;
            }
        }

        private void cbPuertaUSA_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPuertaUSA.Checked)
            {
                this.Material.pbaniousa = 1;
            }
            else
            {
                this.Material.pbaniousa = 0;
            }
        }

        private void cbPVPesada_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPVPesada.Checked)
            {
                this.Material.pvpesada = 1;
            }
            else
            {
                this.Material.pvpesada = 0;
            }
        }

        private void cbPabatible_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPabatible.Checked)
            {
                this.Material.pabatible = 1;
            }
            else
            {
                this.Material.pabatible = 0;
            }
        }

        private void cbVitrina_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVitrina.Checked)
            {
                this.Material.vitrina = 1;
            }
            else
            {
                this.Material.vitrina = 0;
            }
        }

        private void cmbPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(tema);
            EstilosControles.AplicarEstiloFormulario(this);
        }
    }
}
