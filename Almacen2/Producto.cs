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
    public partial class Producto : Form
    {

        public string Nombre { get => txtNombre.Text; }
        public string Descripcion { get => txtDescripcion.Text; }
        public string Categoria { get => cbCategoria.Text; }

        public Producto()
        {
            InitializeComponent();
        }

        public Producto(string nombre, string categoria, string descripcion)
        {
            InitializeComponent();
            txtNombre.Text = nombre;
            txtDescripcion.Text = descripcion;
            cbCategoria.SelectedItem = categoria;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if (String.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                MessageBox.Show("El nombre no debe estar vacio");
            }
            else if (String.IsNullOrEmpty(cbCategoria.Text))
            {
                MessageBox.Show("La categoria no debe estar vacia");
            }
            else
            {                             
                DialogResult = DialogResult.OK;
            }
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            this.AcceptButton = butAceptar;
            this.CancelButton = butCancelar;
            DataTable dt = ConexionBaseDeDatos.ObtenerCategorias();
            DataSet categorias = new DataSet();
            categorias.Tables.Add(dt);
            cbCategoria.DataSource = categorias.Tables[0].DefaultView;
            cbCategoria.DisplayMember = "Categoria";
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
