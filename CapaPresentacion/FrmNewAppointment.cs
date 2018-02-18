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
    public partial class FrmNewAppointment : Form
    {
        private static FrmNewAppointment _Instancia;

        public static FrmNewAppointment GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmNewAppointment();
            }
            return _Instancia;
        }

        public void setCustumer(string id, string nombre)
        {
            Console.WriteLine(id + nombre);
            this.txtId.Text = id;
            this.txtCliente.Text = nombre;
        }


        public FrmNewAppointment()
        {
            InitializeComponent();
            this.txtId.ReadOnly = true;
            this.txtCliente.ReadOnly = true;
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
            this.txtId.Text = String.Empty;
            this.txtCliente.Text = String.Empty;

        }

        private void FrmNewAppointment_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtId.Text == string.Empty || pickerDate.Text == String.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtId, "Ingrese un Nombre");
                    errorIcono.SetError(pickerDate, "Ingrese Apellidps");
                }
                else
                {

                    Console.WriteLine(Convert.ToString(this.pickerDate.Text));
                    rpta = NAppointment.Insert(Convert.ToString(this.pickerDate.Text),Convert.ToInt32(this.txtId.Text),this.txtComments.Text.Trim().ToUpper());
                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto de forma correcta el registro");
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmSelectedCustumer form = new FrmSelectedCustumer();
            form.add = true;
            form.ShowDialog();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.Hide();
        }

        private void FrmNewAppointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
