using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen2
{
    public partial class Productos : Form
    {
        private string usuario;
        private int empleado;
        private VentanaPrincipal ventana;

        public Productos(string usuario, int empleado, VentanaPrincipal ventanaPrincipal)
        {
            this.usuario = usuario;
            this.empleado = empleado;
            this.ventana = ventanaPrincipal;
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = ConexionBaseDeDatos.ObtenerProductos();
        }

        private void Productos_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventana.Show();            
        }

        private void butNuevo_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            p.ShowDialog();
            if (p.DialogResult == DialogResult.OK)
            {
                ConexionBaseDeDatos.CrearProducto(p.Nombre.Trim(), p.Categoria, p.Descripcion);
                int nuevoProducto = ConexionBaseDeDatos.ObtenerUltimoProducto();
                ConexionBaseDeDatos.Logear(empleado, usuario, "ha creado el producto " + nuevoProducto);
                dgvProductos.DataSource = ConexionBaseDeDatos.ObtenerProductos();
            }
            
        }

        private int obtenerSeleccionado()
        {
            if (dgvProductos.SelectedCells.Count != 0)
            {
                int seleccionado = dgvProductos.SelectedCells[0].RowIndex;
                return (int)dgvProductos.Rows[seleccionado].Cells[0].Value;
            }
            else
            {
                MessageBox.Show(this, "Seleccione un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void butEditar_Click(object sender, EventArgs e)
        {
            int producto = obtenerSeleccionado();
            if (producto != -1)
            {
                DataTable dt = ConexionBaseDeDatos.ObtenerProducto(producto);
                string nombre = dt.Rows[0][1].ToString();
                string categoria = dt.Rows[0][2].ToString();
                string descripcion = dt.Rows[0][3].ToString();
                Producto p = new Producto(nombre, categoria, descripcion);
                p.ShowDialog();
                if (p.DialogResult == DialogResult.OK)
                {
                    ConexionBaseDeDatos.ActualizarProducto(producto, p.Nombre, p.Categoria, p.Descripcion);
                    ConexionBaseDeDatos.Logear(this.empleado, this.usuario, "Ha editado al producto " + producto);
                }
            }
            dgvProductos.DataSource = ConexionBaseDeDatos.ObtenerProductos();
        }

        private void butBorrar_Click(object sender, EventArgs e)
        {
            int producto = obtenerSeleccionado();
            if (producto != -1)
            {
                DialogResult dr = MessageBox.Show(this, "¿Esta seguro que quiere borrar el producto?", "Borrar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    ConexionBaseDeDatos.BorrarProducto(producto);
                    ConexionBaseDeDatos.Logear(this.empleado, this.usuario, "Ha borrado al producto " + producto);
                }
            }
            dgvProductos.DataSource = ConexionBaseDeDatos.ObtenerProductos();
        }
    }
}
