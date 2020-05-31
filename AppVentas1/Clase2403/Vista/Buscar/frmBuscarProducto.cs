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
using Clase2403.Vista;

namespace Clase2403.Vista.Buscar
{
    public partial class frmBuscarProducto : Form
    {
        public frmBuscarProducto()
        {
            InitializeComponent();

        }

        private void frmBuscarProducto_Load(object sender, EventArgs e)
        {
            filtro();
        }

        public void filtro()
        {
            dgvBuscarProd.Rows.Clear();
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {

                string Buscar = txtBuscarProd.Text;
                var producto = from prod in db.producto
                               where prod.nombreProducto.Contains(Buscar)
                               select new
                               {
                                   ID = prod.idProducto,
                                   producto = prod.nombreProducto,
                                   precio = prod.precioProducto,
                                   estado = prod.estadoProducto
                               };

                foreach (var iterar in producto)
                {
                    dgvBuscarProd.Rows.Add(iterar.ID, iterar.producto, iterar.precio, iterar.estado);
                }


            }

        }

        public void MostrarDatos()
        {

        }
        

        private void txtBuscarProd_TextChanged(object sender, EventArgs e)
        {
            filtro();

        }
        
       
        private void dgvBuscarProd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String ID = dgvBuscarProd.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dgvBuscarProd.CurrentRow.Cells[1].Value.ToString();
            String precio = dgvBuscarProd.CurrentRow.Cells[2].Value.ToString();

           
            frmMenu.V.txtID.Text = ID;
            frmMenu.V.txtProducto.Text = Nombre;
            frmMenu.V.txtPrecio.Text = precio;
            

            
        }
    }
}
