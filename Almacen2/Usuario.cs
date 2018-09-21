using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Almacen2
{
    public partial class Usuario : Form
    {
        private string cedula;
        private string nombre;
        private string apellido;
        private int cargo;
        private string usuario;
        private string contrasena;
        private DataSet cargos;

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Cargo { get => cargo; set => cargo = value; }
        public string UsuarioNuevo { get => usuario; set => usuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }

        public Usuario(bool habilitarCargo)
        {
            InitializeComponent();
            if (!habilitarCargo)
            {
                cbCargo.Enabled = false;
            }
            else
            {
                cbCargo.Enabled = true;
            }
        }

        public Usuario(int id, string cedula, string nombre, string apellido, int cargo, string usuarioNuevo)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            txtCedula.Text = cedula;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            setCargo(cargo);
            txtUsuario.Text = usuarioNuevo;
            txtUsuario.Enabled = false;
            txtContrasena.Enabled = false;
            txtContrasenaConf.Enabled = false;
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            this.AcceptButton = butAceptar;
            this.CancelButton = butCancelar;
            DataTable dt = ConexionBaseDeDatos.ObtenerCargos();
            cargos = new DataSet();
            cargos.Tables.Add(dt);
            cbCargo.DataSource = cargos.Tables[0].DefaultView;
            cbCargo.DisplayMember = "Cargo";
        }

        private void setCargo(int cargo)
        {
            for (int i = 0; i < cargos.Tables[0].Rows.Count; i++)
            {
                if (cargo == (int)cargos.Tables[0].Rows[0][0])
                {
                    cbCargo.SelectedIndex = cargo;
                }
            }
        }

        private bool validar()
        {
            if (String.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show(this, "Error", "Error en cedula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show(this, "Error", "Error en Nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show(this, "Error", "Error en Apellido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show(this, "Error", "Error en Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (ConexionBaseDeDatos.UsuarioExiste(txtUsuario.Text.Trim()))
            {
                MessageBox.Show(this, "Error", "Error en Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrEmpty(txtContrasena.Text))
            {
                MessageBox.Show(this, "Error", "Error en Contrasea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrEmpty(txtContrasenaConf.Text))
            {
                MessageBox.Show(this, "Error", "Error en Contraseña 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtContrasenaConf.Text != txtContrasena.Text)
            {
                MessageBox.Show(this, "Error", "Error en Contraseña 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Cedula = txtCedula.Text;
                Nombre = txtNombre.Text;
                Apellido = txtApellido.Text;
                Cargo = (int)cargos.Tables[0].Rows[cbCargo.SelectedIndex][0];
                UsuarioNuevo = txtUsuario.Text;
                Contrasena = Encriptador.Encriptar(txtContrasena.Text);
                Debug.WriteLine("Usuario nuevo {" + Cedula + ", " + Nombre + ", " + Apellido + ", " + Cargo + ", " + UsuarioNuevo + ", " + Contrasena + "}");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
