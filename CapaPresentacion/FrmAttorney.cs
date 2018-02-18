using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmAttorney : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmAttorney()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Abogado");
        }
        //mostrar el mensaje de confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //mostrar el mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //limpiar todos los controles del formularios
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtId.Text = string.Empty;
            this.txtLastname.Text = string.Empty;
            this.txtRfc.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtCedula.Text = string.Empty;

        }

        //habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtId.ReadOnly = true;
            this.txtLastname.ReadOnly = !valor;
            this.txtRfc.ReadOnly = !valor;
            this.txtAddress.ReadOnly = !valor;
            this.txtCedula.ReadOnly = !valor;

        }

        //habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        //metodo mostrar
        private void Mostar()
        {
            this.dataListado.DataSource = NAttorney.Show();
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //metodo buscar por el nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NAttorney.TextSearch(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmAttorney_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostar();
            this.Habilitar(false);
            this.Botones();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NAttorney.Insert(this.txtNombre.Text.Trim().ToUpper(),this.txtLastname.Text.Trim().ToUpper(),this.txtRfc.Text.Trim().ToUpper(),this.txtAddress.Text.Trim().ToUpper(),this.txtCedula.Text.Trim().ToUpper());
                    }
                    else
                    {
                        rpta = NAttorney.update(Convert.ToInt32(this.txtId.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtLastname.Text.Trim().ToUpper(), this.txtRfc.Text.Trim().ToUpper(), this.txtAddress.Text.Trim().ToUpper(), this.txtCedula.Text.Trim().ToUpper());
                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se actualizo de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (!this.txtId.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("debe de seleccionar primero el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea eliminar registros", "Sistema de VEntas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NAttorney.Delete(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("se elimino correctamete el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtId.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["name"].Value);
            this.txtLastname.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["lastname"].Value);
            this.txtRfc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["rfc"].Value);
            this.txtCedula.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cedula"].Value);
            this.txtAddress.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["address"].Value);
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
