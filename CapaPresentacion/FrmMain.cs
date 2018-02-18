using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmMain : Form
    {
        private int childFormNumber = 0;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


      

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {

        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void windowsMenu_Click(object sender, EventArgs e)
        {
            FrmNewCaseFIle frm = new FrmNewCaseFIle();
            frm.MdiParent = this;
            frm.Show();
        }

        private void estadosDeProcesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStatusCaseFile frm = new FrmStatusCaseFile();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reporteDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tiposDeExpedientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTypeCaseFile frm = new FrmTypeCaseFile();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTypeCustumer frm = new FrmTypeCustumer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTypePayment frm = new FrmTypePayment();
            frm.MdiParent = this;
            frm.Show();
        }

        private void abogadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAttorney frm = new FrmAttorney();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewCustumer frm = new FrmNewCustumer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditCustumer frm = new FrmEditCustumer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void agendarCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewAppointment frm = FrmNewAppointment.GetInstancia();
                frm.MdiParent = this;
                frm.Show();
            
            

            
        }

        private void listadoDeCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAppointment frm = FrmAppointment.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nuevoExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
    }
}
