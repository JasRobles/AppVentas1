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
    public partial class frmRoles : Form
    {
        string usuariocombo = "";
        Roles_Usuarios rol = new Roles_Usuarios();
        DialogResult R;
        public frmRoles()
        {
            InitializeComponent();
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            CargarCombo();
            CargarDatos();
            desactivareditar();



        }
        public void CargarDatos()
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                dgvRoles.Rows.Clear();
                var jointablas = from tbU in db.tb_usuarios
                                 from tbR in db.Roles_Usuarios
                                 where tbU.Id == tbR.Id_Usuario
                                 select new
                                 {
                                     Id = tbR.Id_Rol_Usuario,
                                     Email = tbU.Email,
                                     Rol = tbR.Tipo_Rol,
                                     IDU = tbR.Id_Usuario
                                 };
                foreach (var lis in jointablas)
                {
                    dgvRoles.Rows.Add(lis.Id, lis.Email, lis.Rol, lis.IDU);
                }
            }
        }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuariocombo = cmbUsuario.SelectedValue.ToString();

        }
        public void CargarCombo()
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var lista = db.tb_usuarios.ToList();

                cmbUsuario.DataSource = lista;
                cmbUsuario.DisplayMember = "Email";
                cmbUsuario.ValueMember = "Id";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                int usu = int.Parse(usuariocombo);
                rol.Id_Usuario = usu;
                rol.Tipo_Rol = txtRolUsuario.Text;
                db.Roles_Usuarios.Add(rol);
                db.SaveChanges();
                CargarDatos();
                txtRolUsuario.Text = "";
                cmbUsuario.Enabled = false;
            }
        }
        public void ActivarBotones()
        {
            cmbUsuario.Enabled = true;
            txtRolUsuario.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }
        public void desactivareditar()
        {
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;

            cmbUsuario.Enabled = false;
            txtRolUsuario.Enabled = false;

        }
        public void ActivarTextbox()
        {
            cmbUsuario.Enabled = true;
            txtRolUsuario.Enabled = true;

        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            txtRolUsuario.Text = "";
            desactivareditar();
            ActivarTextbox();
            btnGuardar.Enabled = true;
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                R = MessageBox.Show("¿Desea guardar los cambios?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (R == DialogResult.Yes)
                {
                    string id = dgvRoles.CurrentRow.Cells[0].Value.ToString();
                    int ID = int.Parse(id);
                    rol = db.Roles_Usuarios.Where(VerificarID => VerificarID.Id_Rol_Usuario == ID).First();
                    rol.Id_Usuario = int.Parse(usuariocombo);
                    rol.Tipo_Rol= txtRolUsuario.Text;
                    db.Entry(rol).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    CargarDatos();
                    desactivareditar();
                    txtRolUsuario.Text = "";
                    btnGuardar.Enabled = false;
                }
                else
                {
                    CargarDatos();
                    desactivareditar();
                    txtRolUsuario.Text = "";
                    btnGuardar.Enabled = false;

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                R = MessageBox.Show("¿Desea eliminar este registro?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (R == DialogResult.Yes)
                {
                    string id = dgvRoles.CurrentRow.Cells[0].Value.ToString();
                    int ID = int.Parse(id);
                    rol = db.Roles_Usuarios.Find(ID);
                    db.Roles_Usuarios.Remove(rol);
                    db.SaveChanges();
                    CargarDatos();
                    desactivareditar();
                    txtRolUsuario.Text = "";
                    btnGuardar.Enabled = false;
                }
                else
                {
                    CargarDatos();
                    desactivareditar();
                    txtRolUsuario.Text = "";
                    btnGuardar.Enabled = false;
                }
            }
        }

        private void dgvRol_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            string usuario = dgvRoles.CurrentRow.Cells[3].Value.ToString();
            string rol = dgvRoles.CurrentRow.Cells[2].Value.ToString();
            usuariocombo = usuario;
            txtRolUsuario.Text = rol;
            ActivarBotones();
            ActivarTextbox();


        }

     
    }
}



