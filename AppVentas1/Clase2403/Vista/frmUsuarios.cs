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

namespace Clase2403.Vista
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }
        tb_usuarios user = new tb_usuarios();

        void CargarDatos ()
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {

                dtvUsuarios.Rows.Clear();

                var tb_Usuarios = db.tb_usuarios;

                foreach (var iterardatostbUsuarios in tb_Usuarios)
                {

                    dtvUsuarios.Rows.Add(iterardatostbUsuarios.Id,iterardatostbUsuarios.Email,iterardatostbUsuarios.Contrasena);

                }


            }
        }

        void LimpiarDatos ()
        {

            txtContraseña.Text = "";
            txtUsuario.Text = "";

        }

      

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities() )
            {

                user.Email = txtUsuario.Text;
                user.Contrasena = txtContraseña.Text;
                db.tb_usuarios.Add(user);
                db.SaveChanges();

            }
            CargarDatos();
            LimpiarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using(sistema_ventasEntities db = new sistema_ventasEntities())
            {
                String Id = dtvUsuarios.CurrentRow.Cells[0].Value.ToString();
                user = db.tb_usuarios.Find(int.Parse(Id));
                db.tb_usuarios.Remove(user);
                db.SaveChanges();
            }
            CargarDatos();
            LimpiarDatos();
        }

        private void dtvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            String email = dtvUsuarios.CurrentRow.Cells[1].Value.ToString();
            String Cont = dtvUsuarios.CurrentRow.Cells[2].Value.ToString();
            txtUsuario.Text = email;
            txtContraseña.Text = Cont;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                String Id = dtvUsuarios.CurrentRow.Cells[0].Value.ToString();
                int idc = int.Parse(Id);
                user = db.tb_usuarios.Where(verificarId => verificarId.Id == idc).First();
                user.Email = txtUsuario.Text;
                user.Contrasena = txtContraseña.Text;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            CargarDatos();
            LimpiarDatos();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

       

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }
    }
}
