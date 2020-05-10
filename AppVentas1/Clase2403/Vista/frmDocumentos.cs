using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase2403.Model;

namespace sistemas_Ventas.Vista
{
    public partial class frmDocumentos : Form
    {
        public frmDocumentos()
        {
            InitializeComponent();
        }

        tb_documento doc = new tb_documento();
        DialogResult R;

        private void frmDocumentos_Load(object sender, EventArgs e)
        {
            cargarDatos();
            Desactivarbotones();
            btnGuardar.Enabled = false;

        }
        void Desactivarbotones()
        {
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            txtNombre.Enabled = false;
        }

        void activarBotones()
        {
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            txtNombre.Enabled = true;
        }

        public void cargarDatos()
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var lista = from doc in db.tb_documento
                            select new
                            {
                                ID = doc.iDDocumento,
                                DOCUMENTO = doc.nombreDocumento
                            };
                dgvDocumentos.DataSource = lista.ToList();
            }

        }
        public void limpiar()
        {
            txtNombre.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                doc.nombreDocumento = txtNombre.Text;
                db.tb_documento.Add(doc);
                db.SaveChanges();
                limpiar();
                btnGuardar.Enabled = false;
                cargarDatos();


            }
        }

        private void dgvDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombre = dgvDocumentos.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = nombre;
            activarBotones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            txtNombre.Enabled = true;
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                R = MessageBox.Show("Desea eliminar el registro", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (R == DialogResult.Yes)
                {
                    string id = dgvDocumentos.CurrentRow.Cells[0].Value.ToString();
                    int ID = int.Parse(id);
                    doc = db.tb_documento.Find(ID);
                    db.tb_documento.Remove(doc);
                    db.SaveChanges();
                    cargarDatos();
                    limpiar();
                    Desactivarbotones();
                }
                else
                {
                    limpiar();
                    Desactivarbotones();
                }
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                R = MessageBox.Show("Desea guardar los cambios", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (R == DialogResult.Yes)
                {
                    string id = dgvDocumentos.CurrentRow.Cells[0].Value.ToString();
                    int ID = int.Parse(id);
                    doc = db.tb_documento.Where(verificarID => verificarID.iDDocumento == (ID)).First();
                    doc.nombreDocumento = txtNombre.Text;
                    db.Entry(doc).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    limpiar();
                    Desactivarbotones();
                    cargarDatos();
                }
                else
                {
                    limpiar();
                    Desactivarbotones();
                }
            }
        }
    }
}