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
    public partial class FrmNewCustumer : Form
    {
        public FrmNewCustumer()
        {
            InitializeComponent();
            this.LlenarComboTypeCustumer();
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
            this.txtName.Text = String.Empty;
            this.txtLastname.Text = String.Empty;
            this.txtPhone.Text = String.Empty;
            this.txtMovil.Text = String.Empty;
            this.txtEmail.Text = String.Empty;
            this.txtComments.Text = String.Empty;           
        }



        private void FrmNewCustumer_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
           
        }

        private void LlenarComboTypeCustumer()
        {
            cbTypeCustumer.DataSource = NTypeCustumer.Show();
            cbTypeCustumer.ValueMember = "id";
            cbTypeCustumer.DisplayMember = "name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtName.Text == string.Empty || txtLastname.Text == String.Empty )
                {
                    MensajeError("Falta Ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtName, "Ingrese un Nombre");
                    errorIcono.SetError(txtLastname, "Ingrese Apellidps");
                }
                else
                {
                        rpta = Ncustumer.Insert(this.txtName.Text.Trim().ToUpper(),this.txtLastname.Text.Trim().ToUpper(),this.txtPhone.Text.Trim(),
                                                    this.txtMovil.Text.Trim(),this.txtEmail.Text.Trim().ToUpper(),this.txtComments.Text.Trim().ToUpper(),
                                                     Convert.ToInt32(this.cbTypeCustumer.SelectedValue)); 
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
