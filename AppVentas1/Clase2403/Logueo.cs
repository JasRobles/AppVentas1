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
using Clase2403.Vista;



namespace Clase2403
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities ())
            {

                var lista = from usuario in db.tb_usuarios
                            where usuario.Email == txtUsuario.Text
                            && usuario.Contrasena == txtContraseña.Text
                            select new { ID = usuario.Id};

                if (lista.Count() > 0)
                {
                    foreach(var iterar in lista)
                    {
                        frmMenu.V.txtIdUsuario.Text = iterar.ID.ToString();
                        frmMenu.V.txtUsuario.Text = txtUsuario.Text;
                    }
                    frmMenu menu = new frmMenu();
                    menu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El usuario no es valido");
                }
            }
        }
    }
}
