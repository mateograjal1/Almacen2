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
            BindingSource bs = new BindingSource();
            bs.DataSource = ConexionBaseDeDatos.ObtenerEmpleados();
            bnNavegador.BindingSource = bs;
            dgvEmpleados.DataSource = bs;            
        }

        private void Empleados_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventana.Show();
        }
    }
}
