using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class TipoVehiculoDatos
    {
        // Método para listar todos los tipos de vehículos
        public DataTable Listar()
        {
            // Inicializa un DataTable para almacenar los resultados de la consulta
            DataTable tabla = new DataTable();

            // Establece la conexión utilizando el método centralizado
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                // Define la consulta SQL para obtener los tipos de vehículos
                string query = "SELECT IdTipo, Nombre, TarifaHora FROM TipoVehiculo";

                // Crea el comando SQL con la consulta y la conexión
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    // Abre la conexión a la base de datos
                    conexion.Open();

                    // Ejecuta el comando y carga los datos en el DataTable
                    tabla.Load(cmd.ExecuteReader());
                }
            }
            // Retorna la tabla con los datos obtenidos
            return tabla;
        }
    }
}