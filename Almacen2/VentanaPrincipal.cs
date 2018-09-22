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
        private int cargo;

        public VentanaPrincipal(string usuario)
        {
            this.empleado = ConexionBaseDeDatos.ObtenerEmpleadoId(usuario);
            this.usuario = usuario;
            InitializeComponent();            
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            ConexionBaseDeDatos.Logear(empleado, usuario, "Inicio sesion");
            cargo = ConexionBaseDeDatos.ObtenerCargo(empleado);
            switch (cargo)
            {
                case 1:
                    inventarioToolStripMenuItem.Enabled = true;
                    productosToolStripMenuItem.Enabled = true;
                    usuariosToolStripMenuItem.Enabled = true;
                    historialToolStripMenuItem.Enabled = true;
                    break;
                case 2:
                    inventarioToolStripMenuItem.Enabled = true;
                    productosToolStripMenuItem.Enabled = true;
                    usuariosToolStripMenuItem.Enabled = false;
                    historialToolStripMenuItem.Enabled = false;
                    break;
                case 3:
                    inventarioToolStripMenuItem.Enabled = true;
                    productosToolStripMenuItem.Enabled = false;
                    usuariosToolStripMenuItem.Enabled = false;
                    historialToolStripMenuItem.Enabled = false;
                    break;
                case 4:
                    inventarioToolStripMenuItem.Enabled = false;
                    productosToolStripMenuItem.Enabled = false;
                    usuariosToolStripMenuItem.Enabled = false;
                    historialToolStripMenuItem.Enabled = false;
                    break;
            }
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

        private void administrarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Productos p = new Productos(usuario, empleado, this);
            p.Show();
        }

        private void inventariarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventario i = new Inventario(usuario, empleado, this);
            i.Show();
        }
    }
}
