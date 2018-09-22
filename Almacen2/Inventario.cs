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
    public partial class Inventario : Form
    {
        private string usuario;
        private int empleado;
        private VentanaPrincipal ventana;

        public Inventario(string usuario, int empleado, VentanaPrincipal ventana)
        {
            this.usuario = usuario;
            this.empleado = empleado;
            this.ventana = ventana;
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            dgvInventario.DataSource = ConexionBaseDeDatos.ObtenerInventario();
            dgvInventario.Columns[0].ReadOnly = true;
            dgvInventario.Columns[1].ReadOnly = true;
            dgvInventario.Columns[2].ReadOnly = true;
            dgvInventario.Columns[3].DefaultCellStyle.Format = "F2";
        }

        private void guardarCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float[] cantidad = new float[dgvInventario.RowCount];
            int[] productos = new int[dgvInventario.RowCount];
            for (int i = 0; i < dgvInventario.RowCount; i++)
            {
                productos[i] = (int)dgvInventario.Rows[i].Cells[0].Value;
                if (!float.TryParse(dgvInventario.Rows[i].Cells[3].Value.ToString(), out cantidad[i]))
                {
                    MessageBox.Show(this, "La cantidad para el producto ID#" + productos[i] + " es invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                
            }
            ConexionBaseDeDatos.ActualizarInventario(productos, cantidad);
            ConexionBaseDeDatos.Logear(empleado, usuario, "Ha actualizado el inventario");
        } 

        private void descartarCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Inventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventana.Show();
        }

        private void dgvInventario_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgvInventario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0.0;
        }
    }
}
