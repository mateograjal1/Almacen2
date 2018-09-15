using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Almacen2
{
    public class ConexionBaseDeDatos
    {
        private static string STRING_CONEXION = "Server=tcp:mateotest.database.windows.net,1433;Initial Catalog=Almacen2;Persist Security Info=False;User ID=almacenadmin;Password=sneYQY61+;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static SqlDataReader lector;

        /// <summary>
        /// Inicia la conexion con la base de datos
        /// </summary>
        /// <returns>true si la conexion fue exitosa, false si no fue exitosa</returns>
        private static bool Conectar()
        {
            try
            {
                conexion = new SqlConnection(STRING_CONEXION);
                conexion.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Obtiene la cantidad de usuarios en el sistema
        /// </summary>
        /// <returns>La cantidad de usuarios en el sistema. Devuelve -1 si no se pudo conectar a la base de datos</returns>
        public static int ContarUsuarios()
        {
            if (Conectar())
            {
                comando = new SqlCommand("ContarUsuarios", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.ExecuteNonQuery();
                lector = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);
                return (int)dt.Rows[0][0];
            }
            return -1;
        }

        public static bool UsuarioExiste(string usuario)
        {
            if (Conectar())
            {
                comando = new SqlCommand("ValidarUsuario", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Usuario", usuario);
                comando.ExecuteNonQuery();
                lector = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);
                return (int)dt.Rows[0][0] == 1 ? true : false;
            }
            return false;
        }

        public static bool UsuarioValido(string usuario, string contrasena)
        {
            if (Conectar())
            {
                comando = new SqlCommand("ValidarInicioSesion", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Usuario", usuario);
                comando.Parameters.AddWithValue("Contrasena", contrasena);
                comando.ExecuteNonQuery();
                lector = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);
                return (int)dt.Rows[0][0] == 1 ? true : false;
            }
            return false;
        }

        public static void CrearPersona(string cedula, string nombre, string apellido, int cargo, string usuario, string contrasena)
        {
            if (Conectar())
            {
                comando = new SqlCommand("CrearPersona", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cedula", cedula);
                comando.Parameters.AddWithValue("Nombre", nombre);
                comando.Parameters.AddWithValue("Apellido", apellido);
                comando.Parameters.AddWithValue("Cargo", cargo);
                comando.Parameters.AddWithValue("Usuario", usuario);
                comando.Parameters.AddWithValue("Contrasena", contrasena);
                comando.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Obtiene un DataTable con los cargos
        /// </summary>
        /// <returns>DataTable: {id int, descripcion string}</returns>
        public static DataTable ObtenerCargos()
        {
            if (Conectar())
            {
                comando = new SqlCommand("ObtenerCargos", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.ExecuteNonQuery();
                lector = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);
                return dt;
            }
            return null;
        }

        public static DataTable ObtenerHistorial()
        {
            if (Conectar())
            {
                comando = new SqlCommand("RevisarHistorial", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.ExecuteNonQuery();
                lector = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);
                return dt;
            }
            return null;
        }

        public static void Logear(int empleadoId, string usuario, string descripcion)
        {
            if (Conectar())
            {
                comando = new SqlCommand("Logear", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("EmpleadoId", empleadoId);
                comando.Parameters.AddWithValue("Usuario", usuario);
                comando.Parameters.AddWithValue("Descripcion", descripcion);
                comando.ExecuteNonQuery();
            }
        }

        public static int ObtenerEmpleadoId(string usuario)
        {
            if (Conectar())
            {
                comando = new SqlCommand("ObtenerEmpleadoId", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Usuario", usuario);
                comando.ExecuteNonQuery();
                lector = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);
                return (int)dt.Rows[0][0];
            }
            return -1;
        }

        public static DataTable ObtenerEmpleados()
        {
            if (Conectar())
            {
                comando = new SqlCommand("ObtenerEmpleados", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.ExecuteNonQuery();
                lector = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);
                return dt;
            }
            return null;
        }


    }
}
