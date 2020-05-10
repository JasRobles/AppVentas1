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
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var JoinTablas = from tbusuarios in db.tb_usuarios
                                 from tbrolesusuarios in db.Roles_Usuarios
                                 where tbusuarios.Id == tbrolesusuarios.Id_Rol_Usuario

                                 select new
                                 {

                                     Id = tbusuarios.Id,
                                     Email = tbusuarios.Email,
                                     Tipo_Rol = tbrolesusuarios.Tipo_Rol

                                 };
                dgvRoles.DataSource = JoinTablas.ToList();



            }
        }
    }
}
