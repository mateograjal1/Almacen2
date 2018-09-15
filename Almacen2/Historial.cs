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
    public partial class Historial : Form
    {
        private VentanaPrincipal ventanaPrincipal;

        public Historial(VentanaPrincipal ventana)
        {
            InitializeComponent();
            this.ventanaPrincipal = ventana;
        }

        private void Historial_Load(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = ConexionBaseDeDatos.ObtenerHistorial();
        }

        private void Historial_FormClosing(object sender, FormClosingEventArgs e)
        {
            ventanaPrincipal.Show();
        }
    }
}
