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
    public partial class FrmSelectedCustumer : Form
    {
        public Boolean add = false;
        public Boolean update = false;
        public FrmSelectedCustumer()
        {
            InitializeComponent();
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
            this.lbltotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //metodo buscar por el nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = Ncustumer.TextSearch(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmSelectedCustumer_Load(object sender, EventArgs e)
        {
            this.Mostar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (add)
            {
                FrmNewAppointment form = FrmNewAppointment.GetInstancia();
                string par1, par2;
                par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
                par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["name"].Value);
                form.setCustumer(par1, par2);
                this.Hide();
            }
            else
            {
                FrmAppointment form = FrmAppointment.GetInstancia();
                string par1, par2;
                par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
                par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["name"].Value);
                form.setCustumer(par1, par2);
                this.Hide();
            }
            this.add = false;
            this.update = false;

          
        }
    }
}
