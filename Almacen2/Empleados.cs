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
    public partial class Empleados : Form
    {
        private string usuario;
        private int empleadoId;
        private VentanaPrincipal ventana;

        public Empleados(string usuario, int empleadoId, VentanaPrincipal ventana)
        {
            this.usuario = usuario;
            this.empleadoId = empleadoId;
            this.ventana = ventana;
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {            
            dgvEmpleados.DataSource = ConexionBaseDeDatos.ObtenerEmpleados();            
        }

        private void Empleados_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventana.Show();
        }

        private void butNuevo_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario(true);
            u.ShowDialog();
            if (u.DialogResult == DialogResult.OK)
            {
                ConexionBaseDeDatos.CrearPersona(u.Cedula, u.Nombre, u.Apellido, u.Cargo, u.UsuarioNuevo, u.Contrasena);
                int empleado = ConexionBaseDeDatos.ObtenerEmpleadoId(u.UsuarioNuevo);
                ConexionBaseDeDatos.Logear(this.empleadoId, this.usuario, "Ha creado al empleado " + empleado);
            }
            dgvEmpleados.DataSource = ConexionBaseDeDatos.ObtenerEmpleados();
        }

        private int obtenerSeleccionado()
        {
            if (dgvEmpleados.SelectedCells.Count != 0)
            {
                int seleccionado = dgvEmpleados.SelectedCells[0].RowIndex;
                return (int)dgvEmpleados.Rows[seleccionado].Cells[0].Value;
            }
            else
            {
                MessageBox.Show(this, "Seleccione un empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void butEditar_Click(object sender, EventArgs e)
        {
            int empleado = obtenerSeleccionado();
            if (empleado == empleadoId)
            {
                MessageBox.Show(this, "No se puede editar al empleado con la sesion abierta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (empleado != -1)
            {
                DataTable dt = ConexionBaseDeDatos.ObtenerEmpleado(empleado);
                string cedula = dt.Rows[0][0].ToString();
                string nombre = dt.Rows[0][1].ToString();
                string apellido = dt.Rows[0][2].ToString();
                int cargo = (int)dt.Rows[0][3];
                string usuario = dt.Rows[0][4].ToString();
                Usuario u = new Usuario(empleado, cedula, nombre, apellido, cargo, usuario);
                u.ShowDialog();
                if (u.DialogResult == DialogResult.OK)
                {
                    ConexionBaseDeDatos.ActualizarEmpleado(empleado, u.Cedula, u.Nombre, u.Apellido, u.Cargo);
                    ConexionBaseDeDatos.Logear(this.empleadoId, this.usuario, "Ha editado al empleado " + empleado);
                }
            }
            dgvEmpleados.DataSource = ConexionBaseDeDatos.ObtenerEmpleados();
        }

        private void butBorrar_Click(object sender, EventArgs e)
        {
            int empleado = obtenerSeleccionado();
            if (empleado == empleadoId)
            {
                MessageBox.Show(this, "No se puede borrar al empleado con la sesion abierta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (empleado != -1)
            {
                DialogResult dr = MessageBox.Show(this, "Esta seguro que quiere borrar el empleado?", "Borrar empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ConexionBaseDeDatos.BorrarEmpleado(empleado);
                    ConexionBaseDeDatos.Logear(this.empleadoId, this.usuario, "Ha borrado al empleado " + empleado);
                }                
            }
            dgvEmpleados.DataSource = ConexionBaseDeDatos.ObtenerEmpleados();
        }
    }
}
