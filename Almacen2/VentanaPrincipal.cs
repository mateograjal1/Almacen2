using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen2
{
    public partial class VentanaPrincipal : Form
    {
        private int empleado;
        private string usuario;

        public VentanaPrincipal(string usuario)
        {
            this.empleado = ConexionBaseDeDatos.ObtenerEmpleadoId(usuario);
            this.usuario = usuario;
            InitializeComponent();            
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            ConexionBaseDeDatos.Logear(empleado, usuario, "Inicio sesion");
        }
        private void verHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Historial h = new Historial(this);
            h.Show();
        }

        private void VentanaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConexionBaseDeDatos.Logear(empleado, usuario, "Cerro sesion");
        }

        private void modificarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empleados emp = new Empleados(usuario, empleado, this);
            emp.Show();
        }
    }
}
