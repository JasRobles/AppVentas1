using sistemas_Ventas.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase2403.Vista
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        frmRoles rol = new frmRoles();
        private void rOLESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rol.CargarCombo();
            mdi(rol);
        }

        public static frmUsuarios usu = new frmUsuarios();
        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            mdi(usu);
            
        }

        frmDocumentos documento = new frmDocumentos();
        private void dOCUMENTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            mdi(documento);
        }
        public void mdi( Form frm)
        {
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.BringToFront();
            frm.Show();

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        frmClientes clientes = new frmClientes();
        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientes.cargarDatos();
            mdi(clientes);
        }

        frmProductos product = new frmProductos();
        private void pRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            product.cargarDatos();
            mdi(product);

        }
    }
}
