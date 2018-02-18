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
    public partial class FrmAppointment : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static FrmAppointment _Instancia;

        public static FrmAppointment GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmAppointment();
            }
            return _Instancia;
        }
        public FrmAppointment()
        {
            InitializeComponent();
        }
        //mostrar el mensaje de confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Despacho Valles", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //mostrar el mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Despacho Valles", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //limpiar todos los controles del formularios
        private void Limpiar()
        {
            this.txtCliente.Text = String.Empty;
            this.pickerDate.Text = DateTime.Today.ToString();
            this.txtComments.Text = String.Empty;
            this.txtIdCliente.Text = String.Empty;

            

        }

        //habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdCliente.ReadOnly = true;
            this.txtCliente.ReadOnly = true;
            this.txtId.ReadOnly = true;
            this.txtComments.ReadOnly = !valor;
        }
        //habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnSave.Enabled = true;
                this.btnEdit.Enabled = false;
                this.BtnCancel.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnSave.Enabled = false;
                this.btnEdit.Enabled = true;
                this.BtnCancel.Enabled = false;
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
            this.dataListado.DataSource = NAppointment.SearchDate(DateTime.Today.ToString());
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        //metodo buscar por fecha
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NAppointment.SearchDate(Convert.ToString(this.pickerSearch.Text));
           this.OcultarColumnas();
            lbltotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void FrmAppointment_Load(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdCliente.Text == string.Empty || pickerDate.Text == String.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(this.btnSearch, "Ingrese un Nombre");
                    errorIcono.SetError(this.pickerDate, "Ingrese Apellidps");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NAppointment.Insert(Convert.ToString(this.pickerDate.Text), Convert.ToInt32(this.txtIdCliente.Text), this.txtComments.Text.Trim().ToUpper());
                    }
                    else
                    {
                        rpta = NAppointment.update(Convert.ToInt32(this.txtId.Text),Convert.ToString(this.pickerDate.Text), Convert.ToInt32(this.txtIdCliente.Text), this.txtComments.Text.Trim().ToUpper());
                      
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

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (!this.txtIdCliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.IsNuevo = false;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("debe de seleccionar primero el registro a modificar");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.tabControl1.SelectedIndex = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea eliminar registros", "Despacho Valles", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NAppointment.Delete(Convert.ToInt32(Codigo));

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
            this.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["custumer_id"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NombreCliente"].Value);
            this.txtComments.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["comments"].Value);
            this.pickerDate.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["date_appountment"].Value);           
            this.tabControl1.SelectedIndex = 1;
        }

        private void FrmAppointment_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FrmAppointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FrmSelectedCustumer form = new FrmSelectedCustumer();
            form.update = true;
            form.ShowDialog();
        }

        public void setCustumer(string id, string nombre)
        {
            Console.WriteLine(id + nombre);
            this.txtIdCliente.Text = id;
            this.txtCliente.Text = nombre;
        }
    }
}
