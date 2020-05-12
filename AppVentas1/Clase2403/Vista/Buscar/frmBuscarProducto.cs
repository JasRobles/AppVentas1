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
    }
}
