using Clase2403.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase2403.Vista.Buscar;


namespace Clase2403.Vista
{
    public partial class frmVentas : Form
    {
        string IdCliente;
        string idDoc;
        public frmVentas()
        {
            InitializeComponent();
            CargarCombos();
            retornoid();
        }

        public void CargarCombos()
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {

                var Clientes = db.tb_cliente.ToList();
                cmbCliente.DataSource = Clientes;
                cmbCliente.ValueMember = "iDCliente";
                cmbCliente.DisplayMember = "nombreCliente";

                var doc = db.tb_documento.ToList();
                cmbDoc.DataSource = doc;
                cmbDoc.ValueMember = "iDDocumento";
                cmbDoc.DisplayMember = "nombreDocumento";
                cmbCliente.SelectedIndex = 0;
                cmbDoc.SelectedIndex = 0;

            }
        }
       
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdCliente = cmbCliente.SelectedValue.ToString();
        }

        private void cmbDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            idDoc = cmbDoc.SelectedValue.ToString();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {

        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarProducto B = new frmBuscarProducto();
            B.ShowDialog();
        }

        void retornoid()
        {
            using(sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var v = db.tb_venta;

                foreach (var iterardatosventa in v)
                {
                    txtID.Text = iterardatosventa.idVenta.ToString();

                }
            }
        }
        
        public void Calculo()
        {


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Double precio;
            Double cantidad;
            Double total;

            precio = Double.Parse(txtPrecio.Text);
            cantidad = Convert.ToDouble(txtCantidad.Text);
            total = precio * cantidad;
            txtTotal.Text = total.ToString();

            dgvVenta.Rows.Add(txtID.Text, txtProducto.Text, txtPrecio.Text, txtCantidad.Text, txtTotal.Text);

        }
        
        private void dgvVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
