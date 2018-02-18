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
    public partial class FrmEditCustumer : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmEditCustumer()
        {
            InitializeComponent();
            this.LlenarComboTypeCustumer();
            this.ttMensaje.SetToolTip(this.txtName, "Ingrese el Nombre del Abogado");
        }
        private void LlenarComboTypeCustumer()
        {
            cbTypeCustumer.DataSource = NTypeCustumer.Show();
            cbTypeCustumer.ValueMember = "id";
            cbTypeCustumer.DisplayMember = "name";
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
            this.txtId.Text = String.Empty;
            this.txtName.Text = String.Empty;
            this.txtLastname.Text = String.Empty;
            this.txtPhone.Text = String.Empty;
            this.txtMovil.Text = String.Empty;
            this.txtEmail.Text = String.Empty;
            this.txtComments.Text = String.Empty;

        }
        //habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtId.ReadOnly = true;
            this.txtName.ReadOnly = !valor;
            this.txtLastname.ReadOnly = !valor;
            this.txtPhone.ReadOnly = !valor;
            this.txtMovil.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
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
            this.dataListado.DataSource = Ncustumer.Show();
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //metodo buscar por el nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = Ncustumer.TextSearch(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void FrmEditCustumer_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostar();
            this.Habilitar(false);
            this.Botones();
        }

        private void cbTypeCustumer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtMovil_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

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
                if (this.txtName.Text == string.Empty || txtLastname.Text == String.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtName, "Ingrese un Nombre");
                    errorIcono.SetError(txtLastname, "Ingrese Apellidps");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = Ncustumer.Insert(this.txtName.Text.Trim().ToUpper(), this.txtLastname.Text.Trim().ToUpper(), this.txtPhone.Text.Trim(),
                                                    this.txtMovil.Text.Trim(), this.txtEmail.Text.Trim().ToUpper(), this.txtComments.Text.Trim().ToUpper(),
                                                     Convert.ToInt32(this.cbTypeCustumer.SelectedValue));
                    }
                    else
                    {
                        rpta = Ncustumer.update(Convert.ToInt32(this.txtId.Text),this.txtName.Text.Trim().ToUpper(), this.txtLastname.Text.Trim().ToUpper(), this.txtPhone.Text.Trim(),
                                                    this.txtMovil.Text.Trim(), this.txtEmail.Text.Trim().ToUpper(), this.txtComments.Text.Trim().ToUpper(),
                                                     Convert.ToInt32(this.cbTypeCustumer.SelectedValue));
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
                            Rpta = Ncustumer.Delete(Convert.ToInt32(Codigo));

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
            this.txtName.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["name"].Value);
            this.txtLastname.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["lastnmae"].Value);
            this.txtPhone.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["phone"].Value);
            this.txtMovil.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["movil"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.txtComments.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["comments"].Value);
            this.cbTypeCustumer.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["type_custumer_id"].Value);
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
