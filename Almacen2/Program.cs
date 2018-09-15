using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen2
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int usuarios = ConexionBaseDeDatos.ContarUsuarios();
            if (usuarios == 0)
            {
                Debug.WriteLine("No hay usuarios");
                MessageBox.Show(null, "No se detecto ningun usuario. Por favor ingrese administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Usuario u = new Usuario();
                u.ShowDialog();
                if (u.DialogResult == DialogResult.OK)
                {
                    ConexionBaseDeDatos.CrearPersona(u.Cedula, u.Nombre, u.Apellido, u.Cargo, u.UsuarioNuevo, u.Contrasena);
                    Application.Run(new VentanaPrincipal(u.UsuarioNuevo));
                }
                else
                {
                    return;
                }
            }
            else if (usuarios > 0)
            {
                Debug.WriteLine("Hay " + usuarios + " en el sistema");
                bool terminar = false;
                do
                {
                    InicioSesion inicio = new InicioSesion();
                    inicio.ShowDialog();
                    if (inicio.DialogResult == DialogResult.OK && ConexionBaseDeDatos.UsuarioValido(inicio.Usuario, Encriptador.Encriptar(inicio.Contrasena)))
                    {
                        Application.Run(new VentanaPrincipal(inicio.Usuario));
                        terminar = true;
                    }
                    else if (inicio.DialogResult == DialogResult.Cancel)
                    {
                        terminar = true;
                    }
                    else
                    {
                        MessageBox.Show(null, "Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                while (!terminar);
            }
            else
            {
                Debug.WriteLine("Error al contar usuarios");
            }
            
            
        }
    }
}
