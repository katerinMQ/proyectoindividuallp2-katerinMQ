using SistemaDesktop_KaterinMerino.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDesktop_KaterinMerino.Presentacion
{
    public partial class FrmSemestre : Form
    {
        private string NombreAnterior;

        public FrmSemestre()
        {
            InitializeComponent();
            txtCodigo.Enabled = false;
        }
        

        //metodo Limpiar
        private void Limpiar()
        {
            txtBuscar.Text = "";
            txtCodigo.Clear();
            txtNombre.Clear();
            txtEstado.Clear();
            txtAño.Clear();
            errorAlerta.Clear();

        }
        //metodo visualizar
        private void Visualizar()
        {
            btnInsertar.Visible = true;
            btnActualizar.Visible = true;
            btnEliminar.Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            dgvGrilla.Columns[0].Visible = false;
        }

        //Metodo Mensaje Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Modelo" + MessageBoxButtons.OK +MessageBoxIcon.Error);
        }

        //Metodo Mensaje Correcto
        private void MensajeCorrecto(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Modelo" + MessageBoxButtons.OK + MessageBoxIcon.Information);
        }

        //Metodo Listar
        private void Listar()
        {
            try
            {
                dgvGrilla.DataSource = SemestreNegocio.Listar();
                this.Formatear();
                this.Limpiar();
                this.Visualizar();
                lblCantidad.Text = "Total de Registros: " + Convert.ToString(dgvGrilla.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Metodo Formatear
        private void Formatear()
        {
            dgvGrilla.Columns[0].Visible = false; //columna seleccionar
            dgvGrilla.Columns[1].Width = 80; //Id
            dgvGrilla.Columns[2].Width = 200; //Semestre
            dgvGrilla.Columns[3].Width = 100; //Año
            dgvGrilla.Columns[4].Width = 100; //Estado

            dgvGrilla.Columns[1].HeaderText = "Codigo";
            dgvGrilla.Columns[2].HeaderText = "Semestre";
            dgvGrilla.Columns[3].HeaderText = "Año"; 
            dgvGrilla.Columns[4].HeaderText = "Estado"; 

        }

        //metodo Buscar
        private void Buscar()
        {
            try
            {
                string buscar = "";
                buscar = txtBuscar.Text;
                dgvGrilla.DataSource = SemestreNegocio.Buscar(buscar);
                this.Formatear();
                lblCantidad.Text = "Total de registros: " + Convert.ToString(dgvGrilla.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmSemestre_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                string nombre = txtNombre.Text;

                if (txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Faltan ingresar algunos datos en los campos....");
                    errorAlerta.SetError(txtNombre, "Ingrese Semestre"); //error provider
                }
                else
                {
                    Rpta = SemestreNegocio.Insertar(txtNombre.Text.Trim(), int.Parse(txtAño.Text.Trim()), txtEstado.Text.Trim());
                    if (Rpta.Equals("Ok"))
                    {
                        this.MensajeCorrecto("Se grabo el registro en la BD correctamente.....");
                        this.Limpiar();
                        this.Visualizar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.Visualizar();
            tabGeneral.SelectedIndex = 0; //Listado 0 - formulario mantenimiento
        }
        private void dgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                this.Visualizar();
                btnBuscar.Visible = true;
                btnInsertar.Visible = false;
                txtCodigo.Text = Convert.ToString(dgvGrilla.CurrentRow.Cells["semestre_id"].Value);
                txtNombre.Text = Convert.ToString(dgvGrilla.CurrentRow.Cells["nombre"].Value);
                txtAño.Text = Convert.ToString(dgvGrilla.CurrentRow.Cells["anio"].Value);
                txtEstado.Text = Convert.ToString(dgvGrilla.CurrentRow.Cells["estado"].Value);

                tabGeneral.SelectedIndex = 1; //Tab Mantenimiento

            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar el campo nombre...");
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                string nombre = txtNombre.Text;

                if (txtNombre.Text == string.Empty || txtCodigo.Text == string.Empty)
                {
                    this.MensajeError("Faltan ingresar algunos datos en los campos....");
                    errorAlerta.SetError(txtNombre, "Ingrese Semestre"); //error provider
                }
                else
                {
                    Rpta = SemestreNegocio.Actualizar(Convert.ToInt32(txtCodigo.Text), this.NombreAnterior,txtNombre.Text.Trim(), int.Parse(txtAño.Text.Trim()),txtEstado.Text.Trim());
                    if (Rpta.Equals("Ok"))
                    {
                        this.MensajeCorrecto("Se Actualizo el registro en la BD correctamente.....");
                        this.Limpiar();
                        this.Visualizar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvGrilla.Columns[0].Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;
            }
            else
            {
                dgvGrilla.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;
            }
        }
        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvGrilla.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvGrilla.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Esta Seguro de elimar el (los) registro(s) selecionado(s)?....", "Eliminar Registro(s)", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dgvGrilla.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[1].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = SemestreNegocio.Eliminar(codigo);
                            if (Rpta == "OK")
                            {
                                this.MensajeCorrecto("Se elimina el los registro(s) correctamente..." + Convert.ToString(row.Cells[1].Value));
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }





        //No valen lo de aqui abajo, si lo borro me falla el formulario
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAño_TextChanged(object sender, EventArgs e)
        {

        }

        private void chbSeleccionar_CheckedChanged(object sender, EventArgs e)
        {

        }

        
    }
}
